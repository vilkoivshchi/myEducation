using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        string formHeader = "CSV to XML converter";
        private TrueFalse database;

        public Form1()
        {
            InitializeComponent();
            this.Text = formHeader;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV, semicolon separated|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFileName.Text = openFileDialog.FileName;
                database = new TrueFalse(openFileDialog.FileName);
                database.LoadCSV();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML file|*.xml";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                destFileName.Text = saveFileDialog.FileName;
            }
        }
    }
}
