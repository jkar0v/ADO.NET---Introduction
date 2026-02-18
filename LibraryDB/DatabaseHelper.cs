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
            "Server=localhost\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable getBooks()
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Title, Author, YearPublished, Category FROM Books";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                table.Load(dr);
            }
            return table;
        }

        public List<string> getCategories()
        {
            List<string> categories = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Category FROM Books";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    categories.Add(dr["Category"].ToString());
                }

                dr.Close();
            }

            return categories;
        }
        public DataTable executeQuery(string query)
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                table.Load(dr);
                dr.Close();
            }

            return table;
        }

        public (int totalBooks, int oldestYear) getStatistics()
        {
            int totalBooks = 0;
            int oldestYear = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) AS TotalBooks, MIN(YearPublished) AS OldestYear FROM Books";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    totalBooks = Convert.ToInt32(dr["TotalBooks"]);
                    oldestYear = Convert.ToInt32(dr["OldestYear"]);
                }

                dr.Close();
            }

            return (totalBooks, oldestYear);
        }


    }
}
