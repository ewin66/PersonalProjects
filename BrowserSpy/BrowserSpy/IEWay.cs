using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserSpy
{
    public class IEWay
    {
        public static List<string> GetIEUrl()
        {
            List<string> Urls = new List<string>();
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
            string filename;
            foreach (SHDocVw.InternetExplorer ie in shellWindows)
            {
                filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                if (filename.Equals("iexplore"))
                {
                    Urls.Add(ie.LocationURL.ToString());
                }
            }

            return Urls;
        }
    }
}
