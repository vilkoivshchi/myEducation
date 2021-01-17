using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// 3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел. 
    ///
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int summ = 0;
            int inputInt;

            do
            {
                Console.Clear();
                Console.Write("Введи число: ");
                inputInt = Int32.Parse(Console.ReadLine());
                if (inputInt > 0 && inputInt % 2 != 0) 
                    summ += inputInt;

            }
            while (inputInt != 0);
            Console.WriteLine($"Сумма всех нечетных положительных чисел равна {summ}");
            Console.ReadKey();




        }
    }
}
