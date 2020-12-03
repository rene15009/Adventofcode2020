using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AventOfCode
{
    internal static class ModuloDay02
    {
        public static (int firstPart, int secondPart) Solve()
        {
            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(appPath, "data.txt");


            int fn = 0, sn = 0;
            foreach (string line in File.ReadLines(filePath, Encoding.UTF8))
            {
                var (f, s) = IsValidRecord(line);

                if (f) fn ++;
                if (s) sn++;
            }

            return (fn, sn);
        }

        private static (bool firstPart, bool secondPart) IsValidRecord(string record)
        {
            var (min, max, letter, password) = DeconstructRecord(record);
            var nLetters = password.ToCharArray().Count(w => w == letter);



            return (
                firstPart: (min <= nLetters && nLetters <= max),
                secondPart: (max <= password.Length
                             && (password[min - 1] == letter ^ password[max - 1] == letter))

                );
        }

        private static (int min, int max, char letter, string password) DeconstructRecord(string record)
        {
            var segmentos = record.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var maxMin = segmentos[0].Split('-', StringSplitOptions.RemoveEmptyEntries);

            int.TryParse(maxMin[0], out int min);
            int.TryParse(maxMin[1], out int max);

            char.TryParse(segmentos[1].Replace(":", string.Empty).Trim(), out char letra);



            return (min, max, letra, segmentos.LastOrDefault()?.Trim());



        }

    }
}