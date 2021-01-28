using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// 2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
    /// а) Вывести только те слова сообщения, которые содержат не более n букв.
    /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    /// в) Найти самое длинное слово сообщения.
    /// г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    /// Продемонстрируйте работу программы на текстовом файле с вашей программой.
    /// </summary>

    class Message
    {
        /// <summary>
        /// Массив для храниния строк
        /// </summary>
        public string[] message { get; set; }

       
        

        /// <summary>
        /// Конструктор читает с диска файл и разделяет содержимое
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <param name="separators">Разделители</param>        
        public Message(string filename, string[] separators)
        {
            if (File.Exists(filename))
            {

                StreamReader reader = new StreamReader(filename, Encoding.Unicode);
                string textMessage = File.ReadAllText(filename);
                
                var parsedMessage = textMessage.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                message = new string[parsedMessage.Length];
                for (int i = 0; i < parsedMessage.Length; i++)
                {
                    message[i] = parsedMessage[i];
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            
        }
        
        /// <summary>
        /// Ищет слова, которые содержат не более n букв
        /// </summary>
        /// <param name="stringsArray">Входной массив</param>
        /// <param name="size">Длина слова</param>
        /// <returns></returns>
        public string[] WordLongerThen(string[] stringsArray, int size)
        {
            if (size < 1)
            {
                throw new Exception("Слово не может быть короче одной буквы");
               }
            else
            {
                string[] newArray = new string[stringsArray.Length];
                int newArrayCount = 0;
                foreach (string a in stringsArray)
                {
                    if (a.Length <= size)
                    {
                        newArray[newArrayCount] = a;
                        newArrayCount++;
                    }
                }
                // выбросим лишнее
                string[] finalArray = new string[newArrayCount];
                for (int i = 0; i < finalArray.Length; i++)
                {
                    finalArray[i] = newArray[i];
                }


                return finalArray;
            }
        }

        /// <summary>
        /// Возвращает массив, из которого удалены слова, заканчивающиеся на нужную букву
        /// </summary>
        /// <param name="array">Входной массив</param>
        /// <param name="letter">Нужная буква</param>
        /// <returns></returns>
        public string[] DeleteIfLastLetterMatch(string[] array, string letter)
        {
            string[] newArray = new string[array.Length];

            int newArrayCount = 0;

            Regex regex = new Regex($"[{letter}]{{1}}$", RegexOptions.IgnoreCase);
            
            foreach (string a in array)
            {
                if (!regex.IsMatch(a))
                {
                    newArray[newArrayCount] = a;
                    newArrayCount++;
                }
            }
            // выбросим лишнее
            string[] finalArray = new string[newArrayCount];
            for (int i = 0; i < finalArray.Length; i++)
            {
                finalArray[i] = newArray[i];
            }
            return finalArray;

        }

        public string FindMostLongWord(string[] array)
        {
            int max = 0;
            string maxWord = " ";
            foreach (string a in array)
            {
                if (a.Length > max)
                {
                    maxWord = a;
                    max = a.Length;
                }
            }
            return maxWord;
        }
        /// <summary>
        /// Найдём самые длинные слова. Найдём самое длинное и будем считать, что "самые длинные" на могут быть на 20% короче
        /// </summary>
        /// <param name="array">Входной массив</param>
        /// <returns>Самые длинные слова в массиве</returns>
        public string MakePhraseFromWords(string[] array)
        {
            // Поищем самые длинные слова в массиве
            string maxWord = FindMostLongWord(array);
            double maxWordsLen = maxWord.Length * 0.2d;
            maxWordsLen = maxWord.Length - Math.Round(maxWordsLen) ;
            string[] maxWordArr = new string[array.Length];
            int maxCount = 0;

            foreach (string a in array)
            {
                if (a.Length >= maxWordsLen)
                {
                    maxWordArr[maxCount] = a;
                    maxCount++;
                }
                
            }

            string[] finalArray = new string[maxCount];
            for (int i = 0; i < finalArray.Length; i++)
            {
                finalArray[i] = maxWordArr[i];
            }
            // Теперь немного перемешаем массив
            Random rnd = new Random();

            string[] randomArray = finalArray.OrderBy(x => rnd.Next()).ToArray();

            var finalString = new StringBuilder();

            foreach (string a in randomArray) finalString.Append($"{a} ");

            return finalString.ToString(0, finalString.Length);
        }
        
    }

    class Program
    {

        static void Main(string[] args)
        {
            string filename = "Text.txt";
            filename = AppDomain.CurrentDomain.BaseDirectory + filename;

            string[] separators = { ",", ".", " ", "?", "!", ";", ":", "(", ")" };

            int maxLetters = 5;

            string letter = "е";

            Message message = new Message(filename, separators);
            string[] fromTextFile = message.message;

            string[] wordsLessThen = message.WordLongerThen(fromTextFile, maxLetters);

            string[] deleteIfLetter = message.DeleteIfLastLetterMatch(fromTextFile, letter);

            string longestWord = message.FindMostLongWord(fromTextFile);

            string longestWrds = message.MakePhraseFromWords(fromTextFile);

            Console.WriteLine($"Массив из файла:");
            foreach (string a in fromTextFile) Console.WriteLine(a);
            Console.WriteLine();
            Console.WriteLine($"Теперь показываем слова не длиннее {maxLetters} букв:");
            foreach (string a in wordsLessThen) Console.WriteLine(a);
            Console.WriteLine();
            Console.WriteLine($"Теперь выбрасываем слова, заканчивающиеся на {letter}");
            foreach (string a in deleteIfLetter) Console.WriteLine(a);
            Console.WriteLine();
            Console.WriteLine($"А самое длинное слово: {longestWord}");
            Console.WriteLine();
            Console.WriteLine($"Строка из самых длинных слов: {longestWrds} ");
            
            Console.ReadKey();
        }
    }
}
