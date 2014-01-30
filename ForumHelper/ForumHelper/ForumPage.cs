using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForumHelper
{
    public class ForumPage : WebPage, IModifiable<WebPage>
    {
        public ForumPage(string url, Regex rgx)
            : base(url)
        {
            this.Rgx = rgx;
        }

        public WebPage Modify(WebPage wp)
        {
            this.CurrentPageVersion = new string(this.Rgx.Replace(this.CurrentPageVersion, "").ToArray());
            this.PreviousPageVersion = new string(this.Rgx.Replace(this.PreviousPageVersion, "").ToArray());
            return wp;
        }


    }
}
