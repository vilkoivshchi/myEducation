using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// 3. Переделать программу «Пример использования коллекций» для решения следующих задач:
    /// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    /// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
    /// в) отсортировать список по возрасту студента;
    /// г) * отсортировать список по курсу и возрасту студента;
    /// д) разработать единый метод подсчета количества студентов по различным параметрам
    /// выбора с помощью делегата и методов предикатов.
    /// 
    /// Переписывайте в начало программы условие и свою фамилию. Все программы сделайте в одном решении.
    /// </summary>
    /// 

    delegate List <CourseCount> CountStudents (int a, int b);

    class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int course { get; set; }
        public int age { get; set; }

        public override string ToString()
        {
            // немного склонений
            if (age % 10 == 1)
            {
                return $"{firstName} {lastName}, {course} курс, {age} год";
            }
            else if (age % 10 > 1 && age % 10 <= 4)
            {
                return $"{firstName} {lastName}, {course} курс, {age} года";
            }
            else
            {
                return $"{firstName} {lastName}, {course} курс, {age} лет";
            }
        }


    }
    class CourseCount
    {
        public int course { get; set; }
        public int studentOnCourse { get; set; }


        public List<CourseCount> countedStudents = new List<CourseCount>();

        public CourseCount()
        {

        }
        /// <summary>
        /// Конструктор считает количество студентов на каждом курсе. 
        /// Можно было бы просто вывести всё это в консоль, но с этим потом ничего не сделать.
        /// </summary>
        /// <param name="studentsList">Лист с данными студентов</param>
        /// <param name="minAge">Мин. курс</param>
        /// <param name="maxAge">Макс. курс</param>
        public CourseCount(List<Student> studentsList, int minAge, int maxAge)
        {
           /* 
            for (int i = minAge; i <= maxAge; i++ )
                {
                    countedStudents.Add(new CourseCount() { course = i, studentOnCourse = 0});
                }
            foreach (CourseCount a in countedStudents) Console.WriteLine($"{a.course}; {a.studentOnCourse}");
           */
            for (int i = minAge; i <= maxAge; i++)
            {
                
                foreach (Student a in studentsList)
                {
                    if (a.age == i)
                    {
                        if (countedStudents.Exists(x => x.course == a.course)) 
                            {
                                countedStudents.Add(new CourseCount() {course = a.course, studentOnCourse = 1});
                            }
                        else 
                            {
                                
                                int index = countedStudents.FindIndex(w => w.course == a.course);
                                Console.WriteLine(index);
                                
                            }
                    }
                }
                
            }
            //foreach (CourseCount a in countedStudents) Console.WriteLine($"{a.course}; {a.studentOnCourse}");
        }

       

    }

    class StudentsParse
    {
        public List<Student> students = new List<Student>();
        public StudentsParse(string filename)
        {
            if (File.Exists(filename))
            {
                int lineCounter = 0;
                using (var reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        int courseStudents, ageStudents;

                        // CSV parse
                        string[] line = reader.ReadLine().Split(';');
                        // Создаём экземпляр класса
                        Student strudent = new Student();
                        Regex nameRegex = new Regex(@"^[ЁёА-Яа-яA-Za-z]*$");
                        if (nameRegex.IsMatch(line[0]) && nameRegex.IsMatch(line[1]))
                        {
                            if (Int32.TryParse(line[2], out courseStudents) && Int32.TryParse(line[3], out ageStudents))
                            {
                                if (courseStudents >= 1 && courseStudents <= 6)
                                {
                                    students.Add(new Student() { firstName = line[0], lastName = line[1], course = courseStudents, age = ageStudents });
                                }
                                else Console.WriteLine($"Курс вне допустимых пределов");
                            }
                            else Console.WriteLine($"Ошибка в строке {lineCounter + 1}. Курс или возраст имеют неверный формат");
                        }
                        else Console.WriteLine($"Ошибка в строке {lineCounter + 1}. Неправильный формат имени или фамилии");
                        lineCounter++;
                    }
                }
                // Сортируем по возрасту
                if (students.Count > 10)
                {
                  students.Sort((x, y) => x.age.CompareTo(y.age));
                }
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filename = "students.csv";
            filename = AppDomain.CurrentDomain.BaseDirectory + filename;

            int minAge = 18;
            int maxAge = 20;
            int studentsTotal = 0;
            // Передаём в конструктор файл, получаем лист из файла
            StudentsParse students = new StudentsParse(filename);
            List<Student> stud = students.students;

            // Передаём в коструктор лист из файла и параметры выбора курса.
            CourseCount courseCount = new CourseCount(stud, minAge, maxAge);
            List<CourseCount> listOfStudents = courseCount.countedStudents;
                        
            foreach (Student a in stud) Console.WriteLine($"{a.ToString()}");
            Console.WriteLine();
            Console.WriteLine($"На каждом курсе с {minAge} по {maxAge} учатся:");
            foreach (CourseCount a in listOfStudents)
            {

                Console.WriteLine($"{a.course} курс: {a.studentOnCourse} человек");
                studentsTotal += a.studentOnCourse;
                
            }
            Console.WriteLine($"Всего c {minAge} по {maxAge} учатся: {studentsTotal} человек");
            
            
            Console.ReadKey();
        }
    }

}
