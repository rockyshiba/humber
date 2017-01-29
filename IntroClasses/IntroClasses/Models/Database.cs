using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace IntroClasses.Models
{
    public class Database
    {
        private string CS { get; set; }
        public SqlConnection conn { get; private set; }

        public Database (string cs)
        {
            CS = cs;
            conn = new SqlConnection(cs);
        }

        public SqlDataReader Select(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            Open();
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void Open()
        {
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }
    }
}