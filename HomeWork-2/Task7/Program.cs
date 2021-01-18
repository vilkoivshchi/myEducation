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
            Console.WriteLine($"a: {a}");
            
            
            if (a < b)
            {
                PrintRecursively(a + 1, b);
            }
            
        }
        static void Main(string[] args)
        {
       
            
            int a = 1;
            int b = 5;
            PrintRecursively(a, b);
            
            Console.ReadKey();
        }
        #endregion
    }
}
