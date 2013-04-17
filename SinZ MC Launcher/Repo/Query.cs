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
    class Query {

        String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");
        Uri versionCheck = new Uri("http://sinz.mca.d3s.co/repo/versions.txt");

        Boolean isDownloading = true;
        String version = "";

        public Query() {
            Console.WriteLine("Querying Repository");
            WebClient client = new WebClient();
            client.DownloadStringCompleted += VersionDetected;
            client.DownloadStringAsync(versionCheck);
            //client.DownloadFileCompleted += QueryCompleted;
            //client.DownloadFileAsync(repo, Path.Combine(location, "modList.txt"));
            while (isDownloading) {
                Application.DoEvents();
            }
        }

        private void VersionDetected(object sender, DownloadStringCompletedEventArgs e) {
            WebClient client = new WebClient();
            client.DownloadFileCompleted += QueryCompleted;
            if (!e.Result.Contains('|')) {
                version = e.Result;
            }
            else {
                String[] versions = e.Result.Split('|');
                version = versions.Last<String>();
            }
            client.DownloadFileAsync(new Uri("http://sinz.mca.d3s.co/repo/" + version + ".txt"), Path.Combine(location, version + ".txt"));
        }

        private void QueryCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            isDownloading = false;
        }
        public Dictionary<String, object> parseRepo() {
            Console.WriteLine("Reading repository");
            FileStream stream = new FileStream(Path.Combine(location, version + ".txt"), FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            String json = reader.ReadToEnd();
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
