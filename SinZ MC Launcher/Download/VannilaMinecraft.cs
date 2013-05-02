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

        Boolean isDownloading = true;
        String path;
        String version;
        public DownloadMinecraft(MainForm form, String version, String path, Boolean New = true) {
            this.path = path;
            this.version = version;
            if (New) {
                Thread thread = new Thread(new ThreadStart(DownloadNewMinecraft));
                thread.Start();
                while (thread.IsAlive) {
                    Application.DoEvents();
                }
            }
            else {
                Thread thread = new Thread(new ThreadStart(DownloadOldMinecraft));
                thread.Start();
                while (thread.IsAlive) {
                    Application.DoEvents();
                }
            }
        }

        public void DownloadOldMinecraft() {
            String URL = String.Format("http://assets.minecraft.net/{0}/minecraft.jar", version);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            WebClient client = new WebClient();
            client.DownloadProgressChanged += SetProgress;
            client.DownloadFile(URL, path + "minecraft.jar");
        }
        public void DownloadNewMinecraft() {
            String URL = String.Format("https://s3.amazonaws.com/Minecraft.Download/versions/{0}/{1}.jar", version);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            WebClient client = new WebClient();
            client.DownloadProgressChanged += SetProgress;
            client.DownloadFile(URL, path + version+".jar");
        }

        private void SetProgress(object sender, DownloadProgressChangedEventArgs e) {
            //TODO: Do hackery to get back to MainForm without sending MainForm
        }
    }
}
