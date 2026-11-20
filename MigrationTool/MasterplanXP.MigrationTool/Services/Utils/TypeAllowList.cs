#nullable disable

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace MasterplanXP.MigrationTool.Services.Utils
{
    /// <summary>
    /// Decides which .NET types an old (BinaryFormatter) Masterplan file is allowed to contain.
    /// Used by LegacySerializationBinder.
    /// </summary>
    /// <remarks>
    /// WHY THIS EXISTS (for new developers):
    /// BinaryFormatter rebuilds whatever types a file names. A deliberately crafted file can name
    /// system types that do harmful things while being rebuilt (a well-known attack). Masterplan
    /// libraries were commonly shared online, so users may convert files they did not make.
    ///
    /// Instead of a hand-written list of types (which could easily miss one and break valid files),
    /// the rules below follow from what valid files CAN contain:
    ///   1. The old Masterplan data classes. The binder maps every old Masterplan type onto this
    ///      tool's own copies in Models.Legacy (and Pair&lt;,&gt; in Services.Utils), so: any
    ///      [Serializable] type from this assembly in those namespaces, including generic ones such
    ///      as Pair&lt;string, string&gt; (when the types inside are allowed), and their INTERFACES
    ///      (IPlayerOption, IToken, IEncounterLogEntry, ...). A saved List&lt;IPlayerOption&gt; records
    ///      the interface as its item type; an interface cannot be created by itself, and the real
    ///      items in the list (Feat, Race, ...) are concrete classes that are checked separately.
    ///   2. Collections (List, Dictionary, KeyValuePair, HashSet, Nullable, arrays) - but ONLY when
    ///      every type inside them is allowed too (checked recursively). Saved Dictionaries also
    ///      record which comparer they used, so the runtime's own comparers are allowed.
    ///   3. Basic values: primitives (int, bool, ...), string, decimal, Guid, DateTime, TimeSpan,
    ///      DateTimeOffset, and enums from this assembly or the runtime.
    ///   4. The drawing types the old classes use: Bitmap, Color, Point(F), Size(F), Rectangle(F).
    /// The old classes have no fields typed as "object" (even add-in data is Dictionary&lt;string,
    /// string&gt;), so every value in a valid file has a known declared type covered by these rules.
    ///
    /// SAFETY NET: run the tool once with "Audit file types" on. It logs every type seen and which
    /// ones these rules would refuse, without refusing anything, so a gap is found before it ever
    /// blocks a valid file.
    /// </remarks>
    public static class TypeAllowList
    {
        static readonly Assembly fOwnAssembly = typeof(TypeAllowList).Assembly;
        static readonly Assembly fRuntimeAssembly = typeof(object).Assembly;

        /// <summary>Namespaces (in this assembly) whose [Serializable] types are allowed.</summary>
        static readonly string[] fOwnNamespaces =
        {
            "MasterplanXP.MigrationTool.Models.Legacy",
            "MasterplanXP.MigrationTool.Services.Utils"
        };

        static readonly HashSet<Type> fBasicTypes = new HashSet<Type>
        {
            typeof(string), typeof(decimal), typeof(Guid), typeof(DateTime), typeof(TimeSpan), typeof(DateTimeOffset)
        };

        static readonly HashSet<Type> fDrawingTypes = new HashSet<Type>
        {
            typeof(Bitmap), typeof(Color),
            typeof(Point), typeof(PointF),
            typeof(Size), typeof(SizeF),
            typeof(Rectangle), typeof(RectangleF)
        };

        /// <summary>Generic containers allowed when all their type arguments are allowed.</summary>
        static readonly HashSet<Type> fGenericContainers = new HashSet<Type>
        {
            typeof(List<>), typeof(Dictionary<,>), typeof(KeyValuePair<,>), typeof(HashSet<>), typeof(Nullable<>)
        };

        /// <summary>
        /// The runtime's internal comparer classes that a saved Dictionary/HashSet may name. They are
        /// internal, so they are matched by name (and must come from the runtime's own assembly).
        /// </summary>
        static readonly HashSet<string> fRuntimeComparerNames = new HashSet<string>
        {
            "GenericEqualityComparer`1", "ObjectEqualityComparer`1", "EnumEqualityComparer`1",
            "ByteEqualityComparer", "NonRandomizedStringEqualityComparer",
            "GenericComparer`1", "ObjectComparer`1"
        };

        /// <summary>Remembers each answer; the same types are checked many times per file.</summary>
        static readonly ConcurrentDictionary<Type, bool> fCache = new ConcurrentDictionary<Type, bool>();

        /// <summary>True if a valid Masterplan file may contain this type (see the class remarks).</summary>
        public static bool IsAllowed(Type t)
        {
            if (t == null)
                return false;

            return fCache.GetOrAdd(t, Compute);
        }

        static bool Compute(Type t)
        {
            // Arrays: allowed if their element type is allowed (byte[] for image data, etc.).
            if (t.IsArray)
                return IsAllowed(t.GetElementType());

            // Generic types: the container must be allowed AND every type inside it.
            if (t.IsGenericType && !t.IsGenericTypeDefinition)
            {
                Type definition = t.GetGenericTypeDefinition();

                // NOTE: IsOwnDataType(definition) was missing at first, so every Pair<,> (and every
                // list of them) was refused although it is one of our own types. Found by the audit.
                bool container_ok = fGenericContainers.Contains(definition)
                                 || IsRuntimeComparer(definition)
                                 || IsOwnDataType(definition);
                return container_ok && t.GetGenericArguments().All(IsAllowed);
            }

            if (t.IsPrimitive || fBasicTypes.Contains(t) || fDrawingTypes.Contains(t))
                return true;

            // Enums are plain numbers; allow this assembly's and the runtime's.
            if (t.IsEnum)
                return (t.Assembly == fOwnAssembly) || (t.Assembly == fRuntimeAssembly);

            if (IsRuntimeComparer(t))
                return true;

            // The old Masterplan data classes (this tool's copies) and their interfaces.
            if (IsOwnDataType(t))
                return true;

            return false;
        }

        /// <summary>
        /// One of this tool's own data types: a [Serializable] class, struct or enum, or an interface,
        /// from this assembly's Models.Legacy or Services.Utils namespaces.
        /// </summary>
        /// <remarks>
        /// Interfaces are never [Serializable] (the attribute cannot be put on them), which is why the
        /// first version, that required IsSerializable, refused every List&lt;IPlayerOption&gt;,
        /// List&lt;IToken&gt; and List&lt;IEncounterLogEntry&gt; (found by the audit). Allowing them is
        /// safe: an interface cannot be created, and the concrete items are checked on their own.
        /// </remarks>
        static bool IsOwnDataType(Type t)
        {
            // SYSLIB0050 says "Type.IsSerializable is obsolete" because it belongs to BinaryFormatter-style
            // serialization. That is exactly what this check is about: only [Serializable] types may be
            // created while reading an old file. It still works on .NET 8, so the warning is switched
            // off for this one check only.
#pragma warning disable SYSLIB0050
            return (t.Assembly == fOwnAssembly)
                && (t.IsSerializable || t.IsInterface)
                && fOwnNamespaces.Contains(t.Namespace);
#pragma warning restore SYSLIB0050
        }

        static bool IsRuntimeComparer(Type t)
        {
            return (t.Assembly == fRuntimeAssembly)
                && (t.Namespace == "System.Collections.Generic")
                && fRuntimeComparerNames.Contains(t.Name);
        }
    }
}
