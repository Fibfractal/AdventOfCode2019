using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent_code_3
{
    public class ImportWirePaths
    {
        public List<WirePath> ImportPaths()
        {
            var wirePaths = new List<WirePath>();

            if (File.Exists("WirePaths.txt"))
            {
                using (var steamReader = new StreamReader("WirePaths.txt", Encoding.Default, true))
                {
                    var paths = steamReader.ReadToEnd().Split('&');
                    string[] arrayString;

                    for (int i = 0; i < paths.Length; i++)
                    {
                        arrayString = paths[i].Trim().Split(',');
                        wirePaths.Add(new WirePath() { WireId = i + 1, Path = arrayString });
                    }

                    return wirePaths;
                }
            }
            else
                System.Console.WriteLine("Can't find textfle!");

            return null;
        }

        public List<WirePath> TestPaths()
        {
            var wirePaths = new List<WirePath>();

            string[] arrayString1 = new string[4] { "U10", "R5", "D5", "L7" };
            string[] arrayString2 = new string[4] { "D3", "R3", "U6", "L5" };


            wirePaths.Add(new WirePath() { WireId = 1, Path = arrayString1 });
            wirePaths.Add(new WirePath() { WireId = 2, Path = arrayString2 });

            return wirePaths;
        }
    }
}
