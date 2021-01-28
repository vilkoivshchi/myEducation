using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        /// <summary>
        /// 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
        /// а) с использованием методов C#;
        /// б) *разработав собственный алгоритм.
        /// Например:
        /// badc являются перестановкой abcd.
        /// </summary>

        /// <summary>
        /// Смотрит, не является ли одна строка перестановкой другой при помощи встроенных методов
        /// </summary>
        /// <param name="one">строка 1</param>
        /// <param name="two">строка 2</param>
        /// <returns></returns>
        static bool CompareStrings(string one, string two)
        {
            bool compareResult = false;
            if (one.Length != two.Length)
            {
                return compareResult;
            }
            else
            {
                char[] oneChar = one.ToCharArray();
                char[] twoChar = two.ToCharArray();

                Array.Sort(oneChar);
                Array.Sort(twoChar);

                compareResult = oneChar.SequenceEqual(twoChar);
                return compareResult;
            }
        }

        /// <summary>
        /// Смотрит, не является ли одна строка перестановкой другой без встроенных методов, сортировки, регистрации и смс
        /// </summary>
        /// <param name="one">строка 1</param>
        /// <param name="two">строка 2</param>
        /// <returns></returns>
        static bool CustomCompareStrings(string one, string two)
        {
            bool compareResult = false;
            if (one.Length != two.Length)
            {
                return compareResult;
            }
            else
            {
                char[] oneChar = one.ToCharArray();
                char[] twoChar = two.ToCharArray();

                for (int i = 0; i < oneChar.Length; i++ )
                {
                 
                    for (int j = 0; j < twoChar.Length; j++)
                    {
                        if (oneChar[i] == twoChar[j])
                        {
                            oneChar[i] = ' ';
                            twoChar[j] = ' ';
                            
                        }
                       
                    }

                }
                int summCheck = 0;
                foreach (char a in oneChar)
                {
                    if (a != ' ') summCheck++;
                }
                if (summCheck == 0)
                {
                    compareResult = true;
                }
                return compareResult;
            }
        }
    

        static void Main(string[] args)
        {
            string one = "abcdeffedcba";
            string two = "fedcbaabcdef";


            Console.WriteLine($"Алгоритм со встроенными методами говорит:");
            Console.WriteLine(CompareStrings(one, two) ? $"Строки совпадают" : $"Строки не совпадают" );
            Console.WriteLine();
            Console.WriteLine($"Алгоритм без встроенными методами говорит:");
            Console.WriteLine(CustomCompareStrings(one, two) ? $"Строки совпадают" : $"Строки не совпадают");
            Console.ReadLine();

        }
    }
}
