using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAdFinderProject
{
    class StringSplitReplaceTrimTest
    {
        public static void StartTest()
        {
            string waterTypes = "Devin, Bankq, Gorna Banq, Konchita Vurst";
            char[] waterTypesSeperators = new char[]
            {
                ' ', //','
            };
            string[] waterTypesArray = waterTypes.Split(waterTypesSeperators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < waterTypesArray.Length; i++)
            {
                Console.Write(waterTypesArray[i] + " ");
            }
        }

        public static void ReplaceTextTest()
        {
            string replaceTestMinecraft = "Hello guys today I will play some Minecraft!";
            string replaceTestMinecraftToFortnite = replaceTestMinecraft.Replace("Minecraft", "Fortnite");
            string compareReplaceTest = $"\nFirst Text: { replaceTestMinecraft } \nSecond Text: { replaceTestMinecraftToFortnite }";
            Console.WriteLine($"\n------------------------------------------\nReplace Text Test\n------------------------------------------ { compareReplaceTest }");

        }

        public static void TrimTextTest()
        {
            string fileData ="   111 $  %    Ivan Ivanov  ### s   ";
            char[] trimChars = new char[] {' ','1','$','%','#','s'};
            string reduced = fileData.Trim(trimChars);
            Console.WriteLine($"\n----------------------------\nTrim Text Test\n----------------------------\n{ reduced }");
        }
    }
}
