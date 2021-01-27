using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// 1. Создать программу, которая будет проверять корректность ввода логина. 
    /// Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    /// а) без использования регулярных выражений;
    /// б) с использованием регулярных выражений.
    /// </summary>
    class Program
    {
        static bool CheckLoginWithoutRegex(string login)
        {
            char[] loginArray = login.ToCharArray();
            bool loginCorrect = false;
            
            if ((loginArray.Length >= 2 && loginArray.Length <= 10) && ((loginArray[0] >= 'A' && loginArray[0] <= 'Z') || (loginArray[0] >= 'a' && loginArray[0] <= 'z')))


            {
                for (int i = 1; i < loginArray.Length; i++)
                {
                    if ((loginArray[i] >= '0' && loginArray[i] <= '9') || (loginArray[i] >= 'A' && loginArray[i] <= 'Z') || (loginArray[0] >= 'a' && loginArray[i] <= 'z'))
                    {
                        loginCorrect = true;
                    }
                }

            }
            return loginCorrect;
        }

        static void Main(string[] args)
        {
            

            Console.Write($"Введите логин: ");
            string login = Console.ReadLine();
            if (CheckLoginWithoutRegex(login))
            {
                Console.WriteLine($"login {login} удовлетворяет условиям задачи");
                    }
            else
            {
                Console.WriteLine($"login {login} НЕ удовлетворяет условиям задачи");
            }
            Console.ReadLine();
        }
    }
}
