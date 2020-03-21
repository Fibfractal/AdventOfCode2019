using System;

namespace Advent_code_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var frontPanel = new FrontPanelGrid(new ImportWirePaths().ImportPaths());

            Console.WriteLine();
            Console.WriteLine("--- Day 3: Crossed Wires ---");
            Console.WriteLine();
            Console.WriteLine("The closest Manhattan distance and the shortest path to a wire crossing are:"
                + "\n" + $" {frontPanel.ManhattanDistance()} and {frontPanel.ShortestPath()} .");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit program.");
            Console.ReadKey();
        }
    }
}
