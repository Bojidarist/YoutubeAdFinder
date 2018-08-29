using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAdFinderProject
{
    public class Bootstrap
    {
        public static void StartProgram()
        {
            
            //IndexOfTest.StartTest();
            //StringSplitReplaceTrimTest.StartTest();
            //StringSplitReplaceTrimTest.ReplaceTextTest();
            //StringSplitReplaceTrimTest.TrimTextTest();

            YoutubeAdMain.FindingAdID();

            // This is used when the other Classes are active!
            Console.ReadKey();
        }
    }
}
