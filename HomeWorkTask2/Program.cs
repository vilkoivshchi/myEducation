using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTask2
{
    /// <summary>
    /// 2. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) 
    /// по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах
    /// Шмаков
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Давайте расскичтаем Индекс массы тела (ИМТ), для этого напишите ");
            Console.Write("Рост (м), через запятую: ");
            string userHeight = Console.ReadLine();
            Console.Write("Вес (кг): ");
            string userWeight = Console.ReadLine();
            
            double m = Convert.ToDouble(userWeight);
            double h = Convert.ToDouble(userHeight);
            
            double weightIndex = (m / (h * h));

            Console.WriteLine($"ИМТ составляет: {weightIndex}"); ;
            Console.ReadLine();
        }
    }
}
