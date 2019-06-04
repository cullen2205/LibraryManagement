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
        public static bool NhanVien_AddNewRecord(SQL.Struct.NhanVien _value)
        {
            try
            {
                string t1 = "insert into NhanVien (MaNhanVien";
                string t2 = "(N'" + _value.MaNhanVien + "'";

                t1 += ", MatKhau";
                t2 += ", N'" + _value.MaNhanVien + "'";

                if (_value.TenNhanVien != null)
                {
                    t1 += ", TenNhanVien";
                    t2 += ", N'" + _value.TenNhanVien + "'";
                }
                if (_value.SoCMND != null)
                {
                    t1 += ", SoCMND";
                    t2 += ", N'" + _value.SoCMND + "'";
                }
                
                if (_value.DiaChi != null)
                {
                    t1 += ", DiaChi";
                    t2 += ", N'" + _value.DiaChi + "'";
                }
                if (_value.SoDienThoai != null)
                {
                    t1 += ", SoDienThoai";
                    t2 += ", N'" + _value.SoDienThoai + "'";
                }

                t1 += ", GioiTinh";
                t2 += ", N'" + (_value.GioiTinh ? "True" : "False") + "'";

                t1 += ", NgaySinh";
                t2 += ", N'" + _value.NgaySinh.ToShortDateString() + "'";

                t1 += ", LaQuanTriVien";
                t2 += ", N'" + (_value.LaQuanTriVien ? "True" : "False") + "'";

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
        public static string NhanVien_GetNext_MaNhanVien()
        {
            string tam = "NV" + NhanVien_GetNextIndex();
            return tam;
        }
        private static int NhanVien_GetNextIndex()
        {
            try
            {
                commandSQL.CommandText = "select MAX(MaNhanVien) as MAXMaNV from NhanVien";
                commandSQL.Connection = connSQL;
                connSQL.Open();

                string stam = commandSQL.ExecuteScalar().ToString();
                stam = stam.Remove(0, 2);

                int tam = int.Parse(stam) + 1;
                connSQL.Close();

                return tam;

            }
            catch
            {
                connSQL.Close();
                return -1;
            }
        }
        public static bool DeleteRecord_NhanVien(string _MaNhanVien)
        {
            try
            {
                commandSQL.CommandText = "delete NhanVien where MaNhanVien = '" + _MaNhanVien + "'";
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
        public static NhanVien Select_NhanVien(Struct.NhanVien.eNhanVien type, string input)
        {
            NhanVien nv = new NhanVien();

            // kiểm tra nếu có dữ liệu thì xử lý, ko thì break
            if (GetDataSQL(
@"select MaNhanVien, MatKhau, TenNhanVien, SoCMND, GioiTinh, NgaySinh,
DiaChi, SoDienThoai, LaQuanTriVien, DuongDanAnhDaiDien from NhanVien where "
+ type.ToString() + " = '" + input + "'"))
            {
                // đọc đến khi hết
                if (reader.Read())
                {

                    // lấy dữ liệu cột MaNhanVien (cột 0)
                    nv.MaNhanVien = reader.GetFieldValue<string>(0);

                    // lấy dữ liệu cột MatKhau (cột 1)
                    nv.MatKhau = reader.GetFieldValue<string>(1);

                    // lấy dữ liệu cột TenNhanVien (cột 2)
                    nv.TenNhanVien = reader.GetFieldValue<string>(2);

                    // lấy dữ liệu cột SoCMND (cột 3)
                    nv.SoCMND = reader.GetFieldValue<string>(3);

                    // lấy dữ liệu cột GioiTinh (cột 4)
                    nv.GioiTinh = reader.GetFieldValue<bool>(4);

                    // lấy dữ liệu cột NgaySinh (cột 5)
                    nv.NgaySinh = reader.GetFieldValue<DateTime>(5);

                    // lấy dữ liệu cột DiaChi (cột 6)
                    nv.DiaChi = reader.GetFieldValue<string>(6);

                    // lấy dữ liệu cột SoDienThoai (cột 7)
                    nv.SoDienThoai = reader.GetFieldValue<string>(7);

                    // lấy dữ liệu cột LaQuanTriVien (cột 8)
                    nv.LaQuanTriVien = reader.GetFieldValue<bool>(8);

                    try
                    {
                        // lấy dữ liệu cột DuongDanAnhDaiDien (cột 9)
                        nv.DuongDanAnhDaiDien = reader.GetFieldValue<string>(9);
                    }
                    catch
                    {
                        nv.DuongDanAnhDaiDien = "";
                    }
                    

                    // lNhanVien.Add(nv);
                }

                reader.Close();
                commandSQL.Dispose();
                connSQL.Close();

            }
            return nv;
        }

        /// <summary>
        /// 
        ///  Update table NhanVien
        /// 
        /// </summary>
        /// <param name="_typeDataNeedUpdate"> Kiểu dữ liệu cần update</param>
        /// <param name="_tableNeedUpdate"> Tên cột cần update</param>
        /// <param name="_input"> Giá trị của cột cần update</param>
        /// <param name="_tableCheck"></param>
        /// <param name="_DataCheck"></param>
        public static void Update_OneTable_NhanVien(string _typeDataNeedUpdate, Struct.NhanVien.eNhanVien _tableNeedUpdate,
            object _input, Struct.NhanVien.eNhanVien _tableCheck, string _DataCheck)
        {
            //try
            //{
                switch (_typeDataNeedUpdate)
                {
                    case "int":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanVien set " + _tableNeedUpdate.ToString() + " = "
                        + int.Parse(_input.ToString()) + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "string":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanVien set " + _tableNeedUpdate.ToString() + " = N'"
                        + _input.ToString() + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "DateTime":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanVien set " + _tableNeedUpdate.ToString() + " = N'"
                        + DateTime.Parse(_input.ToString()) + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");

                        break;
                    case "bool":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NhanVien set " + _tableNeedUpdate.ToString() + " = "
                        + (bool.Parse(_input.ToString()) ? "'True'" : "'False'") + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    default:
                        break;
                }
                // MessageBox.Show("Update success!");
                return;
        }

        public static bool Update_NhanVien(Struct.NhanVien _NV)
        {
            try
            {
                bool bhelp = false;
                string cmd = @"update NhanVien set ";

                if (_NV.MatKhau != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "MatKhau = N'" + _NV.MatKhau + "'";
                    bhelp = true;
                }
                if (_NV.TenNhanVien != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "TenNhanVien = N'" + _NV.TenNhanVien + "'";
                    bhelp = true;

                }
                if (_NV.SoCMND != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "SoCMND = N'" + _NV.SoCMND + "'";
                    bhelp = true;

                }
                if (_NV.DiaChi != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "DiaChi = N'" + _NV.DiaChi + "'";
                    bhelp = true;

                }
                if (_NV.SoDienThoai != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "SoDienThoai = N'" + _NV.SoDienThoai + "'";
                    bhelp = true;

                }

                if (_NV.GioiTinh != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "GioiTinh = '" + (_NV.GioiTinh ? "True" : "False") + "'";
                    bhelp = true;

                }

                if (_NV.NgaySinh != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "NgaySinh = '" + (_NV.NgaySinh.ToShortDateString().ToString()) + "'";
                    bhelp = true;

                }
                if (_NV.LaQuanTriVien != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "LaQuanTriVien = '" + (_NV.LaQuanTriVien ? "True" : "False") + "'";
                    bhelp = true;

                }
                if (_NV.DuongDanAnhDaiDien != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "DuongDanAnhDaiDien = N'" + _NV.DuongDanAnhDaiDien + "'";
                    bhelp = true;

                }
                cmd += " where MaNhanVien = N'" + _NV.MaNhanVien + "'";

                SQL.ListData.GetDataFromSQL.ExecuteNonQuery(cmd);
                return true;
            }
            catch
            {
                MessageBox.Show("One or more table is null!");
                return false;
            }
            
        }
    }
}
