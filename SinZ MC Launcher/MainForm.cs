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
using SinZ_MC_Launcher.Launch;
using SinZ_MC_Launcher.Login;
using SinZ_MC_Launcher.Query;
using SinZ_MC_Launcher.Repo;
using SinZ_MC_Launcher.Server;
using SinZ_MC_Launcher.UI;

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
        TextWriter _writer = null;

        String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");

        String username;
        String sessionID;
        LastLogin lastLogin;

        Dictionary<String, object> db;

        ServerStatus status;

        private Dictionary<string, Dictionary<string, string>> nemDB;


        private void MainForm_Load(object sender, EventArgs e) {
            //CONSOLE
            _writer = new ConsoleStringWriter(this);
            Console.SetOut(_writer);
            //END CONSOLE
            if (!Directory.Exists(location))
                Directory.CreateDirectory(location);

            //SETTINGS
            lastLogin = new LastLogin();

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

            //SERVER STATUS
            status = new ServerStatus(this);
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

            Repo.QueryRepo repo = new Repo.QueryRepo();
            db = repo.parseRepo();
            Console.WriteLine("Finished reading repository");
            foreach (String modName in db.Keys) {
                //modName == Minecraft Forge, Not Enough Items, Modular Power Suits
                modBox.Items.Add(modName);
            }
            modBox.SelectedIndex = 0;

            Assets downloadAssets = new Assets();
            Libraries downloadLibraries = new Libraries("13w17a");
            //LaunchMinecraft mc = new LaunchMinecraft(Path.Combine(location, "vannila_13w16a"), username, sessionID, true);
        }

        private void modBox_SelectedIndexChanged(object sender, EventArgs e) {
            Dictionary<String, object> mod = (Dictionary<String,object>)db[modBox.SelectedItem.ToString()];
            versionBox.Items.Clear();
            foreach (String key in mod.Keys) {
                versionBox.Items.Add(key);
            }
            versionBox.SelectedIndex = 0;
        }

        private void queryButton_Click(object sender, EventArgs e) {
            QueryServer query = new QueryServer(queryHostText.Text, int.Parse(queryPortText.Text));
            //String playerList = "";
            foreach (String msg in query.players) {
                //playerList += "|"+msg;
                playerList.Items.Add(msg);
            }
            String data = "";
            foreach (String msg in query.output.Values) {
                data += "|" + msg;
            }
            try {
                if (query.plugins.Keys.Count > 0) {
                    //MessageBox.Show(query.plugins["SERVER_MOD"]);
                    serverModLabel.Text = query.plugins["SERVER_MOD"];
                    query.plugins.Remove("SERVER_MOD");
                    String pluginList = "";
                    foreach (String key in query.plugins.Keys) {
                        pluginList += key + "_" + query.plugins[key] + " | ";
                    }
                    //MessageBox.Show(pluginList);
                    pluginsLabel.Text = pluginList;
                }
            }
            catch (Exception) {
            }
            //MessageBox.Show(data);
            //MessageBox.Show(playerList);
        }

        private void initStatusBox_Click(object sender, EventArgs e) {
            status.Refresh();
        }

        private delegate void UpdateServerStatus_(Dictionary<String, object> statusReport);
        public void UpdateServerStatus(Dictionary<String, object> statusReport) {
            if (this.InvokeRequired) {
                this.Invoke(new UpdateServerStatus_(UpdateServerStatus), statusReport);
            }
            else {
                serverNameLabel.Text = "";
                serverStatusLabel.Text = "";
                foreach (String key in statusReport.Keys) {
                    serverNameLabel.Text += key + Environment.NewLine;
                    serverStatusLabel.Text += statusReport[key].ToString() + Environment.NewLine;
                }
            }
        }

        private delegate void UpdateConsole_(String text);
        public void UpdateConsole(String text) {
            if (this.InvokeRequired) {
                this.Invoke(new UpdateConsole_(UpdateConsole), text);
            }
            else {
                consoleBox.AppendText(text);
            }
        }

        private void nemRefreshButton_Click(object sender, EventArgs e) {
            QueryNEM nemQuery = new QueryNEM();
            nemDB = nemQuery.NEMDB;
            nemModList.Items.Clear();
            foreach (String modName in nemQuery.NEMDB.Keys) {
                nemModList.Items.Add(modName);
            }
            nemCountLabel.Text = nemDB.Keys.Count + " mods loaded!";
        }

        private void nemModList_SelectedIndexChanged(object sender, EventArgs e) {
            if (nemModList.SelectedItems.Count > 0) {
                Console.WriteLine(nemModList.SelectedItems[0].Text);
                Uri test = new Uri(nemDB[nemModList.SelectedItems[0].Text]["longurl"]);
                Console.WriteLine(test);
                webBrowser.Url = new Uri(nemDB[nemModList.SelectedItems[0].Text]["longurl"]);

                tabControl1.SelectTab(browserTab);
            }
        }
    }
}
