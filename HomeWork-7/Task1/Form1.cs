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
  /// 1. а) Добавить в программу «Удвоитель» подсчет количества отданных команд.
  /// б) Добавить меню и команду «Играть». При нажатии появляется сообщение,
  /// какое число должен получить игрок.
  /// Игрок должен постараться получить это число за минимальное количество ходов.
  /// в) * Добавить кнопку «Отменить», которая отменяет последние ходы.
  /// </summary>

  public partial class Form1 : Form
  {


    public event EventHandler SomeEvent;

    int number = 0;
    int answer = 0;
    int counter = 0;
    int score = 0;
       // int CurrentListPos = 0;

    List<Turns> actionList = new List<Turns>();

    public Form1()
    {
      InitializeComponent();
        
    
            plus1.Text = "+1";
      x2.Text = "x2";
      reset.Text = "Сброс";
      Begin.Text = "Играть";
            Undo.Text = "Отменить";

      label1.Text = $"Ваше число: {score}";
      label2.Text = $"Ваши ходы: {counter}";
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

      number = rand.Next(10, 100);

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
            actionList.Clear();

        }
    // +1
    private void button1_Click(object sender, EventArgs e)
    {
      score++;
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
      else if (counter <= answer && score == number)
      {
        MessageBox.Show("Поздравляю!");
      }


      if (number == 0)
      {
        label3.Text = "Число пока не придумано";
        label4.Text = "Минимальное число ходов неизвестно";
      }

      else
      {
        label3.Text = $"Загаданное число: {number}";
        label4.Text = $"Минимальное число ходов: {answer}";
      }

      actionList.Add(new Turns() { TurnNumber = counter, TurnAnswer = score });
    }

    // x2
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
      else if (counter <= answer && score == number)
      {
        MessageBox.Show("Поздравляю!");
      }



      if (number == 0)
      {
        label3.Text = "Число пока не придумано";
        label4.Text = "Минимальное число ходов неизвестно";
      }

      else
      {
        label3.Text = $"Загаданное число: {number}";
        label4.Text = $"Минимальное число ходов: {answer}";
      }
            actionList.Add(new Turns() { TurnNumber = counter, TurnAnswer = score });

        }

    // Сброс
    private void button3_Click(object sender, EventArgs e)
    {
      score = 0;
      counter = 0;
      label1.Text = $"Ваше число: {score}";
      label2.Text = $"Ваши ходы: {counter}";
      actionList.Clear();
    }

    private void button4_Click(object sender, EventArgs e)
    {

      if (SomeEvent != null)
      {
        SomeEvent.Invoke(sender,  e);
      }

      score = 0;
      counter = 0;
      label1.Text = $"Ваше число: {score}";
      label2.Text = $"Ваши ходы: {counter}";


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
        // Кнопка отмены, показывает всякую дичь, нужно разобраться
        private void Undo_Click(object sender, EventArgs e)
        {
            int CurrentListPos = actionList.Count - 1;
            if (actionList.Count > 0)
            {
                counter = actionList[CurrentListPos].TurnNumber;
                score = actionList[CurrentListPos].TurnAnswer;
                actionList.RemoveRange(CurrentListPos, actionList.Count - CurrentListPos);
                //actionList.RemoveAt(CurrentListPos - 2);
                label1.Text = $"Ваше число: {score}";
                label2.Text = $"Ваши ходы: {counter}";
            }

        }
    }
    class Turns
  {
    public int TurnNumber { get; set; }
    public int TurnAnswer { get; set; }
  }
}
