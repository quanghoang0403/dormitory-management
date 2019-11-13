using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace qlktxserver
{
    public class DataProvider
    {
        private string connection = "Data Source=DESKTOP-AAGVBOR\\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True";
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            set { instance = value; }

        }

        public DataTable ExecuteQuery(string query1, object[] parameter = null)
        {
            DataTable data = new DataTable();
            SqlConnection connect = new SqlConnection(connection);
            connect.Open();
            SqlCommand command = new SqlCommand(query1, connect);
            if (parameter != null)
            {
                string[] listPara = query1.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Clone();
            return data;
        }
        public int ExecuteNonQuery(string query1, object[] parameter = null)
        {
            int data = 0;
            SqlConnection connect = new SqlConnection(connection);
            connect.Open();
            SqlCommand command = new SqlCommand(query1, connect);
            if (parameter != null)
            {
                string[] listPara = query1.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            data = command.ExecuteNonQuery();
            connection.Clone();
            return data;
        }
        public object ExecuteScalar(string query1, object[] parameter = null)
        {
            object data = 0;
            SqlConnection connect = new SqlConnection(connection);
            connect.Open();
            SqlCommand command = new SqlCommand(query1, connect);
            if (parameter != null)
            {
                string[] listPara = query1.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            data = command.ExecuteScalar();
            connection.Clone();
            return data;
        }
    }
}
