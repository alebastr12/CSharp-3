using System;
using System.Threading;
using System.Threading.Tasks;

namespace lesson6_TPLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность массивов:");
            uint nArr;
            int[,] a,b;
            Random r = new Random();
            if (uint.TryParse(Console.ReadLine(), out nArr))
            {
                a = new int[nArr, nArr];
                b = new int[nArr, nArr];
                for (int i = 0; i < nArr; i++)
                {
                    for (int j = 0; j < nArr; j++)
                    {
                        a[i, j] = r.Next(10);
                        b[i, j] = r.Next(10);
                    }
                }
                //Console.WriteLine("Матрица А:");
                //PrintMatrix(a);
                //Console.WriteLine("Матрица Б:");
                //PrintMatrix(b);
                DateTime start = DateTime.Now;
                int[,] c = MatrixMul(a, b);
                Console.WriteLine($"Результат последовательно {DateTime.Now-start}");
                //PrintMatrix(c);
                start = DateTime.Now;
                c = ParallelMatrixMul(a, b);
                Console.WriteLine($"Результат параллельно {DateTime.Now-start}");
                //PrintMatrix(c);
            } else
            {
                Console.WriteLine("Нужно ввести целое положительное число.");
            }
        }
        static void PrintMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(1); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    Console.Write($"{a[i,j],3} ");
                }
                Console.WriteLine();
            }
        }
        static int[,] MatrixMul(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) return new int[0, 0];
            int nx = a.GetLength(0);
            int ny = b.GetLength(1);
            int[,] result = new int[nx, ny];
            for (int i = 0; i < ny; i++)
            {
                for (int j = 0; j < nx; j++)
                {
                    for (int k = 0; k < nx; k++)
                    {
                        result[i, j] += a[i,k]*b[k,j];
                    }
                }
            }
            return result;
        }
        
        static int[,] ParallelMatrixMul(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) return new int[0,0];
            int nx = a.GetLength(0);
            int ny = b.GetLength(1);
            int[,] result = new int[nx, ny];
            Parallel.For(0, ny, (i) =>
            {
                Parallel.For(0, nx, (j) =>
                {
                    for (int k = 0; k < nx; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                    //Parallel.For(0, nx, (k) =>
                    //{
                    //    result[i, j] += a[i, k] * b[k, j];
                    //});
                });
            });
            return result;
        }
    }

}
