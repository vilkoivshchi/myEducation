using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    
    class Program
    {
        struct Account
        {

            public string login, password;
            
        }

        static bool PasswordCheck(string login, string pass, string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string loginFromFile = reader.ReadLine();
            string passwordFromFile = reader.ReadLine();
            reader.Close();

            bool validAuth = false;

            if (login == loginFromFile && pass == passwordFromFile) validAuth = true;

            return validAuth;
        }

        static string[] ReadLogin(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string login = reader.ReadLine();
            string password = reader.ReadLine();
            reader.Close();
            string[] account = new string[] { login, password };
            Account accStruct = new Account();
            accStruct.login = login;
            accStruct.password = password;
            return account;
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
                Console.WriteLine("Аутентификация прошла усппешно");
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
