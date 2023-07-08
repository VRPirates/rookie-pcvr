using JR.Utils.GUI.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AndroidSideloader
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
            intSettings();
            intToolTips();
        }

        //Init form objects with values from settings
        private void intSettings()
        {
            checkForUpdatesCheckBox.Checked = Properties.Settings.Default.checkForUpdates;
            updateConfigCheckBox.Checked = Properties.Settings.Default.autoUpdateConfig;
            singleThread.Checked = Properties.Settings.Default.singleThreadMode;
            virtualFilesystemCompatibilityCheckbox.Checked = Properties.Settings.Default.virtualFilesystemCompatibility;
        }

        private void intToolTips()
        {
            ToolTip checkForUpdatesToolTip = new ToolTip();
            checkForUpdatesToolTip.SetToolTip(checkForUpdatesCheckBox, "If this is checked, the software will check for available updates");
        }

        public void btnUploadDebug_click(object sender, EventArgs e)
        {
            if (File.Exists($"{Properties.Settings.Default.CurrentLogPath}"))
            {
                string UUID = SideloaderUtilities.UUID();
                string debugLogPath = $"{Environment.CurrentDirectory}\\{UUID}.log";
                System.IO.File.Copy("debuglog.txt", debugLogPath);

                Clipboard.SetText(UUID);

                _ = RCLONE.runRcloneCommand_UploadConfig($"copy \"{debugLogPath}\" RSL-gameuploads:DebugLogs");
                _ = MessageBox.Show($"Your debug log has been copied to the server. ID: {UUID}");
            }
        }


        public void btnResetDebug_click(object sender, EventArgs e)
        {
            if (File.Exists($"{Properties.Settings.Default.CurrentLogPath}"))
            {
                File.Delete($"{Properties.Settings.Default.CurrentLogPath}");
            }

            if (File.Exists($"{Environment.CurrentDirectory}\\pcvr-debuglog.txt"))
            {
                File.Delete($"{Environment.CurrentDirectory}\\pcvr-debuglog.txt");
            }
        }

        //Apply settings
        private void applyButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            _ = FlexibleMessageBox.Show(this, "Settings applied!");
        }

        private void checkForUpdatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkForUpdates = checkForUpdatesCheckBox.Checked;
        }

        private void resetSettingsButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.customDownloadDir = false;
            MainForm.BackupFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Rookie Backups");
            Properties.Settings.Default.downloadDir = Environment.CurrentDirectory.ToString();
            intSettings();
        }



        private void updateConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoUpdateConfig = updateConfigCheckBox.Checked;
        }

        private void SettingsForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        private void SettingsForm_Leave(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btnOpenDebug_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{Environment.CurrentDirectory}\\debuglog.txt"))
            {
                _ = Process.Start($"{Environment.CurrentDirectory}\\debuglog.txt");
            }
        }

        private void setDownloadDirectory_Click(object sender, EventArgs e)
        {
            if (downloadDirectorySetter.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.customDownloadDir = true;
                Properties.Settings.Default.downloadDir = downloadDirectorySetter.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void singleThread_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.singleThreadMode = singleThread.Checked;
            Properties.Settings.Default.Save();
        }

        private void virtualFilesystemCompatibilityCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.virtualFilesystemCompatibility = virtualFilesystemCompatibilityCheckbox.Checked;
            Properties.Settings.Default.Save();
        }
    }
}

