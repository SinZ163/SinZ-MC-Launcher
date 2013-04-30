using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace SinZ_MC_Launcher.Download {
    class Assets {
        Uri RESOURCE_LINK = new Uri("https://s3.amazonaws.com/Minecraft.Resources/");
        String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");

        List<String> keys;
        Dictionary<String,String> md5s;
        public Assets() {
            Thread queryThread = new Thread(new ThreadStart(QueryAssets));
            queryThread.Start();
            while (queryThread.IsAlive) {
                Application.DoEvents();
            }
            Thread downloadThread = new Thread(new ParameterizedThreadStart(DownloadAssets));
            downloadThread.Start(keys);
            while (downloadThread.IsAlive) {
                Application.DoEvents();
            }
        }

        private void DownloadAssets(object obj) {
            List<String> keys = (List<String>)obj;
            WebClient client = new WebClient();
            int counter = 1;
            foreach (String key in keys) {
                Console.WriteLine("Downloading asset " + counter + " out of " + keys.Count().ToString());
                if (File.Exists(Path.Combine(location, "assets", key))) {
                    using (var md5 = MD5.Create()) {
                        String local;
                        using (var stream = File.OpenRead(Path.Combine(location, "assets", key))) {
                            local = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                        }
                        md5s[key] = md5s[key].Trim('"');
                        Console.WriteLine(md5s[key] + "|" + local);
                        if (md5s[key] == local) {
                            counter++;
                            continue;
                        }
                        else {
                            File.Delete(Path.Combine(location, "assets", key));
                        }
                    }
                }
                String filename = Path.GetFileName(Path.Combine(location, "assets", key));
                String path = Path.GetDirectoryName(Path.Combine(location, "assets", key));
                if(!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                if (filename.Length > 0) {
                    client.DownloadFile(RESOURCE_LINK + key, path+Path.DirectorySeparatorChar+filename);
                }
                counter++;
            }
        }

        private void QueryAssets() {

            Console.WriteLine("Querying Resource server");
            WebClient client = new WebClient();

            String xmlData = client.DownloadString(RESOURCE_LINK);

            keys = new List<String>();
            md5s = new Dictionary<String, String>();
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlData))) {
                while (true) {
                    try {
                        reader.ReadToFollowing("Contents");
                        reader.ReadToFollowing("Key");
                        keys.Add(reader.ReadElementContentAsString());
                        reader.ReadToFollowing("ETag");
                        md5s[keys.Last()] = reader.ReadElementContentAsString();
                    }
                    catch (Exception) {
                        break;
                    }
                }
            }
        }
    }
}
