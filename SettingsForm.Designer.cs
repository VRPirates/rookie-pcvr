
namespace RookiePCVR
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkForUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.updateConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.crashlogID = new System.Windows.Forms.Label();
            this.downloadDirectorySetter = new System.Windows.Forms.FolderBrowserDialog();
            this.backupDirectorySetter = new System.Windows.Forms.FolderBrowserDialog();
            this.singleThread = new System.Windows.Forms.CheckBox();
            this.setDownloadDirectory = new RookiePCVR.RoundButton();
            this.btnOpenDebug = new RookiePCVR.RoundButton();
            this.btnResetDebug = new RookiePCVR.RoundButton();
            this.btnUploadDebug = new RookiePCVR.RoundButton();
            this.resetSettingsButton = new RookiePCVR.RoundButton();
            this.applyButton = new RookiePCVR.RoundButton();
            this.virtualFilesystemCompatibilityCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkForUpdatesCheckBox
            // 
            this.checkForUpdatesCheckBox.AutoSize = true;
            this.checkForUpdatesCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.checkForUpdatesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkForUpdatesCheckBox.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.checkForUpdatesCheckBox.Location = new System.Drawing.Point(12, 12);
            this.checkForUpdatesCheckBox.Name = "checkForUpdatesCheckBox";
            this.checkForUpdatesCheckBox.Size = new System.Drawing.Size(148, 22);
            this.checkForUpdatesCheckBox.TabIndex = 0;
            this.checkForUpdatesCheckBox.Text = "Check for updates";
            this.checkForUpdatesCheckBox.UseVisualStyleBackColor = false;
            this.checkForUpdatesCheckBox.CheckedChanged += new System.EventHandler(this.checkForUpdatesCheckBox_CheckedChanged);
            // 
            // updateConfigCheckBox
            // 
            this.updateConfigCheckBox.AutoSize = true;
            this.updateConfigCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.updateConfigCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateConfigCheckBox.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.updateConfigCheckBox.Location = new System.Drawing.Point(11, 40);
            this.updateConfigCheckBox.Name = "updateConfigCheckBox";
            this.updateConfigCheckBox.Size = new System.Drawing.Size(208, 22);
            this.updateConfigCheckBox.TabIndex = 6;
            this.updateConfigCheckBox.Text = "Update config automatically";
            this.updateConfigCheckBox.UseVisualStyleBackColor = false;
            this.updateConfigCheckBox.CheckedChanged += new System.EventHandler(this.updateConfigCheckBox_CheckedChanged);
            // 
            // crashlogID
            // 
            this.crashlogID.AutoSize = true;
            this.crashlogID.Location = new System.Drawing.Point(13, 439);
            this.crashlogID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.crashlogID.Name = "crashlogID";
            this.crashlogID.Size = new System.Drawing.Size(0, 13);
            this.crashlogID.TabIndex = 15;
            // 
            // downloadDirectorySetter
            // 
            this.downloadDirectorySetter.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // backupDirectorySetter
            // 
            this.backupDirectorySetter.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // singleThread
            // 
            this.singleThread.AutoSize = true;
            this.singleThread.BackColor = System.Drawing.Color.Transparent;
            this.singleThread.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.singleThread.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.singleThread.Location = new System.Drawing.Point(11, 68);
            this.singleThread.Name = "singleThread";
            this.singleThread.Size = new System.Drawing.Size(186, 22);
            this.singleThread.TabIndex = 25;
            this.singleThread.Text = "Enable Single-Threading";
            this.singleThread.UseVisualStyleBackColor = false;
            this.singleThread.CheckedChanged += new System.EventHandler(this.singleThread_CheckedChanged);
            // 
            // setDownloadDirectory
            // 
            this.setDownloadDirectory.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.setDownloadDirectory.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.setDownloadDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.setDownloadDirectory.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.setDownloadDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.setDownloadDirectory.ForeColor = System.Drawing.Color.White;
            this.setDownloadDirectory.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.setDownloadDirectory.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.setDownloadDirectory.Location = new System.Drawing.Point(27, 323);
            this.setDownloadDirectory.Name = "setDownloadDirectory";
            this.setDownloadDirectory.Radius = 5;
            this.setDownloadDirectory.Size = new System.Drawing.Size(285, 31);
            this.setDownloadDirectory.Stroke = false;
            this.setDownloadDirectory.StrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.setDownloadDirectory.TabIndex = 23;
            this.setDownloadDirectory.Text = "Set Download Directory";
            this.setDownloadDirectory.Transparency = false;
            this.setDownloadDirectory.Click += new System.EventHandler(this.setDownloadDirectory_Click);
            // 
            // btnOpenDebug
            // 
            this.btnOpenDebug.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnOpenDebug.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnOpenDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOpenDebug.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOpenDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnOpenDebug.ForeColor = System.Drawing.Color.White;
            this.btnOpenDebug.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnOpenDebug.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnOpenDebug.Location = new System.Drawing.Point(27, 194);
            this.btnOpenDebug.Name = "btnOpenDebug";
            this.btnOpenDebug.Radius = 5;
            this.btnOpenDebug.Size = new System.Drawing.Size(285, 31);
            this.btnOpenDebug.Stroke = false;
            this.btnOpenDebug.StrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.btnOpenDebug.TabIndex = 21;
            this.btnOpenDebug.Text = "Open Debug Log";
            this.btnOpenDebug.Transparency = false;
            this.btnOpenDebug.Click += new System.EventHandler(this.btnOpenDebug_Click);
            // 
            // btnResetDebug
            // 
            this.btnResetDebug.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnResetDebug.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnResetDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnResetDebug.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnResetDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnResetDebug.ForeColor = System.Drawing.Color.White;
            this.btnResetDebug.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnResetDebug.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnResetDebug.Location = new System.Drawing.Point(27, 231);
            this.btnResetDebug.Name = "btnResetDebug";
            this.btnResetDebug.Radius = 5;
            this.btnResetDebug.Size = new System.Drawing.Size(285, 31);
            this.btnResetDebug.Stroke = false;
            this.btnResetDebug.StrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.btnResetDebug.TabIndex = 20;
            this.btnResetDebug.Text = "Reset Debug Log";
            this.btnResetDebug.Transparency = false;
            this.btnResetDebug.Click += new System.EventHandler(this.btnResetDebug_click);
            // 
            // btnUploadDebug
            // 
            this.btnUploadDebug.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnUploadDebug.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnUploadDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUploadDebug.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUploadDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnUploadDebug.ForeColor = System.Drawing.Color.White;
            this.btnUploadDebug.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnUploadDebug.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnUploadDebug.Location = new System.Drawing.Point(27, 268);
            this.btnUploadDebug.Name = "btnUploadDebug";
            this.btnUploadDebug.Radius = 5;
            this.btnUploadDebug.Size = new System.Drawing.Size(285, 31);
            this.btnUploadDebug.Stroke = false;
            this.btnUploadDebug.StrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.btnUploadDebug.TabIndex = 19;
            this.btnUploadDebug.Text = "Upload Debug Log";
            this.btnUploadDebug.Transparency = false;
            this.btnUploadDebug.Click += new System.EventHandler(this.btnUploadDebug_click);
            // 
            // resetSettingsButton
            // 
            this.resetSettingsButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.resetSettingsButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.resetSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.resetSettingsButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.resetSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.resetSettingsButton.ForeColor = System.Drawing.Color.White;
            this.resetSettingsButton.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.resetSettingsButton.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.resetSettingsButton.Location = new System.Drawing.Point(179, 137);
            this.resetSettingsButton.Name = "resetSettingsButton";
            this.resetSettingsButton.Radius = 5;
            this.resetSettingsButton.Size = new System.Drawing.Size(133, 31);
            this.resetSettingsButton.Stroke = false;
            this.resetSettingsButton.StrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.resetSettingsButton.TabIndex = 18;
            this.resetSettingsButton.Text = "Reset Settings";
            this.resetSettingsButton.Transparency = false;
            this.resetSettingsButton.Click += new System.EventHandler(this.resetSettingsButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.applyButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.applyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.applyButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.applyButton.ForeColor = System.Drawing.Color.White;
            this.applyButton.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.applyButton.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.applyButton.Location = new System.Drawing.Point(27, 137);
            this.applyButton.Name = "applyButton";
            this.applyButton.Radius = 5;
            this.applyButton.Size = new System.Drawing.Size(133, 31);
            this.applyButton.Stroke = false;
            this.applyButton.StrokeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.applyButton.TabIndex = 17;
            this.applyButton.Text = "Apply Settings";
            this.applyButton.Transparency = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // virtualFilesystemCompatibilityCheckbox
            // 
            this.virtualFilesystemCompatibilityCheckbox.AutoSize = true;
            this.virtualFilesystemCompatibilityCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.virtualFilesystemCompatibilityCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.virtualFilesystemCompatibilityCheckbox.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.virtualFilesystemCompatibilityCheckbox.Location = new System.Drawing.Point(11, 96);
            this.virtualFilesystemCompatibilityCheckbox.Name = "virtualFilesystemCompatibilityCheckbox";
            this.virtualFilesystemCompatibilityCheckbox.Size = new System.Drawing.Size(279, 22);
            this.virtualFilesystemCompatibilityCheckbox.TabIndex = 26;
            this.virtualFilesystemCompatibilityCheckbox.Text = "Enable Virtual Filesystem Compatibility";
            this.virtualFilesystemCompatibilityCheckbox.UseVisualStyleBackColor = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::RookiePCVR.Properties.Settings.Default.BackColor;
            this.ClientSize = new System.Drawing.Size(339, 374);
            this.Controls.Add(this.virtualFilesystemCompatibilityCheckbox);
            this.Controls.Add(this.singleThread);
            this.Controls.Add(this.setDownloadDirectory);
            this.Controls.Add(this.btnOpenDebug);
            this.Controls.Add(this.btnResetDebug);
            this.Controls.Add(this.btnUploadDebug);
            this.Controls.Add(this.resetSettingsButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.crashlogID);
            this.Controls.Add(this.updateConfigCheckBox);
            this.Controls.Add(this.checkForUpdatesCheckBox);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::RookiePCVR.Properties.Settings.Default, "BackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SettingsForm_KeyPress);
            this.Leave += new System.EventHandler(this.SettingsForm_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkForUpdatesCheckBox;
        private System.Windows.Forms.CheckBox updateConfigCheckBox;
        private System.Windows.Forms.Label crashlogID;
        private RoundButton applyButton;
        private RoundButton resetSettingsButton;
        private RoundButton btnResetDebug;
        private RoundButton btnUploadDebug;
        private RoundButton btnOpenDebug;
        private RoundButton setDownloadDirectory;
        private System.Windows.Forms.FolderBrowserDialog downloadDirectorySetter;
        private System.Windows.Forms.FolderBrowserDialog backupDirectorySetter;
        private System.Windows.Forms.CheckBox singleThread;
        private System.Windows.Forms.CheckBox virtualFilesystemCompatibilityCheckbox;
    }
}