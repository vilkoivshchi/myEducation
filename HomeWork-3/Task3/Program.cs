using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Fraction
    {
        private int denom;

        public Fraction()
            {
        
            }

        public Fraction(int numer, int denom)
            {
                Numerator = numer;
                Denominator = denom;
            }
        
        public int Numerator { get; set; }
        // добавляем к знаменателю исключение деления на 0
        public int Denominator 
        {
            get { return denom; }
            set 
                {
                if(value != 0)
                    {
                        denom = value;
                    }
                else
                    {
                       throw new Exception($"Знаменатель не может быть равен 0");
                    }
                }
        }

        

        public Fraction Plus(Fraction x)
            {
// потом прикрутить сокращения дробей, если останется время                
                Fraction y = new Fraction();
                if(x.Denominator == Denominator)
                {
                    y.Numerator = x.Numerator + Numerator;
                    y.Denominator = Denominator;
                }
                else
                {
                    // давайте поищем НОК. Скопируем переменные, чтобы они не поменялись.
                    int denom = Denominator;
                    int denomX = x.Denominator;
                    
                    int numer = Numerator;
                    int numerX = x.Numerator;
                    // ага, вот и НОК!
                    y.Denominator = denomX * denom;
                    
                    // теперь домножим числители 
                    numer *= denomX;
                    numerX *= denom;
                    
                    // теперь сложим то, что получилось
                    y.Numerator = numerX + numer;

                    

                }
               // теперь попробуем сократить дроби
                    int gcd = 0;
                    int fracMax;
                    // посмотрим что больше: числитель или знаменатель
                    if(y.Numerator < y.Denominator || y.Numerator == y.Denominator)
                    {
                        fracMax = y.Denominator;
                    }
                    else
                    {
                        fracMax = y.Numerator;
                    }
                    
                    // теперь найдем НОД (не антивирус), если он есть. Я нарочно не использовал GreatestCommonDivisor
                    for(int i = 2; i <= fracMax; i++)
                    {
                        if (y.Numerator % i == 0 && y.Denominator % i == 0) gcd = i;
                    }

                    // а теперь, если НОД всё же есть, сократим дробь
                    if(gcd > 0)
                    {
                        y.Numerator /= gcd;
                        y.Denominator /= gcd;
                    }
                   
                // хоба!
                return y;
            }

        public Fraction Minus(Fraction x)
            {
                Fraction y = new Fraction();
                if(x.Denominator == Denominator)
                {
                    y.Numerator = x.Numerator - Numerator;
                    y.Denominator = Denominator;
                }
                else
                {
                    // давайте поищем НОК. Скопируем переменные, чтобы они не поменялись.
                    int denom = Denominator;
                    int denomX = x.Denominator;
                    
                    int numer = Numerator;
                    int numerX = x.Numerator;
                    // ага, вот и НОК!
                    y.Denominator = denomX * denom;
                    
                    // теперь домножим числители 
                    numer *= denomX;
                    numerX *= denom;
                    
                    // теперь вычтем то, что получилось
                    y.Numerator = numerX - numer;
                    if(numerX < 0 || numer < 0) y.Numerator = -y.Numerator;
                    
                }
                
                // теперь попробуем сократить дроби
                    int gcd = 0;
                    int fracMax;
                    // посмотрим что больше: числитель или знаменатель
                    if(y.Numerator < y.Denominator || y.Numerator == y.Denominator)
                    {
                        fracMax = y.Denominator;
                    }
                    else
                    {
                        fracMax = y.Numerator;
                    }
                    
                    // теперь найдем НОД (не антивирус), если он есть. Я нарочно не использовал GreatestCommonDivisor
                    for(int i = 2; i <= fracMax; i++)
                    {
                        if (y.Numerator % i == 0 && y.Denominator % i == 0) gcd = i;
                    }

                    // а теперь, если НОД всё же есть, сократим дробь
                    if(gcd > 0)
                    {
                        y.Numerator /= gcd;
                        y.Denominator /= gcd;
                    }
                   
                
                // хоба!
                return y;
            }

        public Fraction Multiple(Fraction x)
            {
                // тут вроде всё просто
                Fraction y = new Fraction();
                y.Numerator = x.Numerator * Numerator;
                y.Denominator = x.Denominator * Denominator;

                // теперь попробуем сократить дроби
                    int gcd = 0;
                    int fracMax;
                    // посмотрим что больше: числитель или знаменатель
                    if(y.Numerator < y.Denominator || y.Numerator == y.Denominator)
                    {
                        fracMax = y.Denominator;
                    }
                    else
                    {
                        fracMax = y.Numerator;
                    }
                    
                    // теперь найдем НОД (не антивирус), если он есть. Я нарочно не использовал GreatestCommonDivisor
                    for(int i = 2; i <= fracMax; i++)
                    {
                        if (y.Numerator % i == 0 && y.Denominator % i == 0) gcd = i;
                    }

                    // а теперь, если НОД всё же есть, сократим дробь
                    if(gcd > 0)
                    {
                        y.Numerator /= gcd;
                        y.Denominator /= gcd;
                    }
                   

                return y;
            }

        public Fraction Devide(Fraction x)
            {
                // тут тоже вроде ничего сложного
                Fraction y = new Fraction();
                y.Numerator = x.Denominator * Numerator;
                y.Denominator = x.Numerator * Denominator;
            
                // теперь попробуем сократить дроби
                    int gcd = 0;
                    int fracMax;
                    // посмотрим что больше: числитель или знаменатель
                    if(y.Numerator < y.Denominator || y.Numerator == y.Denominator)
                    {
                        fracMax = y.Denominator;
                    }
                    else
                    {
                        fracMax = y.Numerator;
                    }
                    
                    // теперь найдем НОД (не антивирус), если он есть. Я нарочно не использовал GreatestCommonDivisor
                    for(int i = 2; i <= fracMax; i++)
                    {
                        if (y.Numerator % i == 0 && y.Denominator % i == 0) gcd = i;
                    }

                    // а теперь, если НОД всё же есть, сократим дробь
                    if(gcd > 0)
                    {
                        y.Numerator /= gcd;
                        y.Denominator /= gcd;
                    }
            
               

                return y;
               
            }

        private Fraction Simplification(Fraction x)
            {
                Fraction y = new Fraction();
        
                // теперь попробуем сократить дроби
                    int gcd = 0;
                    int fracMax;
                    // посмотрим что больше: числитель или знаменатель
                    if(y.Numerator < y.Denominator || y.Numerator == y.Denominator)
                    {
                        fracMax = y.Denominator;
                    }
                    else
                    {
                        fracMax = y.Numerator;
                    }
                    
                    // теперь найдем НОД (не антивирус), если он есть. Я нарочно не использовал GreatestCommonDivisor
                    for(int i = 2; i <= fracMax; i++)
                    {
                        if (y.Numerator % i == 0 && y.Denominator % i == 0) gcd = i;
                    }

                    // а теперь, если НОД всё же есть, сократим дробь
                    if(gcd > 0)
                    {
                        y.Numerator /= gcd;
                        y.Denominator /= gcd;
                    }
                return y;
            }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(-4, 10);
            Fraction fraction2 = new Fraction(6, 63);

            Fraction fraction3 = fraction1.Plus(fraction2);

            Fraction fraction4 = fraction1.Minus(fraction2);

            Fraction fraction5 = fraction1.Multiple(fraction2);

            Fraction fraction6 = fraction1.Devide(fraction2);
            
            Console.WriteLine($"{fraction1.Numerator}/{fraction1.Denominator} + {fraction2.Numerator}/{fraction2.Denominator} = {fraction3.Numerator}/{fraction3.Denominator}");
            Console.WriteLine($"{fraction1.Numerator}/{fraction1.Denominator} - {fraction2.Numerator}/{fraction2.Denominator} = {fraction4.Numerator}/{fraction4.Denominator}");
            Console.WriteLine($"{fraction1.Numerator}/{fraction1.Denominator} * {fraction2.Numerator}/{fraction2.Denominator} = {fraction5.Numerator}/{fraction5.Denominator}");
            Console.WriteLine($"{fraction1.Numerator}/{fraction1.Denominator} / {fraction2.Numerator}/{fraction2.Denominator} = {fraction6.Numerator}/{fraction6.Denominator}");
            Console.ReadKey();
        }
    }
}
