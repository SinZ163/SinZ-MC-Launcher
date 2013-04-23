using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinZ_MC_Launcher.Launch {
    class LaunchMinecraft {
        
        String path;
        String username;
        String sessionID;
        Boolean consoleEnabled;
        //String jvmArgs;

        public LaunchMinecraft(String path, String username, String sessionID, Boolean consoleEnabled, Boolean demo = false) {
            this.path = path;
            this.username = username;
            this.sessionID = sessionID;
            this.consoleEnabled = consoleEnabled;
            //this.jvmArgs = jvmArgs;

            launch();
        }

        void launch() {
            String[] binFiles = Directory.GetFiles(path, "*.jar", SearchOption.AllDirectories);
            String message = "\"";
            message += String.Join("\";\"", binFiles);
            message += "\"";
            MessageBox.Show(message);

            ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/q /c java -Djava.library.path=\"natives\" -cp "+message+" net.minecraft.client.main.Main --workDir \""+path+"\" --username " + username + " --session " + sessionID);
            procStartInfo.WorkingDirectory = path;
            Process proc = new System.Diagnostics.Process();

            if (consoleEnabled == false) {
                procStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            }
            else {
                procStartInfo.Arguments += " &pause";
            }
            proc.StartInfo = procStartInfo;
            proc.Start();
            Application.Exit();
        }
    }
}
