using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTask3
{
    /// <summary>
    /// 3.
    /// а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
    /// по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
    /// Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
    /// б) * Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода;
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1">Координата x1</param>
        /// <param name="y1">Координата y1</param>
        /// <param name="x2">Координата x2</param>
        /// <param name="y2">Координата y2</param>
        /// <returns>Результат рассчета</returns>
        static double CalculateR(double x1, double y1, double x2, double y2)
        {
            
            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return r;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Давайте посчитаем расстояние между координатами.");
            Console.WriteLine("Для этого введите:");
            Console.Write("x1: ");
            string x1String = Console.ReadLine();
            Console.Write("y1: ");
            string y1String = Console.ReadLine();
            Console.Write("x2: ");
            string x2String = Console.ReadLine();
            Console.Write("y2: ");
            string y2String = Console.ReadLine();
            
            //конвертируем string в double
            double x1 = Convert.ToDouble(x1String);
            double y1 = Convert.ToDouble(y1String);
            double x2 = Convert.ToDouble(x2String);
            double y2 = Convert.ToDouble(y2String);

            //double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double r = CalculateR(x1, y1, x2, y2);

            Console.WriteLine("Расстояние: {0:F2}", r);
            Console.ReadLine();

        }
    }
}
