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
    class DownloadLWJGL {
        String downloadLink = "http://s3.amazonaws.com/MinecraftDownload/";

        Uri native;
        Uri lwjgl;
        Uri jinput;
        Uri util;

        String path;

        Boolean isDownloading = true;


        public void SetProgress(object sender, DownloadProgressChangedEventArgs e) {
        }
        public void SetTask(String text) {
        }

        public DownloadLWJGL(String path) {
            this.path = path;

            if (File.Exists(path + "natives.zip"))
                File.Delete(path + "natives.zip");
            if (File.Exists(path + "lwjgl.jar"))
                File.Delete(path + "lwjgl.jar");
            if (File.Exists(path + "jinput.jar"))
                File.Delete(path + "jinput.jar");
            if (File.Exists(path + "lwjgl_util.jar"))
                File.Delete(path + "lwjgl_util.jar");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            native = new Uri(downloadLink + "windows_natives.jar");
            lwjgl = new Uri(downloadLink + "lwjgl.jar");
            jinput = new Uri(downloadLink + "jinput.jar");
            util = new Uri(downloadLink + "lwjgl_util.jar");

            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(SetProgress);
            client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(Downloaded);

            SetTask("Downloading Natives");
            client.DownloadFileAsync(native, path + "natives.zip");

            while (isDownloading) {
                Application.DoEvents();
            }
            isDownloading = true;
            SetTask("Downloading LWJGL"); 
            client.DownloadFileAsync(lwjgl, path + "lwjgl.jar");

            while (isDownloading) {
                Application.DoEvents();
            }
            isDownloading = true;
            SetTask("Downloading JInput");
            client.DownloadFileAsync(jinput, path + "jinput.jar");

            while (isDownloading) {
                Application.DoEvents();
            }
            isDownloading = true;
            SetTask("Downloading LWJGL Util");
            client.DownloadFileAsync(util, path + "jwjgl_util.jar");

            while (isDownloading) {
                Application.DoEvents();
            }
        }

        public void Downloaded(object sender, AsyncCompletedEventArgs e) {
            isDownloading = false;
        }
    }
}
