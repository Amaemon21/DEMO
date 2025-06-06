using System.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DatabaseConnection
    {
        private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=DEMODB;Trusted_Connection=True;";

        private SqlConnection _sqlConnection;

        private void Connection()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
        }

        private DataTable GetPlayersTable()
        {
            Connection();

            DataTable table = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Players", _sqlConnection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            _sqlConnection.Close();
            return table;
        }


        public void DisplayPlayers(DataGridView gridView)
        {
            DataTable table = GetPlayersTable();
            gridView.DataSource = table;
        }
    }
}