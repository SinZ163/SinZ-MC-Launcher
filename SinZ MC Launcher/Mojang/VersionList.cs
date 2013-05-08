using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Mojang
{
    class VersionList
    {
        public Uri DOWNLOAD_LINK = new Uri("https://s3.amazonaws.com/Minecraft.Download/");
        public List<String> versions = new List<string>();

        private MainForm form;

        public VersionList(MainForm form)
        {
            this.form = form;
            Thread thread = new Thread(new ThreadStart(QueryVersionlist));
            thread.Start();
        }

        private void QueryVersionlist()
        {
            try
            {
                WebClient client = new WebClient();
                String versionInfo = client.DownloadString(DOWNLOAD_LINK + "versions/versions.json");
                Dictionary<String, object> output = deserializeToDictionary(versionInfo);
                JArray jsonArray = (JArray)output["versions"];
                foreach (JObject version in jsonArray)
                {
                    versions.Add(version["id"].ToString());
                }
                form.UpdateVersionList(versions);
            }
            catch (WebException)
            {
                Console.WriteLine("The mojang download server must be down..");
            }
        }

        //Got from http://stackoverflow.com/questions/1207731
        private Dictionary<string, object> deserializeToDictionary(string jo)
        {
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(jo);
            Dictionary<string, object> values2 = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> d in values)
            {
                if (d.Value.GetType().FullName.Contains("Newtonsoft.Json.Linq.JObject"))
                {
                    values2.Add(d.Key, deserializeToDictionary(d.Value.ToString()));
                }
                else
                {
                    values2.Add(d.Key, d.Value);
                }
            }
            return values2;
        }
    }
}
