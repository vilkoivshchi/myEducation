using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// 2.  а)  С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
    ///         Требуется подсчитать сумму всех нечетных положительных чисел. 
    ///         Сами числа и сумму вывести на экран, используя tryParse;
    ///     б)  Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
    ///         При возникновении ошибки вывести сообщение.Напишите соответствующую функцию;
    /// </summary>
    class Program
    {
      
        static void Main(string[] args)
        {
            int summ = 0;
            int inputInt;

            do
            {
                
                Console.Write("Введи число: ");
                if (Int32.TryParse(Console.ReadLine(), out inputInt))
                {
                    if (inputInt > 0 && inputInt % 2 != 0)
                        summ += inputInt;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"Нет!");
                    Console.ResetColor();
                    inputInt = 1;
                }
            }
            while (inputInt != 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Сумма всех нечетных положительных чисел равна {summ}");
            Console.ReadKey();

        }
    }
}
