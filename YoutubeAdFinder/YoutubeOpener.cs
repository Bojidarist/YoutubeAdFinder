using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAdFinderProject
{
    class YoutubeOpener
    {
        // Getting Youtube Link
        public static string youtubeLink = $"https://www.youtube.com/watch?v={ YoutubeAdMain.adDocIdStringBuilder.ToString() }";

        public static void OpenQuestion()
        {
            Console.WriteLine("Do you want to open the video in your default browser? 'y' or 'n'");
            string questionAnswer = Console.ReadLine().ToString();
            if (questionAnswer.ToLower().Trim(' ') == "y")
            {
                Open();
            }
            else if (questionAnswer.ToLower().Trim(' ') == "n")
            {
                YoutubeDownloaderClass.YoutubeDownloader(); 
            }
            else
            {
                ProgramRestart.Restart();
            }
        }

        public static void Open()
        {
            

            // Opening Link
            Console.WriteLine($"Opening . . . { youtubeLink }");
            Process.Start(youtubeLink);

            Console.WriteLine("Press Any Key To Continue . . .");
            Console.ReadKey();

            
        }
    }
}
