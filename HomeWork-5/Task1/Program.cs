using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// 1. Создать программу, которая будет проверять корректность ввода логина. 
    /// Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    /// а) без использования регулярных выражений;
    /// б) с использованием регулярных выражений.
    /// Шмаков.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Проверяет корректность ввода логина без регулярок
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        static bool CheckLoginWithoutRegex(string login)
        {
            char[] loginArray = login.ToCharArray();
            bool loginCorrect = false;

            if ((loginArray.Length >= 2 && loginArray.Length <= 10) && ((loginArray[0] >= 'A' && loginArray[0] <= 'Z') || (loginArray[0] >= 'a' && loginArray[0] <= 'z')))
            {
                for (int i = 1; i < loginArray.Length; i++)
                {
                    if ((loginArray[i] >= '0' && loginArray[i] <= '9') || (loginArray[i] >= 'A' && loginArray[i] <= 'Z') || (loginArray[i] >= 'a' && loginArray[i] <= 'z'))
                        
                    {
                        loginCorrect = true;
                    }
                }

            }
            return loginCorrect;
        }

        /// <summary>
        /// Проверяет корректность ввода логина c регулярками
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        static bool CheckLoginWithRegex(string login)
        {
            bool loginCorrect = false;
            Regex check = new Regex(@"^(?!\d)([A-Za-z0-9]{2,10})$");
            if (check.IsMatch(login)) loginCorrect = true;
            return loginCorrect;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write($"Введите логин: ");
                string login = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine($"Проверка логина без регулярок:");
                Console.WriteLine(CheckLoginWithoutRegex(login) ? $"login {login} удовлетворяет условиям задачи" : $"login {login} НЕ удовлетворяет условиям задачи");
                Console.WriteLine();
                Console.WriteLine($"Проверка логина с регулярками:");
                Console.WriteLine(CheckLoginWithRegex(login) ? $"login {login} удовлетворяет условиям задачи" : $"login {login} НЕ удовлетворяет условиям задачи");
            }
            
          
        }
    }
}
