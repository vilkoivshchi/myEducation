using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
   /// <summary>
   /// 2. а) Дописать класс для работы с одномерным массивом. 
   /// Реализовать конструктор, создающий массив заданной размерности и 
   /// заполняющий массив числами от начального значения с заданным шагом. 
   /// 
   /// Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, 
   /// меняющий знаки у всех элементов массива, 
   /// метод Multi, умножающий каждый элемент массива на определенное число, 
   /// свойство MaxCount, возвращающее количество максимальных элементов. 
   /// 
   /// В Main продемонстрировать работу класса.
   /// 
   /// б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
   /// 
   /// Шмаков.
   /// </summary>

    class GetArray
    {
        private int[] _a;
        
        public int step { get; set; }
        public int startNum { get; set; }
        public int size { get; set; }
        
        private int _startNum, _step;

        private int _size
            { 
            // если попросим веруть значение _size, вернётся size
              get { return size; }
                
            // если пытаемся установить _size < 1, то выбросим исключение, иначе присвоим size передаваемое значение
              set
              {
                if(value < 1) 
                    {
                        throw new Exception($"Длина массива должна быть больше нуля");
                    }
                else
                    {
                        size = value;
                    }
              }
            }

        public int[] myArray;

        public GetArray(int[] a)
        {
            _a = a;
        }

        // конструктор, который передаёт условия задачи, на выходе переменные, исп-ся внути класса
        public GetArray(int size, int startNum, int step)
            {
               _size = size;
               _startNum = startNum;
               _step = step;
                MakeArray();
            }


        public int GetValue(int index)
        {
            return _a[index];
        }
        


        /// <summary>
        /// Создаёт массив заданной размерности и заполняет его числами от начального значения с заданным шагом.
        /// <param name="size">Размерность</param>
        /// <param name="startNum">Начальное число</param>
        /// <param name="step">Шаг изменения значений</param>
        public int[] MakeArray()
        {
            myArray = new int[_size];
            
            myArray[0] = _startNum;
            for (int i = 1; i < _size; i++)
                {
                   myArray[i] = myArray[i - 1] + _step;
                                       
                }
            return myArray;
        }

        public int Sum()
            {
                int summ = 0;
                foreach (int a in myArray)
                {
                    summ += a;
                }
                return summ;
            }
        
        /// <summary>
        /// Инвертирует знак каждого элемента массива myArray
        /// </summary>
        public int[] Inverse()
            {
                int[] array = new int[myArray.Length];
                for (int i = 0; i < myArray.Length; i++)
                {
                    array[i] = -myArray[i];
                }
                return array;
            }

        /// <summary>
        /// Умножает каждый элемент массива на число
        /// </summary>
        /// <param name="multi">Множитель</param>
        /// <return></return>
        public int[] Multi(int multi)
            {
                int[] array = new int[myArray.Length];
                
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = myArray[i] * multi;
                }
                return array;
            }

        // сохраняем массив в файл
        /// <summary>
        /// Сохранение массива построчно в файл
        /// </summary>
        /// <param name="filename">имя файла</param>
        public string ToFile(string filename)
        {
            if (File.Exists(filename))
            {
                StreamWriter writer = new StreamWriter(filename);
                // записываем первой строкой размерность массива
                writer.WriteLine(myArray.Length);
                foreach (int a in myArray)
                {
                    writer.WriteLine(a);
                }
                writer.Close();
                return ($"Массив сохранён в файл {filename}");
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        
        public int[] FromFile(string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string str = reader.ReadLine();
                int len = int.Parse(str);
                int[] a = new int[len];
                for (int i = 0; i < len; i++)
                {
                    a[i] = int.Parse(reader.ReadLine());
                }
                reader.Close();
                return a;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        

        /// <summary>
        /// Индексное свойство
        /// </summary>
        /// <param name="i">Индекс</param>
        /// <returns></returns>
        public int this[int i]
        {
            get
            {
                return _a[i];
            }
            set
            {
                _a[i] = value;
            }

        }
        // вот тут я не особоо понял условие задачи. Массив отсортирован изначально и на выходе будет всегда "1"
        
        public int MaxCount
            {
                get 
                { 
                 
                int max;
                int maxCount = 0;
                max = myArray[myArray.Length - 1];
                for (int i = myArray.Length - 1 ; i >= 0; i--)
                {
                    if (myArray[i] >= max) 
                        {
                            max = myArray[i];
                            maxCount++;
                        }
                }
                return maxCount;
                }
            }
        

        // если нужно вернуть длину массива, тогда так:
        /*
        public int MaxCount
            {
                get { return myArray.Length; }
            }
       */
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region a
            // Условия задачи
            int size = 70;
            int startNumber = 3;
            int step = 2;
            int multiplier = 51;
            #endregion

            #region b
            string filename = "array.txt";
            string filename2 = AppDomain.CurrentDomain.BaseDirectory + filename;


            #endregion

            // Позиция курсора слева
            int curLeft = 35;
            
            GetArray getArray = new GetArray(size, startNumber, step);
            // часть а
            int[] array = getArray.myArray;
            int arrSumm = getArray.Sum();
            int[] arrInverse = getArray.Inverse();
            int[] arrMulti = getArray.Multi(multiplier);

            // часть б
            string saveResult = getArray.ToFile(filename2);
            int[] arrFromFile = getArray.FromFile(filename2);



            Console.Write($"Массив: ");
            int curTop = Console.CursorTop;
            Console.SetCursorPosition(curLeft, curTop);
            foreach (int a in array)
                {
                    Console.Write($"{a} ");
                }
            Console.WriteLine();

            Console.Write($"Сумма элементов массива: ");
            curTop = Console.CursorTop;
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write(arrSumm);

            Console.WriteLine();
            Console.Write($"Инвертированный массив: ");
            curTop = Console.CursorTop;
            Console.SetCursorPosition(curLeft, curTop);
            foreach (int a in arrInverse)
                {
                    Console.Write($"{a} ");
                }
            Console.WriteLine();

            Console.Write($"Умножили каждый элемент на {multiplier}: ");
            curTop = Console.CursorTop;
            Console.SetCursorPosition(curLeft, curTop);
            foreach (int a in arrMulti)
                {
                    Console.Write($"{a} ");
                }

            Console.WriteLine();
            
            Console.Write($"MaxCoint: ");
            curTop = Console.CursorTop;
            Console.SetCursorPosition(curLeft, curTop);
            Console.Write(getArray.MaxCount);

            Console.WriteLine();
            Console.WriteLine(saveResult);
            // это в задание не входит, но должно быть удобно
            Console.WriteLine($"Нажмите <Enter> чтобы открыть файл или другую кнопку, чтобы продолжить выполнение...");
            if (Console.ReadKey().Key == ConsoleKey.Enter) System.Diagnostics.Process.Start(filename2);
            Console.ReadKey();
            Console.Write($"Массив из файла: ");
            curTop = Console.CursorTop;
            Console.SetCursorPosition(curLeft, curTop);
            foreach (int a in arrFromFile)
            {
                Console.Write($"{a} ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
