using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent_code_5
{
    public class ImportProgram
    {
        public List<int> Day2Code()
        {
            var program = new List<int>();

            if (File.Exists("OptCodeProgram.txt"))
            {
                using (var steamReader = new StreamReader("OptCodeProgram.txt", Encoding.Default, true))
                {
                    var stringRow = "";
                    string[] numbersOneRow;

                    while ((stringRow = steamReader.ReadLine()) != null)
                    {
                        numbersOneRow = stringRow.Split(',');

                        foreach (string number in numbersOneRow)
                        {
                            program.Add(Int32.Parse(number));
                        }
                    }
                }
                return program;
            }
            else
                return null;
        }

        public List<int> Day5Code()
        {
            var program = new List<int>();

            if (File.Exists("DiagnosticProgram.txt"))
            {
                using (var steamReader = new StreamReader("DiagnosticProgram.txt", Encoding.Default, true))
                {
                    var stringRow = "";
                    string[] numbersOneRow;

                    while ((stringRow = steamReader.ReadLine()) != null)
                    {
                        numbersOneRow = stringRow.Split(',');

                        foreach (string number in numbersOneRow)
                        {
                            program.Add(Int32.Parse(number));
                        }
                    }
                }
                return program;
            }
            else
                return null;
        }
    }
}

