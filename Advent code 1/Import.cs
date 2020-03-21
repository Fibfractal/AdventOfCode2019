using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Advent_code_1
{
    public class Import
    {
        public List<int> DataFromTextFile()
        {
            var fuelList = new List<int>();

            if (File.Exists("FuelData.txt"))
            {
                using (var steamReader = new StreamReader("FuelData.txt", Encoding.Default, true))
                {
                    var stringRow = "";
                    while ((stringRow = steamReader.ReadLine()) != null)
                    {
                        fuelList.Add(Int32.Parse(stringRow));
                    }
                }

                return fuelList;
            }
            else
                return null;
        }
    }
}
