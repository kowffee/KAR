﻿namespace KAR
{
    internal static class Handlers
    {
        internal static async Task<bool> InitSetup()
        {
            try
            {
                Directory.CreateDirectory("KARInstalls");
                Globals.AppList = [
                    ("https://github.com/brave/brave-browser/releases/latest/download/BraveBrowserSetup.exe", "BraveInstaller64bit.exe"),
                    ("https://laptop-updates.brave.com/latest/winx64/beta?bitness=64", "BraveBetaInstaller64bit.exe"),
                    ("https://laptop-updates.brave.com/latest/winx64/nightly?bitness=64", "BraveNightlyInstaller64bit.exe"),
                    ("https://openrgb.org/releases/release_0.9/OpenRGB_0.9_Windows_64_b5f46e3.zip", "OpenRGB.zip"),
                    ("https://github.com/Vencord/Vesktop/releases/download/v0.4.4/Vesktop-Setup-0.4.4.exe", "VesktopV0.4.4Setup.exe"),
                    ("https://central.github.com/deployments/desktop/desktop/latest/win32", "GithubInstaller.exe")
                ];

                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        internal static async Task<bool> StartDownload()
        {
            try
            {
                List<Task> downloadTasks = new List<Task>();

                foreach (var fileInfo in Globals.AppList)
                {
                    downloadTasks.Add(Utils.Network.DownloadFile(fileInfo.Url, fileInfo.fileName));
                }

                await Task.WhenAll(downloadTasks);

                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
