using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    internal static class ModuloDay06
    {


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
            var data = LoadData();


            return data.Count();

        }



        public static long SolveTwo()
        {

            var data = LoadData();
            return data.Count();


        }


    }

}