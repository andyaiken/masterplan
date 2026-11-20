using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Reflection;

namespace MasterplanXP.MigrationTool.Services.Utils
{
    /// <summary>
    /// How LegacySerializationBinder treats a type that TypeAllowList does not allow.
    /// </summary>
    public enum BinderMode
    {
        /// <summary>Normal use: a file containing a type that is not allowed is refused (not converted).</summary>
        Enforce,

        /// <summary>
        /// Checking only: nothing is refused; every type seen is recorded, together with the ones
        /// Enforce mode WOULD refuse. Used by the "Audit file types" switch.
        /// </summary>
        Audit
    }

    /// <summary>
    /// Maps legacy namespaces (e.g., Masterplan.Data) to the new project namespaces
    /// (e.g., MasterplanXP.MigrationTool.Models.Legacy) during BinaryFormatter deserialization,
    /// and refuses types an old Masterplan file should never contain (see TypeAllowList).
    /// </summary>
    /// <remarks>
    /// SECURITY NOTE (for new developers):
    /// Before the allow-list, a type this binder did not map returned null, which let BinaryFormatter
    /// load ANY type a file named - the classic BinaryFormatter attack. Now every type is resolved
    /// here and checked with TypeAllowList.IsAllowed:
    ///   - Enforce mode: a type that is not allowed throws a SerializationException. Serialisation.Load
    ///     catches it and returns null, so only that file fails (logged with the type's name); the
    ///     other files still convert.
    ///   - Audit mode: nothing is refused, but SeenTypes / RefusedTypes record what was found, so the
    ///     rules can be checked against real files before they block anything.
    /// The conversion runs one file at a time, so the static state below is safe; it is still
    /// locked because BinaryFormatter may call the binder from a background thread.
    /// </remarks>
    public class LegacySerializationBinder : SerializationBinder
    {
        #region Mode and audit log

        /// <summary>Enforce (default) or Audit. Set by the main window before a run.</summary>
        public static BinderMode Mode { get; set; } = BinderMode.Enforce;

        /// <summary>The file being read, so refused types can be reported with their file name.</summary>
        public static string CurrentFile { get; set; } = "";

        /// <summary>Every distinct type seen since the last ResetLog (sorted, for the audit summary).</summary>
        public static SortedSet<string> SeenTypes { get; } = new SortedSet<string>();

        /// <summary>Types the allow-list refused (or would refuse, in Audit mode), with their file.</summary>
        public static SortedSet<string> RefusedTypes { get; } = new SortedSet<string>();

        /// <summary>
        /// Old Masterplan types that no longer exist (removed features), with their file. Their data
        /// was discarded via the RemovedLegacyType stand-in; listed in the audit summary.
        /// </summary>
        public static SortedSet<string> DiscardedTypes { get; } = new SortedSet<string>();

        static readonly object fLock = new object();

        /// <summary>
        /// "type in file" entries whose "FAILED to resolve" line has already been written, so it is
        /// logged once per type per file instead of once for every object (see MapLegacyType).
        /// </summary>
        static readonly HashSet<string> fFailedLogged = new HashSet<string>();

        /// <summary>Clears SeenTypes, RefusedTypes and DiscardedTypes before a new run.</summary>
        public static void ResetLog()
        {
            lock (fLock)
            {
                SeenTypes.Clear();
                RefusedTypes.Clear();
                DiscardedTypes.Clear();
                fFailedLogged.Clear();
            }
        }

        #endregion

        // NULLABLE NOTE: "Type?" (with the ?) means "a Type, or null". This method, MapLegacyType and
        // ResolveSystemType really can return null (type not found; see the comments below), so their
        // return types and the variables holding their results say so. That is all the "?"s in this
        // file change: the compiler then checks that null is handled, nothing runs differently.
        public override Type? BindToType(string assemblyName, string typeName)
        {
            // 1. Find the type: old Masterplan types are mapped onto this tool's copies (unchanged
            //    logic, now in MapLegacyType); everything else is looked up as a normal .NET type.
            Type? t = MapLegacyType(assemblyName, typeName) ?? ResolveSystemType(assemblyName, typeName);

            // 1b. An OLD Masterplan type that no longer exists (a removed feature, e.g. Masterplan 11's
            //     "5x5" planner data): hand back the catch-all stand-in, which discards its data, so the
            //     rest of the file can still be read. Logged once per file and listed in the audit.
            //     Safe: it only ever substitutes our own empty class, and only for old Masterplan names.
            //
            // 1c. A CONTAINER of such a type, e.g. List<Masterplan.Data.Goal>: the list itself cannot be
            //     built either (its item type does not exist), so the whole list is discarded the same way.
            //     Found by the audit: Masterplan 11 projects hold List<Goal> (party goals) and
            //     List<FiveByFiveColumn> (5x5 planner), both inside removed features. If such a list ever
            //     sat in a class that still exists, that file would fail with a read error in the audit.
            if ((t == null) && (IsOldMasterplanType(assemblyName, typeName) || IsContainerOfOldMasterplanType(typeName)))
            {
                t = typeof(MasterplanXP.MigrationTool.Models.Legacy.RemovedLegacyType);

                bool first_discard;
                lock (fLock)
                {
                    first_discard = DiscardedTypes.Add(typeName + " in " + CurrentFile);
                }
                if (first_discard)
                    LogSystem.Trace($"Binder: discarded {typeName} in {CurrentFile} (removed in later Masterplan versions; its data is dropped)");
            }

            // 2. Record it and check it against the allow-list.
            bool allowed = TypeAllowList.IsAllowed(t);
            bool first_time = false;   // true the first time this type is refused in this file
            lock (fLock)
            {
                // Type.FullName can be null (for some generic types), so the name from the file is used then.
                SeenTypes.Add((t != null) ? (t.FullName ?? typeName) : typeName + " [" + assemblyName + "] (could not be resolved)");
                if (!allowed)
                    first_time = RefusedTypes.Add(typeName + " [" + assemblyName + "] in " + CurrentFile);
            }

            if (!allowed)
            {
                if (Mode == BinderMode.Enforce)
                {
                    LogSystem.Trace($"Binder: REFUSED type {typeName} [{assemblyName}] in {CurrentFile}");
                    throw new SerializationException(
                        $"Refused type '{typeName}' from '{assemblyName}': an old Masterplan file should not contain it.");
                }

                // Log each refused type once per file. The binder is called for EVERY object of a
                // type, so without this one file could repeat the same line dozens of times.
                if (first_time)
                    LogSystem.Trace($"Binder (audit): would refuse {typeName} [{assemblyName}] in {CurrentFile}");
            }

            // In Audit mode an unresolved type returns null, which lets BinaryFormatter try its own
            // lookup exactly as before this change.
            return t;
        }

        /// <summary>
        /// True for a type written by the old Masterplan itself: a "Masterplan.*" name from the
        /// "Masterplan" assembly (any version). Not true for this tool's own MasterplanXP.* names.
        /// </summary>
        static bool IsOldMasterplanType(string assemblyName, string typeName)
        {
            if (string.IsNullOrEmpty(typeName) || string.IsNullOrEmpty(assemblyName))
                return false;

            bool masterplan_assembly = (assemblyName == "Masterplan") || assemblyName.StartsWith("Masterplan,");
            return masterplan_assembly && typeName.StartsWith("Masterplan.");
        }

        /// <summary>
        /// True for a generic type (List, Dictionary, ...) whose type arguments include an old
        /// Masterplan type, e.g. "System.Collections.Generic.List`1[[Masterplan.Data.Goal, Masterplan, ...]]".
        /// Only used for types that could not be found (so the item type is a removed class).
        /// "[[Masterplan." does not match this tool's own "[[MasterplanXP." names.
        /// </summary>
        static bool IsContainerOfOldMasterplanType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                return false;

            return typeName.Contains("[[Masterplan.")
                && (typeName.Contains(", Masterplan,") || typeName.Contains(", Masterplan]"));
        }

        /// <summary>
        /// Maps an old Masterplan type name onto this tool's own copy (the original binder logic,
        /// moved here unchanged). Returns null for types that are not old Masterplan types.
        /// </summary>
        static Type? MapLegacyType(string assemblyName, string typeName)
        {
            string newTypeName = typeName;

            // 1. Redirect namespaces globally (handles nested types in generics)
            newTypeName = newTypeName.Replace("Masterplan.Data.", "MasterplanXP.MigrationTool.Models.Legacy.");
            newTypeName = newTypeName.Replace("Masterplan.Tools.", "MasterplanXP.MigrationTool.Services.Utils.");

            // Catch any other Masterplan sub-namespaces (Extensibility, UI, etc.)
            newTypeName = newTypeName.Replace("Masterplan.Extensibility.", "MasterplanXP.MigrationTool.Models.Legacy.");
            newTypeName = newTypeName.Replace("Masterplan.UI.", "MasterplanXP.MigrationTool.Models.Legacy.");
            newTypeName = newTypeName.Replace("Masterplan.Events.", "MasterplanXP.MigrationTool.Models.Legacy.");

            // 2. Redirect Assembly information
            if (newTypeName.Contains("Masterplan"))
            {
                // FullName is only null for assemblies built in memory at run time, never for this
                // tool's own exe, so "!" tells the compiler it is safe to treat it as not null.
                string currentAssemblyName = Assembly.GetExecutingAssembly().FullName!;

                // Replace specific assembly signatures
                newTypeName = System.Text.RegularExpressions.Regex.Replace(
                    newTypeName,
                    @"Masterplan,\s*Version=[^,\]]+,\s*Culture=[^,\]]+,\s*PublicKeyToken=[^,\]]+",
                    currentAssemblyName
                );

                // Handle simple assembly name references
                newTypeName = newTypeName.Replace(", Masterplan]", ", " + currentAssemblyName + "]");
            }

            if (newTypeName != typeName || (assemblyName != null && assemblyName.Contains("Masterplan")))
            {
                try
                {
                    Type? t = null;
                    if (newTypeName.StartsWith("System."))
                    {
                        // For System types (like List), we must use Type.GetType to resolve the complex string
                        t = Type.GetType(newTypeName);
                    }
                    else
                    {
                        // For our own types, try loading from the current assembly
                        t = Assembly.GetExecutingAssembly().GetType(newTypeName);
                    }

                    if (t != null)
                    {
                        return t;
                    }
                    else
                    {
                        // Logged once per type per file: the binder is called for every object, so a
                        // removed type used many times would otherwise repeat these lines dozens of times.
                        bool first_failure;
                        lock (fLock)
                        {
                            first_failure = fFailedLogged.Add(typeName + " in " + CurrentFile);
                        }
                        if (first_failure)
                        {
                            LogSystem.Trace($"Binder: FAILED to resolve {typeName}");
                            LogSystem.Trace($"        Attempted mapping: {newTypeName}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogSystem.Trace($"Binder: Exception resolving {newTypeName}: {ex.Message}");
                }
            }

            return null;
        }

        /// <summary>
        /// Looks up a normal .NET type (Guid, List of strings, Bitmap, ...) named by an old file.
        /// The old files were written by .NET Framework (assemblies such as "mscorlib" and
        /// "System.Drawing, Version=4.0.0.0"), so after the full name it also tries the assemblies
        /// where those types live today.
        /// </summary>
        /// <returns>The type, or null if it cannot be found.</returns>
        static Type? ResolveSystemType(string assemblyName, string typeName)
        {
            try
            {
                Type? t = Type.GetType(typeName + ", " + assemblyName, false);
                if (t != null)
                    return t;

                t = Type.GetType(typeName, false);
                if (t != null)
                    return t;

                // Core types, and the drawing types (Point/Size/Rectangle/Color live in one assembly,
                // Bitmap in another, in modern .NET).
                foreach (Assembly a in new[] { typeof(object).Assembly, typeof(Point).Assembly, typeof(Bitmap).Assembly })
                {
                    t = a.GetType(typeName, false);
                    if (t != null)
                        return t;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace($"Binder: Exception resolving {typeName} [{assemblyName}]: {ex.Message}");
            }

            return null;
        }
    }
}
