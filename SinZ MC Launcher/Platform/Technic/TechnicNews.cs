using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SinZ_MC_Launcher.Platform.Technic
{
    class TechnicNews
    {
        public static String NEWS_API = "http://technicpack.net/api/news/";
        public static String NEWS_LINK = "http://technicpack.net/article/view/";

        public List<Dictionary<String, String>> articles;

        private void CheckNews()
        {
            Console.WriteLine("Checking TechnicPlatform news!");
            try
            {
                WebClient client = new WebClient();
                String jsonraw = client.DownloadString(NEWS_API);
                client.Dispose();

                articles = new List<Dictionary<string, string>>();

                JArray json = JArray.Parse(jsonraw);
                foreach (JObject jsonArticle in json)
                {
                    Dictionary<String, String> article = new Dictionary<string, string>();
                    IList<string> keys = jsonArticle.Properties().Select(p => p.Name).ToList();
                    foreach (String key in keys)
                    {
                        article.Add(key, jsonArticle[key].ToString());
                    }
                    article.Add("link", NEWS_LINK + article["title"]);
                    articles.Add(article);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to check TechnicPlatform news!");
#if DEBUG
                Console.WriteLine(e.StackTrace);
#endif
            }
        }
        public void RefreshNews()
        {
            Thread mainThread = new Thread(new ThreadStart(CheckNews));
            mainThread.Start();
            while (mainThread.IsAlive)
            {
                Application.DoEvents();
            }
        }
    }
}
