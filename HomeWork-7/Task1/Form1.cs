using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{

    
    public partial class Form1 : Form
    {


        public event EventHandler SomeEvent;

        int number = 0;
        int answer = 0;
        int counter = 0;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
            button1.Text = "+1";
            button2.Text = "x2";
            button3.Text = "Сброс";
            button4.Text = "Играть";
            label1.Text = $"Число: {score}";
            label2.Text = $"Ходов: {counter}";
            if (number == 0)
            {
                label3.Text = "Число пока не придумано";
                label4.Text = "Минимальное число ходов неисвестно";
            }
            else
            {
                label3.Text = $"Загаданное число: {number}";
                label4.Text = $"Минимальное число ходов: {answer}";
            }
            this.Text = "Удвоитель";


            SomeEvent += Form1_SomeEvent1;


        }

        private void Form1_SomeEvent1(object sender, EventArgs e)
        {
            Random rand = new Random();

            number = rand.Next(50, 500);

            int number1 = number;
            answer = 0;

            // Поищем наименьшее число ходов
            while (number1 > 0)
            {
                if (number1 % 2 == 0)
                {
                    number1 /= 2;
                    answer++;
                }
                else
                {
                    number1--;
                    answer++;
                }
            }
            if (number == 0)
            {
                label3.Text = "Число пока не придумано";
                label4.Text = "Минимальное число ходов неисвестно";
            }
            else
            {
                label3.Text = $"Загаданное число: {number}";
                label4.Text = $"Минимальное число ходов: {answer}";
            }
        }

            private void button1_Click(object sender, EventArgs e)
            {
                score++;
                counter++;
                label1.Text = $"Число: {score}";
                label2.Text = $"Ходов: {counter}";

            if (score > number)
            {
                MessageBox.Show("Перебор");
                score = 0;
                counter = 0;
            }
            else if (counter > answer)
            {
                MessageBox.Show("Вы проиграли");
                score = 0;
                counter = 0;
            }
            if (number == 0)
            {
                label3.Text = "Число пока не придумано";
                label4.Text = "Минимальное число ходов неисвестно";
            }
            else
            {
                label3.Text = $"Загаданное число: {number}";
                label4.Text = $"Минимальное число ходов: {answer}";
            }

        }

            private void button2_Click(object sender, EventArgs e)
            {
                score *= 2;
                counter++;

                label1.Text = $"Ваше число: {score}";
                label2.Text = $"Ваши ходы: {counter}";
            if (score > number)
            {
                MessageBox.Show("Перебор");
                score = 0;
                counter = 0;
            }
            else if (counter > answer)
            {
                MessageBox.Show("Вы проиграли");
                score = 0;
                counter = 0;
            }
            if (number == 0)
            {
                label3.Text = "Число пока не придумано";
                label4.Text = "Минимальное число ходов неисвестно";
            }
            else
            {
                label3.Text = $"Загаданное число: {number}";
                label4.Text = $"Минимальное число ходов: {answer}";
            }
        }

            private void button3_Click(object sender, EventArgs e)
            {
                score = 0;
                counter = 0;
            label1.Text = $"Ваше число: {score}";
            label2.Text = $"Ваши ходы: {counter}";

        }
            private void button4_Click(object sender, EventArgs e)
            {

           if (SomeEvent != null)
            {
                SomeEvent.Invoke(sender,  e);
            }
            string caption = $"Я загадал некое число";

            string message = $"{number}";

            score = 0;
            counter = 0;
            label1.Text = $"Ваше число: {score}";
            label2.Text = $"Ваши ходы: {counter}";

            MessageBox.Show(message, caption);
        }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void Form1_Load(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            //public delegate void SomeNumbersHandler(object sender, SomeNumbers e);

        }

    }

