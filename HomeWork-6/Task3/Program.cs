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
    /// Шмаков.
    /// </summary>
    /// 

    
    delegate int CountStudentsBySomeParams(List<Student> students, string param);

    
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
    class CountedStudents
    {
        public int course { get; set; }
        public int studentOnCourse { get; set; }

        public CountedStudents()
        {

        }
        
        /// <summary>
        /// Создаёт частотный массив из коллекции со студентами
        /// </summary>
        /// <param name="studentsList">Коллекция студентов</param>
        /// <param name="minAge">Минимальный возраст</param>
        /// <param name="maxAge">Максимальный возраст</param>
        /// <returns>Коллекция с распределением по курсам в указанном возрасте</returns>
        public static List<CountedStudents> CountStudentsByAge (List<Student> studentsList, int minAge, int maxAge)
        {
           List<CountedStudents> countedStudents = new List<CountedStudents>();
            for (int i = minAge; i <= maxAge; i++)
            {
                
                foreach (Student a in studentsList)
                {
                    if (a.age == i)
                    {
                        if (!countedStudents.Exists(x => x.course == a.course)) 
                        {
                                countedStudents.Add(new CountedStudents() {course = a.course, studentOnCourse = 1});
                        }
                        else 
                        {
                            int index = countedStudents.FindIndex(w => w.course == a.course);
                            countedStudents[index].studentOnCourse += 1;
                            //Console.WriteLine(countedStudents[index].studentOnCourse);
                                
                        }
                    }
                }
                
            }
            // сортируем массив по возрастанию курса
            if (countedStudents.Count > 2) countedStudents.Sort((x, y) => x.course.CompareTo(y.course));
            return countedStudents;
        }

        

        public static int CountedCourses (List<Student> studentsList, int minCourse, int maxCourse)
        {
            int summ = 0;
            for (int i = minCourse; i <= maxCourse; i++)
            {
                foreach (Student a in studentsList)
                {
                    if (a.course == i)
                    {
                        summ++;
                    }
                }
            }
            return summ;
        }
        // Поищем студентов по произвольному параметру
        public static List<Student> UniversalSearch(List<Student> list, string x)
        {

            List<Student> newList = new List<Student>();
            int intX;
            foreach (Student obj in list)
            {
                if (Int32.TryParse(x, out intX))
                {
                    if (obj.age == intX || obj.course == intX)
                    {
                        newList.Add(obj);
                    }
                    
                }
                else
                {
                    if (obj.firstName.Contains(x) || obj.lastName.Contains(x))
                    {
                        newList.Add(obj);
                    }
                    
                }
                
            }
            
            return newList;
        }

    }

    /// <summary>
    /// Парсит список студентов из CSV
    /// </summary>
    class StudentsParse
    {
        public List<Student> students = new List<Student>();
        

        static int CourceAgeCompare(Student student1, Student student2)
        {
            if (student1.course > student2.course) return 1;
            if (student1.course < student2.course) return -1;
            if (student1.age > student2.age) return 1;
            if (student1.age < student2.age) return -1;
            return 0;
        }

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
                // Сортируем по  возрасту
                if (students.Count > 2)
                {
                    // Сортируем массив по возрасту и курсу
                    students.Sort(new Comparison<Student>(CourceAgeCompare));
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

            int minCourse = 5;
            int maxCourse = 6;

            string searchReq = "Мария";

            // Передаём в конструктор файл, получаем лист из файла

            StudentsParse students = new StudentsParse(filename);
            List<Student> stud = students.students;

            // Считаем студентов по условию задачи
            
            List<CountedStudents> listOfStudents = CountedStudents.CountStudentsByAge(stud, minAge, maxAge);

            int studentsTotal = CountedStudents.CountedCourses(stud, minCourse, maxCourse);
            Console.WriteLine($"Массив студентов из файла: ");
            foreach (Student a in stud) Console.WriteLine($"{a.ToString()}");
            Console.WriteLine($"Всего: {stud.Count}");
            Console.WriteLine();

            if (maxAge % 10 == 1)
            {
                Console.WriteLine($"В возрасте от {minAge} до {maxAge} года на каждом курсе учатся:");
            }
            else
            {
                Console.WriteLine($"В возрасте от {minAge} до {maxAge} лет накаждом курсе учатся:");
            }
            
            

            foreach (CountedStudents a in listOfStudents)
            {

                Console.WriteLine($"{a.course} курс: {a.studentOnCourse} человек");
            }
            Console.WriteLine();

            if (studentsTotal % 10 >= 2 && studentsTotal % 10 <= 5 )
            {
                Console.WriteLine($"Всего c {minCourse} по {maxCourse} курс учатся: {studentsTotal} человека");
            }
            else
            {
                Console.WriteLine($"Всего c {minCourse} по {maxCourse} курс учатся: {studentsTotal} человек");
            }

            List<Student> student1 = CountedStudents.UniversalSearch(stud, searchReq);
            
            Console.WriteLine();
            Console.WriteLine($"Результат поиска \"{searchReq}\":");
            
            
                if (student1.Count == 0)
                {
                    Console.WriteLine($"Ничего не найдено");
                }
                else
                {
                    foreach (Student student in student1)
                    {
                        Console.WriteLine($"{student.firstName} {student.lastName} {student.course} курс  {student.age} лет");
                    }
                }
            

            Console.ReadKey();
        }
    }

}
