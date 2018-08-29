using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAdFinderProject
{
    class YoutubeAdHelp
    {
        public static void AdHelpInfo()
        {
            Console.Clear();

            Console.WriteLine("------------------------------------------------------\nYoutube Ad Help\n------------------------------------------------------");
            Console.WriteLine("When a video AD plays. \nRight click on it and select 'Copy debug info' then add it to a .txt file and drop it in the console!");
            Console.WriteLine("------------------------------------------------------\nPress Any Key To Continue . . .");

            Console.ReadKey();

            ProgramRestart.Restart();
        }
    }
}
