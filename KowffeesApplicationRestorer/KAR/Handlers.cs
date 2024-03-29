﻿namespace KAR
{
    internal static class Handlers
    {
        internal static bool InitSetup()
        {
            try
            {
                Directory.CreateDirectory("KARInstalls");
                // Plan: Read from a file and add the lines to the AppList
                Globals.AppList = [
                    ("https://github.com/brave/brave-browser/releases/latest/download/BraveBrowserSetup.exe", "BraveInstaller64bit.exe"),
                    ("https://github.com/brave/brave-browser/releases/download/v1.63.137/BraveBrowserStandaloneSilentBetaSetup.exe", "BraveBetaSILENTInstaller.exe"),
                    ("https://downloads.vivaldi.com/stable/Vivaldi.6.5.3206.57.x64.exe", "VivaldiInstaller.exe"),
                    ("https://openrgb.org/releases/release_0.9/OpenRGB_0.9_Windows_64_b5f46e3.zip", "OpenRGB.zip"),
                    ("https://vencord.dev/download/vesktop/amd64/windows", "VesktopSetup.exe"),
                    ("https://central.github.com/deployments/desktop/desktop/latest/win32", "GithubInstaller.exe"),
                    ("https://github.com/hellzerg/optimizer/releases/download/16.4/Optimizer-16.4.exe", "Optimizer.exe"),
                    ("https://github.com/pizzaboxer/bloxstrap/releases/download/v2.5.4/Bloxstrap-v2.5.4.exe", "BloxstrapV2.5.4.exe"),
                    ("https://github.com/builtbybel/Bloatynosy/releases/download/1.6.0/BloatynosyApp.zip", "Bloatynosy.zip"),
                    ("https://download3.manycams.com/installer/ManyCamSetup.exe", "ManycamSetup.exe"),
                    ("https://github.com/VSCodium/vscodium/releases/download/1.85.1.23348/VSCodiumSetup-x64-1.85.1.23348.exe", "VSCodiumSetup.exe"),
                    ("https://c2rsetup.officeapps.live.com/c2r/downloadVS.aspx?sku=community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030", "VisualStudio2022Community.exe"),
                    ("https://updates.safing.io/latest/windows_amd64/packages/portmaster-installer.exe", "PortmasterInstaller.exe"),
                    ("https://github.com/CodeDead/MemPlus/releases/download/1.3.2/MP_setup.exe", "MemPlusSetup.exe"),
                    ("https://www.7-zip.org/a/7z2301-x64.exe", "7zipSetup.exe"),
                    ("https://github.com/Klocman/Bulk-Crap-Uninstaller/releases/download/v5.7/BCUninstaller_5.7_setup.exe", "BCUInstaller.exe"),
                    ("https://github.com/keepassxreboot/keepassxc/releases/download/2.7.6/KeePassXC-2.7.6-Win64.msi", "KeePassXCInstaller.msi"),
                    ("https://github.com/nukeop/nuclear/releases/download/v0.6.30/nuclear-v0.6.30.exe", "Nuclear.exe"),
                    ("https://github.com/spacedriveapp/spacedrive/releases/download/0.2.2/Spacedrive-windows-x86_64.msi", "SpacedriveV0.2.2.msi"),
                    ("https://github.com/Tichau/FileConverter/releases/download/v1.2.3/FileConverter-1.2.3-x64-setup.msi", "FileConverterSetup.msi"),
                    ("https://github.com/MCMrARM/mc-w10-version-launcher/releases/download/0.4.0/MCLauncher.zip", "MCLauncher.zip"),
                    ("https://github.com/ShareX/ShareX/releases/download/v15.0.0/ShareX-15.0.0-setup.exe", "ShareXSetupV15.0.0.exe"),
                    ("https://www.malwarebytes.com/api/downloads/mb-windows?filename=MBSetup.exe", "MalwareBytesSetup.exe"),
                    ("https://github.com/SaladTechnologies/salad-applications/releases/download/1.3.6/Salad-1.3.6.exe", "SaladSetupV1.3.6.exe")
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
