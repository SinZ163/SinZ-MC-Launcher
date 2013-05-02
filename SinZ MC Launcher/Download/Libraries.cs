using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Download {
    class Libraries {

        public Uri DOWNLOAD_LINK = new Uri("https://s3.amazonaws.com/Minecraft.Download/");

        public Libraries(String version) {
            WebClient client = new WebClient();
            String versionInfo = client.DownloadString(DOWNLOAD_LINK + "versions/" + version + "/" + version + ".json");
            Dictionary<String, object> output = deserializeToDictionary(versionInfo);

            List<String> libraries = new List<String>();
            foreach (JObject library in (JArray)output["libraries"]) {
                Console.WriteLine(library["name"].ToString());
                libraries.Add(library["name"].ToString());
            }
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
