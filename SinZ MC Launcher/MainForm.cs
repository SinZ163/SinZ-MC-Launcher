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
using SinZ_MC_Launcher.Mojang;
using SinZ_MC_Launcher.UI;
using SinZ_MC_Launcher.Modlist;

namespace SinZ_MC_Launcher {
    public partial class MainForm : Form
    {
        #region FormCreation
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
        #endregion

        String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");

        String username;
        String sessionID;
        LastLogin lastLogin;

        ConsoleStringWriter _writer;
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
            //END SERVER STATUS

            //VERSIONLIST
            versionList = new VersionList(this);
            //END VERSIONLIST

            //NEM
            nemVersionBox.SelectedIndex = nemVersionBox.Items.Count - 1;
            //END NEM

            //OLD REPO
            repo = new Repo.QueryRepo(this);
            //END OLD REPO
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

            Assets downloadAssets = new Assets();
            Libraries downloadLibraries = new Libraries((String)minecraftVersionBox.SelectedItem);
            DownloadMinecraft downloadMinecraft = new DownloadMinecraft((String)minecraftVersionBox.SelectedItem);
            LaunchMinecraft mc = new LaunchMinecraft(username, sessionID, true, (String)minecraftVersionBox.SelectedItem, downloadLibraries.results);
        }

        #region repo
        Repo.QueryRepo repo;
        Dictionary<String, object> db;

        private delegate void RefreshOldRepo_(Dictionary<String,Object> db);
        public void RefreshOldRepo(Dictionary<String, Object> db)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new RefreshOldRepo_(RefreshOldRepo), db);
            }
            else
            {
                this.db = db;
                foreach (String modName in db.Keys)
                {
                    //modName == Minecraft Forge, Not Enough Items, Modular Power Suits
                    modBox.Items.Add(modName);
                }
                modBox.SelectedIndex = 0;
            }
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
#endregion

        #region serverStatus
        ServerStatus status;

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
        #endregion

        #region console
        private delegate void UpdateConsole_(String text);
        public void UpdateConsole(String text) {
            if (this.InvokeRequired) {
                this.Invoke(new UpdateConsole_(UpdateConsole), text);
            }
            else {
                consoleBox.AppendText(text);
            }
        }
        #endregion

        #region nemTab
        private Dictionary<string, Dictionary<string, string>> nemDB;
        private String nemVersion;
        QueryNEM nemQuery = new QueryNEM();

        private void nemRefreshButton_Click(object sender, EventArgs e) {
            nemQuery.UpdateQuery(nemVersion);
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

        private void nemVersionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nemVersion = (String)nemVersionBox.SelectedItem;
        }
#endregion

        #region mcVersion
        VersionList versionList;

        private delegate void UpdateVersionList_(List<String> versions);
        public void UpdateVersionList(List<String> versions)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateVersionList_(UpdateVersionList), versions);
            }
            else
            {
                minecraftVersionBox.Items.Clear();
                foreach (String version in versions)
                {
                    minecraftVersionBox.Items.Add(version);
                }
                minecraftVersionBox.SelectedIndex = 0;
                loginButton.Enabled = true;
            }
        }
        #endregion

        #region Modlist
        ReadModlist modlist;
        private void modpackRefreshButton_Click(object sender, EventArgs e)
        {
            modlist = new ReadModlist();
            if (modlist.modlist.Count > 0)
            {
                modpackVersionBox.Items.Clear();
                foreach (String version in modlist.modlist.Keys)
                {
                    modpackVersionBox.Items.Add(version);
                }
                modpackVersionBox.SelectedIndex = 0;
            }
            else
            {
                modpackVersionBox.Text = "Unable to get info on this modpack.";
            }
        }

        private void modpackVersionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            modpackModList.Items.Clear();
            foreach (String mod in modlist.modlist[(String)modpackVersionBox.SelectedItem].Keys)
            {
                modpackModList.Items.Add(mod + " - " + modlist.modlist[(String)modpackVersionBox.SelectedItem][mod]);
            }
        }
        #endregion
    }
}
