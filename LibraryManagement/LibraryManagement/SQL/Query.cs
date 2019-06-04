using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL
{
    public static class Query
    {
        public static string CommandText;
        private static SqlConnection conn = SQL.ConnectSQL.KenConnectSQL.GetConnect();
        private static SqlCommand cmd = new SqlCommand();
        public static bool ExecuteNonQuery()
        {
            try
            {
                cmd.CommandText = CommandText;
                cmd.Connection = conn;
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }
        public static object ExecuteScalar()
        {
            try
            {
                object t = new object();
                cmd.CommandText = CommandText;
                cmd.Connection = conn;
                conn.Open();

                t = cmd.ExecuteScalar();

                conn.Close();
                return t;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }
    }
}
