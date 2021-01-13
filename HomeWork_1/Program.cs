using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTask1
{
    /// <summary>
    /// 1. Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
    /// В результате вся информация выводится в одну строчку.
    /// а) используя склеивание;
    /// б) используя форматированный вывод;
    /// в) * используя вывод со знаком $.
    /// Шмаков
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            #region Task1
            Console.WriteLine("Привет, давай знакомится. Представься пожлуйста.");
            Console.Write("Имя: ");
            string userName = Console.ReadLine();
            Console.Write("Отчество: ");
            string userMidName = Console.ReadLine();
            Console.Write("Фамилия: ");
            string userLastName = Console.ReadLine();
            Console.WriteLine("Привет, " + userName + " " + userMidName + " " + userLastName + "!");
            Console.WriteLine("Привет, {0} {1} {2}!", userName, userMidName, userLastName);
            Console.WriteLine($"Привет, {userName} {userMidName} {userLastName}!");
            Console.ReadLine();

            #endregion


        }
    }
}
