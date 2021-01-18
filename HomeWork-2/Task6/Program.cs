using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    /// <summary>
    /// 6. *Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000. 
    /// Хорошим называется число, которое делится на сумму своих цифр. 
    /// Реализовать подсчет времени выполнения программы, используя структуру DateTime.
    /// </summary>
    class Program
    {
        static int GoodNumbers(int min, int max)
        {
            // делим число на 10, остаток ещё на 10 и т.д., остаток каждой операции прибавляем к сумме
            // если число делится на сумму своих цифр - прибаляем счетчик
            int count = 0;
            for (int i = min; i <= max; i++)
            {
                int sum = 0;
                for (int n = i; n > 0; sum += n % 10, n /= 10);
                if (i % sum == 0) count++;
            }
            return count;
        }
        static void Main(string[] args)
        {
            // время начала
            DateTime dateStart = DateTime.Now;

            // исходные двнные
            int numMin = 1;
            int numMax = 1000000000;
            
            Console.WriteLine($"Считаю количество \"Хороших\" чисел от {numMin} до {numMax}. Наберитесь терпения...");

            int goodNumbersCount = GoodNumbers(numMin, numMax);

            Console.WriteLine($"Количество \"Хороших\" чисел: {goodNumbersCount}");
            DateTime dateEnd = DateTime.Now;
            // вычитаем из коечной даты начальную. Мудрить с форматом не стал.
            Console.WriteLine($"Затрачено времени: {dateEnd.Subtract(dateStart)}");
            Console.ReadKey();
        }
    }
}
