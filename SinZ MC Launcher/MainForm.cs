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
using Newtonsoft.Json.Linq;
using SinZ_MC_Launcher.Download;
using SinZ_MC_Launcher.Login;
using SinZ_MC_Launcher.Query;
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

        Dictionary<String, object> db;


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

        private void loginButton_Click(object sender, EventArgs e) {
            Console.WriteLine("Attempting Login!");
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
            loginStatus.Text = "Login Status: Logged in as " + username;
            loginButton.Enabled = false;
            //SETTINGS
            FileStream stream = new FileStream(location + "settings", FileMode.OpenOrCreate);
            stream.WriteByte(rememberBox.Checked ? (byte)1 : (byte)0);
            if (rememberBox.Checked) {
                lastLogin.SetLastLogin(userText.Text, passText.Text);
            }
            stream.Close();
            //END SETTINGS

            Repo.Query repo = new Repo.Query();
            db = repo.parseRepo();
            Console.WriteLine("Finished reading repository");
            foreach (String modName in db.Keys) {
                //modName == Minecraft Forge, Not Enough Items, Modular Power Suits
                modBox.Items.Add(modName);
            }
            modBox.SelectedIndex = 0;
        }

        private void modBox_SelectedIndexChanged(object sender, EventArgs e) {
            versionBox.Items.Clear();
            JArray mod = (JArray) db[modBox.SelectedItem.ToString()];
            for (int i = 0; i < mod.Count; i++) {
                JToken version = mod[i];
                versionBox.Items.Add(version["version"]);
            }
            versionBox.SelectedIndex = 0;
        }

        private void queryButton_Click(object sender, EventArgs e) {
            QueryServer query = new QueryServer(queryHostText.Text, int.Parse(queryPortText.Text));
            String playerList = "";
            foreach (String msg in query.players) {
                playerList += "|"+msg;
            }
            String data = "";
            foreach (String msg in query.output.Values) {
                data += "|" + msg;
            }
            if (query.plugins.Keys.Count > 0) {
                MessageBox.Show(query.plugins["SERVER_MOD"]);
                query.plugins.Remove("SERVER_MOD");
                String pluginList = "";
                foreach (String key in query.plugins.Keys) {
                    pluginList += key + "_" + query.plugins[key] + " | ";
                }
                MessageBox.Show(pluginList);
            }
            MessageBox.Show(data);
            MessageBox.Show(playerList);
        }
    }
}
