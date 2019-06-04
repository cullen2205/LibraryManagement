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
        public static bool Sach_TheLoai_CreateNewRecord(SQL.Struct.Sach_TheLoai _value)
        {
            try
            {
                commandSQL.CommandText = "insert into Sach_TheLoai(MaSach, MaTheLoai) values (N'" + _value.MaSach + "', N'" + _value.MaTheLoai + "')";
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
        public static Sach_TheLoai Select_Sach_TheLoai(Struct.Sach_TheLoai.eSach_TheLoai type, string input)
        {
            Sach_TheLoai stl = new Sach_TheLoai();

            if (GetDataSQL(@"select MaSach, MaTheLoai from Sach_TheLoai where " + type.ToString() + " = '" + input + "'"))
            {
                // đọc đến khi hết
                if (reader.Read())
                {

                    // lấy dữ liệu cột MaSach (cột 0)
                    stl.MaSach = reader.GetFieldValue<string>(0);

                    // lấy dữ liệu cột MaTheLoai (cột 1)
                    stl.MaTheLoai = reader.GetFieldValue<string>(1);

                    // lSach_TheLoai.Add(stl);
                }

                reader.Close();
                commandSQL.Dispose();
                connSQL.Close();

            }
            return stl;
        }

        /// <summary>
        /// 
        ///  Update table Sach_TheLoai
        /// 
        /// </summary>
        /// <param name="_typeDataNeedUpdate"> Kiểu dữ liệu cần update</param>
        /// <param name="_tableNeedUpdate"> Tên cột cần update</param>
        /// <param name="_input"> Giá trị của cột cần update</param>
        /// <param name="_tableCheck"></param>
        /// <param name="_DataCheck"></param>
        public static void Update_OneTable_Sach_TheLoai(string _typeDataNeedUpdate, Struct.Sach_TheLoai.eSach_TheLoai _tableNeedUpdate,
            object _input, Struct.Sach_TheLoai.eSach_TheLoai _tableCheck, string _DataCheck)
        {
                switch (_typeDataNeedUpdate)
                {
                    case "int":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update Sach_TheLoai set " + _tableNeedUpdate.ToString() + " = "
                        + int.Parse(_input.ToString()) + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "string":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update Sach_TheLoai set " + _tableNeedUpdate.ToString() + " = N'"
                        + _input.ToString() + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "DateTime":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update Sach_TheLoai set " + _tableNeedUpdate.ToString() + " = N'"
                        + DateTime.Parse(_input.ToString()) + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");

                        break;
                    case "bool":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update Sach_TheLoai set " + _tableNeedUpdate.ToString() + " = "
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
