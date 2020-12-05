using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    internal static class ModuloDay05
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


            return data.Max(m => Calcula(m));

        }



        public static long SolveTwo()
        {

            var data = LoadData();

            var todosLosAsientos = data
                .Select(s => Calcula(s)).OrderBy(s => s)
                .ToList();

            var min = todosLosAsientos.Min();
            var max = todosLosAsientos.Max();

            //buscamos el que no exista en la lista entre las numeraciones tiene que ser el mío
            var miAsiento = Enumerable
                .Range(min, max - min + 1)
                .FirstOrDefault(s => !todosLosAsientos.Contains(s));

            return miAsiento;


        }

        private static int Calcula(string linea, bool debug = false)
        {
            int letraIndicanFilas = 7;

            int fmin = 0, fmax = 127;
            int cmin = 0, cmax = 7;

            for (int i = 0; i < linea.Length; i++)
            {
                char letra = linea[i];

                if (i < letraIndicanFilas)
                    (fmin, fmax) = GetPosition(letra, fmin, fmax);
                else
                    (cmin, cmax) = GetPosition(letra, cmin, cmax);
            }

            if (debug) Console.WriteLine($"\n\n\n\t RESULTADO: {fmin} {cmax} {(fmin * 8 + cmax)}");

          
            return fmin * 8 + cmax;
        }

        private static (int min, int max) GetPosition(char letra, int tMin, int tMax)
        {
            //(tMax - tmin +1 /2)+ tmin = res  -->  tmin --(res-1) || res --tmax

            int middle = (tMax - tMin + 1) / 2 + tMin;


            return (letra == 'F' || letra == 'L')
                ? (tMin, middle - 1)
                : (middle, tMax);



        }


    }

}