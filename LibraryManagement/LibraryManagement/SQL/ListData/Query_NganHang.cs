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
        public static NganHang Select_NganHang(Struct.NganHang.eNganHang type, string input)
        {
            NganHang nh = new NganHang();

            // kiểm tra nếu có dữ liệu thì xử lý, ko thì break
            if (
GetDataSQL(@"select MaNganHang, TenNganHang, DiaChi from NganHang where " 
+ type.ToString() + " = '" + input + "'"))
            {
                // đọc đến khi hết
                if (reader.Read())
                {

                    // lấy dữ liệu cột MaNganHang (cột 0)
                    nh.MaNganHang = reader.GetFieldValue<string>(0);

                    // lấy dữ liệu cột TenNganHang (cột 1)
                    nh.TenNganHang = reader.GetFieldValue<string>(1);

                    // lấy dữ liệu cột DiaChi (cột 2)
                    nh.DiaChi = reader.GetFieldValue<string>(2);

                    // lNganHang.Add(nh);
                    
                }

                reader.Close();
                commandSQL.Dispose();
                connSQL.Close();

            }
            return nh;
        }

        /// <summary>
        /// 
        ///  Update table NganHang
        /// 
        /// </summary>
        /// <param name="_typeDataNeedUpdate"> Kiểu dữ liệu cần update</param>
        /// <param name="_tableNeedUpdate"> Tên cột cần update</param>
        /// <param name="_input"> Giá trị của cột cần update</param>
        /// <param name="_tableCheck"></param>
        /// <param name="_DataCheck"></param>
        public static void Update_OneTableNganHang(string _typeDataNeedUpdate, Struct.NganHang.eNganHang _tableNeedUpdate,
            object _input, Struct.NganHang.eNganHang _tableCheck, string _DataCheck)
        {
                switch (_typeDataNeedUpdate)
                {
                    case "int":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NganHang set " + _tableNeedUpdate.ToString() + " = "
                        + int.Parse(_input.ToString()) + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "string":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NganHang set " + _tableNeedUpdate.ToString() + " = N'"
                        + _input.ToString() + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "DateTime":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NganHang set " + _tableNeedUpdate.ToString() + " = N'"
                        + DateTime.Parse(_input.ToString()) + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");

                        break;
                    case "bool":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NganHang set " + _tableNeedUpdate.ToString() + " = "
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
