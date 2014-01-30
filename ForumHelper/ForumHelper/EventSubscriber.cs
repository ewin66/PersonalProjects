using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ForumHelper
{
    class EventSubscriber
    {
        internal EventSubscriber(Timer t)
        {
            t.OnTick += t_OnTick;
        }

        void t_OnTick(object sender, URLEventArgs e)
        {

            foreach (var item in e.Webpages)
            {
                item.GetPageData();
                if (item is IModifiable<WebPage>)
                {
                    string modCurrent = ((IModifiable<WebPage>)item).Modify(item).CurrentPageVersion;
                    string modPrevious = ((IModifiable<WebPage>)item).Modify(item).PreviousPageVersion;

                    if (modCurrent != modPrevious)
                    {
                        Alerter.Beep();
                        URLEventArgs.Url = item.Url;
                        Alerter.ShowToast();

                        //StreamWriter swCurrent = new StreamWriter("../../Current" + DateTime.Now.ToString("ddMMyyHHmmss") + ".txt");
                        //StreamWriter swPrevious = new StreamWriter("../../Previous" + DateTime.Now.ToString("ddMMyyHHmmss") + ".txt");
                        //swCurrent.Write(item.CurrentPageVersion);
                        //swPrevious.Write(item.PreviousPageVersion);
                    }
                }
                else //is constant page
                {
                    if (item.CurrentPageVersion != item.PreviousPageVersion)
                    {
                        Alerter.Beep();
                        URLEventArgs.Url = item.Url;
                        Alerter.ShowToast();
                    }
                }
            }
        }
    }
}
