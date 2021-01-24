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

        public int[] myArray { get; }

        public GetArray(int[] a)
        {
            _a = a;
        }

        
        /// <summary>
        /// Создаёт массив заданной размерности и заполняет его числами от начального значения с заданным шагом.
        /// <param name="size">Размерность</param>
        /// <param name="startNum">Начальное число</param>
        /// <param name="step">Шаг изменения значений</param>
        public GetArray(int size, int startNum, int step)
            {
               _size = size;
               _startNum = startNum;
               _step = step;
                myArray = new int[_size];
               for (int i = 0; i < _size; i++)
                {
                    myArray[i] = _startNum + (_step * i);
                }
            }
      
        public int GetValue(int index)
        {
            return _a[index];
        }
        

        
        public int Sum(int[] array)
            {
                int summ = 0;
                foreach (int a in array)
                {
                    summ += a;
                }
                return summ;
            }
        
        /// <summary>
        /// Инвертирует знак каждого элемента массива myArray
        /// </summary>
        public int[] Inverse(int[] array)
            {
                int[] array1 = new int[array.Length];
                for (int i = 0; i < array1.Length; i++)
                {
                    array1[i] = -array[i];
                }
                return array1;
            }

        /// <summary>
        /// Умножает каждый элемент массива на число
        /// </summary>
        /// <param name="multi">Множитель</param>
        /// <return></return>
        public int[] Multi(int[] array, int multi)
            {
                int[] array1 = new int[array.Length];
                
                for (int i = 0; i < array1.Length; i++)
                {
                    array1[i] = myArray[i] * multi;
                }
                return array1;
            }

        // сохраняем массив в файл
        /// <summary>
        /// Сохранение массива построчно в файл
        /// </summary>
        /// <param name="filename">имя файла</param>
        public string ToFile(int[] array1, string filename)
        {
            if (File.Exists(filename))
            {
                StreamWriter writer = new StreamWriter(filename);
                // записываем первой строкой размерность массива
                writer.WriteLine(array1.Length);
                foreach (int a in array1)
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
                int len;
                if(!int.TryParse(str, out len)) throw new Exception($"В строке 1 не число!");
                if(len < 1) throw new Exception("Длина массива меньше единицы");
                int[] array1 = new int[len];
                for (int i = 0; i < len; i++)
                {
                     if(!int.TryParse(reader.ReadLine(), out array1[i])) throw new Exception($"В строке {i + 2} не число!");
                }
                reader.Close();
                return array1;
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
        
        


        public int MaxCount(int[] array1)
            {
                int max = array1.Max();
                int maxCount = 0;
                
                for (int i = 0 ; i < array1.Length; i++)
                {
                    if (array1[i] == max) 
                        {
                            maxCount++;
                        }
                }
                return maxCount;
                
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
            int size = 9;
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
            int arrSumm = getArray.Sum(array);
            int[] arrInverse = getArray.Inverse(array);
            int[] arrMulti = getArray.Multi(array, multiplier);
            int maxCount = getArray.MaxCount(array);

            // часть б
            string saveResult = getArray.ToFile(array, filename2);
            



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
            Console.Write(maxCount);

            Console.WriteLine();
            Console.WriteLine(saveResult);
            // это в задание не входит, но должно быть удобно
            Console.WriteLine($"Нажмите <Enter> чтобы открыть файл или другую кнопку, чтобы продолжить выполнение...");
            if (Console.ReadKey().Key == ConsoleKey.Enter) System.Diagnostics.Process.Start(filename2);
// в этом месте можно поменять содердимое файла
            Console.ReadKey();
            int[] arrFromFile = getArray.FromFile(filename2);
            
            
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
