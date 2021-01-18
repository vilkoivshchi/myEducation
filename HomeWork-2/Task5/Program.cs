using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// 5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
    /// б) * Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
    /// Шмаков.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Подсчет Индекса Массы Тела(ИМТ)
        /// </summary>
        /// <param name="h">Рост</param>
        /// <param name="m">Вес</param>
        /// <returns>ИМТ</returns>
        static double IMT(double h, int m)
        {
            double weightIndex = (m / (h * h));
            return weightIndex;
        }
        /// <summary>
        /// Подсчет разницы весов между нормой и результатом IMT()
        /// </summary>
        /// <param name="weightIndex">ИМТ</param>
        /// <param name="h">Рост</param>
        /// <returns>Разница в весе</returns>
        static double WeightDiff(double weightIndex, double h)
        {
            //ищем разницу между индексами веса, из результата ищем разницу в массах
            double targetIndexMin = 18.5;
            double targetIndexMax = 25;
            double indexDiff;
           //если ИМТ выше нормы, возвращаем отрицательное значение, если меньше - положительное.
            if (weightIndex < targetIndexMin)
            {
                indexDiff = targetIndexMin - weightIndex;
            }
            else if (weightIndex >= targetIndexMax)
            {
                indexDiff = targetIndexMax - weightIndex;
            }
            //если ИМТ в норме, возвращаем 0
            else indexDiff = 0;
            double targetMass = Math.Round((h * h) * indexDiff, 1);
            return targetMass;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Давайте расскичтаем Индекс массы тела (ИМТ), для этого напишите ");
            Console.Write("Рост (см): ");
            double h = Int32.Parse(Console.ReadLine());
            h /= 100;
            Console.Write("Вес (кг): ");
            int m = Int32.Parse(Console.ReadLine());
            //вычисляем индекс ИМТ.
            double weighIndex = IMT(h, m);
            //Ищем разницу в ИМТ
            double result = WeightDiff(weighIndex, h);
            //округляем ИМТ до 2 знаков
            weighIndex = Math.Round(weighIndex, 2);
            
            if (weighIndex < 16)
            {
                Console.WriteLine($"Индекс массы тела: {weighIndex}");
                Console.WriteLine("Ярковыраженный дефицит массы");
                if (result > 0) Console.WriteLine($"Нужно набрать {result} кг");

            }
            else if (weighIndex >= 16 && weighIndex < 18.5)
            {
                Console.WriteLine($"Индекс массы тела: {weighIndex}");
                Console.WriteLine("Дефицит массы");
                if (result > 0) Console.WriteLine($"Нужно набрать {result} кг");
            }
            else if (weighIndex >= 18.5 && weighIndex < 25)
            {
                Console.WriteLine($"Индекс массы тела: {weighIndex}");
                Console.WriteLine("Норма");
            }
            else if (weighIndex >= 25 && weighIndex < 30)
            {
                Console.WriteLine($"Индекс массы тела: {weighIndex}");
                Console.WriteLine("Предожирение");
                if (result < 0) Console.WriteLine($"Нужно сбросить {-result} кг");
            }
            else if (weighIndex >= 30 && weighIndex < 35)
            {
                Console.WriteLine($"Индекс массы тела: {weighIndex}");
                Console.WriteLine("Ожирение первой степени");
                if (result < 0) Console.WriteLine($"Нужно сбросить {-result} кг");
            }
            else if (weighIndex >= 35 && weighIndex < 40)
            {
                Console.WriteLine($"Индекс массы тела: {weighIndex}");
                Console.WriteLine("Ожирение второй степени");
                if (result < 0) Console.WriteLine($"Нужно сбросить {-result} кг");
            }
            else if (weighIndex >= 40)
            {
                Console.WriteLine($"Индекс массы тела: {weighIndex}");
                Console.WriteLine("Ожирение третей степени");
                if (result < 0) Console.WriteLine($"Нужно сбросить {-result} кг");
            }
            Console.ReadKey();
        }
    }
}
