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
                if (!File.Exists("Sideloader Launcher.exe"))
                {
                    currentAccessedWebsite = "github";
                    client.DownloadFile("https://github.com/nerdunit/androidsideloader/raw/master/Sideloader%20Launcher.exe", "Sideloader Launcher.exe");
                }

                if (!File.Exists("Rookie Offline.cmd"))
                {
                    currentAccessedWebsite = "github";
                    client.DownloadFile("https://github.com/nerdunit/androidsideloader/raw/master/Rookie%20Offline.cmd", "Rookie Offline.cmd");
                }

                if (!Directory.Exists(Environment.CurrentDirectory + "\\rclone"))
                {
                    currentAccessedWebsite = "rclone";
                    string url = Environment.Is64BitOperatingSystem
                        ? "https://downloads.rclone.org/v1.62.2/rclone-v1.62.2-windows-amd64.zip"
                        : "https://downloads.rclone.org/v1.62.2/rclone-v1.62.2-windows-386.zip";
                    //Since sideloader is build for x86, it should work on both x86 and x64 so we download the according rclone version

                    client.DownloadFile(url, "rclone.zip");

                    Utilities.Zip.ExtractFile(Environment.CurrentDirectory + "\\rclone.zip", Environment.CurrentDirectory);

                    File.Delete("rclone.zip");

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
                else
                {
                    string pathToRclone = Path.Combine(Environment.CurrentDirectory, "rclone", "rclone.exe");
                    if (File.Exists(pathToRclone))
                    {
                        var versionInfo = FileVersionInfo.GetVersionInfo(pathToRclone);
                        string version = versionInfo.ProductVersion;
                        Logger.Log($"Current RCLONE Version {version}");
                        if (version != "1.62.2")
                        {
                            Logger.Log("RCLONE Version not matching! Downloading required version.", LogLevel.WARNING);
                            File.Delete(pathToRclone);
                            currentAccessedWebsite = "rclone";
                            string architecture = Environment.Is64BitOperatingSystem ? "amd64" : "386";
                            string url = $"https://downloads.rclone.org/v1.62.2/rclone-v1.62.2-windows-{architecture}.zip";
                            client.DownloadFile(url, "rclone.zip");
                            Utilities.Zip.ExtractFile(Path.Combine(Environment.CurrentDirectory, "rclone.zip"), Environment.CurrentDirectory);
                            File.Delete("rclone.zip");
                            string rcloneDirectory = Path.Combine(Environment.CurrentDirectory, $"rclone-v1.62.2-windows-{architecture}");
                            File.Move(Path.Combine(rcloneDirectory, "rclone.exe"), pathToRclone);
                            Directory.Delete(rcloneDirectory, true);
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
