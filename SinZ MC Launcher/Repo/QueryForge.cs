using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Repo
{
    class QueryForge
    {
        public Dictionary<String, Dictionary<String, String>> ForgeInfo;
        public QueryForge()
        {
            Thread thread = new Thread(new ThreadStart(DoQuery));
            thread.Start();
            while (thread.IsAlive)
            {
                Application.DoEvents();
            }
        }

        private void DoQuery()
        {
            WebClient client = new WebClient();
            String rawJson = client.DownloadString("http://files.minecraftforge.net/minecraftforge/json");
            JObject json = JObject.Parse(rawJson);
            JArray builds = (JArray)json["builds"];

            ForgeInfo = new Dictionary<string,Dictionary<string,string>>();
            foreach (JObject build in builds)
            {
                Dictionary<String, String> info = new Dictionary<string, string>();
                String version = "";
                foreach (JObject fileInfo in (JArray)build["files"])
                {
                    if (fileInfo["buildtype"].ToString() == "universal")
                    {
                        if (info.ContainsKey("url"))
                        {
                            info["url"] = fileInfo["url"].ToString();
                        } else
                        {
                            info.Add("url", fileInfo["url"].ToString());
                        }

                        if (info.ContainsKey("mcVersion"))
                        {
                            info["mcVersion"] = fileInfo["mcver"].ToString();
                        }
                        else
                        {
                            info.Add("mcVersion", fileInfo["mcver"].ToString());
                        }

                        if (info.ContainsKey("version"))
                        {
                            info["version"] = fileInfo["jobver"].ToString();
                        }
                        else
                        {
                            info.Add("version", fileInfo["jobver"].ToString());
                        }

                        if (info.ContainsKey("build"))
                        {
                            info["build"] = fileInfo["buildnum"].ToString();
                        }
                        else
                        {
                            info.Add("build", fileInfo["buildnum"].ToString());
                        }

                        version = fileInfo["jobbuildver"].ToString();
                    }
                }
                if (!info.ContainsKey("datestamp"))
                {
                    info.Add("datestamp", build["info"].ToString());
                }
                if (!ForgeInfo.ContainsKey(version))
                {
                    ForgeInfo.Add(version, info);
                }
            }
        }
    }
}
