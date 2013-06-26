using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Mojang
{
    class VersionInfo
    {
        public static Uri DOWNLOAD_LINK = new Uri("https://s3.amazonaws.com/Minecraft.Download/");
        public static int MIN_VERSION = 2;

        private Dictionary<String,object> CheckRemote(String version)
        {
            Dictionary<String, object> VersionInfo = new Dictionary<string, object>();
            WebClient client = new WebClient();
            String output = client.DownloadString(DOWNLOAD_LINK + "versions" + Path.DirectorySeparatorChar + version + Path.DirectorySeparatorChar + version + ".json");
            client.Dispose();

            JObject versionData = JObject.Parse(output);
            IList<string> keys = versionData.Properties().Select(p => p.Name).ToList();
            foreach (String key in keys)
            {
                VersionInfo.Add(key, versionData[key].ToString());
            }
            if (keys.Contains("minimumLauncherVersion"))
            {
                if (int.Parse(versionData["minimumLauncherVersion"].ToString()) > MIN_VERSION)
                {
                    MessageBox.Show("Outdated launcher, Contact SinZ!");
                }
            }
            VersionInfo = ParseLibraries((JArray)versionData["libraries"], VersionInfo);
            return VersionInfo;
        }

        private Dictionary<string, object> ParseLibraries(JArray libraries, Dictionary<String,Object> VersionInfo)
        {
            List<String> LibraryList = new List<string>();
            Dictionary<String, Dictionary<String,String>> NativesList = new Dictionary<string, Dictionary<string,string>>();
            foreach (JObject library in libraries)
            {
                IList<string> keys = library.Properties().Select(p => p.Name).ToList();
                if (keys.Contains("natives"))
                {
                    Dictionary<String, object> nativeDict = new Dictionary<string, object>();
                    JObject native = (JObject)library["natives"];
                    IList<string> nativeKeys = native.Properties().Select(p => p.Name).ToList();

                    foreach (String nativeKey in nativeKeys)
                    {
                        nativeDict.Add(nativeKey, native[nativeKey].ToString());
                    }

                    IList<string> extractKeys = ((JObject)VersionInfo["extract"]).Properties().Select(p => p.Name).ToList();
                    Dictionary<String, String> extractDict = new Dictionary<string, string>();
                    foreach (String extractKey in extractKeys)
                    {
                        extractDict.Add(extractKey, ((JObject)VersionInfo["extract"])[extractKey].ToString());
                    }

                    nativeDict.Add("extract", extractDict);
                    VersionInfo.Add("natives", nativeDict);
                }
                else
                {
                    LibraryList.Add(library["name"].ToString());
                }
            }
            VersionInfo["libraries"] = LibraryList;
            return VersionInfo;
        }
    }
}
