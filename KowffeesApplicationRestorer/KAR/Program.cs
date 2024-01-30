using System.Diagnostics;
using static System.ConsoleColor;
using static KAR.Utils.Printer;

namespace KAR
{
    internal class Program
    {
        private static string AppDir = AppDomain.CurrentDomain.BaseDirectory;

        static async Task Main(string[] args)
        {
            Print("Getting ready", Yellow);
            bool setup = Handlers.InitSetup();
            if (!setup)
            {
                Print("Setup has failed", DarkRed);
                Console.ReadLine();
                Environment.Exit(0);
            }

            await Handlers.StartDownload();
            Process.Start(new ProcessStartInfo
            {
                FileName = Path.Combine(AppDir, "KARInstalls", "BraveBetaSILENTInstaller.exe"),
                UseShellExecute = true
            });

            Print("Done!", Green);
            Console.ReadKey();
        }
    }
}
