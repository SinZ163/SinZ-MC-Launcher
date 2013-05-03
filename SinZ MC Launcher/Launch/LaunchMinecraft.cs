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
        
        String username;
        String sessionID;
        Boolean consoleEnabled;

        String version;
        List<String> results;

        String location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".sinzmc/");
        //String jvmArgs;

        public LaunchMinecraft(String username, String sessionID, Boolean consoleEnabled, String version, List<String> results, Boolean demo = false) {
            this.username = username;
            this.sessionID = sessionID;
            this.consoleEnabled = consoleEnabled;
            this.version = version;
            this.results = results;
            //this.jvmArgs = jvmArgs;

            launch();
        }

        void launch() {
            String message = "\"";
            message += Path.Combine(location, "versions", version, version + ".jar");
            message += "\";\"";

            List<String> libraries = new List<string>();
            foreach (String library in results)
            {
                if (!library.Contains("native"))
                    libraries.Add(Path.Combine(location, "libraries", library));
            }

            message += String.Join("\";\"", libraries);
            message += "\"";
            message = message.Replace('\\', '/');
            MessageBox.Show(message);

            String nativesLocation = Path.Combine(location,"versions", version,version+"-natives");
            nativesLocation = nativesLocation.Replace('\\', '/');
            MessageBox.Show(nativesLocation);

            ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c java -Xmx1G -Djava.library.path=\""+nativesLocation+"\" -cp "+message+" net.minecraft.client.main.Main --workDir \""+location+"\" --username " + username + " --session " + sessionID);
            procStartInfo.WorkingDirectory = location;
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
