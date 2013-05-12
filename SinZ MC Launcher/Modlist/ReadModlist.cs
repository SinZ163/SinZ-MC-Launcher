using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Modlist
{
    class ReadModlist
    {
        Uri url = new Uri("http://sinz.x10.mx/repo/modlists/test.json");
        public Dictionary<String, Dictionary<String, String>> modlist;
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
                modlist = new Dictionary<string, Dictionary<string, string>>();
                JObject json = JObject.Parse(rawOutput);
                IList<string> listVersions = json.Properties().Select(p => p.Name).ToList();
                foreach (String version in listVersions)
                {
                    Dictionary<String, String> a = new Dictionary<string, string>();
                    IList<string> mods = ((JObject)json[version]).Properties().Select(p => p.Name).ToList();
                    foreach (String mod in mods)
                    {
                        a.Add(mod, json[version][mod].ToString());
                    }
                    modlist.Add(version, a);
                }
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
    }
}
