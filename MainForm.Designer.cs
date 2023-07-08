
using RookiePCVR.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace RookiePCVR
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.downloadingLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.etaLabel = new System.Windows.Forms.Label();
            this.freeDisclaimer = new System.Windows.Forms.Label();
            this.gamesQueListBox = new System.Windows.Forms.ListBox();
            this.gamesListView = new System.Windows.Forms.ListView();
            this.GameNameIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReleaseAPKPathIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionNameIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.startsideloadbutton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.devicesbutton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.obbcopybutton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.backupbutton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.restorebutton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.getApkButton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.uninstallAppButton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.pullAppToDesktopBtn_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.copyBulkObbButton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.aboutBtn_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.aboutBtn = new System.Windows.Forms.Button();
            this.settingsButton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.settingsButton = new System.Windows.Forms.Button();
            this.InstallQUset_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.removeQUSetting_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.QuestOptionsButton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.ADBWirelessDisable_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.ADBWirelessEnable_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.UpdateGamesButton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.listApkButton_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.speedLabel_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.etaLabel_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.EnterInstallBox_Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.remotesList = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMirror = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.downloadInstallGameButton = new RookiePCVR.RoundButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressBar.ForeColor = System.Drawing.Color.Purple;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.MinimumSize = new System.Drawing.Size(200, 13);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(388, 13);
            this.progressBar.TabIndex = 7;
            // 
            // downloadingLabel
            // 
            this.downloadingLabel.AutoSize = true;
            this.downloadingLabel.BackColor = System.Drawing.SystemColors.WindowText;
            this.downloadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.downloadingLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.downloadingLabel.Location = new System.Drawing.Point(0, 0);
            this.downloadingLabel.Name = "downloadingLabel";
            this.downloadingLabel.Size = new System.Drawing.Size(0, 18);
            this.downloadingLabel.TabIndex = 83;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedLabel.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::RookiePCVR.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.speedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.speedLabel.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.speedLabel.ForeColor = global::RookiePCVR.Properties.Settings.Default.FontColor;
            this.speedLabel.Location = new System.Drawing.Point(2, 14);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(149, 18);
            this.speedLabel.TabIndex = 76;
            this.speedLabel.Text = "DLS: Speed in MBPS";
            this.speedLabel_Tooltip.SetToolTip(this.speedLabel, "Current download speed, updates every second, in mbps");
            // 
            // etaLabel
            // 
            this.etaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.etaLabel.BackColor = System.Drawing.Color.Transparent;
            this.etaLabel.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::RookiePCVR.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.etaLabel.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.etaLabel.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.etaLabel.ForeColor = global::RookiePCVR.Properties.Settings.Default.FontColor;
            this.etaLabel.Location = new System.Drawing.Point(192, 14);
            this.etaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.etaLabel.Name = "etaLabel";
            this.etaLabel.Size = new System.Drawing.Size(196, 18);
            this.etaLabel.TabIndex = 75;
            this.etaLabel.Text = "ETA: HH:MM:SS Left";
            this.etaLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.etaLabel_Tooltip.SetToolTip(this.etaLabel, "Estimated time when game will finish download, updates every 5 seconds, format is" +
        " HH:MM:SS");
            // 
            // freeDisclaimer
            // 
            this.freeDisclaimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.freeDisclaimer.AutoSize = true;
            this.freeDisclaimer.BackColor = System.Drawing.Color.Black;
            this.freeDisclaimer.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::RookiePCVR.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.freeDisclaimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freeDisclaimer.ForeColor = global::RookiePCVR.Properties.Settings.Default.FontColor;
            this.freeDisclaimer.Location = new System.Drawing.Point(203, 497);
            this.freeDisclaimer.Name = "freeDisclaimer";
            this.freeDisclaimer.Size = new System.Drawing.Size(246, 40);
            this.freeDisclaimer.TabIndex = 79;
            this.freeDisclaimer.Text = "This app is FREE!! \r\nClick here to go to the github.";
            this.freeDisclaimer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.freeDisclaimer.Click += new System.EventHandler(this.freeDisclaimer_Click);
            // 
            // gamesQueListBox
            // 
            this.gamesQueListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gamesQueListBox.BackColor = System.Drawing.Color.Black;
            this.gamesQueListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamesQueListBox.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::RookiePCVR.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gamesQueListBox.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gamesQueListBox.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.gamesQueListBox.ForeColor = global::RookiePCVR.Properties.Settings.Default.FontColor;
            this.gamesQueListBox.FormattingEnabled = true;
            this.gamesQueListBox.ItemHeight = 18;
            this.gamesQueListBox.Location = new System.Drawing.Point(11, 435);
            this.gamesQueListBox.Margin = new System.Windows.Forms.Padding(2);
            this.gamesQueListBox.Name = "gamesQueListBox";
            this.gamesQueListBox.Size = new System.Drawing.Size(623, 164);
            this.gamesQueListBox.TabIndex = 9;
            this.gamesQueListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gamesQueListBox_MouseClick);
            // 
            // gamesListView
            // 
            this.gamesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gamesListView.BackColor = System.Drawing.Color.Black;
            this.gamesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GameNameIndex,
            this.ReleaseAPKPathIndex,
            this.VersionNameIndex});
            this.gamesListView.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::RookiePCVR.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gamesListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamesListView.ForeColor = global::RookiePCVR.Properties.Settings.Default.FontColor;
            this.gamesListView.HideSelection = false;
            this.gamesListView.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.gamesListView.Location = new System.Drawing.Point(12, 40);
            this.gamesListView.Name = "gamesListView";
            this.gamesListView.ShowGroups = false;
            this.gamesListView.Size = new System.Drawing.Size(760, 350);
            this.gamesListView.TabIndex = 0;
            this.gamesListView.UseCompatibleStateImageBehavior = false;
            this.gamesListView.View = System.Windows.Forms.View.Details;
            this.gamesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.gamesListView.SelectedIndexChanged += new System.EventHandler(this.gamesListView_SelectedIndexChanged);
            this.gamesListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gamesListView_MouseDoubleClick);
            // 
            // GameNameIndex
            // 
            this.GameNameIndex.Text = "Game Name";
            this.GameNameIndex.Width = 470;
            // 
            // ReleaseAPKPathIndex
            // 
            this.ReleaseAPKPathIndex.Text = "Last Updated";
            this.ReleaseAPKPathIndex.Width = 160;
            // 
            // VersionNameIndex
            // 
            this.VersionNameIndex.Text = "Size (MB)";
            this.VersionNameIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.VersionNameIndex.Width = 100;
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = global::RookiePCVR.Properties.Settings.Default.TextBoxColor;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::RookiePCVR.Properties.Settings.Default, "TextBoxColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.searchTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.searchTextBox.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::RookiePCVR.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.searchTextBox.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.searchTextBox.ForeColor = global::RookiePCVR.Properties.Settings.Default.FontColor;
            this.searchTextBox.Location = new System.Drawing.Point(12, 8);
            this.searchTextBox.MaximumSize = new System.Drawing.Size(760, 26);
            this.searchTextBox.MinimumSize = new System.Drawing.Size(760, 26);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(760, 24);
            this.searchTextBox.TabIndex = 5;
            this.searchTextBox.Text = "Search";
            this.searchTextBox.Click += new System.EventHandler(this.searchTextBox_Click);
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
            // 
            // aboutBtn
            // 
            this.aboutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.aboutBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutBtn.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::RookiePCVR.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.aboutBtn.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.aboutBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aboutBtn.FlatAppearance.BorderSize = 0;
            this.aboutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutBtn.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.aboutBtn.ForeColor = global::RookiePCVR.Properties.Settings.Default.FontColor;
            this.aboutBtn.Location = new System.Drawing.Point(0, 134);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(131, 28);
            this.aboutBtn.TabIndex = 5;
            this.aboutBtn.Text = " ?   ABOUT";
            this.aboutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aboutBtn_Tooltip.SetToolTip(this.aboutBtn, "About the Rookie App and it\'s amazing creators and contributors");
            this.aboutBtn.UseVisualStyleBackColor = false;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButton.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.settingsButton.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::RookiePCVR.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.settingsButton.ForeColor = global::RookiePCVR.Properties.Settings.Default.FontColor;
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(0, 106);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(131, 28);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "⚙ SETTINGS";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton_Tooltip.SetToolTip(this.settingsButton, "Rookie App Settings");
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.downloadInstallGameButton);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.etaLabel);
            this.panel2.Controls.Add(this.speedLabel);
            this.panel2.Location = new System.Drawing.Point(12, 396);
            this.panel2.MinimumSize = new System.Drawing.Size(600, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 34);
            this.panel2.TabIndex = 96;
            // 
            // remotesList
            // 
            this.remotesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.remotesList.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::RookiePCVR.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.remotesList.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.remotesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.remotesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remotesList.Font = global::RookiePCVR.Properties.Settings.Default.FontStyle;
            this.remotesList.ForeColor = global::RookiePCVR.Properties.Settings.Default.FontColor;
            this.remotesList.FormattingEnabled = true;
            this.remotesList.Location = new System.Drawing.Point(0, 18);
            this.remotesList.Margin = new System.Windows.Forms.Padding(2);
            this.remotesList.Name = "remotesList";
            this.remotesList.Size = new System.Drawing.Size(131, 26);
            this.remotesList.TabIndex = 3;
            this.remotesList.SelectedIndexChanged += new System.EventHandler(this.remotesList_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.settingsButton);
            this.panel1.Controls.Add(this.aboutBtn);
            this.panel1.Controls.Add(this.remotesList);
            this.panel1.Controls.Add(this.lblMirror);
            this.panel1.Location = new System.Drawing.Point(639, 435);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 164);
            this.panel1.TabIndex = 97;
            // 
            // lblMirror
            // 
            this.lblMirror.BackColor = System.Drawing.Color.Transparent;
            this.lblMirror.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMirror.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblMirror.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMirror.Location = new System.Drawing.Point(0, 0);
            this.lblMirror.Name = "lblMirror";
            this.lblMirror.Size = new System.Drawing.Size(131, 18);
            this.lblMirror.TabIndex = 90;
            this.lblMirror.Text = "Mirror #";
            this.lblMirror.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // downloadInstallGameButton
            // 
            this.downloadInstallGameButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.downloadInstallGameButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.downloadInstallGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadInstallGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.downloadInstallGameButton.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::RookiePCVR.Properties.Settings.Default, "SubButtonColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.downloadInstallGameButton.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::RookiePCVR.Properties.Settings.Default, "FontColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.downloadInstallGameButton.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::RookiePCVR.Properties.Settings.Default, "FontStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.downloadInstallGameButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.downloadInstallGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.downloadInstallGameButton.ForeColor = global::RookiePCVR.Properties.Settings.Default.FontColor;
            this.downloadInstallGameButton.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.downloadInstallGameButton.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.downloadInstallGameButton.Location = new System.Drawing.Point(393, 0);
            this.downloadInstallGameButton.Margin = new System.Windows.Forms.Padding(0);
            this.downloadInstallGameButton.Name = "downloadInstallGameButton";
            this.downloadInstallGameButton.Radius = 5;
            this.downloadInstallGameButton.Size = new System.Drawing.Size(367, 34);
            this.downloadInstallGameButton.Stroke = true;
            this.downloadInstallGameButton.StrokeColor = System.Drawing.Color.White;
            this.downloadInstallGameButton.TabIndex = 94;
            this.downloadInstallGameButton.Text = "Download Game/Add To Queue ⮩ ";
            this.downloadInstallGameButton.Transparency = false;
            this.downloadInstallGameButton.Click += new System.EventHandler(this.downloadInstallGameButton_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::RookiePCVR.Properties.Settings.Default.BackColor;
            this.ClientSize = new System.Drawing.Size(784, 610);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.freeDisclaimer);
            this.Controls.Add(this.gamesQueListBox);
            this.Controls.Add(this.downloadingLabel);
            this.Controls.Add(this.gamesListView);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::RookiePCVR.Properties.Settings.Default, "BackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 649);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rookie\'s Sideloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label etaLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label freeDisclaimer;
        private System.Windows.Forms.ListBox gamesQueListBox;
        private System.Windows.Forms.ListView gamesListView;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label downloadingLabel;
        private System.Windows.Forms.ColumnHeader ReleaseAPKPathIndex;
        public System.Windows.Forms.ColumnHeader VersionNameIndex;
        private RoundButton downloadInstallGameButton;
        private ToolTip startsideloadbutton_Tooltip;
        private ToolTip devicesbutton_Tooltip;
        private ToolTip obbcopybutton_Tooltip;
        private ToolTip backupbutton_Tooltip;
        private ToolTip restorebutton_Tooltip;
        private ToolTip getApkButton_Tooltip;
        private ToolTip uninstallAppButton_Tooltip;
        private ToolTip pullAppToDesktopBtn_Tooltip;
        private ToolTip copyBulkObbButton_Tooltip;
        private ToolTip aboutBtn_Tooltip;
        private ToolTip settingsButton_Tooltip;
        private ToolTip InstallQUset_Tooltip;
        private ToolTip removeQUSetting_Tooltip;
        private ToolTip QuestOptionsButton_Tooltip;
        private ToolTip ADBWirelessDisable_Tooltip;
        private ToolTip ADBWirelessEnable_Tooltip;
        private ToolTip UpdateGamesButton_Tooltip;
        private ToolTip listApkButton_Tooltip;
        private ToolTip speedLabel_Tooltip;
        private ToolTip etaLabel_Tooltip;
        private ToolTip EnterInstallBox_Tooltip;
        private Panel panel2;
        public ColumnHeader GameNameIndex;
        private Button aboutBtn;
        private Button settingsButton;
        public ComboBox remotesList;
        private Panel panel1;
        private Label lblMirror;
        private FontDialog fontDialog1;
    }
}
