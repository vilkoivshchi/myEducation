using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

                StreamReader reader = new StreamReader(filename);
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
        // запилить поле _size;
        public string[] WordLongerThen(string[] stringsArray, int size)
        {
            //size = _size;
            string[] newArray = new string[stringsArray.Length];
            int newArrayCount = 0;
            foreach(string a in stringsArray)
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





    
    class Program
    {

        static void Main(string[] args)
        {
            string filename = "Text.txt";
            filename = AppDomain.CurrentDomain.BaseDirectory + filename;

            string[] separators = { ",", ".", " ", "?", "!", ";", ":" };

            int maxLetters = 4;

            Message message = new Message(filename, separators);
            string[] fromTextFile = message.message;

            string[] wordsLessThen = message.WordLongerThen(fromTextFile, maxLetters);
            Console.WriteLine($"Массив из файла:");
            foreach (string a in fromTextFile) Console.WriteLine(a);
            Console.WriteLine();
            Console.WriteLine($"Теперь показываем слова не длиннее {maxLetters} букв:");
            foreach (string a in wordsLessThen) Console.WriteLine(a);

            Console.ReadKey();
        }
    }
}
