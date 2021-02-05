using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    /// <summary>
    /// 2. Используя Windows Forms, разработать игру «Угадай число». 
    /// Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. 
    /// Для ввода данных от человека используется элемент TextBox.
    /// Шмаков.
    /// </summary>
    public partial class Form1 : Form
    {
        int inputInt;
        Random rnd = new Random();
        int someInt = 0;
        int counter = 0;

        /// <summary>
        /// Чтобы быстрее проверить, напишу ответ в конце
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Text = "Угадай число";
            label1.Text = $"Я загадал некое число,\n" +
                $"от 1 до 100 \n" +
                $"попробуй угадать какое ({someInt})";
            button1.Text = "Угадать";
            someInt = rnd.Next(1, 100);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out inputInt))
            {
                textBox1.BackColor = Color.Pink;
            }
            else
            {
                textBox1.ResetBackColor();

            }

            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inputInt == someInt)
            {
                MessageBox.Show($"Ура!\n" +
                    $"Было попыток: {counter}");
            }
            else if (inputInt == 0)
            {
                MessageBox.Show("Введите число");
                
            }
            else if (inputInt < someInt)
            {
                MessageBox.Show("Моё число больше");
                counter++;
            }
            
            else
            {
                MessageBox.Show("Моё число меньше");
                counter++;
            }
        }
    }
}
