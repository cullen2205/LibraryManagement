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
        public static bool DeleteRecord_NhanVien_NganHang(SQL.Struct.NhanVien_NganHang.eNhanVien_NganHang _eTable , string valueStringOnly)
        {
            try
            {
                commandSQL.CommandText = "delete NhanVien_NganHang where " + _eTable.ToString() + " = N'" + valueStringOnly + "'";
                connSQL.Open();
                commandSQL.Connection = connSQL;
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
        public static NhanVien_NganHang Select_NhanVien_NganHang(Struct.NhanVien_NganHang.eNhanVien_NganHang type, string input)
        {
            NhanVien_NganHang nvnh = new NhanVien_NganHang();

            if (GetDataSQL(@"select MaNhanVien, MaNganHang, SoTaiKhoanNganHang from NhanVien_NganHang where " + type.ToString() + " = '" + input + "'"))
            {
                // đọc đến khi hết
                if (reader.Read())
                {

                    // lấy dữ liệu cột MaNhanVien (cột 0)
                    nvnh.MaNhanVien = reader.GetFieldValue<string>(0);

                    // lấy dữ liệu cột MaNganHang (cột 1)
                    nvnh.MaNganHang = reader.GetFieldValue<string>(1);

                    // lấy dữ liệu cột SoTaiKhoanNganHang (cột 2)
                    nvnh.SoTaiKhoanNganHang = reader.GetFieldValue<string>(2);

                    // lNhanVien_NganHang.Add(nvnh);
                }

                reader.Close();
                commandSQL.Dispose();
                connSQL.Close();

            }
            return nvnh;
        }

        /// <summary>
        /// 
        ///  Update table NhanVien_NganHang
        /// 
        /// </summary>
        /// <param name="_typeDataNeedUpdate"> Kiểu dữ liệu cần update</param>
        /// <param name="_tableNeedUpdate"> Tên cột cần update</param>
        /// <param name="_input"> Giá trị của cột cần update</param>
        /// <param name="_tableCheck"></param>
        /// <param name="_DataCheck"></param>
        public static void Update_OneTable_NhanVien_NganHang(string _typeDataNeedUpdate,
            Struct.NhanVien_NganHang.eNhanVien_NganHang _tableNeedUpdate,
            object _input,
            Struct.NhanVien_NganHang.eNhanVien_NganHang _tableCheck, string _DataCheck)
        {
                switch (_typeDataNeedUpdate)
                {
                    case "int":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanVien_NganHang set " + _tableNeedUpdate.ToString() + " = "
                        + int.Parse(_input.ToString()) + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "string":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanVien_NganHang set " + _tableNeedUpdate.ToString() + " = N'"
                        + _input.ToString() + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "DateTime":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanVien_NganHang set " + _tableNeedUpdate.ToString() + " = N'"
                        + DateTime.Parse(_input.ToString()) + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");

                        break;
                    case "bool":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanVien_NganHang set " + _tableNeedUpdate.ToString() + " = "
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
