using LibraryManagement.SQL.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.SQL.ListData
{
    public partial class GetDataFromSQL
    {
        public static bool NhanSach_UpdateAllRecord_HaveTableX(SQL.Struct.NhanSach.eNhanSach _eTable, string _value, SQL.Struct.NhanSach.eNhanSach _eWhere, string _where)
        {
            try
            {
                commandSQL.CommandText = "update NhanSach set " + _eTable.ToString() + " = N'" + _value + "' where " + _eWhere.ToString() + " = N'" + _where + "'";
                commandSQL.Connection = connSQL;
                connSQL.Open();
                commandSQL.ExecuteNonQuery();
                connSQL.Close();
                return true;
            }
            catch
            {
                connSQL.Close();
                return false;
            }
        }
        public static NhanSach Select_NhanSach(Struct.NhanSach.eNhanSach type, string input)
        {
            NhanSach ns = new NhanSach();

            // kiểm tra nếu có dữ liệu thì xử lý, ko thì break
            if (
GetDataSQL(@"select MaSach, MaNhanVien, NgayNhanSach, NgayTreHan from NhanSach where " + type.ToString() + " = '" + input +"'"))
            {
                // đọc đến khi hết
                if (reader.Read())
                {

                    // lấy dữ liệu cột MaSach (cột 0)
                    ns.MaSach = reader.GetFieldValue<string>(0);

                    // lấy dữ liệu cột MaNhanVien (cột 1)
                    ns.MaNhanVien = reader.GetFieldValue<string>(1);

                    // lấy dữ liệu cột NgayNhanSach (cột 2)
                    ns.NgayNhanSach = reader.GetFieldValue<DateTime>(2);

                    // lấy dữ liệu cột NgayTreHan (cột 3)
                    ns.NgayTreHan = reader.GetFieldValue<int>(3);

                    // lNhanSach.Add(ns);
                }

                reader.Close();
                commandSQL.Dispose();
                connSQL.Close();

            }

            return ns;
        }


        /// <summary>
        /// 
        ///  Update table NhanSach
        /// 
        /// </summary>
        /// <param name="_typeDataNeedUpdate"> Kiểu dữ liệu cần update</param>
        /// <param name="_tableNeedUpdate"> Tên cột cần update</param>
        /// <param name="_input"> Giá trị của cột cần update</param>
        /// <param name="_tableCheck"></param>
        /// <param name="_DataCheck"></param>
        public static void Update_OneTable_NhanSach(string _typeDataNeedUpdate, Struct.NhanSach.eNhanSach _tableNeedUpdate,
            object _input, Struct.NhanSach.eNhanSach _tableCheck, string _DataCheck)
        {
                switch (_typeDataNeedUpdate)
                {
                    case "int":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanSach set " + _tableNeedUpdate.ToString() + " = "
                        + int.Parse(_input.ToString()) + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "string":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanSach set " + _tableNeedUpdate.ToString() + " = N'"
                        + _input.ToString() + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "DateTime":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanSach set " + _tableNeedUpdate.ToString() + " = N'"
                        + DateTime.Parse(_input.ToString()) + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");

                        break;
                    case "bool":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanSach set " + _tableNeedUpdate.ToString() + " = "
                        + (bool.Parse(_input.ToString()) ? "'True'" : "'False'") + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    default:
                        break;
                }
                MessageBox.Show("Update success!");
                return;
        }
    }
}
