using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Введите количество знаков после запятой:";
            label3.Text = "Результат: ";
            button1.Text = "Рассчитать";
            button2.Text = "Очистить";
            button1.AutoSize = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            listBox1.Items.Clear();
            label3.Text = "Результат: ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int decNumber = int.Parse(textBox1.Text);

                if (decNumber > 15)
                {
                    MessageBox.Show("Привышено количество знаков после запятой (15)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string formattedNum = Math.Round(Math.PI, decNumber).ToString($"F{decNumber}");
                label3.Text = $"Результат: {formattedNum}";
                listBox1.Items.Add(formattedNum);
            }

            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, используйте только числа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
