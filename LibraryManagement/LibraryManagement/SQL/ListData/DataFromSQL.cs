using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.SQL.Struct;
using LibraryManagement.SQL.ConnectSQL;
using System.Data.Common;
using System.Data.SqlClient;
using LibraryManagement.SQL.ListData;

namespace LibraryManagement.SQL.ListData
{
    public partial class GetDataFromSQL
    {
        //public static List<MuonSach> lMuonSach;
        //public static List<NganHang> lNganHang;
        //public static List<NguoiDung> lNguoiDung;
        //public static List<NguoiDung_NganHang> lNguoiDung_NganHang;
        //public static List<NhanSach> lNhanSach;
        //public static List<NhanVien> lNhanVien;
        //public static List<NhanVien_NganHang> lNhanVien_NganHang;
        //public static List<Sach> lSach;
        //public static List<Sach_TheLoai> lSach_TheLoai;
        //public static List<TheLoai> lTheLoai;

        private static DbDataReader reader;

        public static SqlCommand commandSQL = new SqlCommand();

        public static SqlConnection connSQL = KenConnectSQL.GetConnect();

        public static void GetALL()
        {
            //connSQL.Open();
            //commandSQL.Connection = connSQL;

            //GetData_MuonSach();
            //GetData_NganHang();
            //GetData_NguoiDung();
            //GetData_NguoiDung_NganHang();
            //GetData_NhanSach();
            //GetData_NhanVien();
            //GetData_NhanVien_NganHang();
            //GetData_Sach();
            //GetData_Sach_TheLoai();
            //GetData_TheLoai();
        }

        public static void ExecuteNonQuery(string command)
        {
            DefaultState();

            commandSQL.CommandText = command;
            commandSQL.ExecuteNonQuery();

            connSQL.Close();
        }

        public static DbDataReader GetData(string command)
        {
            DefaultState();
            
            commandSQL.CommandText = command;
            DbDataReader t = commandSQL.ExecuteReader();

            connSQL.Close();

            return t;
        }

        private static bool GetDataSQL(string command)
        {
            DefaultState();

            commandSQL.CommandText = command;
            reader = commandSQL.ExecuteReader();
            return reader.HasRows;
        }

        private static void DefaultState()
        {
            connSQL.Close();

            connSQL.Open();
            commandSQL.Connection = connSQL;
        }
        /// <summary>
        /// 
        /// Trả về một object duy nhất
        /// 
        /// </summary>
        /// <param name="_command"> câu lệnh truy xuất trả về một tham số </param>
        /// <returns></returns>
        public static object Query_All(string _command)
        {
            object t = new object();

            commandSQL.CommandText = _command;
            commandSQL.Connection = connSQL;
            connSQL.Open();

            t = commandSQL.ExecuteScalar();
            connSQL.Close();

            return t;
        }
    }
}
