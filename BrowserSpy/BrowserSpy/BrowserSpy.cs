using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserSpy
{
    class BrowserSpy
    {
        static void Main(string[] args)
        {
            DDEWay myDde = new DDEWay();
            Console.WriteLine(myDde.GetBrowserURL("firefox"));
            Console.WriteLine();
            Console.WriteLine(myDde.GetBrowserURL("opera"));
            Console.WriteLine();
            GetIEUrl();
        }

        public static void GetIEUrl()
        {
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
            string filename;
            foreach (SHDocVw.InternetExplorer ie in shellWindows)
            {
                filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                if (filename.Equals("iexplore"))
                {
                    Console.WriteLine(ie.LocationURL.ToString());
                }
            }
        }
    }


}
