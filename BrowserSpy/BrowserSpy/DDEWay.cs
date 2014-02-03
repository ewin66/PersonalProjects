using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDde;
using NDde.Client;

namespace BrowserSpy
{
   public class DDEWay
    {

        public string GetBrowserURL(string browser)
        {
            try
            {
                DdeClient dde = new DdeClient(browser, "WWW_GetWindowInfo");
                dde.Connect();
                string url = dde.Request("URL", int.MaxValue);
                string[] text = url.Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
                dde.Disconnect();
                return text[0].Substring(1);
            }
            catch
            {
                return null;
            }
        }
    }
}
