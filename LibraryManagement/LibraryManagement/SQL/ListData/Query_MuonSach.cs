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
        public static bool MuonSach_RemoveOneRecord(string _MaSach)
        {
            try
            {
                commandSQL.CommandText = "delete MuonSach where MaSach = N'" + _MaSach + "'";
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
        public static bool MuonSach_CreateNewRecord(SQL.Struct.MuonSach _value)
        {
            try
            {
                string t1 = "insert into MuonSach (MaSach, NgayMuon";
                string t2 = "(N'" + _value.MaSach + "', N'" + _value.NgayMuon.ToShortDateString() + "'";
                
                _value.NgayTra = _value.NgayMuon.AddDays(150);
                _value.TinhTrang = false;

                t1 += ", NgayTra, TinhTrang";
                t2 += ", N'" + _value.NgayTra.ToShortDateString() + "', N'False'";

                if (_value.SoCMND != null)
                {
                    t1 += ", SoCMND";
                    t2 += ", N'" + _value.SoCMND + "'";
                }
                if (_value.MaNhanVien != null)
                {
                    t1 += ", MaNhanVien";
                    t2 += ", N'" + _value.MaNhanVien + "'";
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
        public static bool MuonSach_UpdateAllRecord_HaveTableX(SQL.Struct.MuonSach.eMuonSach _eTable, string _value, SQL.Struct.MuonSach.eMuonSach _eWhere, string _where)
        {
            try
            {
                commandSQL.CommandText = "update MuonSach set " + _eTable.ToString() + " = N'" + _value + "' where " + _eWhere.ToString() + " = N'" + _where + "'";
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
        public static MuonSach Select_MuonSach( Struct.MuonSach.eMuonSach type, string input)
        {
            MuonSach ms = new MuonSach();

            if (
GetDataSQL(@"select MaSach, NgayMuon, NgayTra, TinhTrang, SoCMND, MaNhanVien from MuonSach where " 
+ type.ToString() + " = '" + input + "'"))
            {
                // đọc đến khi hết
                if (reader.Read())
                {

                    // lấy dữ liệu cột MaSach (cột 0)
                    ms.MaSach = reader.GetFieldValue<string>(0);

                    // lấy dữ liệu cột NgayMuon (cột 1)
                    ms.NgayMuon = reader.GetFieldValue<DateTime>(1);

                    // lấy dữ liệu cột NgayTra (cột 2)
                    ms.NgayTra = reader.GetFieldValue<DateTime>(2);

                    // lấy dữ liệu cột TinhTrang (cột 3)
                    ms.TinhTrang = reader.GetFieldValue<bool>(3);

                    // lấy dữ liệu cột SoCMND (cột 4)
                    ms.SoCMND = reader.GetFieldValue<string>(4);

                    // lấy dữ liệu cột MaNhanVien (cột 5)
                    ms.MaNhanVien = reader.GetFieldValue<string>(5);

                    // lMuonSach.Add(ms);
                    
                }

                reader.Close();
                commandSQL.Dispose();
                connSQL.Close();

            }
            return ms;
        }

        /// <summary>
        /// 
        ///  Update table MuonSach
        /// 
        /// </summary>
        /// <param name="_typeDataNeedUpdate"> Kiểu dữ liệu cần update</param>
        /// <param name="_tableNeedUpdate"> Tên cột cần update</param>
        /// <param name="_input"> Giá trị của cột cần update</param>
        /// <param name="_tableCheck"></param>
        /// <param name="_DataCheck"></param>
        public static void Update_OneTable_MuonSach(string _typeDataNeedUpdate, Struct.MuonSach.eMuonSach _tableNeedUpdate,
            object _input, Struct.MuonSach.eMuonSach _tableCheck, string _DataCheck)
        {
                switch (_typeDataNeedUpdate)
                {
                    case "int":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update MuonSach set " + _tableNeedUpdate.ToString() + " = "
                        + int.Parse(_input.ToString()) + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "string":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update MuonSach set " + _tableNeedUpdate.ToString() + " = N'"
                        + _input.ToString() + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "DateTime":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update MuonSach set " + _tableNeedUpdate.ToString() + " = N'"
                        + DateTime.Parse(_input.ToString()) + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");

                        break;
                    case "bool":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update MuonSach set " + _tableNeedUpdate.ToString() + " = "
                        + (bool.Parse(_input.ToString()) ? "'True'" : "'False'") + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    default:
                        break;
                }
                MessageBox.Show("Update success!");
                return;
        }

        public static List<string> MuonSach_GetOneColumn(string _NameTable, string _NameColumn)
        {
            List<string> t = new List<string>();

            commandSQL.CommandText = "select " + _NameColumn + " from " + _NameTable;

            connSQL.Open();
            commandSQL.Connection = connSQL;
            reader = commandSQL.ExecuteReader();
            string re;
            while (reader.Read())
            {
                re = "";

                re = reader[_NameColumn].ToString();

                t.Add(re);
            }

            connSQL.Close();

            return t;
        }
    }
}
