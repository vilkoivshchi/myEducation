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
            label1.Text = "1";
            label2.Text = (int.Parse(label2.Text) + 1).ToString();
        }
    }
}
