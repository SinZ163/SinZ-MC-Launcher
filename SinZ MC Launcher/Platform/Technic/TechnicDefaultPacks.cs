using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Platform.Technic
{
    class TechnicDefaultPacks
    {
        MainForm form;

        public static String DEFAULT_LIST = "http://solder.technicpack.net/api/modpack/?include=full";

        public Dictionary<String, Dictionary<String, String>> DefaultModpacks = new Dictionary<string, Dictionary<String, String>>();

        public TechnicDefaultPacks(MainForm form)
        {
            this.form = form;
        }

        private void QueryDefaultList()
        {
            WebClient client = new WebClient();
            String jsonraw = client.DownloadString(DEFAULT_LIST);
            client.Dispose();

            JObject json = JObject.Parse(jsonraw);
            IList<string> keys = ((JObject)json["modpacks"]).Properties().Select(p => p.Name).ToList();
            foreach (String key in keys)
            {
                Dictionary<String,String> modpack = new Dictionary<string,string>();
                IList<string> modKeys = ((JObject)json["modpacks"][key]).Properties().Select(p => p.Name).ToList();
                foreach (String modKey in modKeys)
                {
                    modpack.Add(modKey, json["modpacks"][key][modKey].ToString());
                }
                DefaultModpacks.Add(key, modpack);
            }
        }
        public void RefreshList() {
            Thread thread = new Thread(new ThreadStart(QueryDefaultList));
            thread.Start();
            while (thread.IsAlive)
            {
                Application.DoEvents();
            }
        }
    }
}
