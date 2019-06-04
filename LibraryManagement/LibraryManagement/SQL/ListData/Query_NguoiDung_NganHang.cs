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
        public static bool DeleteRecord_NguoiDung_NganHang(SQL.Struct.NguoiDung_NganHang.eNguoiDung_NganHang _eTable, string valueStringOnly)
        {
            try
            {
                commandSQL.CommandText = "delete NguoiDung_NganHang where " + _eTable.ToString() + " = N'" + valueStringOnly + "'";
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

        public static NguoiDung_NganHang Select_NguoiDung_NganHang(Struct.NguoiDung_NganHang.eNguoiDung_NganHang type, string input)
        {
            NguoiDung_NganHang ms = new NguoiDung_NganHang();

            if (
GetDataSQL(@"select SoCMND, MaNganHang, SoTaiKhoanNganHang from NguoiDung_NganHang where " + type.ToString() + " = '" + input + "'"))
            {
                // đọc đến khi hết
                if (reader.Read())
                {

                    // lấy dữ liệu cột SoCMND (cột 0)
                    ms.SoCMND = reader.GetFieldValue<string>(0);

                    // lấy dữ liệu cột MaNganHang (cột 1)
                    ms.MaNganHang = reader.GetFieldValue<string>(1);

                    // lấy dữ liệu cột SoTaiKhoanNganHang (cột 2)
                    ms.SoTaiKhoanNganHang = reader.GetFieldValue<string>(2);
                    
                    // lNguoiDung_NganHang.Add(ms);
                }

                reader.Close();
                commandSQL.Dispose();
                connSQL.Close();

            }
            return ms;
        }

        /// <summary>
        /// 
        ///  Update table NguoiDung_NganHang
        /// 
        /// </summary>
        /// <param name="_typeDataNeedUpdate"> Kiểu dữ liệu cần update</param>
        /// <param name="_tableNeedUpdate"> Tên cột cần update</param>
        /// <param name="_input"> Giá trị của cột cần update</param>
        /// <param name="_tableCheck"></param>
        /// <param name="_DataCheck"></param>
        public static void Update_OneTable_NguoiDung_NganHang(
            string _typeDataNeedUpdate,
            Struct.NguoiDung_NganHang.eNguoiDung_NganHang _tableNeedUpdate,
            object _input,
            Struct.NguoiDung_NganHang.eNguoiDung_NganHang _tableCheck,
            string _DataCheck)
        {
                switch (_typeDataNeedUpdate)
                {
                    case "int":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NguoiDung_NganHang set " + _tableNeedUpdate.ToString() + " = "
                        + int.Parse(_input.ToString()) + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "string":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NguoiDung_NganHang set " + _tableNeedUpdate.ToString() + " = N'"
                        + _input.ToString() + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "DateTime":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NguoiDung_NganHang set " + _tableNeedUpdate.ToString() + " = N'"
                        + DateTime.Parse(_input.ToString()) + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");

                        break;
                    case "bool":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NguoiDung_NganHang set " + _tableNeedUpdate.ToString() + " = "
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
