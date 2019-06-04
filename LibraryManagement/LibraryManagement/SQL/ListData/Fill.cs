using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.SQL.ListData
{
    public static class Fill
    {
        private static SqlConnection connnect;
        private static SqlDataAdapter adapter;
        public static bool AllToDataGridView(string _NameTable, ref DataGridView _NameDataGridView)
        {
            try
            {
                connnect = SQL.ConnectSQL.KenConnectSQL.GetConnect();
                connnect.Open();
                adapter = new SqlDataAdapter(@"select * from " + _NameTable, connnect);
                DataSet ds = new DataSet();
                adapter.Fill(ds, _NameTable);

                _NameDataGridView.DataSource = ds;
                _NameDataGridView.DataMember = _NameTable;
                connnect.Close();
                return true;
            }
            catch
            {
                connnect.Close();

                MessageBox.Show("Can not fill to data grid view");
                return false;
            }
        }
        public static bool SomeToDataGridView(string _command, ref DataGridView _NameDataGridView)
        {
            try
            {
                connnect = SQL.ConnectSQL.KenConnectSQL.GetConnect();
                connnect.Open();
                adapter = new SqlDataAdapter(_command, connnect);
                DataTable ds = new DataTable();
                adapter.Fill(ds);

                _NameDataGridView.DataSource = ds;
                // _NameDataGridView.DataMember = _DataMember;

                connnect.Close();
                return true;
            }
            catch
            {
                connnect.Close();
                MessageBox.Show("Can not fill to data grid view");
                return false;
            }
        }
    }
}
