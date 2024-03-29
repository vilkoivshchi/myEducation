﻿using System;
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
        private NewStudent database;
        private string file2save;
        private bool src = false;
        private bool dst = false;

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
                database = new NewStudent(openFileDialog.FileName);
                database.LoadCSV();
                
                if (database.Count == 0)
                {
                    sourceFileName.BackColor = Color.Pink;
                    MessageBox.Show("Wrong File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    src = true;
                    sourceFileName.ResetBackColor();
                }
                    
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML file|*.xml";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                destFileName.Text = saveFileDialog.FileName;
                file2save = saveFileDialog.FileName;
                dst = true;
                destFileName.ResetBackColor();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!src)
            {
                sourceFileName.BackColor = Color.Pink;
            }
            else
            {
                sourceFileName.ResetBackColor();
            }
            if (!dst)
            {
                destFileName.BackColor = Color.Pink;
            }
            else
            {
                destFileName.ResetBackColor();
            }

            if (src && dst)
            {
                database.SaveAs(file2save);
                MessageBox.Show("Complete");
            }
            
            
        }
    }
}
