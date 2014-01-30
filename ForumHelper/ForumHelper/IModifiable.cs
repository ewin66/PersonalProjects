using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForumHelper
{
    interface IModifiable<WebPage>
    {
        WebPage Modify(WebPage wp);
    }
}
