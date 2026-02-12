using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad_1
{
    internal class DatabaseHelper
    {
        private string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable getStudents(int option)
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "";

                if (option == 1)
                {
                    query = "SELECT Name, Age, Grade, Mark FROM Students";
                }
                else if (option == 2)
                {
                    query = "SELECT Name, Age FROM Students";
                }
                else if (option == 3)
                {
                    query = "SELECT Name, Age, Grade, Mark FROM Students WHERE Age > 18";
                }
                else
                {
                    MessageBox.Show("Please select a radiobutton.");
                    return table;
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                table.Load(dr);
            }
            return table;
        }
    }
}
