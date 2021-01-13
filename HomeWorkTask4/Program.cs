using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTask4
{
/// <summary>
/// 4. Написать программу обмена значениями двух переменных.
/// а) с использованием третьей переменной;
/// б) * без использования третьей переменной.
/// Шмаков
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Настало время поменять местами переменные");
            Console.Write("Введи a (целое):");
            string stringA = Console.ReadLine();
            Console.Write("Введи b (целое):");
            string stringB = Console.ReadLine();
            int a = Convert.ToInt32(stringA);
            int b = Convert.ToInt32(stringB);
            /*
            int c = b;
            b = a;
            a = c;
            */
            a -= b;
            b = a + 2 * b;
            a = (b - a) / 2;
            b = (b - a);
            Console.WriteLine($"А теперь a={a}, b={b}");
            Console.ReadLine();
        }
    }
}
