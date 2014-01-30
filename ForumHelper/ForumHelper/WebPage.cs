using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForumHelper
{
    public abstract class WebPage
    {   
        public WebPage(string url)
        {
            this.Url = url;
        }

        string url;
        string previousPageVersion;
        string currentPageVersion;
        internal bool notChecked=true;
        Regex rgx;

       public string Url
        {
            get { return this.url; }
            set
            {
                if (value == null) throw new ArgumentNullException("URL can't be null");
                this.url = value;
            }
        }
        public string PreviousPageVersion
        {
            get { return this.previousPageVersion; }
            set
            {
                if (value == null) throw new ArgumentNullException("Previous Version can't be null!");
                this.previousPageVersion = value;
            }
        }
        public string CurrentPageVersion
        {
            get { return this.currentPageVersion; }
            set
            {
                if (value == null) throw new ArgumentNullException("Previous Version can't be null!");
                this.currentPageVersion = value;
            }
        }
        public Regex Rgx
        {
            get { return this.rgx; }
            set
            {
                if(value==null) throw new ArgumentNullException("Regex expression doesn't exist!");
                this.rgx = value;
            }
        }

        public string GetPageData()
        {
            if (this.PreviousPageVersion !=null) this.PreviousPageVersion = this.CurrentPageVersion;

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(this.Url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();//TODO: take care about System.Net.Webexception
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            if (this.PreviousPageVersion == null) this.PreviousPageVersion = result;
            this.CurrentPageVersion = result;
            return result;
        }
        public bool CompareVersions()
        {
            if (this.CurrentPageVersion == this.PreviousPageVersion) return true;
            return false;
        }
    }
}
