using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinZ_MC_Launcher {
    class QueryRepo {

        String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");
        Uri repo = new Uri("http://sinz.mca.d3s.co/repo/test.txt");

        Boolean isDownloading = true;

        public QueryRepo() {
            WebClient client = new WebClient();
            client.DownloadFileCompleted += QueryCompleted;
            client.DownloadFileAsync(repo, Path.Combine(location, "modList.txt"));
            while (isDownloading) {
                Application.DoEvents();
            }
        }

        private void QueryCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            isDownloading = false;
        }
    }
}
