using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SinZ_MC_Launcher.Download {
    class Resources {
        Uri resourceLink = new Uri("https://s3.amazonaws.com/Minecraft.Resources/");

        public Resources() {
            WebClient client = new WebClient();
            String xmlData = client.DownloadString(resourceLink);
            var xDoc = XDocument.Parse(xmlData);
            var contentArray = xDoc.Descendants("Contents");
            foreach (var content in contentArray) {
                Console.WriteLine(content.Value);
            }
        }
    }
}
