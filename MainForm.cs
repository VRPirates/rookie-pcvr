using RookiePCVR.Models;
using RookiePCVR.Utilities;
using JR.Utils.GUI.Forms;
using Newtonsoft.Json;
using SergeUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RookiePCVR
{
    public partial class MainForm : Form
    {

        private readonly ListViewColumnSorter lvwColumnSorter;

#if DEBUG
        public static bool debugMode = true;
        public bool DeviceConnected = false;
        public bool keyheld;
        public bool keyheld2;
        public static string CurrAPK;
        public static string CurrPCKG;
        List<UploadGame> gamesToUpload = new List<UploadGame>();


        public static string currremotesimple = "";
#else
        public bool keyheld;
        public static string CurrAPK;
        public static string CurrPCKG;
        public static bool debugMode = false;
        public bool DeviceConnected = false;


        public static string currremotesimple = "";

#endif

        private bool isLoading = true;
        public static bool hasPublicPCVRConfig = false;
        public static PublicConfig PublicConfigFile;
        public static string PublicMirrorExtraArgs = " --tpslimit 1.0 --tpslimit-burst 3";
        private System.Windows.Forms.Timer _debounceTimer;
        private CancellationTokenSource _cts;
        private List<ListViewItem> _allItems;
        public MainForm()
        {
            InitializeComponent();
            _debounceTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000, // 1 second delay
                Enabled = false
            };
            _debounceTimer.Tick += async (sender, e) => await RunSearch();
            gamesQueListBox.DataSource = gamesQueueList;
            //Time for debuglog
            string launchtime = DateTime.Now.ToString("hh:mmtt(UTC)");
            _ = Logger.Log($"\n------\n------\nProgram Launched at: {launchtime}\n------\n------");
            if (string.IsNullOrEmpty(Properties.Settings.Default.CurrentLogPath))
            {
                Properties.Settings.Default.CurrentLogPath = $"{Environment.CurrentDirectory}\\debuglog.txt";
            }
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer
            {
                Interval = 840000 // 14 mins between wakeup commands
            };
            t.Start();
            System.Windows.Forms.Timer t2 = new System.Windows.Forms.Timer
            {
                Interval = 300 // 30ms
            };
            t2.Tick += new EventHandler(timer_Tick2);
            t2.Start();

            lvwColumnSorter = new ListViewColumnSorter();
            gamesListView.ListViewItemSorter = lvwColumnSorter;
        }

        public static string DonorApps = "";
        private string oldTitle = "";
        public static bool updatesnotified = false;
        public static string BackupFolder;

        private async void Form1_Load(object sender, EventArgs e)
        {
            Splash splash = new Splash();
            splash.Show();
                if (File.Exists($"{Environment.CurrentDirectory}\\vrp-public-pcvr.json"))
                {
                    Thread worker = new Thread(() =>
                    {
                        SideloaderRCLONE.updatePublicConfig();
                    });
                    worker.Start();
                    while (worker.IsAlive)
                    {
                        Thread.Sleep(10);
                    }

                    try
                    {
                        string configFileData =
                            File.ReadAllText($"{Environment.CurrentDirectory}\\vrp-public-pcvr.json");
                        PublicConfig config = JsonConvert.DeserializeObject<PublicConfig>(configFileData);

                        if (config != null
                            && !string.IsNullOrWhiteSpace(config.BaseUri)
                            && !string.IsNullOrWhiteSpace(config.Password))
                        {
                            PublicConfigFile = config;
                            hasPublicPCVRConfig = true;
                        }
                    }
                    catch
                    {
                        hasPublicPCVRConfig = false;
                    }

                    if (!hasPublicPCVRConfig)
                    {
                        _ = FlexibleMessageBox.Show(Program.form, "Failed to fetch public mirror config, and the current one is unreadable.\r\nPlease ensure you can access https://vrpirates.wiki/ in your browser.", "Config Update Failed", MessageBoxButtons.OK);
                    }

                    if (Directory.Exists(@"C:\RSL\EBWebView"))
                    {
                        Directory.Delete(@"C:\RSL\EBWebView", true);
                    }
                }

            Properties.Settings.Default.MainDir = Environment.CurrentDirectory;
            Properties.Settings.Default.Save();
            FetchDependencies.downloadFiles();
            await Task.Delay(100);
            if (Directory.Exists(FetchDependencies.TempFolder))

            {
                Directory.Delete(FetchDependencies.TempFolder, true);
                _ = Directory.CreateDirectory(FetchDependencies.TempFolder);
            }

            //Delete the Debug file if it is more than 5MB
            if (File.Exists($"{Properties.Settings.Default.CurrentLogPath}"))
            {
                long length = new System.IO.FileInfo(Properties.Settings.Default.CurrentLogPath).Length;
                if (length > 5000000)
                {
                    File.Delete($"{Properties.Settings.Default.CurrentLogPath}");
                }
            }
            RCLONE.Init();
            if (Properties.Settings.Default.CallUpgrade)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.CallUpgrade = false;
                Properties.Settings.Default.Save();
            }
            CenterToScreen();
            gamesListView.View = View.Details;
            gamesListView.FullRowSelect = true;
            gamesListView.GridLines = false;
            etaLabel.Text = "";
            speedLabel.Text = "";
            if (File.Exists("crashlog.txt"))
            {
                if (File.Exists(Properties.Settings.Default.CurrentCrashPath))
                {
                    File.Delete(Properties.Settings.Default.CurrentCrashPath);
                }

                DialogResult dialogResult = FlexibleMessageBox.Show(Program.form, $"Sideloader crashed during your last use.\nPress OK if you'd like to send us your crash log.\n\n NOTE: THIS CAN TAKE UP TO 30 SECONDS.", "Crash Detected", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    if (File.Exists($"{Environment.CurrentDirectory}\\crashlog.txt"))
                    {
                        string UUID = SideloaderUtilities.UUID();
                        System.IO.File.Move("crashlog.txt", $"{Environment.CurrentDirectory}\\{UUID}.log");
                        Properties.Settings.Default.CurrentCrashPath = $"{Environment.CurrentDirectory}\\{UUID}.log";
                        Properties.Settings.Default.CurrentCrashName = UUID;
                        Properties.Settings.Default.Save();

                        Clipboard.SetText(UUID);
                        _ = RCLONE.runRcloneCommand_UploadConfig($"copy \"{Properties.Settings.Default.CurrentCrashPath}\" RSL-gameuploads:CrashLogs");
                        _ = FlexibleMessageBox.Show(Program.form, $"Your CrashLog has been copied to the server.\nPlease mention your CrashLogID ({Properties.Settings.Default.CurrentCrashName}) to the Mods.\nIt has been automatically copied to your clipboard.");
                        Clipboard.SetText(Properties.Settings.Default.CurrentCrashName);
                    }
                }
                else
                {
                    File.Delete($"{Environment.CurrentDirectory}\\crashlog.txt");
                }
            }

            if (hasPublicPCVRConfig)
            {
                lblMirror.Text = " Public Mirror";
                remotesList.Size = Size.Empty;
            }

            splash.Close();
        }


        private async void Form1_Shown(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Thread.Sleep(10000);
                freeDisclaimer.Invoke(() => { freeDisclaimer.Dispose(); });
            }).Start();

            progressBar.Style = ProgressBarStyle.Marquee;
            Thread t1 = new Thread(() =>
            {
                if (!debugMode && Properties.Settings.Default.checkForUpdates)
                {
                    Updater.AppName = "PCVR-Rookie";
                    Updater.Repostory = "VRPirates/rookie-pcvr";
                    Updater.Update();
                }
                progressBar.Invoke(() => { progressBar.Style = ProgressBarStyle.Marquee; });

                progressBar.Style = ProgressBarStyle.Marquee;
                    ChangeTitle("Initializing Servers...");
                    initMirrors(true);
                    if (Properties.Settings.Default.autoUpdateConfig)
                    {
                        ChangeTitle("Checking for a new Configuration File...");
                        SideloaderRCLONE.updateDownloadConfig();
                    }

                    SideloaderRCLONE.updateUploadConfig();

                    if (!hasPublicPCVRConfig)
                    {
                        ChangeTitle("Grabbing the Games List...");
                        SideloaderRCLONE.initGames(currentRemote);
                    }
                else
                {
                    ChangeTitle("Offline mode enabled, no Rclone");
                }

            });
            t1.SetApartmentState(ApartmentState.STA);
            t1.IsBackground = true;
            t1.Start();
            while (t1.IsAlive)
            {
                await Task.Delay(100);
            }
            if (hasPublicPCVRConfig)
            {
                remotesList.Visible = false;
                Thread t2 = new Thread(() =>
                {
                    ChangeTitle("Updating Metadata...");
                    SideloaderRCLONE.UpdateMetadataFromPublic();

                    ChangeTitle("Processing Metadata...");
                    SideloaderRCLONE.ProcessMetadataFromPublic();
                })
                {
                    IsBackground = true
                };
                t2.Start();
                while (t2.IsAlive)
                {
                    await Task.Delay(50);
                }
            }

            progressBar.Style = ProgressBarStyle.Marquee;

            ChangeTitle("Populating Game Update List, Almost There!");

            downloadInstallGameButton.Enabled = true;
            isLoading = false;
            initListPCVRView();
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);
            foreach (string file in files)
            {
                string fileName = file;
                while (fileName.Contains("\\"))
                {
                    fileName = fileName.Substring(fileName.IndexOf("\\") + 1);
                }
                if (!fileName.Contains(Properties.Settings.Default.CurrentLogName) && !fileName.Contains(Properties.Settings.Default.CurrentCrashName))
                {
                    if (!fileName.Contains("debuglog") && fileName.EndsWith(".txt"))
                    {
                        System.IO.File.Delete(fileName);
                    }
                }
            }
        }

        private void initMirrors(bool random)
        {
            int index = 0;
            remotesList.Invoke(() => { index = remotesList.SelectedIndex; remotesList.Items.Clear(); });

            string[] mirrors = RCLONE.runRcloneCommand_DownloadConfig("listremotes").Output.Split('\n');

            _ = Logger.Log("Loaded following mirrors: ");
            int itemsCount = 0;
            foreach (string mirror in mirrors)
            {
                if (mirror.Contains("mirror"))
                {
                    _ = Logger.Log(mirror.Remove(mirror.Length - 1));
                    remotesList.Invoke(() => { _ = remotesList.Items.Add(mirror.Remove(mirror.Length - 1).Replace("VRP-mirror", "")); });
                    itemsCount++;

                }
            }

            if (itemsCount > 0)
            {

                Random rand = new Random();
                // Code that implements a randomized mirror.  The rotation logic (the rotation) is reported as being bugged so I just disabled as a workaround ~pmow
                //  if (random == true && index < itemsCount)
                //    index = rand.Next(0, itemsCount);
                //    remotesList.Invoke(() =>
                // {
                //     remotesList.SelectedIndex = index;
                //     remotesList.SelectedIndex = 0;
                //    currentRemote = "VRP-mirror" + remotesList.SelectedItem.ToString();
                //  });

                remotesList.Invoke(() =>
                {
                    remotesList.SelectedIndex = 0; // Set mirror to first item in array.
                    currentRemote = "VRP-mirror" + remotesList.SelectedItem.ToString(); ;
                });


            };
        }

        public static string processError = string.Empty;

        public static string currentRemote = string.Empty;

        private void timer_Tick2(object sender, EventArgs e)
        {
            keyheld = false;
        }

        public async void ChangeTitle(string txt, bool reset = true)
        {
            try
            {
                this.Invoke(() => { oldTitle = txt; Text = "Rookie PCVR v" + Updater.LocalVersion + " | " + txt; });
                if (!reset)
                {
                    return;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
                this.Invoke(() => { Text = "Rookie PCVR v" + Updater.LocalVersion + " | " + oldTitle; });
            }
            catch
            {

            }
        }

        private void ShowSubMenu(Panel subMenu)
        {
            subMenu.Visible = subMenu.Visible == false;
        }

        public void ShowPrcOutput(ProcessOutput prcout)
        {
            string message = $"Output: {prcout.Output}";
            if (prcout.Error.Length != 0)
            {
                message += $"\nError: {prcout.Error}";
            }

            _ = FlexibleMessageBox.Show(Program.form, message);
        }

        public List<string> Devices = new List<string>();
        private List<string> newGamesList = new List<string>();
        private List<string> newGamesToUploadList = new List<string>();

        private readonly List<UpdateGameData> gamesToAskForUpdate = new List<UpdateGameData>();
        public static bool loaded = false;
        public static string rookienamelist;
        public static string rookienamelist2;
        private bool errorOnList;
        public static bool updates = false;
        public static bool newapps = false;
        public static int newint = 0;
        public static int updint = 0;
        public static bool nodeviceonstart = false;
        public static bool either = false;

        private async void initListPCVRView()
        {
            rookienamelist = "";
            loaded = false;
            char[] delims = new[] { '\r', '\n' };

            List<ListViewItem> GameList = new List<ListViewItem>();
            GameList.Clear();
            List<string> rookieList = new List<string>();
            errorOnList = false;
            //This is for black list, but temporarly will be whitelist
            //this list has games that we are actually going to upload
            progressBar.Style = ProgressBarStyle.Marquee;
            if (SideloaderRCLONE.games.Count > 5)
            {
                Thread t1 = new Thread(() =>
                {
                    foreach (string[] release in SideloaderRCLONE.games)
                    {
                        if (!rookienamelist.Contains(release[SideloaderRCLONE.GameNameIndex].ToString()))
                        {
                            rookienamelist += release[SideloaderRCLONE.GameNameIndex].ToString() + "\n";
                            rookienamelist2 += release[SideloaderRCLONE.GameNameIndex].ToString() + ", ";
                        }

                        ListViewItem Game = new ListViewItem(release);
                        GameList.Add(Game);
                    }
                })
                {
                    IsBackground = true
                };
                t1.Start();
                while (t1.IsAlive)
                {
                    await Task.Delay(100);
                }
            }
            else
            {
                SwitchMirrors();
                initListPCVRView();
            }
            progressBar.Style = ProgressBarStyle.Continuous;
            ChangeTitle("Populating game list...                               \n\n");
            ListViewItem[] arr = GameList.ToArray();
            gamesListView.BeginUpdate();
            gamesListView.Items.Clear();
            gamesListView.Items.AddRange(arr);
            gamesListView.EndUpdate();
            ChangeTitle("                                                \n\n");
            loaded = true;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show(Program.form);
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            string about = $@"Version: {Updater.LocalVersion}

 - Software orignally coded by rookie.wtf
 - Fork of AndroidSideloader made by Chax to work with PCVR
 ";

            _ = FlexibleMessageBox.Show(Program.form, about);
        }
  
        private static readonly HttpClient client = new HttpClient();
        public static bool reset = false;
        public static bool updatedConfig = false;
        public static int steps = 0;
        public static bool gamesAreDownloading = false;
        private readonly BindingList<string> gamesQueueList = new BindingList<string>();
        public static int quotaTries = 0;
        public static bool timerticked = false;
        public static bool skiponceafterremove = false;


        public void SwitchMirrors()
        {
            try
            {
                quotaTries++;
                remotesList.Invoke(() =>
                {
                    if (quotaTries > remotesList.Items.Count)
                    {
                        ShowError_QuotaExceeded();
                        RCLONE.killRclone();
                        Application.Exit();
                        return;
                    }
                    if (remotesList.SelectedIndex + 1 == remotesList.Items.Count)
                    {
                        reset = true;
                        for (int i = 0; i < steps; i++)
                        {
                            remotesList.SelectedIndex--;
                        }
                    }
                    if (reset)
                    {
                        remotesList.SelectedIndex--;
                    }
                    if (remotesList.Items.Count > remotesList.SelectedIndex && !reset)
                    {
                        remotesList.SelectedIndex++;
                        steps++;
                    }
                });
            }
            catch { }
        }

        private static void ShowError_QuotaExceeded()
        {
            string errorMessage =
$@"Unable to connect to Remote Server. Rookie is unable to connect to our Servers.

First time launching Rookie-PCVR? Please relaunch and try again.

Things you can try:
1) Move the Rookie-PCVR directory (Folder containing Rookie-PCVR.exe) into {Path.GetPathRoot(Environment.SystemDirectory)}RSL
2) Try changing your systems DNS to either Cloudflare/Google/OpenDNS
3) Try using a systemwide VPN like ProtonVPN
4) Sponsor a private server (https://vrpirates.wiki/en/Howto/sponsored-mirrors)
";

            _ = FlexibleMessageBox.Show(Program.form, errorMessage, "Unable to connect to Remote Server");
        }

        public void cleanupActiveDownloadStatus()
        {
            speedLabel.Text = "";
            etaLabel.Text = "";
            progressBar.Value = 0;
            gamesQueueList.RemoveAt(0);
        }

        public bool isinstalling = false;
        public static bool removedownloading = false;
        public async void downloadInstallGameButton_Click(object sender, EventArgs e)
        {
            {
                if (!Properties.Settings.Default.customDownloadDir)
                {
                    Properties.Settings.Default.downloadDir = Environment.CurrentDirectory.ToString();
                }
                progressBar.Style = ProgressBarStyle.Marquee;
                if (gamesListView.SelectedItems.Count == 0)
                {
                    progressBar.Style = ProgressBarStyle.Continuous;
                    ChangeTitle("You must select a game from the Game List!");
                    return;
                }
                string namebox = gamesListView.SelectedItems[0].ToString();
                int count = 0;
                string[] gamesToDownload;
                if (gamesListView.SelectedItems.Count > 0)
                {
                    count = gamesListView.SelectedItems.Count;
                    gamesToDownload = new string[count];
                    for (int i = 0; i < count; i++)
                    {
                        gamesToDownload[i] = gamesListView.SelectedItems[i].SubItems[SideloaderRCLONE.GameNameIndex].Text;
                    }
                }
                else
                {
                    return;
                }

                progressBar.Value = 0;
                progressBar.Style = ProgressBarStyle.Continuous;
                string game = gamesToDownload.Length == 1 ? $"\"{gamesToDownload[0]}\"" : "the selected games";
                isinstalling = true;
                //Add games to the queue
                for (int i = 0; i < gamesToDownload.Length; i++)
                {
                    gamesQueueList.Add(gamesToDownload[i]);
                }

                if (gamesAreDownloading)
                {
                    return;
                }

                gamesAreDownloading = true;

                ProcessOutput output = new ProcessOutput("", "");

                string gameName = "";
                while (gamesQueueList.Count > 0)
                {
                    gameName = gamesQueueList.ToArray()[0];
                    string dir = Path.GetDirectoryName(gameName);
                    string gameDirectory = Properties.Settings.Default.downloadDir + "\\" + gameName;
                    string path = gameDirectory;

                    string gameNameHash = string.Empty;
                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(gameName + "\n");
                        byte[] hash = md5.ComputeHash(bytes);
                        StringBuilder sb = new StringBuilder();
                        foreach (byte b in hash)
                        {
                            _ = sb.Append(b.ToString("x2"));
                        }

                        gameNameHash = sb.ToString();
                    }

                    ProcessOutput gameDownloadOutput = new ProcessOutput("", "");

                    _ = Logger.Log($"Starting Game Download");

                    Thread t1;
                    string extraArgs = string.Empty;
                    string virtualFilesystemCompatibilityArg = string.Empty;
                    if (Properties.Settings.Default.singleThreadMode)
                    {
                        extraArgs = "--transfers 1 --multi-thread-streams 0";
                    }
                    if (hasPublicPCVRConfig)
                    {
                        bool doDownload = true;
                        if (Directory.Exists(gameDirectory))
                        {
                            DialogResult res = FlexibleMessageBox.Show(
                                $"{gameName} exists in destination directory.\r\nWould you like to overwrite it?",
                                "Download again?", MessageBoxButtons.YesNo);

                            doDownload = res == DialogResult.Yes;

                            if (doDownload)
                            {
                                // only delete after extraction; allows for resume if the fetch fails midway.
                                if (Directory.Exists($"{Properties.Settings.Default.downloadDir}\\{gameName}"))
                                {
                                    Directory.Delete($"{Properties.Settings.Default.downloadDir}\\{gameName}", true);
                                }
                            }
                        }

                        if (doDownload)
                        {
                            _ = Logger.Log($"rclone copy \"Public:{SideloaderRCLONE.RcloneGamesFolder}/{gameName}\"");
                            t1 = new Thread(() =>
                            {
                                string rclonecommand =
                                $"copy \":http:/{gameNameHash}/\" \"{Properties.Settings.Default.downloadDir}\\{gameNameHash}\" {extraArgs} {virtualFilesystemCompatibilityArg} --progress --rc";
                                gameDownloadOutput = RCLONE.runRcloneCommand_PublicConfig(rclonecommand);
                            });
                        }
                        else
                        {
                            t1 = new Thread(() => { gameDownloadOutput = new ProcessOutput("Download skipped."); });
                        }
                    }
                    else
                    {
                        _ = Directory.CreateDirectory(gameDirectory);
                        _ = Logger.Log($"rclone copy \"{currentRemote}:{SideloaderRCLONE.RcloneGamesFolder}/{gameName}\"");
                        t1 = new Thread(() =>
                        {
                            gameDownloadOutput = RCLONE.runRcloneCommand_DownloadConfig($"copy \"{currentRemote}:{SideloaderRCLONE.RcloneGamesFolder}/{gameName}\" \"{Properties.Settings.Default.downloadDir}\\{gameName}\" {extraArgs} {virtualFilesystemCompatibilityArg} --progress --rc --retries 1 --low-level-retries 1");
                        });
                    }

                    t1.IsBackground = true;
                    t1.Start();

                    ChangeTitle("Downloading game " + gameName, false);
                    speedLabel.Text = "Starting download..."; etaLabel.Text = "Please wait...";
                    int i = 0;
                    //Download
                    while (t1.IsAlive)
                    {
                        try
                        {
                            HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:5572/core/stats", null);
                            string foo = await response.Content.ReadAsStringAsync();
                            Debug.WriteLine("RESP CONTENT " + foo);
                            dynamic results = JsonConvert.DeserializeObject<dynamic>(foo);

                            if (results["transferring"] != null)
                            {
                                long allSize = 0;
                                long downloaded = 0;

                                foreach (dynamic obj in results.transferring)
                                {
                                    allSize += obj["size"].ToObject<long>();
                                    downloaded += obj["bytes"].ToObject<long>();
                                }

                                float downloadSpeed = results.speed.ToObject<float>() / 1000000;
                                allSize /= 1000000;
                                downloaded /= 1000000;

                                Debug.WriteLine("Allsize: " + allSize + "\nDownloaded: " + downloaded + "\nValue: " + (downloaded / (double)allSize * 100));

                                progressBar.Style = ProgressBarStyle.Continuous;
                                progressBar.Value = Convert.ToInt32(downloaded / (double)allSize * 100);

                                i++;
                                if (i == 4)
                                {
                                    i = 0;
                                    float seconds = (allSize - downloaded) / downloadSpeed;
                                    TimeSpan time = TimeSpan.FromSeconds(seconds);
                                    etaLabel.Text = "ETA: " + time.ToString(@"hh\:mm\:ss") + " left";
                                }

                                speedLabel.Text = "DLS: " + string.Format("{0:0.00}", downloadSpeed) + " MB/s";
                            }
                        }
                        catch { }

                        await Task.Delay(100);

                    }

                    if (removedownloading)
                    {
                        ChangeTitle("Deleting game files", false);
                        try
                        {
                            cleanupActiveDownloadStatus();
                            if (hasPublicPCVRConfig)
                            {
                                if (Directory.Exists($"{Properties.Settings.Default.downloadDir}\\{gameNameHash}"))
                                {
                                    Directory.Delete($"{Properties.Settings.Default.downloadDir}\\{gameNameHash}", true);
                                }

                                if (Directory.Exists($"{Properties.Settings.Default.downloadDir}\\{gameName}"))
                                {
                                    Directory.Delete($"{Properties.Settings.Default.downloadDir}\\{gameName}", true);
                                }
                            }
                            else
                            {
                                Directory.Delete(Properties.Settings.Default.downloadDir + "\\" + gameName, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            _ = FlexibleMessageBox.Show($"Error deleting game files: {ex.Message}");
                        }
                        ChangeTitle("");
                        break;
                    }
                    {
                        //Quota Errors
                        bool quotaError = false;
                        bool otherError = false;
                        if (gameDownloadOutput.Error.Length > 0)
                        {
                            string err = gameDownloadOutput.Error.ToLower();
                            err += gameDownloadOutput.Output.ToLower();
                            if ((err.Contains("quota") && err.Contains("exceeded")) || err.Contains("directory not found"))
                            {
                                quotaError = true;

                                SwitchMirrors();

                                cleanupActiveDownloadStatus();
                            }
                            else if (!gameDownloadOutput.Error.Contains("Serving remote control on http://127.0.0.1:5572/"))
                            {
                                otherError = true;

                                //Remove current game
                                cleanupActiveDownloadStatus();

                                _ = FlexibleMessageBox.Show($"Rclone error: {gameDownloadOutput.Error}");
                                output += new ProcessOutput("", "Download Failed");
                            }
                        }

                        if (hasPublicPCVRConfig && otherError == false && gameDownloadOutput.Output != "Download skipped.")
                        {
                            Thread extractionThread = new Thread(() =>
                            {
                                try
                                {
                                    Invoke(new Action(() =>
                                    {
                                        speedLabel.Text = "Extracting..."; etaLabel.Text = "Please wait...";
                                    }));
                                    ChangeTitle("Extracting " + gameName, false);
                                    Zip.ExtractFile($"{Properties.Settings.Default.downloadDir}\\{gameNameHash}\\{gameNameHash}.7z.001", $"{Properties.Settings.Default.downloadDir}", PublicConfigFile.Password);
                                    Program.form.ChangeTitle("");
                                }
                                catch (Exception ex)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        cleanupActiveDownloadStatus();
                                    }));
                                    otherError = true;
                                    _ = FlexibleMessageBox.Show($"7zip error: {ex.Message}");
                                    output += new ProcessOutput("", "Extract Failed");
                                }
                            })
                            {
                                IsBackground = true
                            };
                            extractionThread.Start();

                            while (extractionThread.IsAlive)
                            {
                                await Task.Delay(100);
                            }

                            string[] partFiles = Directory.GetFiles($"{Properties.Settings.Default.downloadDir}\\{gameName}", "*.001");
                            string[] sevenZipFiles = Directory.GetFiles($"{Properties.Settings.Default.downloadDir}\\{gameName}", "*.7z");
                            string[] zipFiles = Directory.GetFiles($"{Properties.Settings.Default.downloadDir}\\{gameName}", "*.zip");

                            bool extracted = false; // Flag to track if any zip file has been extracted

                            if (Properties.Settings.Default.autoExtract)
                            {
                                if (partFiles != null && partFiles.Length > 0)
                                {
                                    // Extract the first part file
                                    Zip.ExtractFile(partFiles.First(), $"{Properties.Settings.Default.downloadDir}\\{gameName}");
                                    extracted = true;
                                    string[] allPartFiles = Directory.GetFiles($"{Properties.Settings.Default.downloadDir}\\{gameName}", "*.7z.*");
                                    foreach (string part in allPartFiles)
                                    {
                                        File.Delete(part);
                                    }
                                }
                                else if (sevenZipFiles != null && sevenZipFiles.Length > 0)
                                {
                                    // If there are no part files, extract the 7z file
                                    Zip.ExtractFile(sevenZipFiles.First(), $"{Properties.Settings.Default.downloadDir}\\{gameName}");
                                    File.Delete(sevenZipFiles.First());
                                    extracted = true;
                                }
                                else if (zipFiles != null && zipFiles.Length > 0)
                                {
                                    // If there are no part or 7z files, extract the zip file
                                    Zip.ExtractFile(zipFiles.First(), $"{Properties.Settings.Default.downloadDir}\\{gameName}");
                                    File.Delete(zipFiles.First());
                                    extracted = true;
                                }

                                if (Properties.Settings.Default.autoRunSetup)
                                {
                                    if (extracted)
                                    {
                                        string[] exeFiles = Directory.GetFiles($"{Properties.Settings.Default.downloadDir}\\{gameName}", "*.exe");
                                        // Run the executable if it exists
                                        if (exeFiles != null && exeFiles.Length > 0)
                                        {
                                            Process.Start(exeFiles.First());
                                        }
                                    }
                                }
                            }

                            if (Directory.Exists($"{Properties.Settings.Default.downloadDir}\\{gameNameHash}"))
                            {
                                Directory.Delete($"{Properties.Settings.Default.downloadDir}\\{gameNameHash}", true);
                            }
                        } 

                        if (quotaError == false && otherError == false)
                        {
                            ChangeTitle($"Installation of {gameName} completed.");
                            //Remove current game
                            cleanupActiveDownloadStatus();
                        }
                    }
                    }
                }
                if (removedownloading)
                {
                    removedownloading = false;
                    gamesAreDownloading = false;
                    isinstalling = false;
                    return;
                }
                    ChangeTitle("Refreshing games list, please wait...         \n");
                    progressBar.Style = ProgressBarStyle.Continuous;
                    etaLabel.Text = "ETA: Finished Queue";
                    speedLabel.Text = "DLS: Finished Queue";
                    gamesAreDownloading = false;
                    isinstalling = false;

                    ChangeTitle(" \n\n");
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isinstalling)
            {
                DialogResult res1 = FlexibleMessageBox.Show(Program.form, "There are downloads and/or installations in progress,\nif you exit now you'll have to start the entire process over again.\nAre you sure you want to exit?", "Still downloading/installing.",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res1 != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    RCLONE.killRclone();
                }
            }
            else
            {
                RCLONE.killRclone();
            }

        }

        private void disPosed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void gamesQueListBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (gamesQueListBox.SelectedIndex == 0 && gamesQueueList.Count == 1)
            {
                removedownloading = true;
                RCLONE.killRclone();
            }
            if (gamesQueListBox.SelectedIndex != -1 && gamesQueListBox.SelectedIndex != 0)
            {
                _ = gamesQueueList.Remove(gamesQueListBox.SelectedItem.ToString());
            }

        }

        private void remotesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (remotesList.SelectedItem != null)
            {
                remotesList.Invoke(() => { currentRemote = "VRP-mirror" + remotesList.SelectedItem.ToString(); });
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                lvwColumnSorter.Order = lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = e.Column == 4 ? SortOrder.Descending : SortOrder.Ascending;
            }
            // Perform the sort with these new sort options.
            gamesListView.Sort();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            _debounceTimer.Stop();
            _debounceTimer.Start();
        }

        private async Task RunSearch()
        {
            _debounceTimer.Stop();

            // Cancel any ongoing searches
            _cts?.Cancel();

            _allItems = gamesListView.Items.Cast<ListViewItem>().ToList();

            string searchTerm = searchTextBox.Text;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                _cts = new CancellationTokenSource();
                try
                {
                    var matches = await Task.Run(() =>
                        _allItems
                            .Where(i => i.Text.IndexOf(searchTerm, StringComparison.CurrentCultureIgnoreCase) >= 0)
                            .ToList(),
                        _cts.Token);

                    // Update UI on UI thread
                    Invoke(new Action(() =>
                    {
                        gamesListView.Items.Clear();
                        foreach (var match in matches)
                        {
                            gamesListView.Items.Add(match);
                        }
                    }));
                }
                catch (OperationCanceledException)
                {
                    // A new search was initiated before the current search completed.
                }
            }
            else
            {
                // No matching items found, restore the original list
                initListPCVRView();
            }
        }

        public void gamesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gamesListView.SelectedItems.Count < 1)
            {
                return;
            }
            string CurrentReleaseName = gamesListView.SelectedItems[gamesListView.SelectedItems.Count - 1].SubItems[SideloaderRCLONE.GameNameIndex].Text;
            string CurrentGameName = gamesListView.SelectedItems[gamesListView.SelectedItems.Count - 1].SubItems[SideloaderRCLONE.GameNameIndex].Text;
            Console.WriteLine(CurrentGameName);
        }

        private void gamesListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gamesListView.SelectedItems.Count > 0)
            {
                downloadInstallGameButton_Click(sender, e);
            }
        }

        private void freeDisclaimer_Click(object sender, EventArgs e)
        {
            _ = Process.Start("https://github.com/VRPirates/rookie-pcvr");
        }
 
        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            _ = gamesListView.Focus();
        }

        private void gamesQueListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (gamesQueListBox.SelectedItem == null)
            {
                return;
            }

            _ = gamesQueListBox.DoDragDrop(gamesQueListBox.SelectedItem, DragDropEffects.Move);
        }

        private void gamesQueListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void searchTextBox_Click(object sender, EventArgs e)
        {
            searchTextBox.Clear();
            _ = searchTextBox.Focus();
        }
    }

    public static class ControlExtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                _ = control.Invoke(new MethodInvoker(action), null);
            }
            else
            {
                action.Invoke();
            }
        }
    }
}