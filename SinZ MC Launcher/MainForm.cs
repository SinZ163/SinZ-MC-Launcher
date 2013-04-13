using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SinZ_MC_Launcher.Login;
using SinZ_MC_Launcher.Repo;

namespace SinZ_MC_Launcher {
    public partial class MainForm : Form {
        public MainForm() {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource)) {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
        }
        String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");

        String username;
        String sessionID;
        LastLogin lastLogin;


        private void launchButton_Click(object sender, EventArgs e) {
            Login.Login login = new Login.Login(userText.Text, passText.Text);
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
            Console.WriteLine("Login successful: " + sessionID);

            //SETTINGS
            FileStream stream = new FileStream(location + "settings", FileMode.OpenOrCreate);
            stream.WriteByte(rememberBox.Checked ? (byte)1 : (byte)0);
            if (rememberBox.Checked) {
                lastLogin.SetLastLogin(userText.Text, passText.Text);
            }
            stream.Close();
            //END SETTINGS

            Query repo = new Query();
            Dictionary<String, object> db = repo.parseRepo();

            //MessageBox.Show("Parse success");//debug

            Dictionary<String, object> v1_5_1 = (Dictionary<String,object>)db["1_5_1"];
            Dictionary<String, object> v1_5_1_jarMods = (Dictionary<String,object>)v1_5_1["jarMods"];
            Dictionary<String, object> minecraftForge = (Dictionary<String,object>)v1_5_1_jarMods["Minecraft Forge"];
            MessageBox.Show(minecraftForge["version"].ToString());
        }

        private void MainForm_Load(object sender, EventArgs e) {
            lastLogin = new LastLogin();

            if (!Directory.Exists(location))
                Directory.CreateDirectory(location);

            //SETTINGS
            if (File.Exists(Path.Combine(location, "lastlogin"))) {
                String[] lastLoginData = lastLogin.GetLastLogin();
                userText.Text = lastLoginData[0];
                passText.Text = lastLoginData[1];
            }

            try {
                FileStream stream = new FileStream(location + "settings", FileMode.Open);
                rememberBox.Checked = Convert.ToBoolean(stream.ReadByte());
            }
            catch (Exception) { }
            //END SETTINGS
        }

    }
}
