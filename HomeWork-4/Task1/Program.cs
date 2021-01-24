using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// 1. Дан целочисленный массив из 20 элементов. 
    /// Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
    /// Написать программу, позволяющую найти и вывести количество пар элементов массива, 
    /// в которых хотя бы одно число делится на 3. 
    /// В данной задаче под парой подразумевается два подряд идущих элемента массива. 
    /// Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
    /// Шмаков.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Создадим массив изаполним его (почти)случайными значениями.
        /// </summary>
        /// <param name="size">Количество элементов</param>
        /// <returns>Массив, заполненный (почти)случайными значениями.</returns>
        static int[] MakeArray(int size)
        {
            int[] array = new int[size];
            System.Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(-10000, 10000);

            }
            return array;
        }
        static void Main(string[] args)
        {
            // исходные данные.
            // размерность массива
            int arraySize = 20;
            // число, на которое должно делиться хотя бы одно число из пары элементов.
            int devider = 3;

            int[] myArray = MakeArray(arraySize);
            int counter = 0;
            
            for (int i = 1; i < myArray.Length; i++)
            {
                int oldValue = myArray[i - 1];
                int newValue = myArray[i];

                // чтобы не делать лишних проверок, сложим результат деления сюда
                float isOldValueDevide = oldValue % devider;
                float isNewValueDevide = newValue % devider;

                if (isOldValueDevide == 0 || isNewValueDevide == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    Console.Write($"Пара: {oldValue}\t{newValue}. ");
                    if (isOldValueDevide == 0)
                    {
                        Console.WriteLine($"\t{oldValue} делится на {devider}");
                    }
                    else if (isOldValueDevide == 0 && isNewValueDevide == 0)
                    { 
                         Console.WriteLine($"\t{oldValue} и {newValue} делятся на {devider}");
                    }
                    else if (isNewValueDevide == 0)
                    {
                        Console.WriteLine($"\t{newValue} делится на {devider}");
                    }
                    Console.ResetColor();
                    counter++;
                }
                else
                {
                    Console.WriteLine($"Пара: {oldValue}\t{newValue}.\tНи одно число из пары не делится на {devider}");
                }
    
            }
            Console.WriteLine(("").PadRight((Console.WindowWidth / 2), '-'));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Всего пар, один из эементов которых делится на {devider} == {counter}");
            Console.ReadKey();
        }
    }
}
