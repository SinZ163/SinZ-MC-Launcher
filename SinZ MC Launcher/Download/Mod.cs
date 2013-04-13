using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using SinZ_MC_Launcher.Repo;

namespace SinZ_MC_Launcher.Download {
    class Mod {
        public Mod(Dictionary<String,object> db, String name, String type, String mcVersion) {
            Dictionary<String, object> version = (Dictionary<String, object>)db[mcVersion];
            Dictionary<String, object> modType = (Dictionary<String, object>)version[type];
            JArray mod = (JArray)modType[name];
            MessageBox.Show(mod[1]["version"].ToString());
        }
    }
}
