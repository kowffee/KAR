using static System.ConsoleColor;
using static KAR.Utils.Printer;

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

            await Handlers.StartDownload();

            Print("Done!", Green);
            Console.ReadKey();
        }
    }
}
