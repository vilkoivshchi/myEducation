using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// 5. **Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет. 
    /// Например: «Шариковую ручку изобрели в древнем Египте», «Да». 
    /// Компьютер загружает эти данные, случайным образом выбирает 
    /// 5 вопросов и задаёт их игроку. Игрок отвечает Да или Нет на каждый 
    /// вопрос и набирает баллы за каждый правильный ответ. 
    /// Список вопросов ищите во вложении или воспользуйтесь интернетом.
    /// </summary>
    
    
    class Game
    {
        /// <summary>
        /// Содержит вопросы и ответы к игре
        /// </summary>
        public struct GameData
        {
            public GameData(int _number, string _quession, bool _answer)
            {
                number = _number;
                quession = _quession;
                answer = _answer;
            }

            public int number { get;  }
            public string quession { get; }
            public bool answer { get;  }

        }

        public GameData[] gameDatas;

        public Game(string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                // Считаем количество строк в файле 
                int lines = File.ReadAllLines(filename).Length;

                gameDatas = new GameData[lines];

                char[] splitter = { '.', '(', ')' };
                // Парсим файл
                for (int i = 0; i < lines; i++)
                {
                    string line = reader.ReadLine();
                    string[] parsedLine = line.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                    int quessionNum;
                    bool answer;
                    if (Int32.TryParse(parsedLine[0], out quessionNum))
                    {
                        if (String.Compare(parsedLine[2], "да", true) == 0)
                        {
                            answer = true;
                            GameData completeAnswer = new GameData(quessionNum, parsedLine[1], answer);
                            gameDatas[i] = completeAnswer;
                        }
                        else if (String.Compare(parsedLine[2], "нет", true) == 0)
                        {
                            answer = false;
                            GameData completeAnswer = new GameData(quessionNum, parsedLine[1], answer);
                            gameDatas[i] = completeAnswer;
                        }
                        else Console.WriteLine($"Ошибка в строке {i + 1}. Ответ на вопрос должен быть \"Да\" или \"Нет\"");

                    }
                    else Console.WriteLine($"Ошибка в строке {i + 1}. Первым должен быть номер вопроса.");
                    
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
            
            string filename = "quessions.txt";
            filename = AppDomain.CurrentDomain.BaseDirectory + filename;
            Game game = new Game(filename);
            Game.GameData[] gameData = game.gameDatas;

            Random rand = new Random();

            int qNum = 5;
            
            int score = 0;
            for (int i = 0; i < qNum; i++)
            {
                int quessNum = rand.Next(1, gameData.Length);

                bool wrongKey = true;
                                
                do
                {
                    Console.Clear();
                    Console.Write($"{gameData[quessNum].quession} ");
                    
                    char key = Console.ReadKey().KeyChar;

                    if (key == 'д' || key == 'н' || key == 'Д' || key == 'Н')
                    {
                        if (key == 'Д' || key == 'д')
                        {
                            bool currentAnswer = true;
                            if (currentAnswer == gameData[quessNum].answer) score++;
                        }
                        else 
                        {
                            bool currentAnswer = false;
                            if (currentAnswer == gameData[quessNum].answer) score++;
                        }
                            wrongKey = false;
                    }
                }
                while (wrongKey != false);

                Console.WriteLine();
            }
            Console.WriteLine($"Ваш счёт: {score}");
            Console.ReadKey();
        }
    }
}
