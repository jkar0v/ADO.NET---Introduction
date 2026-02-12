using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad_1
{
    public partial class SchoolDB : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        public SchoolDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedOption = 0;

            if (radioButton1.Checked)
                selectedOption = 1;
            else if (radioButton2.Checked)
                selectedOption = 2;
            else if (radioButton3.Checked)
                selectedOption = 3;

            dataGridView1.DataSource = dbHelper.getStudents(selectedOption);
        }

    }
}
