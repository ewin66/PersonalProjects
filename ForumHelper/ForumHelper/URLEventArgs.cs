using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumHelper
{
    public  class URLEventArgs : EventArgs
    {
       static string url;
        List<WebPage> webPages = new List<WebPage>();

        public static string Url
        {
            get { return url; }
            set
            {
                if (value == null) throw new ArgumentNullException("URL string can't be null!");
                url = value;
            }
        }
        public IEnumerable<WebPage> Webpages
        {
            get { return this.webPages; }
            set
            {
                if (value == null) throw new ArgumentNullException("Webpages must exist!");
                this.webPages = value.ToList();
            }
        }
        public URLEventArgs(IEnumerable<WebPage> webPages)
        {
            this.Webpages = webPages;
        }
    }
}
