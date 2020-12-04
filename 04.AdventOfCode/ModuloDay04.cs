using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    internal static class ModuloDay04
    {


        private static IEnumerable<Passport> LoadData()
        {
            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(appPath, "data.txt");
            var lineas = File
                    .ReadLines(filePath, Encoding.UTF8)
                ;

            string partialPassportString = string.Empty;
            foreach (var linea in lineas)
            {
                if (string.IsNullOrEmpty(linea))
                {
                    yield return GetPassPort(partialPassportString);
                    partialPassportString = string.Empty;

                }
                else
                {
                    partialPassportString = $"{partialPassportString} {linea}";
                }
            }

            if (!string.IsNullOrEmpty(partialPassportString))
                yield return GetPassPort(partialPassportString);

        }

        private static Passport GetPassPort(string partialPassportString)
        {
            if (string.IsNullOrEmpty(partialPassportString)) return null;
            var p = new Passport();
            Type type = p.GetType();

            foreach (var s in partialPassportString.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {

                var keyValue = s
                    .Trim()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                type.GetProperty(keyValue[0])?.SetValue(p, keyValue[1]);
            }

            return p;

        }


        public static int Solve()
        {
            var data = LoadData();

            return data.Count(w => w.IsValidForProblemOne);
        }

        public static long SolveTwo()
        {

            var data = LoadData();
            return data.Count(w => w.IsValidForProblemTwo);

        }




    }

    internal class Passport
    {
        /*
            byr (Birth Year)
            iyr (Issue Year)
            eyr (Expiration Year)
            hgt (Height)
            hcl (Hair Color)
            ecl (Eye Color)
            pid (Passport ID)
            cid (Country ID)
        */

        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }


        public bool IsValidForProblemOne =>
            !string.IsNullOrEmpty(byr)
            && !string.IsNullOrEmpty(iyr)
            && !string.IsNullOrEmpty(eyr)
            && !string.IsNullOrEmpty(hgt)
            && !string.IsNullOrEmpty(hcl)
            && !string.IsNullOrEmpty(ecl)
            && !string.IsNullOrEmpty(pid)
        //    && !string.IsNullOrEmpty(cid)
        ;

        public bool IsValidForProblemTwo
        {
            get
            {
                var dev = true;

                dev &= byr.IsBetween(1920, 2002, 4);

                dev &= iyr.IsBetween(2010, 2020, 4);

                dev &= eyr.IsBetween(2020, 2030, 4);

                dev &= (!string.IsNullOrEmpty(hgt) &&
                        (
                             (hgt.Contains("cm") && hgt.IsBetween(150, 193, replaceToGetNumber: "cm"))
                             ||
                             (hgt.Contains("in") && hgt.IsBetween(59, 76, replaceToGetNumber: "in"))
                         )
                        );

                dev &= hcl.IsValidHcl();

                dev &= (!string.IsNullOrEmpty(ecl)
                        && "amb blu brn gry grn hzl oth"
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Contains(ecl.Trim())
                    );

                dev &= (!string.IsNullOrEmpty(pid) && pid.Length == 9 && long.TryParse(pid, out _));


                return dev;


            }
        }
    }

    public static class Extensions
    {
        public static bool IsBetween(this string cad, int from, int too, int minLeng = 0, string replaceToGetNumber = "")
        {
            if (string.IsNullOrEmpty(cad)) return false;

            if (cad.Length < minLeng) return false;

            if (!string.IsNullOrEmpty(replaceToGetNumber)) cad = cad.Replace(replaceToGetNumber, string.Empty);

            if (!int.TryParse(cad, out int n)) return false;

            return (from <= n && n <= too);


        }


        public static bool IsValidHcl(this string hcl)
        {
            if (string.IsNullOrEmpty(hcl)) return false;

            if (hcl.Trim().Length != 7 || hcl[0] != '#') return false;

            const string validChars = "0123456789abcdef";

            return hcl.Replace("#", string.Empty)
                .ToCharArray()
                .All(w => validChars.Contains(w));
            ;

        }
    }
}