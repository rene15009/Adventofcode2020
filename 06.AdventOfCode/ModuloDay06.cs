using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    internal static class ModuloDay06
    {

        /// <summary>
        /// return one group by item
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> LoadData()
        {
            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(appPath!, "data.txt");

            var lineas = File
                    .ReadLines(filePath, Encoding.UTF8)
                ;

            string group = string.Empty;
            foreach (var linea in lineas)
            {
                if (string.IsNullOrEmpty(linea.Trim()))
                {
                    yield return group;
                    group = string.Empty;
                }
                else
                {
                    group = $"{group}{linea}";
                }

            }


            if (!string.IsNullOrEmpty(group)) yield return group;


        }



        /// <summary>
        /// return one group by item
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<List<string>> LoadDataInGroups()
        {
            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(appPath!, "data.txt");

            var lineas = File
                    .ReadLines(filePath, Encoding.UTF8)
                ;

            List<string> group = new List<string>();
            foreach (var linea in lineas)
            {
                if (string.IsNullOrEmpty(linea.Trim()))
                {
                    yield return group;
                    group = new List<string>();
                }
                else
                {
                    group.Add(linea);
                }

            }


            if (@group.Any()) yield return group;


        }



        public static int Solve()
        {
            var data = LoadData();


            return data.Sum(s => s.CountDifernetLetters());

        }



        public static long SolveTwo()
        {

            var data = LoadDataInGroups();

            return data.Sum(s => s.CountSameLettersInGroup());

        }


        private static int CountDifernetLetters(this string group)
        {
            return group.ToCharArray().Distinct().Count();
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