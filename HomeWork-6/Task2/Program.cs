using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Task2
{
    /// <summary>
    /// 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    /// а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
    /// б) Используйте массив(или список) делегатов, в котором хранятся различные функции.
    /// в) * Переделайте функцию Load, чтобы она возвращала массив считанных значений.Пусть она
    /// возвращает минимум через параметр.
    /// </summary>
    
    class Program
    {
        /*
        delegate double F(double x);

        static double Func1(double x)
        {
            return x * x - 50 * x + 10;
        }

        static void CalcF(F func, int a)
        {
            Console.WriteLine($"{func(a)}");
        }
        static void SaveFunc(string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        static void Main(string[] args)
        {
            SaveFunc("data.bin", -100, 100, 0.5);
            Console.WriteLine(Program.Load("data.bin"));
            Console.ReadKey();
        }
        */
    }
        
}
