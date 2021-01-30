using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// 1. Написать метод, возвращающий минимальное из трех чисел.
    /// Шмаков.
    /// </summary>
    class Program
    {
        static int MaxValue(int a, int b, int c)
        {
            int max;
            
            if (a > b)
            {
                max = a;
            } 
            else
            {
                max = b;
            }

            if (c > max)
            {
                max = c;
            } 
            

            return max;

        }
        static void Main(string[] args)
        {
            int a, b, c, max;
            Console.Write("Введите a: ");
            a = Int32.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            b = Int32.Parse(Console.ReadLine());
            Console.Write("Введите c: ");
            c = Int32.Parse(Console.ReadLine());

            max = MaxValue(a, b, c);

            Console.WriteLine($"Максимально число: {max}");

            Console.ReadKey();
        }
    }
}
