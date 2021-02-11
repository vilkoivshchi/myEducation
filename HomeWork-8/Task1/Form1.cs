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
    /// <summary>
    /// 1. а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок 
    /// (не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
    /// б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» 
    /// улучшения на свое усмотрение.
    /// в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
    /// г) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос.
    /// д) Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog).
    /// </summary>
    public partial class Form1 : Form
    {
        private TrueFalse database;
        public string formHeader = "Question editor";
        
        public Form1()
        {
            InitializeComponent();
            this.Text = formHeader;
            
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(saveFileDialog.FileName);
                database.Add("Тестовый вопрос, да или нет?", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;

            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(openFileDialog.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;

                if (database.Count != 0)
                {
                    tbQuestion.Text = database[0].Text;
                    cbTrue.Checked = database[0].TrueFalse;
                }
                this.Text = formHeader + $" - {openFileDialog.FileName}";
            }

        }

        /// <summary>
        /// Обновим вопрос в коллекции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
            database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
        }

        // Проверка поля с номером вопроса
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if (database != null)
            {
                tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
            }
            else
            {
                nudNumber.Value = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Create database first!", "Oooops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
            database.Save();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                var dialog = MessageBox.Show("Delete question?", "Confim deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (nudNumber.Maximum == 1 || database == null)
                        return;
                    database.Remove((int)nudNumber.Value - 1);
                    nudNumber.Maximum--;
                    database.Save();
                }
            }
            else
            {
                MessageBox.Show("Create database first!", "Oooops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {

                database.Save();
            }
            else
            {
                MessageBox.Show("Create database first!", "Oooops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show($"Training application\n" +
                $"v.{version}", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (database != null)
            {
                if (cbTrue.Checked)
                {
                    database[(int)nudNumber.Value - 1].TrueFalse = true;
                }
                else
                {
                    database[(int)nudNumber.Value - 1].TrueFalse = false;
                }
            }
        }

       

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                
                saveFileDialog.Filter = "xml files (*.xml)|*.xml";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    database.SaveAs(saveFileDialog.FileName);
                }
                this.Text = formHeader + $" - {saveFileDialog.FileName}";

            }
            else
            {
                MessageBox.Show("Create database first!", "Oooops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
