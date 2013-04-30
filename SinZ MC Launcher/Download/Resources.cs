using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace SinZ_MC_Launcher.Download {
    class Resources {
        Uri resourceLink = new Uri("https://s3.amazonaws.com/Minecraft.Resources/");
        Uri downloadLink = new Uri("https://s3.amazonaws.com/Minecraft.Download/");

        public Resources() {
            Thread thread = new Thread(new ThreadStart(QueryResources));
            thread.Start();
            while (thread.IsAlive) {
                Application.DoEvents();
            }
        }

        private void QueryResources() {
            WebClient client = new WebClient();
            //Console.WriteLine("Querying Resource server...");
            String xmlData = client.DownloadString(resourceLink);
            //Console.WriteLine("Downloaded Resource list, parsing...");
            var xDoc = XDocument.Parse(xmlData);
            var contentArray = xDoc.Descendants("Contents");
            foreach (var content in contentArray) {
                var key = content.Descendants("Key");
                MessageBox.Show(key.First().ToString());
                //Console.WriteLine(content.Value);
            }
        }
    }
}
