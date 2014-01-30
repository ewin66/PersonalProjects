using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForumHelper
{

    class ForumHelperClass
    {
        static void Main(string[] args)
        {
            if (UserIO.WantsPageScript())
            {
                Console.WriteLine("Insert the URL of the page:");
                WebPage wp = new ConstantPage(Console.ReadLine());
                Console.WriteLine("Insert the file path where the page script will be saved:");
                string path = Console.ReadLine();
                using (StreamWriter sw = new StreamWriter(path))
                {
                   sw.Write(wp.GetPageData()) ; 
                }
            }
            if (UserIO.IsFromFile())
            {
                Console.WriteLine("Insert the absolute path of the file: ");
                UserFileIO.filePath = Console.ReadLine();
                UserFileIO newUser = new UserFileIO();
            }
            else
            {
                UserConsoleIO newUser = new UserConsoleIO();
            }
           
            var t = CreateTimer(UserIO.GetTimerInterval());
            EventSubscriber sub = new EventSubscriber(t);
            t.Tick(new URLEventArgs(CreatePages(UserIO.GetPagesNumber(), UserIO.GetPageCharacteristics())));

        }

        private static List<WebPage> CreatePages(uint sitesCount, IEnumerable<string> wpCharacteristics)
        {
            List<WebPage> webPages = new List<WebPage>();
            int i = 1;
            while (i <= sitesCount)
            {
                string input = wpCharacteristics.ToArray()[i - 1];
                string url = input.Substring(0, input.IndexOf(",,") > 0 ? input.IndexOf(",,") : input.Length);
                string strRgx = input.Substring(url.Length + 2, input.Length - url.Length - 2);
                if (strRgx == string.Empty)//WebPage is not modifiable
                {
                    webPages.Add(new ConstantPage(url));
                    i++;
                }
                else
                {
                    webPages.Add(new ForumPage(url, new Regex(strRgx)));
                    i++;
                }
            }
            return webPages;
        }
        private static Timer CreateTimer(uint interval)
        {
            Timer t = new Timer(1000 * interval);
            return t;
        }
    }
}
