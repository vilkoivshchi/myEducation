using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4
{
    class StudentsList
    {
        
        
        /// <summary>
        /// 4. Задача ЕГЭ.
        /// *На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
        /// школы.В первой строке сообщается количество учеников N, которое не меньше 10, но не
        /// превосходит 100, каждая из следующих N строк имеет следующий формат:
        /// <Фамилия> <Имя> <оценки>,
        /// где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
        /// более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
        /// пятибалльной системе. <Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом.
        /// Пример входной строки: Иванов Петр 4 5 3
        /// Требуется написать как можно более эффективную программу, которая будет выводить на экран
        /// фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
        /// набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
        /// Достаточно решить 2 задачи.Старайтесь разбивать программы на подпрограммы.Переписывайте в
        /// начало программы условие и свою фамилию. Все программы сделать в одном решении. Для решения
        /// задач используйте неизменяемые строки (string)
        /// Шмаков.
        /// </summary>
        
        public struct Students
        {
            /// <summary>
            /// Хранит сданные студента
            /// </summary>
            /// <param name="_name">Имя</param>
            /// <param name="_lastName">Фамилия</param>
            /// <param name="_grade1">Оценка №1</param>
            /// <param name="_grade2">Оценка №2</param>
            /// <param name="_grade3">Оценка №3</param>
            /// <param name="_middleGrade">Средняя оценка</param>
            public Students(string _name, string _lastName, byte _grade1, byte _grade2, byte _grade3, int _middleGrade)
            {
                name = _name;
                lastName = _lastName;
                grade1 = _grade1;
                grade2 = _grade2;
                grade3 = _grade3;
                middleGrade = _middleGrade;
            }
        
            public string name { get; }
            public string lastName { get; }
            public byte grade1 { get; } 
            public byte grade2 { get; } 
            public byte grade3 { get; }
            public int middleGrade { get; }
        }

        public Students[] studentsArr;

        /// <summary>
        /// Заполняет структуру Students
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public StudentsList(string filename)
        {
            if (File.Exists(filename))
            { 
                StreamReader reader = new StreamReader(filename);
                byte linesNum = 0;
                string line = reader.ReadLine();
                if (Byte.TryParse(line, out linesNum) && linesNum >= 10 && linesNum <= 100)
                {
                    studentsArr = new Students[linesNum];
                    for (int i = 0; i < linesNum; i++)
                    {
                        line = reader.ReadLine();
                        string[] lineArr = line.Split(' ');
                        Regex nameRegex = new Regex(@"^[ЁёА-Яа-яA-Za-z]*$");
                        if ((lineArr[0].Length >= 1 && lineArr[0].Length <= 20) && (lineArr[0].Length >= 1 && lineArr[1].Length <= 20))
                        {
                            if (nameRegex.IsMatch(lineArr[0]) && nameRegex.IsMatch(lineArr[1]))
                            {

                                byte byteValue1, byteValue2, byteValue3;
                                if (Byte.TryParse(lineArr[2], out byteValue1) && Byte.TryParse(lineArr[3], out byteValue2) && Byte.TryParse(lineArr[4], out byteValue3))
                                {
                                    if ((byteValue1 >= 2 && byteValue1 <= 5) && (byteValue2 >= 2 && byteValue2 <= 5) && (byteValue3 >= 2 && byteValue3 <= 5))
                                    {
                                        int midGr = (byteValue1 + byteValue2 + byteValue3) / 3;
                                        Students student = new Students(lineArr[0], lineArr[1], byteValue1, byteValue2, byteValue3, midGr);
                                        studentsArr[i] = student;

                                    }
                                    else Console.WriteLine($"Ошибка в строке {i + 2}. Оценка вне диапазона");
                                } else Console.WriteLine($"Ошибка в строке {i + 2}. Оценка - не число");
                            } else Console.WriteLine($"Ошибка в строке {i + 2}. Имя и фамилия должны состоять из букв.");
                        } else Console.WriteLine($"Ошибка в строке {i + 2}. Имя или фамилия слишком длинные");
                    }
                }
                else
                {
                    throw new Exception($"Строк меньше 10 или больше 100");
                }
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
            string filename = "Class.txt";
            filename = AppDomain.CurrentDomain.BaseDirectory + filename;
            StudentsList students = new StudentsList(filename);
            StudentsList.Students[] studentsArray = students.studentsArr;
            // Сортируем структуру
            Array.Sort<StudentsList.Students>(studentsArray, (x, y) => x.middleGrade.CompareTo(y.middleGrade));
            
            for (byte i = 0; i < studentsArray.Length; i++)
            {
               
                Console.WriteLine($"Средний балл студента {studentsArray[i].name} {studentsArray[i].lastName}: {studentsArray[i].middleGrade}");
            }
            
            
            Console.ReadLine();
        }
    }
}
