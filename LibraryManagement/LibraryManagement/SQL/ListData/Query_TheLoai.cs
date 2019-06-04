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
        public static TheLoai Select_TheLoai(Struct.Sach_TheLoai.eSach_TheLoai type, string input)
        {
            TheLoai ms = new TheLoai();

            if (GetDataSQL(@"select MaTheLoai, TenTheLoai from TheLoai where " + type.ToString() + " = '" + input + "'"))
            {
                // đọc đến khi hết
                if (reader.Read())
                {

                    // lấy dữ liệu cột MaTheLoai (cột 0)
                    ms.MaTheLoai = reader.GetFieldValue<string>(0);

                    // lấy dữ liệu cột TenTheLoai (cột 1)
                    ms.TenTheLoai = reader.GetFieldValue<string>(1);
                    
                    // lTheLoai.Add(ms);
                }

                reader.Close();
                commandSQL.Dispose();
                connSQL.Close();

            }
            return ms;
        }

        /// <summary>
        /// 
        ///  Update table TheLoai
        /// 
        /// </summary>
        /// <param name="_typeDataNeedUpdate"> Kiểu dữ liệu cần update</param>
        /// <param name="_tableNeedUpdate"> Tên cột cần update</param>
        /// <param name="_input"> Giá trị của cột cần update</param>
        /// <param name="_tableCheck"></param>
        /// <param name="_DataCheck"></param>
        public static void Update_OneTable_TheLoai(string _typeDataNeedUpdate, Struct.Sach_TheLoai.eSach_TheLoai _tableNeedUpdate,
            object _input, Struct.Sach_TheLoai.eSach_TheLoai _tableCheck, string _DataCheck)
        {
                switch (_typeDataNeedUpdate)
                {
                    case "int":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update TheLoai set " + _tableNeedUpdate.ToString() + " = "
                        + int.Parse(_input.ToString()) + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "string":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update TheLoai set " + _tableNeedUpdate.ToString() + " = N'"
                        + _input.ToString() + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "DateTime":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update TheLoai set " + _tableNeedUpdate.ToString() + " = N'"
                        + DateTime.Parse(_input.ToString()) + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");

                        break;
                    case "bool":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update TheLoai set " + _tableNeedUpdate.ToString() + " = "
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
