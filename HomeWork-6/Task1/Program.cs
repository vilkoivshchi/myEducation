using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// 1. Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
    /// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
    /// Шмаков.
    /// </summary>
    


    delegate double DoOperation(double x, double y);

    class Program
    {
        static double Plus(double a, double b)
        {
            Console.Write($"{a} + {b}");
            return a + b;
        }

        static double Minus(double a, double b)
        {
            Console.Write($"{a} - {b}");
            return a - b;
        }
        /// <summary>
        /// Первая часть задания
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        static double Pow2(double a, double x)
        {
            Console.Write($"{a} * {x}^2");
            return a * Math.Pow((x), 2);
        }

        /// <summary>
        /// Вторая часть задания
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        static double SinX(double a, double x)
        {
            Console.Write($"{a}*sin({x})");
            return a * Math.Sin(x);
        }

        static void Process(DoOperation operation12, double x, double y)
        {
            Console.WriteLine($" = {operation12(x, y)}");
            Console.WriteLine();
        }

        static void ProcessDivision(string txt, double x, double y, DoOperation operation12)
        {
            Console.WriteLine($" ({txt}): {operation12(x, y)}");
        }
       

        static void Main(string[] args)
        {
            Process(Plus, 2, 3);
            Process(Minus, 40, -3);
            Process(Pow2, 2, 3);
            Process(SinX, 2, 30);

            DoOperation miltiOperation = delegate (double x, double y)
            {
                Console.Write($"{x} * {y}");
                return x * y;
            };

            Console.WriteLine($" = {miltiOperation(5, 5)}");

            ProcessDivision("Результат деления", 20, 2, delegate (double x, double y)
            {
                Console.Write($"{x} / {y}");
                return x / y;
            });

           
            Console.ReadKey();
        }
    }
}
