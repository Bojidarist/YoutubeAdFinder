using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExtractor;

namespace YoutubeAdFinderProject
{
    class YoutubeDownloaderClass
    {
        public static string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
        private static string downloadVideoQualityAnswer;

        public static void YoutubeDownloader()
        {

            Console.WriteLine("Do you wish to download that video? 'y' or 'n' ");
            string downloadVideoAnswer = Convert.ToString(Console.ReadLine());

            if (downloadVideoAnswer.ToLower() == "y")
            {
                Console.WriteLine("Type the download quality '360', '480', '720', '1080'");
                downloadVideoQualityAnswer = Console.ReadLine().ToString();

                YoutubeDownloaderStart();
            }
            else if (downloadVideoAnswer.ToLower() == "n")
            {
                ProgramRestart.Restart();
            }
            else
            {
                ProgramRestart.Restart();
            }

            Console.ReadKey();
        }

        public static void YoutubeDownloaderStart()
        {
            try
            {
                IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(YoutubeOpener.youtubeLink);
                /*
                * Select the first .mp4 video 
                */



                VideoInfo video = videoInfos
                    .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == Convert.ToInt32(downloadVideoQualityAnswer));

                /*
                 * If the video has a decrypted signature, decipher it
                 */
                if (video.RequiresDecryption)
                {
                    DownloadUrlResolver.DecryptDownloadUrl(video);
                }

                /*
                 * Create the video downloader.
                 * The first argument is the video to download.
                 * The second argument is the path to save the video file.
                 */
                var videoDownloader = new VideoDownloader(video, Path.Combine(downloadsPath, video.Title + video.VideoExtension));

                // Register the ProgressChanged event and print the current progress
                videoDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage);

                /*
                 * Execute the video downloader.
                 * For GUI applications note, that this method runs synchronously.
                 */
                videoDownloader.Execute();

                Console.WriteLine($"File downloaded at: { downloadsPath }");
                Console.WriteLine("Press Any Key To Continue . . .");

                Console.ReadKey();

                ProgramRestart.Restart();

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Looks like this quality cannot be downloaded or the video is listed or private.\nTry another quality option!");
                YoutubeDownloader();

            }

        }
    }
}
