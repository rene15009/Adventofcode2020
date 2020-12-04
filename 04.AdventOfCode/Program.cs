using System;
using static AdventOfCode.ModuloDay04;

namespace AdventOfCode
{
    class Program
    {
        private const int day = 4;

        static void Main(string[] args)
        {
            
            Console.WriteLine($"AdventOfCode Day {day} Part One \n");
            var n1 = Solve();
            Console.WriteLine($"Found: {n1} ");

          
            Console.WriteLine($"\n\nAdventOfCode Day {day} Part Two \n");
            var n2 = SolveTwo();
            Console.WriteLine($"Found: {n2} ");
            
            Console.WriteLine("Press any key to close");
            Console.ReadLine();
        }
    }
}
