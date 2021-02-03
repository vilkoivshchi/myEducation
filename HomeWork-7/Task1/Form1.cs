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
        public Form1()
        {
            InitializeComponent();
            button1.Text = "+1";
            button2.Text = "x2";
            button3.Text = "Сброс";
            button4.Text = "Играть";
            label1.Text = "0";
            label2.Text = "0";
            this.Text = "Удвоитель";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (int.Parse(label1.Text) + 1).ToString();
            label2.Text = (int.Parse(label2.Text) + 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = (int.Parse(label1.Text) * 2).ToString();
            label2.Text = (int.Parse(label2.Text) + 1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "0";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string caption = "Я загадал число";
            
            string message = numbers.number.ToString();
            
            label1.Text = "0";
            label2.Text = "0";

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

        public delegate void SomeNumbersHandler(object sender, SomeNumbers e);
       public class SomeNumbers
        {
            public int number { get; }
            public int answer { get; }
            public SomeNumbers()
            {
                int[] finalArr = new int[2];
                
                Random rand = new Random();

                number = rand.Next(50, 500);
                
                int answer = 0;
                
                // Поищем наименьшее число ходов
                while (number > 0)
                {
                    if (number % 2 == 0)
                    {
                        number /= 2;
                        answer++;
                    }
                    else
                    {
                        number--;
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
}
