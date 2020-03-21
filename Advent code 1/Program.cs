using System;

namespace Advent_code_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var spaceShip = new SpaceShip();
            spaceShip.GetSpaceShipData();

            ShowInConsole(spaceShip);
        }

        private static void ShowInConsole(SpaceShip spaceShip)
        {
            Console.WriteLine();
            Console.WriteLine("--- Day 1: The Tyranny of the Rocket Equation ---");
            Console.WriteLine();
            Console.WriteLine($"Part 1, the spaceship is fueled up with {spaceShip.FuelModulesPart1()} , and is ready to fly!");
            Console.WriteLine();
            Console.WriteLine($"Part 2, the spaceship is fueled up with {spaceShip.FuelModulesPart2()} , and is ready to fly!");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit program.");
            Console.ReadKey();
        }
    }
}
