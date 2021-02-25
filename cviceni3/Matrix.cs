using System;

namespace cviceni3
{
    /// <summary>
    /// Matrix class is class for working with two matrix
    /// </summary>
    public class Matrix
    {
        double[,] matrix;

        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
        }

        /// <summary>
        /// Adding operation for two matrix
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            try
            {
                var mtx = new Matrix(
                    new double[a.matrix.GetLength(0), a.matrix.GetLength(1)]);
                for (int i = 0; i < a.matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < a.matrix.GetLength(1); j++)
                    {
                        mtx.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                    }
                }
                return mtx;
            }
            catch
            {
                Console.WriteLine("Error: incorect matrix size");
            }

            return a;
        }

        /// <summary>
        /// Subtracting two matrix
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            try
            {
                var mtx = new Matrix(
                       new double[a.matrix.GetLength(0), a.matrix.GetLength(1)]);
                for (int i = 0; i < a.matrix.GetLength(1); i++)
                {
                    for (int j = 0; j < a.matrix.GetLength(0); j++)
                    {
                        mtx.matrix[i, j] = a.matrix[j, i] - b.matrix[j, i];
                    }
                }
                return mtx;
            }
            catch
            {
                Console.WriteLine("Error: incorect matrix size");
            }
            return a;
        }

        /// <summary>
        /// Multipling two matrix
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">first matrix</param>
        /// <returns></returns>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            try
            {
                var mtx = new Matrix(
                    new double[a.matrix.GetLength(0), a.matrix.GetLength(1)]);
                var c = mtx.matrix;
                for (int i = 0; i < c.GetLength(0); i++)
                {
                    for (int j = 0; j < c.GetLength(1); j++)
                    {
                        c[i, j] = 0;
                        for (int k = 0; k < a.matrix.GetLength(1); k++) // OR k<b.GetLength(0)
                            c[i, j] = c[i, j] + a.matrix[i, k] * b.matrix[k, j];
                    }
                }
                mtx.matrix = c;
                return mtx;
            }
            catch
            {
                Console.WriteLine("Error: incorect matrix size");

            }

            return a;

        }

        /// <summary>
        /// Bool operation for comparing two matrix. This one is for getting equal
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        public static bool operator ==(Matrix a, Matrix b)
        {
            try
            {
                for (int i = 0; i < a.matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < a.matrix.GetLength(1); j++)
                    {
                        if (a.matrix[i, j] != b.matrix[i, j]) return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Bool operation for comparing two matrix. This one is for getting not equal
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Matrix a, Matrix b)
        {
            try
            {
                for (int i = 0; i < a.matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < a.matrix.GetLength(1); j++)
                    {
                        if (a.matrix[j, i] == b.matrix[j, i]) 
                        { 
                            return false; 
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Unary operation for only one matrix
        /// </summary>
        /// <param name="a">Only one parameter for this operation</param>
        /// <returns></returns>
        public static Matrix operator -(Matrix a)
        {
            var mtx = new Matrix(
                    new double[a.matrix.GetLength(0), a.matrix.GetLength(1)]);
            for (int i = 0; i < a.matrix.GetLength(1); i++)
            {
                for (int j = 0; j < a.matrix.GetLength(0); j++)
                {
                    mtx.matrix[j, i] = a.matrix[j, i] * (-1);
                }
            }

            return mtx;
        }

        /// <summary>
        /// Operation for getting matrix determinant. Only works for matrix that is 3x3
        /// </summary>
        /// <returns></returns>
        public double Determinant()
        {
            try
            {
                if (matrix.GetLength(0) == matrix.GetLength(1) && matrix.GetLength(1) == 1)
                {
                    return matrix[0, 0];
                }
                else if (matrix.GetLength(0) == matrix.GetLength(1) && matrix.GetLength(1) == 2)
                {
                    return matrix[0, 0] * (matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);

                }
                else if (matrix.GetLength(0) == matrix.GetLength(1) && matrix.GetLength(1) == 3)
                {
                    var determinant = matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) -
                                      matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]) +
                                      matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);

                    return determinant;
                }
            }
            catch
            {
                Console.WriteLine("Size of matrix is bigger then 3x3");
            }
            return 0;
        }

        /// <summary>
        /// As reuested from assignment override method for ToString() to give us better display of matrix
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != matrix.GetLength(0) - 1) output += $"{matrix[i, j]},";
                }
                output += Environment.NewLine;
            }

            return output;
        }



    }
}
