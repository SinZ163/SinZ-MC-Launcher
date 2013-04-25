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
            this.modList = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.queryList = new System.Windows.Forms.TabPage();
            this.playerList = new System.Windows.Forms.ListView();
            this.pluginsLabel = new System.Windows.Forms.Label();
            this.serverModLabel = new System.Windows.Forms.Label();
            this.consoleList = new System.Windows.Forms.TabPage();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.serverStatusList = new System.Windows.Forms.TabPage();
            this.initStatusBox = new System.Windows.Forms.Button();
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.serverStatusLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.modList.SuspendLayout();
            this.queryList.SuspendLayout();
            this.consoleList.SuspendLayout();
            this.serverStatusList.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.rememberBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rememberBox.AutoSize = true;
            this.rememberBox.Checked = true;
            this.rememberBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rememberBox.Location = new System.Drawing.Point(13, 533);
            this.rememberBox.Name = "rememberBox";
            this.rememberBox.Size = new System.Drawing.Size(98, 17);
            this.rememberBox.TabIndex = 5;
            this.rememberBox.Text = "Remember Me!";
            this.rememberBox.UseVisualStyleBackColor = true;
            // 
            // loginStatus
            // 
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
            this.tabControl1.Controls.Add(this.modList);
            this.tabControl1.Controls.Add(this.queryList);
            this.tabControl1.Controls.Add(this.consoleList);
            this.tabControl1.Controls.Add(this.serverStatusList);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 470);
            this.tabControl1.TabIndex = 27;
            // 
            // modList
            // 
            this.modList.Controls.Add(this.label2);
            this.modList.Controls.Add(this.button2);
            this.modList.Controls.Add(this.button1);
            this.modList.Controls.Add(this.comboBox1);
            this.modList.Controls.Add(this.listView1);
            this.modList.Controls.Add(this.mcVersionBox);
            this.modList.Controls.Add(this.versionBox);
            this.modList.Controls.Add(this.modBox);
            this.modList.Location = new System.Drawing.Point(4, 22);
            this.modList.Name = "modList";
            this.modList.Padding = new System.Windows.Forms.Padding(3);
            this.modList.Size = new System.Drawing.Size(752, 444);
            this.modList.TabIndex = 0;
            this.modList.Text = "Mod List";
            this.modList.UseVisualStyleBackColor = true;
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
            // queryList
            // 
            this.queryList.Controls.Add(this.playerList);
            this.queryList.Controls.Add(this.pluginsLabel);
            this.queryList.Controls.Add(this.serverModLabel);
            this.queryList.Controls.Add(this.queryHostText);
            this.queryList.Controls.Add(this.queryButton);
            this.queryList.Controls.Add(this.queryPortText);
            this.queryList.Location = new System.Drawing.Point(4, 22);
            this.queryList.Name = "queryList";
            this.queryList.Padding = new System.Windows.Forms.Padding(3);
            this.queryList.Size = new System.Drawing.Size(752, 444);
            this.queryList.TabIndex = 1;
            this.queryList.Text = "Query Server";
            this.queryList.UseVisualStyleBackColor = true;
            // 
            // playerList
            // 
            this.playerList.Location = new System.Drawing.Point(492, 6);
            this.playerList.MultiSelect = false;
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(254, 432);
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
            // consoleList
            // 
            this.consoleList.Controls.Add(this.consoleBox);
            this.consoleList.Location = new System.Drawing.Point(4, 22);
            this.consoleList.Name = "consoleList";
            this.consoleList.Padding = new System.Windows.Forms.Padding(3);
            this.consoleList.Size = new System.Drawing.Size(752, 444);
            this.consoleList.TabIndex = 2;
            this.consoleList.Text = "Launcher Console";
            this.consoleList.UseVisualStyleBackColor = true;
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
            this.consoleBox.Size = new System.Drawing.Size(740, 432);
            this.consoleBox.TabIndex = 0;
            // 
            // serverStatusList
            // 
            this.serverStatusList.Controls.Add(this.serverStatusLabel);
            this.serverStatusList.Controls.Add(this.serverNameLabel);
            this.serverStatusList.Controls.Add(this.initStatusBox);
            this.serverStatusList.Location = new System.Drawing.Point(4, 22);
            this.serverStatusList.Name = "serverStatusList";
            this.serverStatusList.Padding = new System.Windows.Forms.Padding(3);
            this.serverStatusList.Size = new System.Drawing.Size(752, 444);
            this.serverStatusList.TabIndex = 3;
            this.serverStatusList.Text = "Server Status";
            this.serverStatusList.UseVisualStyleBackColor = true;
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
            // serverNameLabel
            // 
            this.serverNameLabel.AutoSize = true;
            this.serverNameLabel.Location = new System.Drawing.Point(7, 47);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(0, 13);
            this.serverNameLabel.TabIndex = 2;
            // 
            // serverStatusLabel
            // 
            this.serverStatusLabel.AutoSize = true;
            this.serverStatusLabel.Location = new System.Drawing.Point(145, 47);
            this.serverStatusLabel.Name = "serverStatusLabel";
            this.serverStatusLabel.Size = new System.Drawing.Size(0, 13);
            this.serverStatusLabel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.loginStatus);
            this.Controls.Add(this.rememberBox);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userText);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.loginButton);
            this.Name = "MainForm";
            this.Text = "SinZ MC Launcher - v0.0.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.modList.ResumeLayout(false);
            this.modList.PerformLayout();
            this.queryList.ResumeLayout(false);
            this.queryList.PerformLayout();
            this.consoleList.ResumeLayout(false);
            this.consoleList.PerformLayout();
            this.serverStatusList.ResumeLayout(false);
            this.serverStatusList.PerformLayout();
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
        private System.Windows.Forms.TabPage modList;
        private System.Windows.Forms.TabPage queryList;
        private System.Windows.Forms.TabPage consoleList;
        private System.Windows.Forms.TextBox consoleBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label serverModLabel;
        private System.Windows.Forms.Label pluginsLabel;
        private System.Windows.Forms.ListView playerList;
        private System.Windows.Forms.TabPage serverStatusList;
        private System.Windows.Forms.Button initStatusBox;
        private System.Windows.Forms.Label serverNameLabel;
        private System.Windows.Forms.Label serverStatusLabel;
    }
}

