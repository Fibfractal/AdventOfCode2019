using System;

namespace Advent_code_2
{
    class RunProgram
    {
        static void Main(string[] args)
        {
            var managedComputer = new ManageComputer();

            Console.WriteLine();
            Console.WriteLine("--- Day 2: 1202 Program Alarm ---");
            Console.WriteLine();
            Console.WriteLine("Part 1, the right answer is: {0}", managedComputer.RunComputerPart1());
            Console.WriteLine();
            Console.WriteLine("Loading ...");
            Console.WriteLine();
            Console.WriteLine("Part 2, the right answer is: {0}", managedComputer.RunComputerPart2());
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
