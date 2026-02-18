using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zad_1;

namespace LibraryDB
{
    public partial class Library : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        public Library()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbHelper.getBooks();

            var stats = dbHelper.getStatistics();

            label1.Text = "Общо книги: " + stats.totalBooks;
            label2.Text = "Най-стара година: " + stats.oldestYear;

            label1.Visible = true;
            label2.Visible = true;
        }

        private void Library_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            var categories = dbHelper.getCategories();
            foreach (var cat in categories)
            {
                comboBox1.Items.Add(cat);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedCategory = comboBox1.SelectedItem.ToString();
                string query = $"SELECT Title, Author, YearPublished, Category FROM Books WHERE Category = '{selectedCategory}'";
                dataGridView1.DataSource = dbHelper.executeQuery(query);
            }
            else
            {
                MessageBox.Show("Please select a category.");
            }
        }
    }
}
