using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace YoutubeAdFinderProject
{
    class YoutubeAdMain
    {

        public static string writtenPath;
        public static int writtenPathExtentionCheckInt;
        public static string writtenPathExtentionCheckString;
        public static StringBuilder adDocIdStringBuilder = new StringBuilder();


        public static void FindingAdID()
        {

            try
            {
                // Removes Previous StringBuilder's characters. If its not removed it only plays 1 video no matter the ID.
                adDocIdStringBuilder.Remove(0, adDocIdStringBuilder.Length);

                // Asking for a file
                Console.WriteLine("Drop in the console the txt file with the debug info for the ad! Type 'Help' for more info!\nType 'Exit', 'Close' or 'Quit' to exit the program!");
                writtenPath = Console.ReadLine().ToString();


                // Checking for Ad Help
                if (writtenPath.ToLower() == "help")
                {
                    YoutubeAdHelp.AdHelpInfo();
                }

                // Checking for blank space input
                else if (writtenPath.Trim(' ') == "")
                {
                    ProgramRestart.Restart();
                }

                // Checking for "Exit" input
                else if (writtenPath.ToLower() == "quit" || writtenPath.ToLower() == "close" || writtenPath.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }

                // Part of checking if the file extention is incorrect ".exe"
                writtenPathExtentionCheckInt = writtenPath.LastIndexOf('.');
                writtenPathExtentionCheckString = writtenPath.Substring(writtenPathExtentionCheckInt);

                //Checking for exe extention
                if (writtenPathExtentionCheckString.ToLower().Trim(' ', '.', '"') == "exe" || writtenPathExtentionCheckString.ToLower().Trim(' ', '.', '"') == ".exe")
                {
                    throw new ArgumentOutOfRangeException();
                }


                // Reading File
                string debugInfo = File.ReadAllText($@"{ writtenPath.Trim('"') }");

                // Getting "ad_docid"
                int debugInfoIndexOf = debugInfo.IndexOf("ad_docid");
                string adDocIdLine = debugInfo.Substring(debugInfoIndexOf, 24);

                // Seperator
                char[] seperator = new char[]
                {
                ' ', '"', ':'
                };

                // String Split
                string[] adDocIdSplit = adDocIdLine.Split(seperator, StringSplitOptions.RemoveEmptyEntries);


                // StringBuilder Time

                for (int i = 1; i < adDocIdSplit.Length; i++)
                {
                    adDocIdStringBuilder.Append(adDocIdSplit[i]);
                }


                Console.Clear();

                // Printing the StringBuilder/ID
                Console.WriteLine($"ID: {adDocIdStringBuilder.ToString()}");

                //Opening Youtube Video
                YoutubeOpener.OpenQuestion();

                // Downloading video
               
                YoutubeDownloaderClass.YoutubeDownloader();

                // Reseting Program after opening/downloading video
                ProgramRestart.Restart();
            }

            // Catching exceptions
            catch (FileNotFoundException)
            {
                Console.Clear();
                Console.WriteLine("The file is not found please try again!\nPress Any Key To Continue . . .");
                Console.ReadKey();
            }
            catch (NotSupportedException)
            {
                Console.Clear();
                Console.WriteLine("The file is not found please try again!\nPress Any Key To Continue . . .");
                Console.ReadKey();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("The path is not valid or the file does not contain an AD ID or is a wrong extention.\nMake sure you drop the right file!\nPress Any Key To Continue . . .");
                Console.ReadKey();
            }
            catch (ArgumentException)
            {
                Console.Clear();
                Console.WriteLine("You typed something wrong please try again!\nPress Any Key To Continue . . .");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("The path is not valid or the file does not contain an AD ID or is a wrong extention.\nMake sure you drop the right file!\nPress Any Key To Continue . . .");
                Console.ReadKey();
            }
            finally
            {
                ProgramRestart.Restart();
            }

        }



    }
}
