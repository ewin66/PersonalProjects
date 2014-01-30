using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumHelper
{
    class UserFileIO : UserIO
    {
        internal static string filePath;
         internal UserFileIO()
        {
            if (filePath == String.Empty || filePath == null) filePath = "../../input.txt";
            using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("UTF-8")))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    fileLines.Add(line);
                    line = sr.ReadLine();
                }
            }
        }
    }
}
