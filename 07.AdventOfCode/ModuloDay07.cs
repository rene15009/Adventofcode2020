using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    internal static class ModuloDay07
    {

        /// <summary>
        /// return one linea by item
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> LoadData()
        {
            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(appPath!, "data.txt");

            var lineas = File
                    .ReadLines(filePath, Encoding.UTF8)
                ;


            return lineas;


        }




        public static int Solve()
        {
            var data = LoadData().ToList();

            var bagsPuedenContenerShiny = data
                .Where(s => s.ContainsShinyGold(new List<string> { "shiny gold" }))
                .Select(s => s.ToBagName())
                .Distinct();
            
           // bagsPuedenContenerShiny=new List<string>{ "shiny gold" };


            var containsShinyGold = data
                .Where(s => s.ContainsShinyGold(bagsPuedenContenerShiny))
                .Select(s=>s.ToBagName());

            Console.WriteLine("\n\n Bolsos\n");
            containsShinyGold.ToList().ForEach(Console.WriteLine);

           var coloreS= containsShinyGold.Select(s =>
            {
                var aux = s.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                return aux[1];
            }).ToList();

           Console.WriteLine("\n\n Colores \n");
           coloreS.ForEach(Console.WriteLine);

           Console.WriteLine("\n\n Colores Unicos\n");
           coloreS.Distinct().ToList().ForEach(Console.WriteLine);

            return coloreS.Distinct().Count();
        }



        public static long SolveTwo()
        {

            var data = LoadData();

            return data.Count();

        }


        private static bool ContainsShinyGold(this string linea, IEnumerable<string> bagsPuedenContenerShiny)
        {


            return !linea.StartsWith("shiny gold") && (linea.Contains("shiny gold") || bagsPuedenContenerShiny.Any(s => linea.Contains(s)));
        }

        private static string ToBagName(this string linea)
        {
            var bags = linea.Split("bags", StringSplitOptions.RemoveEmptyEntries);

            if (bags == null || bags.Length == 0) return null;

            return bags[0];

        }


        private static int CountSameLettersInGroup(this List<string> group)
        {
            //97-122 int counters[27]; //--> [0] ->a, [1] ->b .... [26]->z
            int[] counters = new int[27];

            foreach (byte[] answersByPerson in group.Select(s => Encoding.ASCII.GetBytes(s.ToLower())))
            {
                foreach (var asciiCharInCounterPosition in answersByPerson.Select(s => s - 97))
                {
                    counters[asciiCharInCounterPosition]++;
                }
            }

            //obtenemos las preguntas que todos contestaron si, que serán las que tengan tantos sis como grupos,
            //es decir que el contador de repeticiones sea igual al número de personas en el grupo.

            return counters.Count(i => i == @group.Count);



        }

    }

}