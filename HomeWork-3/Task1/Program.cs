using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{/// <summary>
/// 1.  а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры;
///     б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса;
///     Шмаков.
/// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            Complex complex1 = new Complex(-2, 1);
            
            Complex complex2 = new Complex(-2, 1);
            
            Complex complex3 = complex1.Plus(complex2);

            Complex complex4 = complex1.Minus(complex2);

            Complex complex5 = complex1.Multiple(complex2);

            Console.WriteLine($"z1 = {complex1.Re} + {complex1.Im}i");
            Console.WriteLine($"z2 = {complex2.Re} + {complex2.Im}i");
            Console.WriteLine($"Сумма двух комплексных чисел z1 и z2, z= {complex3.Re} + {complex3.Im}i");
            Console.WriteLine($"Разность двух комплексных чисел z1 и z2, z= {complex4.Re} + {complex4.Im}i");
            Console.WriteLine($"Произведение двух комплексных чисел z1 и z2, z= {complex5.Re} + {complex5.Im}i");

            Console.ReadKey();
        }
    }

    class Complex
    {
        // private double _im;
       // private double re; // поля
       /// <summary>
       /// x = Re
       /// y = Im
       /// </summary>
        public Complex()
        {


        }

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
            //this.re = re;
            
        }

        public double Re { get; set; }
        public double Im { get; set; }
        

        public Complex Plus(Complex x)
        {
            //(x1 + x2) + (y1 + y2)i
            Complex y = new Complex();
            y.Re = x.Re + Re;
            y.Im = x.Im + Im;

            return y;
        }

        public Complex Minus(Complex x)
        {
            //(x1 - x2) + (y1 - y2)i
            Complex y = new Complex();
            y.Re = x.Re - Re;
            y.Im = x.Im - Im;
            

            return y;
        }

        public Complex Multiple(Complex x)
        {
            //(x1*x2 - y1*y2) + (x1*y2+x2*y1)i
            Complex y = new Complex();
            
            y.Re = (x.Re * Re) - (x.Im * Im);
            y.Im = (x.Im * Re) + (Im * x.Re);
            return y;
        }
        /*
        public double Re
        {
            get { return re; }
            set
            {
                if (value != 0)
                {
                    re = value;
                }
                else
                {

                    //throw new Exception("Деление на ноль.");

                    ///.....
                }
            }
        
        }
       
/*
        public override string ToString()
        {
            return $"{re} + {Im}i";
        }
*/
    }
}
