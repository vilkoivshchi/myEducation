using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        private TrueFalse database;
        // счет
        private int score = 0;
        // всего вопросов
        private int questions = 1;
        // текущий индекс вопроса и ответа
        int currQuestNum = 0;
        bool currAnswer;
        // текущий номер вопроса в раунде
        int questionsInRound = 1;
        int currRoundQuestion = 1;
        // запущена ли игра?
        bool isGameRun = false;


        public Form1()
        {
            InitializeComponent();
            trackBar1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(openFileDialog.FileName);
                database.Load();
                trackBar1.Minimum = 1;
                QuesionsNum.Text = $"Вопросов в раунде: {trackBar1.Minimum}";
                trackBar1.Maximum = database.Count;
                trackBar1.Enabled = true;

                if (database.Count == 0)
                {
                    MessageBox.Show("Файл повреждён", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    QuestionLabel.Text = "Файл с вопросами загружен";
                }

            }
           
        }
        /// <summary>
        /// Метод начинает новую игру
        /// </summary>
        private void NewGame()
        {
            if (database != null)
            {
                score = 0;
                NewQuestion();
                questionsInRound = trackBar1.Value;
                trackBar1.Enabled = false;
                isGameRun = true;
                currRoundQuestion = 1;
                QuestCount.Text = $"Вопрос {currRoundQuestion} из {questionsInRound}";
            }
            else
            {
                QuestionLabel.Text = "Сперва загрузите файл с вопросами";
            }

        }
        /// <summary>
        /// Метод выбирает и показывает вопрос
        /// </summary>
        private void NewQuestion()
        {
            Random rand = new Random();
            currQuestNum = rand.Next(0, database.Count - 1);
            QuestionLabel.Text = database[currQuestNum].Text;
            currAnswer = database[currQuestNum].TrueFalse;
            QuestCount.Text = $"Вопрос {currRoundQuestion} из {questionsInRound}";
        }

        private void GameOver()
        {
            MessageBox.Show($"Ваш результат: {score} из {questionsInRound}");
            trackBar1.Enabled = true;
            isGameRun = false;
        }
        /// <summary>
        /// Ползунок устанавливет кол-во вопросов в раунде
        /// </summary>
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            questions = trackBar1.Value;
            QuesionsNum.Text = $"Вопросов в раунде: {trackBar1.Value}";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (isGameRun)
            {
                if (currRoundQuestion < questionsInRound)
                {
                    if (currAnswer)
                    {
                        score++;
                    }
                    ScoreLabel.Text = $"Счёт: {score}";
                    currRoundQuestion++;
                    NewQuestion();
                }
                else
                {
                    GameOver();
                }
            }
            else
            {
                QuestionLabel.Text = "Начните новую игру";
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (isGameRun)
            {
                if (currRoundQuestion < questionsInRound)
                {
                    if (!currAnswer)
                    {
                        score++;
                    }
                    
                    ScoreLabel.Text = $"Счёт: {score}";
                    currRoundQuestion++;
                    NewQuestion();
                }
                else
                {
                    GameOver();
                }
            }
            else
            {
                QuestionLabel.Text = "Начните новую игру";
            }
        }

        private void QuestionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
