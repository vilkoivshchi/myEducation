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
            
            /// <param name="_middleGrade">Средняя оценка</param>
            public Students(string _name, string _lastName, double _middleGrade)
            {
                name = _name;
                lastName = _lastName;
                
                middleGrade = _middleGrade;
            }
        
            public string name { get; }
            public string lastName { get; }
            
            public double middleGrade { get; }
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
                                        double midGr = Math.Round(((byteValue1 + byteValue2 + byteValue3) / 3.0f), 2);
                                        Students student = new Students(lineArr[0], lineArr[1], midGr);
                                        studentsArr[i] = student;

                                    }
                                    else Console.WriteLine($"Ошибка в строке {i + 2}. Оценка вне диапазона");
                                } else Console.WriteLine($"Ошибка в строке {i + 2}. Оценка - не число");
                            } else Console.WriteLine($"Ошибка в строке {i + 2}. Имя и фамилия должны состоять из букв.");
                        } else Console.WriteLine($"Ошибка в строке {i + 2}. Имя или фамилия слишком длинные");
                    }
                    // Сортируем структуру
                    if (studentsArr.Length > 10)
                    {
                        Array.Sort<StudentsList.Students>(studentsArr, (x, y) => x.middleGrade.CompareTo(y.middleGrade));
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
        
        public static Students[] WorstGrades(Students[] students)
        {
            Students[] worstStudentsTemp = new Students[students.Length];

            byte counter = 1;
            // Поскольку структура отсортирована. меньшим значением будет лежащее в нулевом индексе
            double min = students[0].middleGrade;
            worstStudentsTemp[0] = students[0];

            int j = 1;

            for (byte i = 1; i < students.Length; i++)
            {
                
                if (students[i].middleGrade > min && counter < 3)
                {
                    worstStudentsTemp[j] = students[i];
                    min = students[i].middleGrade;
                    counter++;
                    j++;
                }
                else if (students[i].middleGrade == min && counter <= 3)
                {
                    worstStudentsTemp[j] = students[i];
                    min = students[i].middleGrade;
                    
                    j++;
                }
            }
            // Чистим структуру, если это необходимо
            if (worstStudentsTemp.Length > j)
            {
                Students[] worstStudents = new Students[j];
                for (byte i = 0; i < worstStudents.Length; i++)
                {
                    worstStudents[i] = worstStudentsTemp[i];
                }

                return worstStudents;
            }
            else 
            {
                return worstStudentsTemp;
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

            StudentsList.Students[] worstStudents = StudentsList.WorstGrades(studentsArray);
            Console.WriteLine($"Список студентов: ");
            foreach (StudentsList.Students a in studentsArray)
            {
               
                Console.WriteLine($"Средний балл студента {a.name} {a.lastName}: {a.middleGrade}");
            }
            Console.WriteLine();
            Console.WriteLine($"Список худших студентов: ");
            
            foreach (StudentsList.Students a in worstStudents)
            {

                Console.WriteLine($"Средний балл студента {a.name} {a.lastName}: {a.middleGrade}");
            }

            Console.ReadLine();
        }
    }
}
