using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// 2. Написать метод подсчета количества цифр числа.
    /// </summary>
    class Program
    {
        static int CountChars(string input)
        {
            int count = 0;
            foreach(char charCount in input)
            {
                count++;
            }
            return count;
        }
            
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string inpuString = Console.ReadLine();
            Console.WriteLine(CountChars(inpuString));
            Console.ReadKey();
        }
    }
}
