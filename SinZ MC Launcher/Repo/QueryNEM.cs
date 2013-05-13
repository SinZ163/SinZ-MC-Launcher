using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Repo {
    class QueryNEM {
        private Uri serverURL = new Uri("http://bot.notenoughmods.com/");
        private String version;
        public Dictionary<String,Dictionary<String,String>> NEMDB = new Dictionary<string,Dictionary<string,string>>();

        MainForm form;
        public QueryNEM(MainForm form)
        {
            this.form = form;
            GetVersions();
        }

        private void DoQuery() {
            WebClient client = new WebClient();
            String nemOutput = client.DownloadString(serverURL + version + ".json");
            client.Dispose();
            JArray jsonArray = JArray.Parse(nemOutput);
            NEMDB.Clear();
            foreach (JObject mod in jsonArray) {
                IList<string> keys = mod.Properties().Select(p => p.Name).ToList();
                Dictionary<String,String> modInfo = new Dictionary<String,String>();
                foreach (String key in keys) {
                    modInfo.Add(key, mod[key].ToString());
                }
                modInfo.Remove("name");
                NEMDB.Add(mod["name"].ToString(), modInfo);
            }
        }
        public void UpdateQuery(String _version)
        {
            this.version = _version;
            Thread thread = new Thread(new ThreadStart(DoQuery));
            thread.Start();
            while (thread.IsAlive)
            {
                Application.DoEvents();
            }
        }
        List<String> versions = new List<string>();
        public void GetVersions()
        {
            Thread thread = new Thread(new ThreadStart(DoVersions));
            thread.Start();
        }

        private void DoVersions()
        {
            try
            {
                WebClient client = new WebClient();
                byte[] webPage = client.DownloadData(new Uri("http://bot.notenoughmods.com"));
                client.Dispose();

                String lineArray = Encoding.UTF8.GetString(webPage);
                String[] lines = lineArray.Split(new Char[] { });

                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i].Contains(".json"))
                    {
                        String message = lines[i].Substring(6); //to remove " href=" "
                        message = message.Replace(".json", ""); //the start of removing everything after the version
                        int j = message.IndexOf('"');           //To get the position of the first character after the version
                        message = message.Substring(0,j);       //Clean our entry to what we want
                        Console.WriteLine("Detected NEM Version: "+message);
                        versions.Add(message);
                    }
                }
                form.RefreshNEMVersions(versions);
            }
            catch (WebException e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
    }
}
