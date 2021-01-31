using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// 1. Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
    /// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
    /// </summary>
    
    public delegate double Fun(double a, double b);

    class Program
    {
        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, b));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Функция a*x^2
        public static double MyFunc(double x, double a)
        {
            return a * Math.Pow(x, 2);
        }
        

        static void Main()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            
            Console.WriteLine("Функция a*x^2");
                        
            Table(MyFunc, -2, 2);
            
            // Анонимный метод, считающий a*Sin(x)
            Console.WriteLine("Таблица функции a*Sin(x):");
            Table(delegate (double x, double a) { return a * Math.Sin(x); }, 0, 3);
            Console.ReadKey();
        }
    }

}
