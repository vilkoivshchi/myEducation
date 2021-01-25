using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    /// <summary>
    /// 3. Решить задачу с логинами из предыдущего урока, 
    /// только логины и пароли считать из файла в массив. 
    /// Создайте структуру Account, содержащую Login и Password.
    /// </summary>
    class Program
    {
       
        struct Account
        {
            public Account(string _login, string _pass)
                {
                    login = _login;

                    password = _pass;
                }


            public string login { get; }
            public string password { get; }
            
        }

        static bool PasswordCheck(string login, string pass, string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string loginFromFile = reader.ReadLine();
            string passwordFromFile = reader.ReadLine();
            reader.Close();

            string[] accountData = new string[] { loginFromFile, passwordFromFile };
            Account account = new Account(accountData[0], accountData[1]);
            
            bool validAuth = false;

            if (login == account.login && pass == account.password) validAuth = true;

            return validAuth;
        }
        
        static void Main(string[] args)
        {
            string filename = "account.txt";
            string filename2 = AppDomain.CurrentDomain.BaseDirectory + filename;

            //string[] account = ReadLogin(filename2);

            bool validAuth = false;
            int count = 0;
            do
            {
                Console.Clear();
                Console.Write("Login: ");
                string userLogin = Console.ReadLine();
                Console.Write("Password: ");
                string userPass = Console.ReadLine();
                if (PasswordCheck(userLogin, userPass, filename2))
                {
                    validAuth = true;
                    break;
                }
                count++;
            }
            while (count < 3);
            if (validAuth)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Аутентификация прошла успешно");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы превысили количество попыток");
                Console.ResetColor();
            }
            Console.ReadKey();

        }
    }
}
