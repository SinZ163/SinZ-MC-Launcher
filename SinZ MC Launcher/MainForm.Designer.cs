﻿namespace SinZ_MC_Launcher {
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
            this.queryMCBox = new System.Windows.Forms.DomainUpDown();
            this.queryTypeBox = new System.Windows.Forms.DomainUpDown();
            this.queryModBox = new System.Windows.Forms.DomainUpDown();
            this.queryVersionBox = new System.Windows.Forms.DomainUpDown();
            this.loginStatus = new System.Windows.Forms.Label();
            this.queryHostText = new System.Windows.Forms.TextBox();
            this.queryPortText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.queryButton = new System.Windows.Forms.Button();
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
            // queryMCBox
            // 
            this.queryMCBox.Location = new System.Drawing.Point(12, 12);
            this.queryMCBox.Name = "queryMCBox";
            this.queryMCBox.Size = new System.Drawing.Size(120, 20);
            this.queryMCBox.TabIndex = 14;
            this.queryMCBox.Text = "Minecraft Versions";
            this.queryMCBox.Visible = false;
            this.queryMCBox.SelectedItemChanged += new System.EventHandler(this.queryMCBox_SelectedItemChanged);
            // 
            // queryTypeBox
            // 
            this.queryTypeBox.Location = new System.Drawing.Point(138, 12);
            this.queryTypeBox.Name = "queryTypeBox";
            this.queryTypeBox.Size = new System.Drawing.Size(120, 20);
            this.queryTypeBox.TabIndex = 15;
            this.queryTypeBox.Text = "Mod Types";
            this.queryTypeBox.Visible = false;
            this.queryTypeBox.SelectedItemChanged += new System.EventHandler(this.queryTypeBox_SelectedItemChanged);
            // 
            // queryModBox
            // 
            this.queryModBox.Location = new System.Drawing.Point(264, 12);
            this.queryModBox.Name = "queryModBox";
            this.queryModBox.Size = new System.Drawing.Size(120, 20);
            this.queryModBox.TabIndex = 16;
            this.queryModBox.Text = "Mods";
            this.queryModBox.Visible = false;
            this.queryModBox.SelectedItemChanged += new System.EventHandler(this.queryModBox_SelectedItemChanged);
            // 
            // queryVersionBox
            // 
            this.queryVersionBox.Location = new System.Drawing.Point(390, 12);
            this.queryVersionBox.Name = "queryVersionBox";
            this.queryVersionBox.Size = new System.Drawing.Size(120, 20);
            this.queryVersionBox.TabIndex = 17;
            this.queryVersionBox.Text = "Versions";
            this.queryVersionBox.Visible = false;
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
            this.queryHostText.Location = new System.Drawing.Point(566, 12);
            this.queryHostText.Name = "queryHostText";
            this.queryHostText.Size = new System.Drawing.Size(100, 20);
            this.queryHostText.TabIndex = 19;
            // 
            // queryPortText
            // 
            this.queryPortText.Location = new System.Drawing.Point(672, 12);
            this.queryPortText.Name = "queryPortText";
            this.queryPortText.Size = new System.Drawing.Size(100, 20);
            this.queryPortText.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(566, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Query hostname, port";
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(680, 38);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(75, 23);
            this.queryButton.TabIndex = 22;
            this.queryButton.Text = "Query!";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryPortText);
            this.Controls.Add(this.queryHostText);
            this.Controls.Add(this.loginStatus);
            this.Controls.Add(this.queryVersionBox);
            this.Controls.Add(this.queryModBox);
            this.Controls.Add(this.queryTypeBox);
            this.Controls.Add(this.queryMCBox);
            this.Controls.Add(this.rememberBox);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userText);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.loginButton);
            this.Name = "MainForm";
            this.Text = "SinZ MC Launcher - v0.0.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
        private System.Windows.Forms.DomainUpDown queryMCBox;
        private System.Windows.Forms.DomainUpDown queryTypeBox;
        private System.Windows.Forms.DomainUpDown queryModBox;
        private System.Windows.Forms.DomainUpDown queryVersionBox;
        private System.Windows.Forms.Label loginStatus;
        private System.Windows.Forms.TextBox queryHostText;
        private System.Windows.Forms.TextBox queryPortText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button queryButton;
    }
}

