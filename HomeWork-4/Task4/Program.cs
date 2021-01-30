using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    /// <summary>
    /// *а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив 
    /// случайными числами. 
    /// Создать методы: 
    /// 
    /// которые возвращают сумму всех элементов массива, 
    /// сумму всех элементов массива больше заданного, 
    /// свойство, возвращающее минимальный элемент массива, 
    /// свойство, возвращающее максимальный элемент массива, 
    /// метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
    /// 
    /// * б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    /// Дополнительные задачи
    /// в) Обработать возможные исключительные ситуации при работе с файлами.
    /// Шмаков.
    /// </summary>
    class Array2d
    {
        public int dimention1 { get; set; }
        public int dimention2 { get; set; }
        private int _dimention1
        {
            // если попросим веруть значение _size, вернётся size
            get { return dimention1; }

            // если пытаемся установить _size < 1, то выбросим исключение, иначе присвоим size передаваемое значение
            set
            {
                if (value < 1)
                {
                    throw new Exception($"Длина массива должна быть больше нуля");
                }
                else
                {
                    dimention1 = value;
                }
            }
        }

        private int _dimention2
        {
            // если попросим веруть значение _dimention2, вернётся dimention
            get { return dimention2; }

            // если пытаемся установить _dimention2 < 1, то выбросим исключение, иначе присвоим size передаваемое значение
            set
            {
                if (value < 1)
                {
                    throw new Exception($"Длина массива должна быть больше нуля");
                }
                else
                {
                    dimention2 = value;
                }
            }
        }

        public int[,] array2d;

        public Array2d(int dimention1, int dimention2, int minValue, int maxValue)
        {
            _dimention1 = dimention1;
            _dimention2 = dimention2;
            Random random = new Random();
            array2d = new int[_dimention1, _dimention2];
            for (int i = 0; i < _dimention1; i++)
            {
                for (int j = 0; j < _dimention2; j++)
                {
                    array2d[i, j] = random.Next(minValue, maxValue);
                }
            }
        }

        /// <summary>
        /// Возвращает сумму всех элементов массива
        /// </summary>
        /// <param name="array">Входной двумерный массив</param>
        /// <returns>Сумма</returns>
        public int Sum(int[,] array)
        {
            int summ = 0;
            foreach (int a in array)
            {
                summ += a;
            }
            return summ;
        }

        /// <summary>
        /// Возвращает сумму всех элементов больше заданного
        /// </summary>
        /// <param name="array">Входной двумерный массив</param>
        /// <param name="marker">Число, больше которого искать</param>
        /// <returns></returns>
        public int FindSummMoreThen(int[,] array, int marker)
        {
            int[,] array1 = array;
            int summ = 0;
            foreach (int a in array1)
            {
                if (a > marker) summ += a;
            }
            return summ;
        }

        public int FindSummFromHere(int[,] array, int[] point)
        {
            int[,] array1 = array;
            int summ = 0;
            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                {

                    if (i > point[0] && j > point[1]) summ += array1[i, j];
                }
            }
            return summ;
        }

        /// <summary>
        /// Свойство возвращает минимальное значение элемента массива
        /// </summary>
        public int Min
        {

            get
            {
                int min = array2d[0, 0];
                foreach (int a in array2d)
                {
                    if (a < min) min = a;
                }
                return min;
            }
        }

        /// <summary>
        /// Свойство возвращает минимальное значение элемента массива
        /// </summary>
        public int Max
        {

            get
            {
                int max = array2d[0, 0];
                foreach (int a in array2d)
                {
                    if (a > max) max = a;
                }
                return max;
            }
        }

        /// <summary>
        /// Возвращает индекс максимального элемента массива
        /// </summary>
        /// <param name="array">Входящий массив</param>
        /// <param name="maxElemNum">Массив с индексом</param>
        public void MaxElemNum(int[,] array, out int[] maxElemNum)
        {
            maxElemNum = new int[] { 0, 0 };
            int maxNum = array[0, 0];
       
            for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++) 
            { 
                for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                {
                    
                    if (array[i,j] > maxNum)
                    {
                        maxNum = array[i, j];
                        maxElemNum[0] = i;
                        maxElemNum[1] = j;
                    }
                }
            }
        }

        /// <summary>
        /// Сохраняет двумерный массив в файл
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
        public string Save2dArrayToFile(int[,] array, string filename)
        {
            if (File.Exists(filename))
            {
                StreamWriter writer = new StreamWriter(filename);
                // записываем первой строкой размерность массива
                writer.WriteLine(array.GetLength(0));
                writer.WriteLine(array.GetLength(1)); 
                // writer.WriteLine(array1.Length);
                for (int i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
                {
                    for (int j = array.GetLowerBound(1); j <= array.GetUpperBound(1); j++)
                    {
                        writer.WriteLine(array[i, j]);
                    }
                    
                }
                writer.Close();
                return ($"Массив сохранён в файл {filename}");
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        
        /// <summary>
        /// Загружает двумерный массив из файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
        public int[,] Load2dArrayFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                
                int dim1, dim2;
                

                if (!int.TryParse(reader.ReadLine(), out dim1)) throw new Exception($"В строке 1 не число!");
                if (!int.TryParse(reader.ReadLine(), out dim2)) throw new Exception($"В строке 2 не число!");
                if (dim1 < 1 || dim2 < 1) throw new Exception("Хотя бы одно измерение массива < 1");
                int[,] array1 = new int[dim1, dim2];
                for (int i = 0; i < dim1; i++)
                {
                    for (int j = 0; j < dim2; j++)
                    {
                        if (!int.TryParse(reader.ReadLine(), out array1[i, j])) throw new Exception($"В строке {i + 2} не число!");
                    }
                }

                reader.Close();
                return array1;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            int dim1 = 6;
            int dim2 = 6;
            int minVal = -50;
            int maxVal = 190;

            //int findMoreThenThis = 3;
            int[] findMoreThenThis = { 0, 2 };


            Array2d myArray2d = new Array2d(dim1, dim2, minVal, maxVal);
            #region a

            // вытаскиваем массив, созданный конструктором
            int[,] myArr = myArray2d.array2d;

            // сумма элементов массива
            int summ = myArray2d.Sum(myArr);

            // Поиск суммы элементов массива больше заданного


            int summFromHere = myArray2d.FindSummFromHere(myArr, findMoreThenThis);

            /* массив для проверки свойства
             
            myArray2d.array2d = new int[,] { { 1, 2, 3 }, { 4, 2, 3 } };
            */

            int[] maxElement = new int[2];
            myArray2d.MaxElemNum(myArr, out maxElement);
            #endregion

            string filename = "array2d.txt";
            string filename2 = AppDomain.CurrentDomain.BaseDirectory + filename;

            string saveResult = myArray2d.Save2dArrayToFile(myArr, filename2);

            Console.WriteLine($"Массив из коструктора:");
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {
                    if (myArr[i, j] == myArray2d.Max) Console.ForegroundColor = ConsoleColor.Yellow;
                    //Console.WriteLine($"i: {i}, j: {j} : {myArr[i, j]}");
                    Console.Write($"{myArr[i, j]}\t");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Сумма всех элементов массива: {summ}");
            Console.WriteLine();


            Console.WriteLine($"Элементы массива после {{ {findMoreThenThis[0]} : {findMoreThenThis[1]} }}");
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim2; j++)
                {

                    //Console.Write( myArr[i,j] > findMoreThenThis ? $"{myArr[i, j]} " : "0 ");
                    if (i > findMoreThenThis[0] && j > findMoreThenThis[1])
                    {
                        Console.Write($"{myArr[i, j]}\t");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"0\t");
                        Console.ResetColor();
                    }

                }
                Console.WriteLine();
            }

            Console.WriteLine($"Сумма элементов после {{ {findMoreThenThis[0]} : {findMoreThenThis[1]} }}: {summFromHere}");
            Console.WriteLine();
            Console.WriteLine($"Свойство: минимальный элемент массива: {myArray2d.Min}");
            Console.WriteLine();
            Console.Write($"Свойство: максимальный элемент массива: ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{myArray2d.Max}");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine($"Индекс максимального элемента массива: {{ {maxElement[0]} : {maxElement[1]} }}");
            Console.WriteLine();
            Console.WriteLine(saveResult);
            // это в задание не входит, но должно быть удобно
            Console.WriteLine($"Нажмите <Enter> чтобы открыть файл или другую кнопку, чтобы продолжить выполнение...");
            if (Console.ReadKey().Key == ConsoleKey.Enter) System.Diagnostics.Process.Start(filename2);
            Console.ReadKey();
            // в этом месте можно поменять содержимое файла
            int[,] arrLoadedFromFile = myArray2d.Load2dArrayFromFile(filename2);

            for (int i = 0; i < arrLoadedFromFile.GetLength(0); i++)
            {
                for (int j = 0; j < arrLoadedFromFile.GetLength(1); j++)
                {

                    Console.Write($"{arrLoadedFromFile[i, j]}\t");
                    

                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
