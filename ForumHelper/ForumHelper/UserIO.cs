using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForumHelper
{
    abstract class UserIO
    {

        internal static List<string> fileLines = new List<string>();

        internal static bool WantsPageScript()
        {
            int n;
            bool isInvalid;
            Console.WriteLine("Do you want to extract the script for a webpage?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            do
            {
                isInvalid = int.TryParse(Console.ReadLine(), out n);
                switch (n)
                {
                    case 1: return true;
                    case 2: return false;
                    default:
                        Console.WriteLine("Invalid choice! Please try again!");
                        break;
                }
            } while (true);
            
        }
        internal static bool IsFromFile()
        {
            int n;
            bool isInvalid;
            Console.WriteLine("1. Insert data from the console.");
            Console.WriteLine("2. Insert data from a file.");
            do
            { 
                isInvalid = int.TryParse(Console.ReadLine(), out n);
                switch (n)
                {
                    case 1: return false;
                    case 2: return true;
                    default:
                        Console.WriteLine("Invalid choice! Please try again!");
                        break;
                }
            } while (true);
        }
        internal static uint GetTimerInterval()
        {
            uint interval;
            if (uint.TryParse(fileLines.ToArray()[0], out interval)) return interval;
            else throw new ArgumentException("Couldn't get the timer interval!");
        }
        internal static uint GetPagesNumber()
        {
            uint pageNum;
            if (uint.TryParse(fileLines.ToArray()[1], out pageNum)) return pageNum;
            else throw new ArgumentException("Couldn't get the number of webpages!");
        }
        internal static IEnumerable<string> GetPageCharacteristics()
        {
            return fileLines.Skip(2).AsEnumerable<string>();
        }



    }
}
