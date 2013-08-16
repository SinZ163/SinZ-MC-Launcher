﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Download {
    class Libraries {

        public Uri DOWNLOAD_LINK = new Uri("https://s3.amazonaws.com/Minecraft.Download/");
        String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");
        private string version;
        public String launchArgs;
        public String launchClass;
        List<String> natives = new List<string>();
        public List<String> results = new List<string>();

        public Libraries(String version) {
            this.version = version;
            Thread queryThread = new Thread(new ThreadStart(QueryLibraryServer));
            queryThread.Start();
            while (queryThread.IsAlive)
            {
                Application.DoEvents();
            }
            Thread downloadThread = new Thread(new ThreadStart(DownloadLibraries));
            downloadThread.Start();
            while (downloadThread.IsAlive)
            {
                Application.DoEvents();
            }
            Thread installThread = new Thread(new ThreadStart(InstallNatives));
            installThread.Start();
            while (installThread.IsAlive)
            {
                Application.DoEvents();
            }
        }

        private void InstallNatives()
        {
            foreach (String native in natives)
            {
                using (ZipFile nativeFile = ZipFile.Read(Path.Combine(location, "libraries", native)))
                {
                    foreach (ZipEntry file in nativeFile)
                    {
                        if (!file.FileName.Contains("META-INF"))
                        {
                            if (!Directory.Exists(Path.Combine(location, "versions", version, version + "-natives")))
                                Directory.CreateDirectory(Path.Combine(location, "versions", version, version + "-natives"));
                            if (!File.Exists(Path.Combine(location, "versions", version, version + "-natives")+Path.DirectorySeparatorChar+file.FileName))
                                file.Extract(Path.Combine(location, "versions", version, version + "-natives"));
                        }
                    }
                }
            }
        }

        private void DownloadLibraries()
        {
            WebClient client = new WebClient();

            foreach (String result in results)
            {
                if (!File.Exists(Path.Combine(location, "libraries", result)))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(Path.Combine(location, "libraries", result))))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(location, "libraries", result)));
                    }
                    Console.WriteLine(result);
                    client.DownloadFile(DOWNLOAD_LINK +"libraries/"+ result.Replace('\\','/'), Path.Combine(location, "libraries", result));
                }
            }
        }
        public void QueryLibraryServer()
        {
            WebClient client = new WebClient();
            String versionInfo = client.DownloadString(DOWNLOAD_LINK + "versions" + Path.DirectorySeparatorChar + version + Path.DirectorySeparatorChar + version + ".json");
            client.Dispose();
            Dictionary<String, object> output = deserializeToDictionary(versionInfo);
            launchArgs = output["minecraftArguments"].ToString();
            launchClass = output["mainClass"].ToString();
            List<String> libraries = new List<String>();
            List<String> natives = new List<string>();
            foreach (JObject library in (JArray)output["libraries"])
            {
                libraries.Add(library["name"].ToString());
                try
                {
                    if (library["rules"].ToString().Length > 0)
                    {
                        continue;
                        //TODO: Actually check if it is allow/deny and OSX
                    }
                }
                catch (NullReferenceException)
                {
                    //No conditions, lovelly
                }
                try
                {
                    if (library["natives"].ToString().Length > 0)
                    {
                        natives.Add(library["name"].ToString());
                        Console.WriteLine("It is natives?" + library["name"]);
                    }
                }
                catch (NullReferenceException)
                {
                    //it isn't a native...
                }
            }
            foreach (String library in libraries)
            {
                String[] a = library.Split(':');
                a[0] = a[0].Replace('.', '/');
                if (natives.Contains(library))
                {
                    this.natives.Add(a[0] + Path.DirectorySeparatorChar + a[1] + Path.DirectorySeparatorChar + a[2] + Path.DirectorySeparatorChar + a[1] + "-" + a[2] + "-natives-windows.jar");
                    results.Add(a[0] + Path.DirectorySeparatorChar + a[1] + Path.DirectorySeparatorChar + a[2] + Path.DirectorySeparatorChar + a[1] + "-" + a[2] + "-natives-windows.jar");
                }
                else
                {
                    results.Add(a[0] + Path.DirectorySeparatorChar + a[1] + Path.DirectorySeparatorChar + a[2] + Path.DirectorySeparatorChar + a[1] + "-" + a[2] + ".jar");
                }
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
