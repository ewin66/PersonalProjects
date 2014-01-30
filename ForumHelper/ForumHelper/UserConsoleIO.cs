using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumHelper
{
    class UserConsoleIO :UserIO
    {
        internal UserConsoleIO()
        {
            Console.Write("Insert the time interval in seconds for webpage checking: ");
            fileLines.Add(Console.ReadLine());
            Console.Write("Insert the number of the webpages: ");
            fileLines.Add(Console.ReadLine());
            Console.WriteLine("Insert the webpages' URL and the replacing regex string separated by double comma \",,\".");
            Console.WriteLine("If regex string is not applicable end with the double comma!");
            for (int i = 0; i < int.Parse(fileLines[1]); i++)
            {
                fileLines.Add(Console.ReadLine());
            }

        }
    }
}
