using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// 4. Реализовать метод проверки логина и пароля. На вход подается логин и пароль. 
    /// На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
    /// Используя метод проверки логина и пароля, написать программу: 
    /// пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
    /// С помощью цикла do while ограничить ввод пароля тремя попытками.
    /// </summary>
    class Program
    {
        static bool PasswordCheck(string login, string pass)
        {
            bool validAuth = false;
            
            if (login == "root" && pass == "GeekBrains") validAuth = true;

            return validAuth;
        }
        static void Main(string[] args)
        {
            bool validAuth = false;
            int count = 0;
            do
            {
                Console.Clear();
                Console.Write("Login: ");
                string userLogin = Console.ReadLine();
                Console.Write("Password: ");
                string userPass = Console.ReadLine();
                if (PasswordCheck(userLogin, userPass))
                {
                    validAuth = true;
                    break;
                }
                count++;
            }
            while (count < 3);
            if (validAuth)
            {
                Console.WriteLine("Аутентификация прошла усппешно");
            } else
            {
                Console.WriteLine("Вы превысили количество попыток");
            }
            Console.ReadKey();
        }
    }
}
