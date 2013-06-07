using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Modlist
{
    class ReadModlist
    {
        Uri url = new Uri("http://sinz.x10.mx/repo/modlists/test.json");
        public Dictionary<String, object> modlist;
        public ReadModlist()
        {
            Thread downloadThread = new Thread(new ThreadStart(DownloadModlist));
            downloadThread.Start();
            while (downloadThread.IsAlive)
            {
                Application.DoEvents();
            }
        }

        private void DownloadModlist()
        {
            try
            {
                WebClient client = new WebClient();
                String rawOutput = client.DownloadString(url);
                client.Dispose();
                modlist = deserializeToDictionary(rawOutput);
            }
            catch (WebException)
            {
                Console.WriteLine("Webserver is completely down...");
            }
            catch (Newtonsoft.Json.JsonException)
            {
                Console.WriteLine("Something isn't right...");
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
