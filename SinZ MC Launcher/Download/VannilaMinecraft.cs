using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinZ_MC_Launcher.Download {
    class DownloadMinecraft {

        String version;

        public Uri DOWNLOAD_LINK = new Uri("https://s3.amazonaws.com/Minecraft.Download/");
        String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");

        String path;

        public DownloadMinecraft(String version, Boolean New = true) {
            path = Path.Combine(location, "versions", version);
            this.version = version;
            if (New) {
                Thread thread = new Thread(new ThreadStart(DownloadNewMinecraft));
                thread.Start();
                while (thread.IsAlive) {
                    Application.DoEvents();
                }
            }
        }

        public void DownloadNewMinecraft() {
            if (!File.Exists(path + Path.DirectorySeparatorChar + version + ".jar"))
            {
                String URL = String.Format(DOWNLOAD_LINK + "versions/{0}/{0}.jar", version);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                WebClient client = new WebClient();
                client.DownloadProgressChanged += SetProgress;
                client.DownloadFile(URL, path + Path.DirectorySeparatorChar + version + ".jar");
                client.Dispose();
            }
        }

        private void SetProgress(object sender, DownloadProgressChangedEventArgs e) {
            //TODO: Do hackery to get back to MainForm without sending MainForm
        }
    }
}
