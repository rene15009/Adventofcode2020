using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    internal static class ModuloDay03
    {
        private static int lLinea = 1;

        private static char[,] Matrix = null;

        private static char[,] LoadData()
        {
            if (Matrix != null) return Matrix;

            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(appPath, "data.txt");

            var lineas = File
                .ReadLines(filePath, Encoding.UTF8)
                .ToList();

            int topeY = lineas.Count;
            int topeX = lLinea = lineas.Max(s => s.Length);


            char[,] dev = new char[topeY, topeX];



            int i = 0;
            foreach (var fila in lineas.Select(linea => linea.ToCharArray()))
            {

                for (int j = 0; j < fila.Length; j++)
                {
                    dev[i, j] = fila[j];
                }

                i++;
            }

            Matrix = dev;

            return dev;

        }

        //Este es el pedido en el primer ejercicio
        public static int Solve() => SolveXY(3, 1);

        public static int SolveTwo()
        {
            /*
                Right 1, down 1.
                Right 3, down 1. (This is the slope you already checked.)
                Right 5, down 1.
                Right 7, down 1.
                Right 1, down 2.          
             */

            var n1 = SolveXY(1, 1);
            var n2 = SolveXY(3, 1);
            var n3 = SolveXY(5, 1);
            var n4 = SolveXY(7, 1);
            var n5 = SolveXY(1, 2);

            return n5 * n4 * n3 * n2 * n1;
        }

        public static int SolveXY(int steepX, int steepY)
        {
            var matrix = LoadData();

            int n = 0;
            for (int x = 0, y = 0;
                y < matrix.GetLength(0);
                x += steepX, y += steepY)
            {
                if (matrix[y, x % 31] == '#') n++;
            }

            return n;
        }




    }
}