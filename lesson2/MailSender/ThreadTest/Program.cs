using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write($"Введите положительное число (CPU {Environment.ProcessorCount}):");
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine($"Рекурсивный факториал: {Factorial(n)}");
                Console.WriteLine($"Параллельный факториал: {ParallelFactorial(n)}");
            }

        }

        static double ParallelFactorial(int n)
        {
            double fact = 1;
            object _locker = new object();
            int nCPU = Environment.ProcessorCount;
            if (n <= nCPU) fact = Factorial(n);
            else
            {
                var tasks = new List<Task>();
                for (int i = 0; i < n; i+=n/nCPU)
                {
                    int right = (i + n / nCPU) > n ? n : i + n / nCPU;
                    int left = i + 1;
                    tasks.Add(Task.Run(() =>
                    {
                        double res = FactorialFromTo(left, right);
                        lock (_locker)
                        {
                            fact *= res;
                        }
                    }));
                    //ThreadPool.QueueUserWorkItem((e) =>
                    //{
                    //    double res=FactorialFromTo(i + 1, right);
                    //    lock (_locker)
                    //    {
                    //        fact *= res;
                    //    }
                    //});
                }
                Task.WaitAll(tasks.ToArray());
            }
            return fact;
        }
        static double FactorialFromTo(int from, int to)
        {
            double fact = from==0?1:from;
            while (from < to)
            {
                fact *= (from + 1);
                from++;
            }
            return fact;
        }
        static double Factorial(int n)
        {
            if (n == 0) return 1;
            return n * Factorial(n - 1);
        }
    }
}
