using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserSpy
{
    class BrowserSpy
    {
        static void Main(string[] args)
        {
            foreach (var url in GetUrl())
            {
                Console.WriteLine(url);
            }
        }
        public static IEnumerable<string> GetUrl()
        {
            DDEWay myDde = new DDEWay();
            return myDde.GetBrowserURL("firefox").Concat(myDde.GetBrowserURL("opera")).Concat(IEWay.GetIEUrl()).Concat(ChromeWay.GetChromeUrl());
        }
    }
}
