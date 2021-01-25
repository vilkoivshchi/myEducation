using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// *а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив 
    /// случайными числами. Создать методы, которые возвращают сумму всех элементов массива, 
    /// сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, 
    /// свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента 
    /// массива (через параметры, используя модификатор ref или out)
    /// * б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    /// Дополнительные задачи
    /// в) Обработать возможные исключительные ситуации при работе с файлами.
    /// Шмаков.
    /// </summary>
    class Array2d
        {
        public int dimention1, dimention2;
        public int[,] array2d;
        public Array2d(int _dimention1, int _dimention2, int minValue, int maxValue)
        {
            Random random = new Random();
            array2d = new int[_dimention1, _dimention2];
            for(int i = 0; i < _dimention1; i++)
            {
                for(int j = 0; j < _dimention2; j++)
                {
                    array2d[i, j] = random.Next(minValue, maxValue); 
                }
            }
        }
        }

    class Program
    {
        static void Main(string[] args)
        {
            int dim1 = 6;
            int dim2 = 5;
            int minVal = -100;
            int maxVal = 100;
            
            Array2d myArray2d = new Array2d(dim1, dim2, minVal, maxVal);
            int[,] myArr = myArray2d.array2d;

            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    //Console.WriteLine($"i: {i}, j: {j} : {myArr[i, j]}");
                    Console.Write($"{myArr[i, j]} ");
                   
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
