using System;

namespace Advent_code_5
{
    static public class Input
    {
        static public int InputToInteger()
        {
            bool inputOk = false;
            int output = 0;

            while (!inputOk)
            {
                Console.Write("Enter input: ");
                inputOk = Int32.TryParse(Console.ReadLine(), out output);
                if (!inputOk)
                    Console.WriteLine("Input must be an integer!");
                Console.WriteLine();
            }

            return output;
        }
    }
}
