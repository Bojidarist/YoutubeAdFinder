using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAdFinderProject
{
    class IndexOfTest
    {
        public static void StartTest()
        {
            string randomString = "Hello bace ti si golem retard xaxaxaxaxa!";
            int randomStringIndex = randomString.IndexOf("ti");
            
            string golemRetard = randomString.Substring(randomStringIndex, 18);
            Console.WriteLine(golemRetard);
        }
    }
}
