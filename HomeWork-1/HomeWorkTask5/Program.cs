using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTask5
{
    /// <summary>
    /// 5.
    /// а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
    /// б) Сделать задание, только вывод организуйте в центре экрана
    /// в) * Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет, давай знакомится. Опять. Представься пожлуйста.");
            Console.Write("Имя: ");
            string userName = Console.ReadLine();
            Console.Write("Фамилия: ");
            string userLastName = Console.ReadLine();
            Console.Write("Откуда ты: ");
            string userCity = Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine($"Привет, {userName} {userLastName} из {userCity}");
            Console.Read();


        }
    }
}
