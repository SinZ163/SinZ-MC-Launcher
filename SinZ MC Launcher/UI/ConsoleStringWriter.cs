using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinZ_MC_Launcher.UI {
    class ConsoleStringWriter : TextWriter {
        MainForm _output = null;
        public ConsoleStringWriter(MainForm output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            
            _output.UpdateConsole(value.ToString()); // When character data is written, append it to the text box.
        }
 
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
