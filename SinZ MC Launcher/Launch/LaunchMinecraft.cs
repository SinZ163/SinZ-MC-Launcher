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

        String location;
        String assets;

        String launchArgs;
        String launchClass;
        //String jvmArgs;

        public LaunchMinecraft(String location, String assets, String username, String sessionID, Boolean consoleEnabled, String version, List<String> results, String launchArgs, String launchClass, Boolean demo = false) {
            this.location = location;
            this.assets = assets;
            
            this.username = username;
            this.sessionID = sessionID;
            this.consoleEnabled = consoleEnabled;
            this.version = version;
            this.results = results;

            this.launchArgs = launchArgs;
            this.launchClass = launchClass;
            //this.jvmArgs = jvmArgs;

            launch();
        }

        void launch() {
            String message = "\"";
            message += Path.Combine(location, "versions", version, version + ".jar");
            message += "\";\"";

            //Libraries time
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

            //Natives time
            String nativesLocation = Path.Combine(location,"versions", version,version+"-natives");
            nativesLocation = nativesLocation.Replace('\\', '/');
            MessageBox.Show(nativesLocation);

            //Launch Arguments
            String[] launchWords = launchArgs.Split(' ');
            List<String> launchArguments = new List<string>();
            foreach (String launchWord in launchWords)
            {
                if (!launchWord.StartsWith("$"))
                    continue;
                //"--username ${auth_player_name} --session ${auth_session} --version ${version_name} --gameDir ${game_directory} --assetsDir ${game_assets}"
                String tmp = launchWord.Substring(1);
                tmp = launchWord.Trim(new[] { '{', '}' });
                switch (tmp)
                {
                    case "auth_player_name":
                        launchArguments.Add(username);
                        break;
                    case "auth_session":
                        launchArguments.Add(sessionID);
                        break;
                    case "version_name":
                        launchArguments.Add(version);
                        break;
                    case "game_directory":
                        launchArguments.Add(location);
                        break;
                    case "game_assets":
                        launchArguments.Add(assets);
                        break;
                }
            }
            String outputArgs = String.Join(" ", launchArguments);

            //Time to Do everything
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe", "/c java -Xmx1G -Djava.library.path=\""+nativesLocation+"\" -cp "+message+" "+launchClass+" "+outputArgs);
            procStartInfo.WorkingDirectory = location;
            Process proc = new Process();

            if (consoleEnabled == false) {
                procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
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
