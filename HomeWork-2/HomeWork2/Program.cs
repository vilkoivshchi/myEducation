using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        static void f(int n)
        {
            Console.WriteLine(n);
            if (n >= 3)
            {
                f(n - 1);
                f(n - 2);
                f(n - 2);

            }
        }
        enum Seasons
        {
            Winter,
            Spring,
            Summer,
            Autumn
        };

        static void Main(string[] args)
        {
            /*
            Seasons seasons = Seasons.Winter;
            switch(seasons)
            {
                case Seasons.Winter;
                    break;
                case Seasons.Summer;
                    break;
            }
        
        */
            f(4);
            Console.Read();
        }
    }
}
