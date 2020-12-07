using System;
using static AdventOfCode.ModuloDay07;

namespace AdventOfCode
{
    class Program
    {
        private const int Day = 7;

        static void Main(string[] args)
        {

            Console.WriteLine($"AdventOfCode Day {Day} Part One \n");
            var n1 = Solve();
            Console.WriteLine($"Found: {n1} ");


            Console.WriteLine($"\n\nAdventOfCode Day {Day} Part Two \n");
            var n2 = SolveTwo();
            Console.WriteLine($"Found: {n2} ");

            Console.WriteLine("\n\n\n\nPress any key to close");
            Console.ReadLine();
        }
    }
}
