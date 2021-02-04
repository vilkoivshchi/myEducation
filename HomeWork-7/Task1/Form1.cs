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

    public delegate void SomeNumbersHandler(object sender, SomeNumbers e);
    public partial class Form1 : Form
    {
        public event EventHandler NumbersHandler;
        public event SomeNumbersHandler SomeNumbersHandlerEvent;

        int counter = 0;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
            button1.Text = "+1";
            button2.Text = "x2";
            button3.Text = "Сброс";
            button4.Text = "Играть";
            label1.Text = $"Число: {score.ToString()}";
            label2.Text = $"Ходов: {counter.ToString()}";
            this.Text = "Удвоитель";

            NumbersHandler += Form1_NumbersHandler1;
            SomeNumbersHandlerEvent += Form1_SomeNumbersHandlerEvent;

        }

        private void Form1_SomeNumbersHandlerEvent(object sender, SomeNumbers e)
        {
            //throw new NotImplementedException();
            string caption = $"Я загадал число {e.answer}";

            string message = $"{e.number}";

            score = 0;
            counter = 0;
            label1.Text = $"Число: {score}";
            label2.Text = $"Ходов: {counter}";

            MessageBox.Show(message, caption);
        }

        private void Form1_NumbersHandler1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            score++;
            counter++;
            label1.Text = $"Число: {score}";
            label2.Text = $"Ходов: {counter}";
            //NumbersHandler.Invoke(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            score *= 2;
            counter++;
            if (score > 10) NumbersHandler.Invoke(sender, e);
            label1.Text = $"Число: {score}";
            label2.Text = $"Ходов: {counter}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            score = 0;
            counter = 0;
            label1.Text = $"Число: {score}";
            label2.Text = $"Ходов: {counter}";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SomeNumbersHandlerEvent.Invoke(sender, new SomeNumbers());
            

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
    public class SomeNumbers : EventArgs
    {
        public int number { get; }
        public int answer { get; }
        
        public SomeNumbers()
        {
            
            Random rand = new Random();

            number = rand.Next(50, 500);

            int number1 = number;
            int answer = 0;

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

        }
        /*
        public static int CheckAnswer(int a)
        {

        }
        */
    }
}
