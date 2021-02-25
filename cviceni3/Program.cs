using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cviceni3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix1 = new double[,]
            {
                { 1, 9, 5 },
                { 3, 4, 10 },
                { 7, 8, 5 }
            };

            double[,] matrix2 = new double[,]
            {
                { 1, 5, 5 },
                { 3, 4, 5 },
                { 5, 6, 5 }
            };

            Matrix m1 = new Matrix(matrix1);
            Matrix m2 = new Matrix(matrix2);

            Console.WriteLine("Adding two matrixies together...");
            Console.WriteLine(m1 + m2);
            Console.WriteLine("Multipliing two matrixies together...");
            Console.WriteLine(m1 * m2);
            Console.WriteLine("Subtracting two matrixies together...");
            Console.WriteLine(m1 - m2);
            Console.WriteLine("Unary operation with matrix");
            Console.WriteLine(- m1);
            Console.WriteLine("Are those two matrixeis same?");
            Console.WriteLine(m1 == m2);
            Console.WriteLine("Nonequal?");
            Console.WriteLine(m1 != m2);
            Console.WriteLine("Getting determinant of first matrix...");
            Console.WriteLine(m2.Determinant());
            Console.ReadKey();
        }
    }
}
