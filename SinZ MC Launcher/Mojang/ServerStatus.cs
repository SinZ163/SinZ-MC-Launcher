using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Mojang {
    class ServerStatus {
        Uri serverCheck = new Uri("http://status.mojang.com/check");
 
        private MainForm form;
        public ServerStatus(MainForm form) {
            this.form = form;
            Thread thread = new Thread(new ThreadStart(doStatus));
            thread.Start();
        }
        public void doStatus() {
            WebClient client = new WebClient();
            String serverResult = client.DownloadString(serverCheck);

            serverResult = serverResult.TrimStart('[');
            serverResult = serverResult.TrimEnd(']');
            serverResult = Regex.Replace(serverResult, "},{", ",");

            //MessageBox.Show(serverResult);
            JObject rawOutput = JObject.Parse(serverResult);
            Dictionary<String, object> output = new Dictionary<string, object>();

            IList<string> keys = rawOutput.Properties().Select(p => p.Name).ToList();
            foreach (String key in keys) {
                output.Add(key, rawOutput[key].ToString());
                //MessageBox.Show(key);
                //MessageBox.Show(rawOutput[key].ToString());
            }
            form.UpdateServerStatus(parseStatus(output));
        }
        public static Dictionary<String, object> parseStatus(Dictionary<String, object> input) {
            const String GREEN= "Servers are Online, no problems detected.";
            const String ORANGE="May be experiencing issues.";
            const String RED =  "Offline, experiencing problems.";
            Dictionary<String, object> output = new Dictionary<String, object>();
            var keys = input.Keys;
            foreach (String key in keys) {
                switch ((String)input[key]) {
                    case "green":
                        output[key] = GREEN;
                        break;
                    case "orange":
                        output[key] = ORANGE;
                        break;
                    case "red":
                        output[key] = RED;
                        break;
                    default:
                        output[key] = "UNDEFINED";
                        break;
                }
            }

            return output;
        }
        //Got from http://stackoverflow.com/questions/1207731
        private static Dictionary<string, object> deserializeToDictionary(string jo) {
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


        public void Refresh() {
            Thread thread = new Thread(new ThreadStart(doStatus));
            thread.Start();
        }
    }
}
