using System;
using System.Reflection;
using System.Runtime.Loader;

namespace Masterplan.Extensibility
{
    /// <summary>
    /// The "load context" one add-in is loaded into: it finds the add-in's own dependencies (helper
    /// DLLs, native libraries) in the add-in's folder, while Masterplan itself always comes from the
    /// running app.
    /// </summary>
    /// <remarks>
    /// WHY THIS EXISTS (for new developers):
    /// In .NET (Core / 5+) an add-in DLL loaded from some folder does not automatically find the other
    /// DLLs it needs from that folder; the app only looks in its own folder. AssemblyDependencyResolver
    /// reads the add-in's .deps.json (or, without one, looks next to the add-in) and tells us where each
    /// dependency is. Each add-in gets its OWN context, so two add-ins can even use different versions
    /// of the same helper library.
    ///
    /// The one assembly that must NOT come from the add-in's folder is Masterplan itself: IAddIn,
    /// IApplication, Project, ... are types in Masterplan. If an add-in folder contains its own copy of
    /// Masterplan.dll and we loaded it here, that copy's IAddIn would be a DIFFERENT type from the app's
    /// IAddIn, and the add-in would silently not be recognised. So for Masterplan (and anything else not
    /// in the add-in's folder) Load returns null, which means "use the app's own copy" (the default
    /// context).
    /// </remarks>
    internal sealed class AddInLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver fResolver;

        /// <summary>Name of the assembly that defines the add-in API (Masterplan itself).</summary>
        private static readonly string HostAssemblyName = typeof(IAddIn).Assembly.GetName().Name ?? "Masterplan";

        /// <param name="addInPath">Full path of the add-in's main DLL.</param>
        public AddInLoadContext(string addInPath)
            : base("AddIn: " + System.IO.Path.GetFileName(addInPath), isCollectible: false)
        {
            fResolver = new AssemblyDependencyResolver(addInPath);
        }

        /// <summary>Called when the add-in needs another .NET assembly.</summary>
        protected override Assembly? Load(AssemblyName assemblyName)
        {
            // Always share Masterplan with the app (see remarks), never load a second copy.
            if (string.Equals(assemblyName.Name, HostAssemblyName, StringComparison.OrdinalIgnoreCase))
                return null;

            // The add-in's own dependency, if it has one with that name.
            string? path = fResolver.ResolveAssemblyToPath(assemblyName);
            if (path != null)
                return LoadFromAssemblyPath(path);

            // Anything else (the .NET framework, WinForms, ...) comes from the app.
            return null;
        }

        /// <summary>Called when the add-in needs a native (non-.NET) DLL.</summary>
        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            string? path = fResolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            return (path != null) ? LoadUnmanagedDllFromPath(path) : IntPtr.Zero;
        }
    }
}
