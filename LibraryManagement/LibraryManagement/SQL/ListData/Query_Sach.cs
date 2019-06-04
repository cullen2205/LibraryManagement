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
        private static List<string> lstring = new List<string>();

        public static bool Sach_CreateNewRecord(SQL.Struct.Sach _value)
        {
            try
            {
                string t1 = "insert into Sach (MaSach";
                string t2 = "(N'" + _value.MaSach + "'";

                if (_value.TenSach != null)
                {
                    t1 += ", TenSach";
                    t2 += ", N'" + _value.TenSach + "'";
                }
                if (_value.TacGia != null)
                {
                    t1 += ", TacGia";
                    t2 += ", N'" + _value.TacGia + "'";
                }
                if (_value.NamXuatBan != null)
                {
                    t1 += ", NamXuatBan";
                    t2 += ", " + _value.NamXuatBan;
                }

                if (_value.Gia != null)
                {
                    t1 += ", Gia";
                    t2 += ", " + _value.Gia;
                }
                if (_value.NhaXuatBan != null)
                {
                    t1 += ", NhaXuatBan";
                    t2 += ", N'" + _value.NhaXuatBan + "'";
                }
                if (_value.GioiHanTuoi != null)
                {
                    t1 += ", GioiHanTuoi";
                    t2 += ", " + _value.GioiHanTuoi;
                }

                if (_value.DuongDanAnhDaiDien != null)
                {
                    t1 += ", DuongDanAnhDaiDien";
                    t2 += ", N'" + _value.DuongDanAnhDaiDien + "'";
                }

                t1 += ") values " + t2 + ")";

                commandSQL.CommandText = t1;
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
        public static string Sach_GetNextIndex()
        {
            try
            {
                commandSQL.CommandText = "select MAX(MaSach) from Sach";
                commandSQL.Connection = connSQL;
                connSQL.Open();
                string tam = commandSQL.ExecuteScalar() as string;
                tam = tam.Remove(0,1);
                int itam = int.Parse(tam);
                if (itam < 9)
                    tam = "S00" + (itam + 1);
                else if (itam < 99)
                    tam = "S0" + (itam + 1);
                else
                    tam = "S" + (itam + 1);



                connSQL.Close();
                return tam;
            }
            catch
            {
                connSQL.Close();
                return null;
            }
        }

        public static Sach Select_Sach(Struct.Sach.eSach type, string input)
        {
            Sach ms = new Sach();

            if (
GetDataSQL(@"select MaSach, TenSach, TacGia, NamXuatBan, Gia, NhaXuatBan, GioiHanTuoi, DuongDanAnhDaiDien from Sach where "
+ type.ToString() + " = '" + input + "'"))
            {
                // đọc đến khi hết
                if (reader.Read())
                {
                    // lấy dữ liệu cột MaSach (cột 0)
                    ms.MaSach = reader.GetFieldValue<string>(0);

                    // lấy dữ liệu cột TenSach (cột 1)
                    ms.TenSach = reader.GetFieldValue<string>(1);

                    // lấy dữ liệu cột TacGia (cột 2)
                    ms.TacGia = reader.GetFieldValue<string>(2);

                    // lấy dữ liệu cột NamXuatBan (cột 3)
                    ms.NamXuatBan = reader.GetFieldValue<int>(3);

                    // lấy dữ liệu cột Gia (cột 4)
                    ms.Gia = reader.GetFieldValue<int>(4);

                    // lấy dữ liệu cột NhaXuatBan (cột 5)
                    ms.NhaXuatBan = reader.GetFieldValue<string>(5);

                    // lấy dữ liệu cột GioiHanTuoi (cột 6)
                    ms.GioiHanTuoi = reader.GetFieldValue<int>(6);

                    // lấy dữ liệu cột DuongDanAnhDaiDien (cột 7)
                    ms.DuongDanAnhDaiDien = reader.GetFieldValue<string>(7);

                    // lSach.Add(ms);
                }

                reader.Close();
                commandSQL.Dispose();
                connSQL.Close();

            }
            return ms;
        }


        /// <summary>
        /// 
        ///  Update table Sach
        /// 
        /// </summary>
        /// <param name="_typeDataNeedUpdate"> Kiểu dữ liệu cần update</param>
        /// <param name="_tableNeedUpdate"> Tên cột cần update</param>
        /// <param name="_input"> Giá trị của cột cần update</param>
        /// <param name="_tableCheck"></param>
        /// <param name="_DataCheck"></param>
        public static void Update_OneTable_Sach(string _typeDataNeedUpdate, Struct.Sach.eSach _tableNeedUpdate,
            object _input, Struct.Sach.eSach _tableCheck, string _DataCheck)
        {
                switch (_typeDataNeedUpdate)
                {
                    case "int":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update Sach set " + _tableNeedUpdate.ToString() + " = "
                        + int.Parse(_input.ToString()) + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "string":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update Sach set " + _tableNeedUpdate.ToString() + " = N'"
                        + _input.ToString() + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "DateTime":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update Sach set " + _tableNeedUpdate.ToString() + " = N'"
                        + DateTime.Parse(_input.ToString()) + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");

                        break;
                    case "bool":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update Sach set " + _tableNeedUpdate.ToString() + " = "
                        + (bool.Parse(_input.ToString()) ? "'True'" : "'False'") + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    default:
                        break;
                }
                MessageBox.Show("Update success!");
                return;
        }

        public static bool Update_ARecord_Sach(SQL.Struct.Sach s)
        {
            try
            {
                lstring.Clear();
                lstring.Add(@"TenSach = N'" + s.TenSach + "'");
                lstring.Add(@"TacGia = N'" + s.TacGia + "'");
                lstring.Add(@"NamXuatBan = " + s.NamXuatBan.ToString());
                lstring.Add(@"Gia = "+ s.Gia.ToString());
                lstring.Add(@"NhaXuatBan = N'" + s.NhaXuatBan + "'");
                lstring.Add(@"GioiHanTuoi = " + s.GioiHanTuoi.ToString());
                lstring.Add(@"DuongDanAnhDaiDien = N'" + s.DuongDanAnhDaiDien + "'");

                commandSQL.CommandText = EditString(@"update Sach set ", @"where MaSach = N'" + s.MaSach + "'", ref lstring);
                commandSQL.Connection = connSQL;
                connSQL.Open();
                commandSQL.ExecuteNonQuery();

                connSQL.Close();

                lstring.Clear();
                return true;
            }
            catch
            {
                MessageBox.Show("Cant update the record!");

                connSQL.Close();

                return false;
            }
            
        }

        /// <summary>
        /// 
        /// Do nothing without add string to string
        /// exaple:
        ///     _root = "update DUAN set "
        ///     list[0] = "MADA = value"
        ///     list[1] = "MAPB = value"
        ///     ...
        ///     _where = "where MANV = value"
        ///     return -> "update DUAN set MADA = value, MAPB = value where MANV = value"
        /// 
        /// </summary>
        /// <param name="_root"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private static string EditString(string _root, string _where, ref List<string> list)
        {
            int index = list.Count;
            int i = 0;
            while (i < index)
            {
                _root += @" " + list[i];
                if (i < index - 1 && list[i] != null)
                {
                    _root += @",";
                }
                ++i;
            }
            _root += @" " + _where;
            return _root;
        }

        public static List<string> Sach_SelectOneTableString(string query, string nameTable)
        {
            List<string> t = new List<string>();

            commandSQL.CommandText = query;
            
            connSQL.Open();
            commandSQL.Connection = connSQL;
            reader = commandSQL.ExecuteReader();
            string re;
            while (reader.Read())
            {
                re = "";

                re = reader[nameTable].ToString();

                t.Add(re);
            }

            connSQL.Close();

            return t;
        }
    }
}
