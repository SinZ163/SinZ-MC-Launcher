using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinZ_MC_Launcher {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }
        String username;
        String sessionID;
        private void launchButton_Click(object sender, EventArgs e) {
            Login login = new Login(userText.Text, passText.Text);
            this.username = login.username;
            this.sessionID = login.sessionID;
            if (login.error == "Success") {
                LoginSuccessful();
            } else {
                switch (login.error) {
                    case "Bad login":
                        MessageBox.Show("Invalid username and/or password.");
                        break;
                    default:
                        MessageBox.Show("Login failed: "+login.error);
                        break;
                }
            }
        }
        public void LoginSuccessful() {
            MessageBox.Show("Huzzah!");
            QueryRepo repo = new QueryRepo();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");
            if (!Directory.Exists(location))
                Directory.CreateDirectory(location);
        }

    }
}
