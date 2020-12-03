using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AventOfCode
{
    internal static class ModuloDay01
    {
        private const int ResultadoSuma = 2020;
        private static List<int> _menores;
        private static List<int> _mayores;


        static ModuloDay01()
        {
            LoadData(); //Cargar el archivo o pedirlo a internet https://adventofcode.com/2020/day/1/input
        }

        private static void LoadData()
        {
            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(appPath, "data.txt");


            _mayores = new List<int>();
            _menores = new List<int>();
            int discriminador = ResultadoSuma / 2;


            foreach (string line in File.ReadLines(filePath, Encoding.UTF8))
            {

                if (!int.TryParse(line, out var n)) continue;

                if (n > discriminador) { _mayores.Add(n); }
                else { _menores.Add(n); }
            }


        }

        public static (int a, int b) Solve()
        {
            foreach (int menor in _menores)
            {
                int toFind = ResultadoSuma - menor;
                if (_mayores.Any(w => w == toFind))
                {
                    return (menor, toFind);
                }
            }

            return (-1, -1); //no encontrado
        }

        public static (int a, int b, int c) SolveSecond()
        {

            foreach (int primerTermino in _menores)
            {
                int topeSegundoTermino = ResultadoSuma - primerTermino;
                var candidatos = _mayores.Where(w => w < topeSegundoTermino)
                    .Concat(_menores.Where(w => w < topeSegundoTermino && w != primerTermino));

                foreach (var segundoTermino in candidatos)
                {
                    int toFind = ResultadoSuma - segundoTermino - primerTermino;

                    //descartamos números repetidos, ni idea si se daria el caso :P
                    if ((toFind != primerTermino && _menores.Any(w => w == toFind))
                        || (toFind != segundoTermino && _mayores.Any(w => w == toFind)))
                    {
                        return (primerTermino, segundoTermino, toFind);
                    }

                }
            }

            return (-1, -1, -1); //no encontrado
        }

    }
}