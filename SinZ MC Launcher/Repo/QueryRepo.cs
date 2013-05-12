using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;


namespace SinZ_MC_Launcher.Repo {
    class QueryRepo {

        String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");
        Uri versionCheck = new Uri("http://sinz.mca.d3s.co/repo/versions.txt");

        String version = "";

        MainForm form;

        public QueryRepo(MainForm form) {
            this.form = form;

            Thread thread = new Thread(new ThreadStart(CheckVersions));
            thread.Start();
            //client.DownloadFileCompleted += QueryCompleted;
            //client.DownloadFileAsync(repo, Path.Combine(location, "modList.txt"));
            while (thread.IsAlive) {
                Application.DoEvents();
            }
        }
        private void CheckVersions() {
            try
            {
                Console.WriteLine("Querying Repository");
                WebClient client = new WebClient();
                String result = client.DownloadString(versionCheck);

                if (!result.Contains('|'))
                {
                    version = result;
                }
                else
                {
                    String[] versions = result.Split('|');
                    version = versions.Last<String>();
                }
                client.DownloadFile(new Uri("http://sinz.mca.d3s.co/repo/" + version + ".txt"), Path.Combine(location, version + ".txt"));
                Dictionary<String,object> db = parseRepo();
                Console.WriteLine("Finished reading repository");
                form.RefreshOldRepo(db);
                client.Dispose();
            }
            catch (WebException)
            {
                Console.WriteLine("Old mod repository must be down... =S");
            }
        }
        public Dictionary<String, object> parseRepo() {
            //Console.WriteLine("Reading repository");
            FileStream stream = new FileStream(Path.Combine(location, version + ".txt"), FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            String json = reader.ReadToEnd();
            reader.Dispose();
            return deserializeToDictionary(json);
        }

        //Got from http://stackoverflow.com/questions/1207731
        private Dictionary<string, object> deserializeToDictionary(string jo) {
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(jo);
            Dictionary<string, object> values2 = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> d in values) {
                if (d.Value.GetType().FullName.Contains("Newtonsoft.Json.Linq.JObject")) {
                    values2.Add(d.Key, deserializeToDictionary(d.Value.ToString()));
                }
                else {
                    values2.Add(d.Key, d.Value);
                }
            }
            return values2;
        }
    }
}
