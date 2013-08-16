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
                String webPage = client.DownloadString(new Uri("http://bot.notenoughmods.com?json"));
                client.Dispose();

                JArray json = JArray.Parse(webPage);

                List<String> versions = new List<string>();
                foreach (JToken key in json)
                {
                    if (!key.ToString().Contains("-dev"))
                    {
                        Console.WriteLine("Detected NEM Version: " + key.ToString());
                        versions.Add(key.ToString());
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
