using System;

namespace Advent_code_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var passwordRange = new PasswordRange();

            Console.WriteLine();
            Console.WriteLine(" --- Day 4: Secure Container --- ");
            Console.WriteLine();
            Console.WriteLine("The number of passwords matching the rules are :" + "\n" +
                $" {passwordRange.PasswordAfterRulesPart1()} in part 1 and {passwordRange.PasswordAfterRulesPart2()} in part 2 .");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit the program.");
            Console.ReadKey();
        }
    }
}
