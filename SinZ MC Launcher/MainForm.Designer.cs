using System.Windows.Forms;
namespace SinZ_MC_Launcher {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                _writer.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.loginButton = new System.Windows.Forms.Button();
            this.passText = new System.Windows.Forms.TextBox();
            this.userText = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.rememberBox = new System.Windows.Forms.CheckBox();
            this.loginStatus = new System.Windows.Forms.Label();
            this.queryHostText = new System.Windows.Forms.TextBox();
            this.queryPortText = new System.Windows.Forms.TextBox();
            this.queryButton = new System.Windows.Forms.Button();
            this.modBox = new System.Windows.Forms.ComboBox();
            this.mcVersionBox = new System.Windows.Forms.ComboBox();
            this.versionBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.nemTab = new System.Windows.Forms.TabPage();
            this.nemVersionBox = new System.Windows.Forms.ComboBox();
            this.nemCountLabel = new System.Windows.Forms.Label();
            this.nemModList = new System.Windows.Forms.ListView();
            this.nemRefreshButton = new System.Windows.Forms.Button();
            this.modpackTab = new System.Windows.Forms.TabPage();
            this.modpackModList = new System.Windows.Forms.ListView();
            this.modpackVersionBox = new System.Windows.Forms.ComboBox();
            this.modpackRefreshButton = new System.Windows.Forms.Button();
            this.oldRepoTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.queryTab = new System.Windows.Forms.TabPage();
            this.playerList = new System.Windows.Forms.ListView();
            this.pluginsLabel = new System.Windows.Forms.Label();
            this.serverModLabel = new System.Windows.Forms.Label();
            this.serverStatusTab = new System.Windows.Forms.TabPage();
            this.serverStatusLabel = new System.Windows.Forms.Label();
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.initStatusBox = new System.Windows.Forms.Button();
            this.browserTab = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.consoleTab = new System.Windows.Forms.TabPage();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.optionTab = new System.Windows.Forms.TabPage();
            this.minecraftVersionBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.nemTab.SuspendLayout();
            this.modpackTab.SuspendLayout();
            this.oldRepoTab.SuspendLayout();
            this.queryTab.SuspendLayout();
            this.serverStatusTab.SuspendLayout();
            this.browserTab.SuspendLayout();
            this.consoleTab.SuspendLayout();
            this.optionTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.Enabled = false;
            this.loginButton.Location = new System.Drawing.Point(675, 506);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(97, 44);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login!";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passText
            // 
            this.passText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.passText.Location = new System.Drawing.Point(569, 530);
            this.passText.Name = "passText";
            this.passText.Size = new System.Drawing.Size(100, 20);
            this.passText.TabIndex = 1;
            this.passText.UseSystemPasswordChar = true;
            // 
            // userText
            // 
            this.userText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.userText.Location = new System.Drawing.Point(569, 504);
            this.userText.Name = "userText";
            this.userText.Size = new System.Drawing.Size(100, 20);
            this.userText.TabIndex = 0;
            // 
            // userLabel
            // 
            this.userLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(505, 511);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(58, 13);
            this.userLabel.TabIndex = 3;
            this.userLabel.Text = "Username:";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // passLabel
            // 
            this.passLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(507, 533);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(56, 13);
            this.passLabel.TabIndex = 4;
            this.passLabel.Text = "Password:";
            this.passLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rememberBox
            // 
            this.rememberBox.AutoSize = true;
            this.rememberBox.Checked = true;
            this.rememberBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rememberBox.Location = new System.Drawing.Point(6, 3);
            this.rememberBox.Name = "rememberBox";
            this.rememberBox.Size = new System.Drawing.Size(98, 17);
            this.rememberBox.TabIndex = 5;
            this.rememberBox.Text = "Remember Me!";
            this.rememberBox.UseVisualStyleBackColor = true;
            // 
            // loginStatus
            // 
            this.loginStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loginStatus.AutoSize = true;
            this.loginStatus.Location = new System.Drawing.Point(569, 485);
            this.loginStatus.Name = "loginStatus";
            this.loginStatus.Size = new System.Drawing.Size(135, 13);
            this.loginStatus.TabIndex = 18;
            this.loginStatus.Text = "Login Status: Not logged in";
            // 
            // queryHostText
            // 
            this.queryHostText.Location = new System.Drawing.Point(6, 6);
            this.queryHostText.Name = "queryHostText";
            this.queryHostText.Size = new System.Drawing.Size(159, 20);
            this.queryHostText.TabIndex = 19;
            // 
            // queryPortText
            // 
            this.queryPortText.Location = new System.Drawing.Point(171, 6);
            this.queryPortText.MaxLength = 5;
            this.queryPortText.Name = "queryPortText";
            this.queryPortText.Size = new System.Drawing.Size(41, 20);
            this.queryPortText.TabIndex = 20;
            this.queryPortText.Text = "25565";
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(120, 32);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(75, 23);
            this.queryButton.TabIndex = 22;
            this.queryButton.Text = "Query!";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // modBox
            // 
            this.modBox.FormattingEnabled = true;
            this.modBox.Location = new System.Drawing.Point(133, 7);
            this.modBox.Name = "modBox";
            this.modBox.Size = new System.Drawing.Size(121, 21);
            this.modBox.Sorted = true;
            this.modBox.TabIndex = 23;
            this.modBox.Text = "Mods";
            this.modBox.SelectedIndexChanged += new System.EventHandler(this.modBox_SelectedIndexChanged);
            // 
            // mcVersionBox
            // 
            this.mcVersionBox.FormattingEnabled = true;
            this.mcVersionBox.Location = new System.Drawing.Point(7, 7);
            this.mcVersionBox.Name = "mcVersionBox";
            this.mcVersionBox.Size = new System.Drawing.Size(121, 21);
            this.mcVersionBox.TabIndex = 24;
            this.mcVersionBox.Text = "MCVersion";
            this.mcVersionBox.Visible = false;
            // 
            // versionBox
            // 
            this.versionBox.FormattingEnabled = true;
            this.versionBox.Location = new System.Drawing.Point(260, 7);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(121, 21);
            this.versionBox.Sorted = true;
            this.versionBox.TabIndex = 25;
            this.versionBox.Text = "Versions";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.nemTab);
            this.tabControl1.Controls.Add(this.modpackTab);
            this.tabControl1.Controls.Add(this.oldRepoTab);
            this.tabControl1.Controls.Add(this.queryTab);
            this.tabControl1.Controls.Add(this.serverStatusTab);
            this.tabControl1.Controls.Add(this.browserTab);
            this.tabControl1.Controls.Add(this.consoleTab);
            this.tabControl1.Controls.Add(this.optionTab);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(781, 470);
            this.tabControl1.TabIndex = 27;
            // 
            // nemTab
            // 
            this.nemTab.Controls.Add(this.nemVersionBox);
            this.nemTab.Controls.Add(this.nemCountLabel);
            this.nemTab.Controls.Add(this.nemModList);
            this.nemTab.Controls.Add(this.nemRefreshButton);
            this.nemTab.Location = new System.Drawing.Point(4, 22);
            this.nemTab.Name = "nemTab";
            this.nemTab.Padding = new System.Windows.Forms.Padding(3);
            this.nemTab.Size = new System.Drawing.Size(773, 444);
            this.nemTab.TabIndex = 4;
            this.nemTab.Text = "Not Enough Mods";
            this.nemTab.UseVisualStyleBackColor = true;
            // 
            // nemVersionBox
            // 
            this.nemVersionBox.FormattingEnabled = true;
            this.nemVersionBox.Items.AddRange(new object[] {
            "1.4.6-1.4.7",
            "1.5.1",
            "1.5.2"});
            this.nemVersionBox.Location = new System.Drawing.Point(88, 9);
            this.nemVersionBox.Name = "nemVersionBox";
            this.nemVersionBox.Size = new System.Drawing.Size(121, 21);
            this.nemVersionBox.TabIndex = 3;
            this.nemVersionBox.SelectedIndexChanged += new System.EventHandler(this.nemVersionBox_SelectedIndexChanged);
            // 
            // nemCountLabel
            // 
            this.nemCountLabel.AutoSize = true;
            this.nemCountLabel.Location = new System.Drawing.Point(88, 12);
            this.nemCountLabel.Name = "nemCountLabel";
            this.nemCountLabel.Size = new System.Drawing.Size(0, 13);
            this.nemCountLabel.TabIndex = 2;
            // 
            // nemModList
            // 
            this.nemModList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nemModList.Location = new System.Drawing.Point(7, 37);
            this.nemModList.MultiSelect = false;
            this.nemModList.Name = "nemModList";
            this.nemModList.Size = new System.Drawing.Size(739, 401);
            this.nemModList.TabIndex = 1;
            this.nemModList.UseCompatibleStateImageBehavior = false;
            this.nemModList.View = System.Windows.Forms.View.List;
            this.nemModList.SelectedIndexChanged += new System.EventHandler(this.nemModList_SelectedIndexChanged);
            // 
            // nemRefreshButton
            // 
            this.nemRefreshButton.Location = new System.Drawing.Point(7, 7);
            this.nemRefreshButton.Name = "nemRefreshButton";
            this.nemRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.nemRefreshButton.TabIndex = 0;
            this.nemRefreshButton.Text = "Refresh!";
            this.nemRefreshButton.UseVisualStyleBackColor = true;
            this.nemRefreshButton.Click += new System.EventHandler(this.nemRefreshButton_Click);
            // 
            // modpackTab
            // 
            this.modpackTab.Controls.Add(this.modpackModList);
            this.modpackTab.Controls.Add(this.modpackVersionBox);
            this.modpackTab.Controls.Add(this.modpackRefreshButton);
            this.modpackTab.Location = new System.Drawing.Point(4, 22);
            this.modpackTab.Name = "modpackTab";
            this.modpackTab.Padding = new System.Windows.Forms.Padding(3);
            this.modpackTab.Size = new System.Drawing.Size(773, 444);
            this.modpackTab.TabIndex = 6;
            this.modpackTab.Text = "Modpacks";
            this.modpackTab.UseVisualStyleBackColor = true;
            // 
            // modpackModList
            // 
            this.modpackModList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.modpackModList.Location = new System.Drawing.Point(7, 65);
            this.modpackModList.Name = "modpackModList";
            this.modpackModList.Size = new System.Drawing.Size(216, 411);
            this.modpackModList.TabIndex = 2;
            this.modpackModList.UseCompatibleStateImageBehavior = false;
            this.modpackModList.View = System.Windows.Forms.View.List;
            // 
            // modpackVersionBox
            // 
            this.modpackVersionBox.FormattingEnabled = true;
            this.modpackVersionBox.Location = new System.Drawing.Point(7, 37);
            this.modpackVersionBox.Name = "modpackVersionBox";
            this.modpackVersionBox.Size = new System.Drawing.Size(121, 21);
            this.modpackVersionBox.TabIndex = 1;
            this.modpackVersionBox.Text = "Modlist version";
            this.modpackVersionBox.SelectedIndexChanged += new System.EventHandler(this.modpackVersionBox_SelectedIndexChanged);
            // 
            // modpackRefreshButton
            // 
            this.modpackRefreshButton.Location = new System.Drawing.Point(7, 7);
            this.modpackRefreshButton.Name = "modpackRefreshButton";
            this.modpackRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.modpackRefreshButton.TabIndex = 0;
            this.modpackRefreshButton.Text = "Refresh!";
            this.modpackRefreshButton.UseVisualStyleBackColor = true;
            this.modpackRefreshButton.Click += new System.EventHandler(this.modpackRefreshButton_Click);
            // 
            // oldRepoTab
            // 
            this.oldRepoTab.Controls.Add(this.label2);
            this.oldRepoTab.Controls.Add(this.button2);
            this.oldRepoTab.Controls.Add(this.button1);
            this.oldRepoTab.Controls.Add(this.comboBox1);
            this.oldRepoTab.Controls.Add(this.listView1);
            this.oldRepoTab.Controls.Add(this.mcVersionBox);
            this.oldRepoTab.Controls.Add(this.versionBox);
            this.oldRepoTab.Controls.Add(this.modBox);
            this.oldRepoTab.Location = new System.Drawing.Point(4, 22);
            this.oldRepoTab.Name = "oldRepoTab";
            this.oldRepoTab.Padding = new System.Windows.Forms.Padding(3);
            this.oldRepoTab.Size = new System.Drawing.Size(773, 444);
            this.oldRepoTab.TabIndex = 0;
            this.oldRepoTab.Text = "Mod List";
            this.oldRepoTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "No work done on this at all";
            this.label2.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(387, 412);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Save Modlist";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Add to Modlist";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(387, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.Text = "(new)";
            this.comboBox1.Visible = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(7, 34);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(374, 404);
            this.listView1.TabIndex = 26;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            // 
            // queryTab
            // 
            this.queryTab.Controls.Add(this.playerList);
            this.queryTab.Controls.Add(this.pluginsLabel);
            this.queryTab.Controls.Add(this.serverModLabel);
            this.queryTab.Controls.Add(this.queryHostText);
            this.queryTab.Controls.Add(this.queryButton);
            this.queryTab.Controls.Add(this.queryPortText);
            this.queryTab.Location = new System.Drawing.Point(4, 22);
            this.queryTab.Name = "queryTab";
            this.queryTab.Padding = new System.Windows.Forms.Padding(3);
            this.queryTab.Size = new System.Drawing.Size(773, 444);
            this.queryTab.TabIndex = 1;
            this.queryTab.Text = "Query Server";
            this.queryTab.UseVisualStyleBackColor = true;
            // 
            // playerList
            // 
            this.playerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerList.Location = new System.Drawing.Point(492, 6);
            this.playerList.MultiSelect = false;
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(254, 470);
            this.playerList.TabIndex = 25;
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.List;
            // 
            // pluginsLabel
            // 
            this.pluginsLabel.AutoSize = true;
            this.pluginsLabel.Location = new System.Drawing.Point(6, 96);
            this.pluginsLabel.Name = "pluginsLabel";
            this.pluginsLabel.Size = new System.Drawing.Size(0, 13);
            this.pluginsLabel.TabIndex = 24;
            // 
            // serverModLabel
            // 
            this.serverModLabel.AutoSize = true;
            this.serverModLabel.Location = new System.Drawing.Point(6, 69);
            this.serverModLabel.Name = "serverModLabel";
            this.serverModLabel.Size = new System.Drawing.Size(0, 13);
            this.serverModLabel.TabIndex = 23;
            // 
            // serverStatusTab
            // 
            this.serverStatusTab.Controls.Add(this.serverStatusLabel);
            this.serverStatusTab.Controls.Add(this.serverNameLabel);
            this.serverStatusTab.Controls.Add(this.initStatusBox);
            this.serverStatusTab.Location = new System.Drawing.Point(4, 22);
            this.serverStatusTab.Name = "serverStatusTab";
            this.serverStatusTab.Padding = new System.Windows.Forms.Padding(3);
            this.serverStatusTab.Size = new System.Drawing.Size(773, 444);
            this.serverStatusTab.TabIndex = 3;
            this.serverStatusTab.Text = "Server Status";
            this.serverStatusTab.UseVisualStyleBackColor = true;
            // 
            // serverStatusLabel
            // 
            this.serverStatusLabel.AutoSize = true;
            this.serverStatusLabel.Location = new System.Drawing.Point(145, 47);
            this.serverStatusLabel.Name = "serverStatusLabel";
            this.serverStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.serverStatusLabel.TabIndex = 3;
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.AutoSize = true;
            this.serverNameLabel.Location = new System.Drawing.Point(7, 47);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(0, 13);
            this.serverNameLabel.TabIndex = 2;
            // 
            // initStatusBox
            // 
            this.initStatusBox.Location = new System.Drawing.Point(7, 4);
            this.initStatusBox.Name = "initStatusBox";
            this.initStatusBox.Size = new System.Drawing.Size(97, 36);
            this.initStatusBox.TabIndex = 1;
            this.initStatusBox.Text = "Refresh Status";
            this.initStatusBox.UseVisualStyleBackColor = true;
            this.initStatusBox.Click += new System.EventHandler(this.initStatusBox_Click);
            // 
            // browserTab
            // 
            this.browserTab.Controls.Add(this.webBrowser);
            this.browserTab.Location = new System.Drawing.Point(4, 22);
            this.browserTab.Name = "browserTab";
            this.browserTab.Padding = new System.Windows.Forms.Padding(3);
            this.browserTab.Size = new System.Drawing.Size(773, 444);
            this.browserTab.TabIndex = 5;
            this.browserTab.Text = "Web Browser";
            this.browserTab.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(767, 438);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("http://mcupdate.tumblr.com", System.UriKind.Absolute);
            // 
            // consoleTab
            // 
            this.consoleTab.Controls.Add(this.consoleBox);
            this.consoleTab.Location = new System.Drawing.Point(4, 22);
            this.consoleTab.Name = "consoleTab";
            this.consoleTab.Padding = new System.Windows.Forms.Padding(3);
            this.consoleTab.Size = new System.Drawing.Size(773, 444);
            this.consoleTab.TabIndex = 2;
            this.consoleTab.Text = "Launcher Console";
            this.consoleTab.UseVisualStyleBackColor = true;
            // 
            // consoleBox
            // 
            this.consoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleBox.Location = new System.Drawing.Point(6, 6);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(761, 470);
            this.consoleBox.TabIndex = 0;
            // 
            // optionTab
            // 
            this.optionTab.Controls.Add(this.rememberBox);
            this.optionTab.Location = new System.Drawing.Point(4, 22);
            this.optionTab.Name = "optionTab";
            this.optionTab.Size = new System.Drawing.Size(773, 444);
            this.optionTab.TabIndex = 7;
            this.optionTab.Text = "Options";
            this.optionTab.UseVisualStyleBackColor = true;
            // 
            // minecraftVersionBox
            // 
            this.minecraftVersionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.minecraftVersionBox.FormattingEnabled = true;
            this.minecraftVersionBox.Location = new System.Drawing.Point(13, 485);
            this.minecraftVersionBox.Name = "minecraftVersionBox";
            this.minecraftVersionBox.Size = new System.Drawing.Size(121, 21);
            this.minecraftVersionBox.TabIndex = 28;
            this.minecraftVersionBox.Text = "Versions";
            // 
            // MainForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.minecraftVersionBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.loginStatus);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userText);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.loginButton);
            this.Name = "MainForm";
            this.Text = "SinZ MC Launcher - "+Application.ProductVersion;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.nemTab.ResumeLayout(false);
            this.nemTab.PerformLayout();
            this.modpackTab.ResumeLayout(false);
            this.oldRepoTab.ResumeLayout(false);
            this.oldRepoTab.PerformLayout();
            this.queryTab.ResumeLayout(false);
            this.queryTab.PerformLayout();
            this.serverStatusTab.ResumeLayout(false);
            this.serverStatusTab.PerformLayout();
            this.browserTab.ResumeLayout(false);
            this.consoleTab.ResumeLayout(false);
            this.consoleTab.PerformLayout();
            this.optionTab.ResumeLayout(false);
            this.optionTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.TextBox userText;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.CheckBox rememberBox;
        private System.Windows.Forms.Label loginStatus;
        private System.Windows.Forms.TextBox queryHostText;
        private System.Windows.Forms.TextBox queryPortText;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.ComboBox modBox;
        private System.Windows.Forms.ComboBox mcVersionBox;
        private System.Windows.Forms.ComboBox versionBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage oldRepoTab;
        private System.Windows.Forms.TabPage queryTab;
        private System.Windows.Forms.TabPage consoleTab;
        private System.Windows.Forms.TextBox consoleBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label serverModLabel;
        private System.Windows.Forms.Label pluginsLabel;
        private System.Windows.Forms.ListView playerList;
        private System.Windows.Forms.TabPage serverStatusTab;
        private System.Windows.Forms.Button initStatusBox;
        private System.Windows.Forms.Label serverNameLabel;
        private System.Windows.Forms.Label serverStatusLabel;
        private System.Windows.Forms.TabPage nemTab;
        private System.Windows.Forms.Button nemRefreshButton;
        private System.Windows.Forms.ListView nemModList;
        private System.Windows.Forms.TabPage browserTab;
        private System.Windows.Forms.WebBrowser webBrowser;
        private Label nemCountLabel;
        private ComboBox minecraftVersionBox;
        private TabPage modpackTab;
        private Button modpackRefreshButton;
        private ComboBox modpackVersionBox;
        private ListView modpackModList;
        private ComboBox nemVersionBox;
        private TabPage optionTab;
    }
}

