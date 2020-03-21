using System;

namespace Advent_code_5
{
    class RunProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("--- Day 5: Sunny with a Chance of Asteroids ---");
            Console.WriteLine();

            var managedComputer = new ManageComputer();

            //var answer = managedComputer.RunComputerDay2_1(); // Still OK
            //var answer = managedComputer.RunComputerDay2_2(); // Still OK

            var answer = managedComputer.RunComputerDay5();

            Console.WriteLine();
            Console.WriteLine("The right answer is: {0}", answer);
            Console.WriteLine();
            Console.WriteLine("Press any key to exit program.");
            Console.ReadKey();
        }
    }
}
