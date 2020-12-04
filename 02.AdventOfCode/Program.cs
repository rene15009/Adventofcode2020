using System;

namespace AventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AdventOfCode Day 2 \n");

            var n1 = ModuloDay02.Solve();

            Console.WriteLine($"Passwords Found: {n1} ");

            Console.WriteLine("Press any key to close");
            Console.ReadLine();
        }
    }
}
