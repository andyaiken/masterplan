using Avalonia;
using Avalonia.Svg.Skia;
using MessagePack;
using MessagePack.Resolvers;
using MessagePack.Formatters;
using MasterplanXP.MigrationTool.Services.Utils;
using System;
using System.Runtime.Versioning;

// WINDOWS ONLY: this tool reads old Masterplan files with BinaryFormatter and handles their images
// with System.Drawing (Bitmap, Image, Graphics...), and both only work on Windows. It is also only
// ever published for Windows (win-x64 profile). This line tells the code analyzer so; without it,
// every System.Drawing call (ImageCompression, BitmapFormatter, Session, Tile...) gets a CA1416
// "only supported on Windows" warning. It changes nothing when the tool runs.
// (Masterplan M14 does not need this: its target, net10.0-windows, already says Windows.)
[assembly: SupportedOSPlatform("windows6.1")]

namespace MasterplanXP.MigrationTool
{
    internal sealed class Program
    {
        /// <summary>
        /// This tool's version, e.g. "14.1.0.5". It comes from Version.props in the repository root,
        /// which Masterplan (M14) shares, so the tool and M14 of one release always show the same number.
        /// Shown in the window title and written to migration_log.txt.
        /// </summary>
        internal static string VersionText => typeof(Program).Assembly.GetName().Version?.ToString() ?? "unknown";

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            SetupMessagePackResolvers();
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        private static void SetupMessagePackResolvers()
        {
            try
            {
                var resolver = CompositeResolver.Create(
                    new IMessagePackFormatter[] {
                        ColorFormatter.Instance,
                        BitmapFormatter.Instance
                    },
                    new IFormatterResolver[] {
                        NativeDateTimeResolver.Instance,
                        TypelessContractlessStandardResolver.Instance,
                        StandardResolver.Instance,
                        ContractlessStandardResolver.Instance
                    }
                );

                var options = MessagePackSerializerOptions.Standard.WithResolver(resolver);
                MessagePackSerializer.DefaultOptions = options;
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                
#if DEBUG
                .WithDeveloperTools()
#endif
                .WithInterFont()
                .LogToTrace();
    }
}
