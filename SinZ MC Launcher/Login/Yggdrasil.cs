using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SinZ_MC_Launcher.Login
{
    class Yggdrasil
    {
        public static readonly Uri YGGDRASIL_BASE = new Uri("https://authserver.mojang.com/");
        public static readonly String YGGDRASIL_LOGIN = "authenticate";

        public String username;
        protected internal String password;
        public Yggdrasil(String username, String password)
        {
            this.username = username;
            this.password = password;

            Thread thread = new Thread(new ThreadStart(DoLogin));
            thread.Start();
            while (thread.IsAlive)
            {
                Application.DoEvents();
            }
        }

        private void DoLogin()
        {
            Dictionary<String, object> PostInfo = new Dictionary<string, object>
            {
                //{"agent","Agent{name='" + "Minecraft" + "'" + ", version=" + 1 + "}"}, //TODO: use variables
                {"agent", new Dictionary<String,String>{{"name","Minecraft"},{"version", "1"}}},
                {"username",username},
                {"password",password}
            };
            //String json = "{'agent':'Agent{name='Minecraft', version=1}','username':'" + username + "','password':'" + password + "'}";
            String json = JsonConvert.SerializeObject(PostInfo, Formatting.Indented);
            MessageBox.Show(json);
            byte[] bytes = new byte[json.Length * sizeof(char)];
            Buffer.BlockCopy(json.ToCharArray(), 0, bytes, 0, bytes.Length);

            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(YGGDRASIL_BASE + YGGDRASIL_LOGIN);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            requestStream.Dispose();

            HttpWebResponse respnse = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(respnse.GetResponseStream());
            string tmp = sr.ReadToEnd();
            MessageBox.Show(tmp);
        }
    }
}
