using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinZ_MC_Launcher.Query {
    class QueryServer {

        UdpClient client;
        IPAddress[] ip;
        int port;
        IPEndPoint connection;

        int token;

        String[] result;
        public Dictionary<String, String> output = new Dictionary<String, String>();
        public List<String> players = new List<String>();
        public Dictionary<string, string> plugins;


        public QueryServer(String address, int port) {
            this.port = port;
            ip = Dns.GetHostAddresses(address);
            client = new UdpClient();
            client.Connect(ip[0], port);
            connection = new IPEndPoint(ip[0], port);
            Thread thread = new Thread(new ThreadStart(DoQuery));
            thread.Start();
            while (thread.IsAlive) {
                Application.DoEvents();
            }

        }
        public void DoQuery() {
            try {
                SendHandshake();
                ReceiveHandshake();
                SendFullRequest();
                ReceiveFullRequest();
                for (int i = 0; i + 1 < result.Length; i = i + 2) {
                    output[result[i]] = result[i + 1];
                }
                if (output["plugins"] != "") {
                    plugins = ParsePlugins(output["plugins"]);
                }
                output.Remove("plugins");
            }
            catch (Exception) {
                MessageBox.Show("An error occured querying that server");
            }            
        }
        public void SendHandshake() {
            Console.WriteLine("Sending Query Handshake");
            byte[] data = {0xFE,0xFD,0x09,0x01,0x01,0x01,0x01};
            client.Send(data, data.Length);
        }
        public void ReceiveHandshake() {
            Console.WriteLine("Waiting for Query Response...");
            byte[] data = client.Receive(ref connection);
            Console.WriteLine("Receieved Query Response");
            data = data.Skip(5).ToArray<byte>();
            List<byte> tempString = new List<byte>();
            while (data[0] != 0x00) {
                tempString.Add(data[0]);
                data = data.Skip(1).ToArray<byte>();
            }
            String tmp = Encoding.UTF8.GetString(tempString.ToArray());
            Console.WriteLine("Token: " + tmp);
            token = int.Parse(tmp);
        }

        public void SendFullRequest() {
            Console.WriteLine("Sending Query Request");
            List<byte> data = new List<byte>{
                0xFE, 0xFD,
                0x00,
                0x01, 0x01, 0x01, 0x01,
                (byte)((token & 0xFF000000) >> 24),
                (byte)((token & 0xFF0000) >> 16),
                (byte)((token & 0xFF00) >> 8),
                (byte)(token & 0xFF),
                0x01,0x01,0x01,0x01
            };
            client.Send(data.ToArray(), data.Count);
        }
        public void ReceiveFullRequest() {
            Console.WriteLine("Waiting for Query Response...");
            byte[] data = client.Receive(ref connection);
            Console.WriteLine("Receieved Query Response");
            data = data.Skip(16).ToArray<byte>();
            List<String> strings = new List<String>();
            int i = 0;
            while (i <= 20) {
                List<byte> tempString = new List<byte>();
                while (data[0] != 0x00) {
                    tempString.Add(data[0]);
                    data = data.Skip(1).ToArray<byte>();
                }
                data = data.Skip(1).ToArray<byte>();
                String tmp = Encoding.UTF8.GetString(tempString.ToArray());
                strings.Add(tmp);
                i++;
            }
            result = strings.ToArray(); //Most of the output
            data = data.Skip(10).ToArray<byte>();
            bool reading = true;
            while (reading) {
                List<byte> tempString = new List<byte>();
                while (data[0] != 0x00) {
                    tempString.Add(data[0]);
                    data = data.Skip(1).ToArray<byte>();
                }
                data = data.Skip(1).ToArray<byte>();
                String tmp = Encoding.UTF8.GetString(tempString.ToArray());
                if (tmp.Length == 0) {
                    reading = false;
                    break;
                }
                else {
                    players.Add(tmp);
                }
            }
        }
        public static Dictionary<String, String> ParsePlugins(String pluginDump) {
            Dictionary<String, String> output = new Dictionary<string, string>();
            String[] pluginSplit = pluginDump.Split(':');
            output["SERVER_MOD"] = pluginSplit[0];
            String[] plugins = pluginSplit[1].Split(';');
            foreach (String data in plugins) {
                String[] plugin = data.Split(' ');
                output[plugin[0]] = plugin[1];
            }
            return output;
        }
       
    }
}
