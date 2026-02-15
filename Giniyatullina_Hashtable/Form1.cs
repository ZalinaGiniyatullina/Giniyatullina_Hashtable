using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giniyatullina_Hashtable
{
    public partial class Form1 : Form
    {
        private Hashtable phoneBook = new Hashtable();
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdatePhoneList()
        {
            listBox1.Items.Clear();
            foreach (DictionaryEntry entry in phoneBook)
            {
                listBox1.Items.Add($"{entry.Key}: {entry.Value}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text.Trim();
            string phone = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Введите фамилию и телефон!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (phoneBook.ContainsKey(surname))
            {
                MessageBox.Show("Запись с такой фамилией уже существует!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            phoneBook.Add(surname, phone);
            textBox1.Clear();
            textBox2.Clear();
            UpdatePhoneList();
            MessageBox.Show("Запись добавлена!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Введите фамилию для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (phoneBook.ContainsKey(surname))
            {
                phoneBook.Remove(surname);
                UpdatePhoneList();
                textBox1.Clear();
                MessageBox.Show("Запись удалена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Запись с такой фамилией не найдена!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Введите фамилию для поиска!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listBox1.Items.Clear();

            if (phoneBook.ContainsKey(surname))
            {
                string phone = phoneBook[surname].ToString();
                listBox1.Items.Add($"Найдено: {surname} - {phone}");
            }
            else
            {
                listBox1.Items.Add($"Фамилия '{surname}' не найдена");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string phone = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Введите номер телефона для поиска!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listBox1.Items.Clear();
            bool found = false;

            foreach (DictionaryEntry entry in phoneBook)
            {
                if (entry.Value.ToString() == phone)
                {
                    listBox1.Items.Add($"Найдено: {entry.Value} - {entry.Key}");
                    found = true;
                }
            }

            if (!found)
            {
                listBox1.Items.Add($"Телефон '{phone}' не найден");
            }
        }
    }
}
