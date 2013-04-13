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
            this.launchButton = new System.Windows.Forms.Button();
            this.passText = new System.Windows.Forms.TextBox();
            this.userText = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(499, 361);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(97, 44);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "Launch!";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // passText
            // 
            this.passText.Location = new System.Drawing.Point(393, 384);
            this.passText.Name = "passText";
            this.passText.Size = new System.Drawing.Size(100, 20);
            this.passText.TabIndex = 1;
            this.passText.UseSystemPasswordChar = true;
            // 
            // userText
            // 
            this.userText.Location = new System.Drawing.Point(393, 361);
            this.userText.Name = "userText";
            this.userText.Size = new System.Drawing.Size(100, 20);
            this.userText.TabIndex = 2;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(329, 364);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(58, 13);
            this.userLabel.TabIndex = 3;
            this.userLabel.Text = "Username:";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(331, 387);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(56, 13);
            this.passLabel.TabIndex = 4;
            this.passLabel.Text = "Password:";
            this.passLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 417);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userText);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.launchButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.TextBox userText;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label passLabel;
    }
}

