using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Program
    {
        static void Move(int number, int from, int to, int free)
            /// <summary>
            /// 
            /// </summary>
            /// <param name="args">кол-в блинов, башня 1, башня 2, башня 3</param>
            {
                if (number > 0)
                {
                Move(number - 1, from, free, to);
                Console.WriteLine($"Диск {number} из {from} в {to}");
                Move(number - 1, free, to, from);
                }
            }
        static void Main(string[] args)
        {
        Move(6, 1, 2, 3);
        Console.Read();
        }
    }
}
