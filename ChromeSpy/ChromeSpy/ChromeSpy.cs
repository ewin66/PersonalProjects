using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserSpy;

namespace ChromeSpy
{
    class ChromeSpyClass
    {
        static void Main(string[] args)
        {
           var chromeUrls= ChromeWay.GetChromeUrl();
           foreach (var url in chromeUrls)
           {
               Console.WriteLine(url);
           }

        }
    }
}
