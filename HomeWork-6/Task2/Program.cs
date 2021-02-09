using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Task2
{
    /// <summary>
    /// 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    /// а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
    /// б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
    /// в) * Переделайте функцию Load, чтобы она возвращала массив считанных значений.Пусть она
    /// возвращает минимум через параметр.
    /// Шмаков.
    /// </summary>
    
    class Program
    {
        
         
        delegate double F(double x1, double x2);
        
        static double Func1(double x1, double x2)
        {
            double step = 0.01;
            double x = x1;
            double y = 0;
            double min = 0;
            while (x <= x2)
            {
                
                y = (Math.Pow(x, 4) / 4) - Math.Pow(x, 3);
                if (min < y) y = min;
                x += step;
                
            }
            return Math.Round(y, 4);
            
        }

        static double Func2(double x1, double x2)
        {
            double step = 0.01;
            double x = x1;
            double y = 0;
            double min = 0;
            while (x <= x2)
            {

                y = (Math.Pow(x, 2)  - 8 * x + 1.0d );
                if (min < y) y = min;
                x += step;

            }
            return Math.Round(y, 4);

        }

        static void CalcF(F func, double a, double b)
        {
            Console.WriteLine($"{func(a, b)}");
        }

        static void Main(string[] args)
        {
            double x1 = -2.0d;
            double x2 = 2.0d;
            char cki;
            Console.WriteLine($"Выберите функцию:");
            Console.WriteLine($"1. y = (x ^ 4) / 4) - x ^ 3 ");
            Console.WriteLine($"2. y = (x ^ 2) - 8x + 1 ");
            Console.WriteLine();
            // тут грабли
            cki = Console.ReadKey().KeyChar;
            
                switch (cki)
                {
                    case '1':
                    Console.WriteLine();
                        CalcF(Func1, x1, x2);
                        break;
                    case '2':
                    Console.WriteLine();
                    CalcF(Func2, x1, x2);
                        break;
                }
            
        

            
            Console.ReadKey();
        }
        
    }
        
}
