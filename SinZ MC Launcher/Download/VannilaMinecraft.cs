using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinZ_MC_Launcher.Download {
    class DownloadMinecraft {

        Boolean isDownloading = true;
        
        public DownloadMinecraft(MainForm form, String version, String path) {
            String URL = String.Format("http://assets.minecraft.net/{0}/minecraft.jar", version);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            WebClient client = new WebClient();
            client.DownloadProgressChanged += SetProgress;
            client.DownloadFileCompleted += Downloaded;
            client.DownloadFileAsync(new Uri(URL), path + "minecraft.jar");
            while (isDownloading) {
                Application.DoEvents();
            }
        }

        private void SetProgress(object sender, DownloadProgressChangedEventArgs e) {
            //TODO: Do hackery to get back to MainForm without sending MainForm
        }

        public void Downloaded(object sender, AsyncCompletedEventArgs e) {
            isDownloading = false;
        }
    }
}
