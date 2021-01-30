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
        
        static int CheckInput(string input)
        {
            int inputInt;
            if (Int32.TryParse(input, out inputInt))
            {
                // Если строка распарсилась, число > 0 и нечётное, то возвращаем значение
                if (inputInt > 0 && inputInt % 2 != 0)
                {
                    return inputInt;
                }
                
                else if (inputInt == 0)
                {
                    return 0;
                }
                
                else
                {
                    return -1;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Нет!");
                Console.ResetColor();
                return -1;
            }
            

        }
        

        static void Main(string[] args)
        {
            int summ = 0;
            int inputInt;

            do
            {
               
                Console.Write("Введи число: ");
                inputInt = CheckInput(Console.ReadLine());
                
                if(inputInt != -1)
                {
                    summ += inputInt;
                }
            }
            while (inputInt != 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Сумма всех нечетных положительных чисел равна {summ}");
            Console.ReadKey();

        }
    }
    

}
