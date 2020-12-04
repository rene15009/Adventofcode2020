using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AdventOfCode Day 3 Part One \n");
            var n1 = ModuloDay03.Solve();
            Console.WriteLine($"Trees found: {n1} ");

          
            Console.WriteLine("AdventOfCode Day 3 Part Two \n");
            var n2 = ModuloDay03.SolveTwo();
            Console.WriteLine($"Trees found: {n2} ");
            
            Console.WriteLine("Press any key to close");
            Console.ReadLine();
        }
    }
}
