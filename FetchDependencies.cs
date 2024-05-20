using JR.Utils.GUI.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RookiePCVR
{
    internal class FetchDependencies
    {
        public static string TempFolder = Path.Combine(Environment.CurrentDirectory, "temp");
        public static string CrashLogPath = "crashlog.txt";

        //push user.json to device (required for some devices like oculus quest)
        //List of all installed package names from connected device
        //public static List<string> InstalledPackageNames = new List<string>();        //Remove folder from device
    
        //For games that require manual install, like having another folder that isnt an obb

        //Downloads the required files
        public static void downloadFiles()
        {
            WebClient client = new WebClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var currentAccessedWebsite = "";
            try
            {
                Boolean updateRclone = false;
                string wantedVersion = "1.66.0";
                string version = "0.0.0";
                string pathToRclone = Path.Combine(Environment.CurrentDirectory, "rclone", "rclone.exe");
                if (File.Exists(pathToRclone))
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(pathToRclone);
                    version = versionInfo.ProductVersion;
                    Logger.Log($"Current RCLONE Version {version}");
                    if (version != wantedVersion)
                    {
                        updateRclone = true;
                    }
                }

                if (!Directory.Exists(Environment.CurrentDirectory + "\\rclone") || updateRclone == true)
                {
                    if (!Directory.Exists(Environment.CurrentDirectory + "\\rclone")) {
                        Logger.Log($"rclone does not exist.", LogLevel.WARNING);
                    } else {
                        Logger.Log($"rclone is the wrong version. Wanted: {wantedVersion} Current: {version}", LogLevel.WARNING);
                        if (Directory.Exists(Environment.CurrentDirectory + "\\rclone")) {
                            Directory.Delete(Environment.CurrentDirectory + "\\rclone", true);
                        }
                    }

                    Logger.Log($"Downloading from rclone.org", LogLevel.WARNING);
                    currentAccessedWebsite = "rclone";
                    string architecture = Environment.Is64BitOperatingSystem ? "amd64" : "386";
                    string url = $"https://downloads.rclone.org/v{wantedVersion}/rclone-v{wantedVersion}-windows-{architecture}.zip";
                    //Since sideloader is build for x86, it should work on both x86 and x64 so we download the according rclone version

                    Logger.Log(url, LogLevel.INFO);
                    client.DownloadFile(url, "rclone.zip");

                    Logger.Log($"rclone download completed, unzipping contents");
                    Utilities.Zip.ExtractFile(Environment.CurrentDirectory + "\\rclone.zip", Environment.CurrentDirectory);

                    File.Delete("rclone.zip");
                    Logger.Log($"rclone downloaded successfully");

                    string[] folders = Directory.GetDirectories(Environment.CurrentDirectory);
                    foreach (string folder in folders)
                    {
                        if (folder.Contains("rclone"))
                        {
                            Directory.Move(folder, "rclone");
                            break; //only 1 rclone folder
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (currentAccessedWebsite == "github")
                {
                    _ = FlexibleMessageBox.Show($"You are unable to access the raw.githubusercontent.com page with the Exception: {ex.Message}");
                    _ = FlexibleMessageBox.Show("These required files were unable to be downloaded\nRookie-PCVR will now close");
                    Application.Exit();
                }
                if (currentAccessedWebsite == "rclone")
                {
                    _ = FlexibleMessageBox.Show($"You are unable to access the rclone page with the Exception: {ex.Message}\nSome files may be missing (RCLONE)");
                    _ = FlexibleMessageBox.Show("Rclone was unable to be downloaded\nRookie-PCVR will now close");
                    Application.Exit();
                }
            }
        }
    }


}
