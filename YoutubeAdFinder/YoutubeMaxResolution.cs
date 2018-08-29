using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YoutubeAdFinderProject
{
    class YoutubeMaxResolution
    {
        public static string playBackQuality;

        public static void MaxResolution()
        {
            string debugInfo = File.ReadAllText($@"{ YoutubeAdMain.writtenPath.Trim('"') }");
            
            DebugInfoDeserialize info = JsonConvert.DeserializeObject<DebugInfoDeserialize>(debugInfo);

            

            playBackQuality = info.debug_playbackQuality.Trim('h', 'd', ' ');
        }
    }
}
