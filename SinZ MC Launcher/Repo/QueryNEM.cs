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
        private Uri serverURL = new Uri("http://bot.notenoughmods.com/1.5.1.json");
        public Dictionary<String,Dictionary<String,String>> NEMDB = new Dictionary<string,Dictionary<string,string>>();
        public QueryNEM() {
            Thread thread = new Thread(new ThreadStart(DoQuery));
            thread.Start();
            while (thread.IsAlive) {
                Application.DoEvents();
            }
        }

        private void DoQuery() {
            WebClient client = new WebClient();
            String nemOutput = client.DownloadString(serverURL);
            JArray jsonArray = JArray.Parse(nemOutput);
            foreach (JObject mod in jsonArray) {
                NEMDB.Add(mod["name"].ToString(), new Dictionary<String, String> {
                    {"version", mod["version"].ToString() },
                    {"longurl", mod["longurl"].ToString() },
                    {"shorturl", mod["shorturl"].ToString() },
                    {"aliases", mod["aliases"].ToString() },
                    {"comment", mod["comment"].ToString() }
                });
            }
        }
    }
}
