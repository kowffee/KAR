using static System.ConsoleColor;
using static KAR.Utils.Printer;
using static KAR.Utils.Network;

namespace KAR
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Print("Getting ready", Yellow);
            bool setup = await Handlers.InitSetup();
            if (!setup)
            {
                Print("Setup has failed", DarkRed);
                Console.ReadLine();
                Environment.Exit(0);
            }

            // Might improve this but not rlly needed rn
            await DownloadFile("https://github.com/brave/brave-browser/releases/latest/download/BraveBrowserSetup.exe", "BraveInstaller64bit.exe");
            await DownloadFile("https://laptop-updates.brave.com/latest/winx64/beta?bitness=64", "BraveBetaInstaller64bit.exe");
            await DownloadFile("https://laptop-updates.brave.com/latest/winx64/nightly?bitness=64", "BraveNightlyInstaller64bit.exe");
            await DownloadFile("https://openrgb.org/releases/release_0.9/OpenRGB_0.9_Windows_64_b5f46e3.zip", "OpenRGB.zip");
            await DownloadFile("https://github.com/Vencord/Vesktop/releases/download/v0.4.4/Vesktop-Setup-0.4.4.exe", "VesktopV0.4.4Setup.exe");
            await DownloadFile("https://central.github.com/deployments/desktop/desktop/latest/win32", "GithubInstaller.exe");

            Print("Done!", Green);
            Console.ReadKey();
        }
    }
}
