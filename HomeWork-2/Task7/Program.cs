using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    /// <summary>
    /// 7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b (a<b);
    /// б) *Разработать рекурсивный метод, который считает сумму чисел от a до b
    /// Шмаков.
    /// </summary>
    class Program
    {

        
        #region Task7
        static void PrintRecursively(int a, int b)
        {

            Console.WriteLine($"Текущее число: {a}");
            if (a < b)
            {
                PrintRecursively(a + 1, b);
            }
            
        }
        static void Main(string[] args)
        {
            Console.Write("Введите a: ");
            int a = Int32.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            int b = Int32.Parse(Console.ReadLine());
            PrintRecursively(a, b);
            Console.WriteLine($"Сумма целых чисел от {a} до {b} : {RecursiveSumm(a, b)}");
            Console.ReadKey();
        }
        #endregion
        
        #region Task7*

        static int RecursiveSumm(int a, int b)
        {
        return a == b? b : a + RecursiveSumm(a + 1, b);
        }

        #endregion
    }
}
