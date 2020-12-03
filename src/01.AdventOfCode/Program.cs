using System;
using System.ComponentModel;

namespace AventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AdventOfCode Day 1 First");

            var (n1, n2) = ModuloDay01.Solve();
            Console.WriteLine($"Numbers Found: {n1} * {n2} = {n1 * n2}");


            Console.WriteLine("AdventOfCode Day 1 Second");

            var (s1, s2, s3) = ModuloDay01.SolveSecond();
            Console.WriteLine($"Numbers Found: {s1} * {s2} * {s3} = {s1 * s2 * s3}");

            Console.WriteLine("Press any key to close");

            Console.ReadLine();
        }
    }
}
