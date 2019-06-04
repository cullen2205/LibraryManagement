using LibraryManagement.SQL.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using LibraryManagement.SQL.ListData;

namespace LibraryManagement.SQL.ListData
{
    public partial class GetDataFromSQL
    {
        public static bool NguoiDung_AddNewRecord(SQL.Struct.NguoiDung _value)
        {
            try
            {
                string t1 = "insert into NguoiDung (SoCMND";
                string t2 = "(N'" + _value.SoCMND + "'";

                t1 += ", MatKhau";
                t2 += ", N'" + _value.SoCMND + "'";

                if (_value.TenDangNhap != null)
                {
                    t1 += ", TenDangNhap";
                    t2 += ", N'" + _value.TenDangNhap + "'";
                }
                if (_value.HoTen != null)
                {
                    t1 += ", HoTen";
                    t2 += ", N'" + _value.HoTen + "'";
                }
                if (_value.SoDienThoai != null)
                {
                    t1 += ", SoDienThoai";
                    t2 += ", N'" + _value.SoDienThoai + "'";
                }
                if (_value.DiaChiThuongTru != null)
                {
                    t1 += ", DiaChiThuongTru";
                    t2 += ", N'" + _value.DiaChiThuongTru + "'";
                }

                t1 += ", GioiTinh";
                t2 += ", N'" + (_value.GioiTinh ? "True" : "False") + "'";

                t1 += ", NgaySinh";
                t2 += ", N'" + _value.NgaySinh.ToShortDateString() + "'";

                if (_value.TenNguoiBaoHo != null)
                {
                    t1 += ", TenNguoiBaoHo";
                    t2 += ", N'" + _value.TenNguoiBaoHo + "'";
                }
                if (_value.SDTNguoiBaoHo != null)
                {
                    t1 += ", SDTNguoiBaoHo";
                    t2 += ", N'" + _value.SDTNguoiBaoHo + "'";
                }
                if (_value.DiaChiNguoiBaoHo != null)
                {
                    t1 += ", DiaChiNguoiBaoHo";
                    t2 += ", N'" + _value.DiaChiNguoiBaoHo + "'";
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
        public static int NguoiDung_GetMaxIndex()
        {
            try
            {
                commandSQL.CommandText = "select MAX(SoCMND) as MAXCMND from NguoiDung";
                commandSQL.Connection = connSQL;
                connSQL.Open();

                int tam = int.Parse(commandSQL.ExecuteScalar().ToString());
                connSQL.Close();

                return tam;

            }
            catch
            {
                connSQL.Close();
                return -1;
            }
        }
        public static bool DeleteRecord_NguoiDung(string _SoCMND)
        {
            try
            {
                commandSQL.CommandText = "delete NguoiDung where SoCMND = '" + _SoCMND + "'";
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
        public static NguoiDung Select_NguoiDung(Struct.NguoiDung.eNguoiDung type, string IDName)
        {
            NguoiDung nd = new NguoiDung();

            if (GetDataSQL(
@"select SoCMND, TenDangNhap, MatKhau, HoTen, SoDienThoai, DiaChiThuongTru,
GioiTinh, NgaySinh, TenNguoiBaoHo, SDTNguoiBaoHo, DiaChiNguoiBaoHo,
DuongDanAnhDaiDien from NguoiDung where " 
+ type.ToString() + " = '" + IDName + "'"))
            {
                // đọc đến khi hết
                if (reader.Read())
                {
                    // lấy dữ liệu cột SoCMND (cột 0)
                    nd.SoCMND = reader.GetFieldValue<string>(0);

                    // lấy dữ liệu cột TenDangNhap (cột 1)
                    nd.TenDangNhap = reader.GetFieldValue<string>(1);

                    // lấy dữ liệu cột MatKhau (cột 2)
                    nd.MatKhau = reader.GetFieldValue<string>(2);

                    // lấy dữ liệu cột HoTen (cột 3)
                    nd.HoTen = reader.GetFieldValue<string>(3);

                    // lấy dữ liệu cột SoDienThoai (cột 4)
                    nd.SoDienThoai = reader.GetFieldValue<string>(4);

                    // lấy dữ liệu cột DiaChiThuongTru (cột 5)
                    nd.DiaChiThuongTru = reader.GetFieldValue<string>(5);

                    // lấy dữ liệu cột GioiTinh (cột 6)
                    nd.GioiTinh = reader.GetFieldValue<bool>(6);

                    // lấy dữ liệu cột NgaySinh (cột 7)
                    nd.NgaySinh = reader.GetFieldValue<DateTime>(7);

                    // lấy dữ liệu cột TenNguoiBaoHo (cột 8)
                    nd.TenNguoiBaoHo = reader.GetFieldValue<string>(8);

                    // lấy dữ liệu cột SDTNguoiBaoHo (cột 9)
                    nd.SDTNguoiBaoHo = reader.GetFieldValue<string>(9);

                    // lấy dữ liệu cột DiaChiNguoiBaoHo (cột 10)
                    nd.DiaChiNguoiBaoHo = reader.GetFieldValue<string>(10);

                    // lấy dữ liệu cột DuongDanAnhDaiDien (cột 11)
                    try
                    {
                        nd.DuongDanAnhDaiDien = reader.GetFieldValue<string>(11);
                    }
                    catch
                    {
                        nd.DuongDanAnhDaiDien = "";
                    }
                    

                    // lNguoiDung.Add(nd);

                }
                
                reader.Close();
                commandSQL.Dispose();
                connSQL.Close();
            }
            return nd;
        }
        /// <summary>
        /// 
        ///  Update table NguoiDung
        /// 
        /// </summary>
        /// <param name="_typeDataNeedUpdate"> Kiểu dữ liệu cần update</param>
        /// <param name="_tableNeedUpdate"> Tên cột cần update</param>
        /// <param name="_input"> Giá trị của cột cần update</param>
        /// <param name="_tableCheck"></param>
        /// <param name="_DataCheck"></param>
        public static void Update_OneTable_NguoiDung(string _typeDataNeedUpdate, Struct.NguoiDung.eNguoiDung _tableNeedUpdate,
            object _input, Struct.NguoiDung.eNguoiDung _tableCheck, string _DataCheck)
        {
                switch (_typeDataNeedUpdate)
                {
                    case "int":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NguoiDung set " + _tableNeedUpdate.ToString() +" = " 
                        + int.Parse(_input.ToString()) + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "string":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NguoiDung set " + _tableNeedUpdate.ToString() + " = N'"
                        + _input.ToString() + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    case "DateTime":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NguoiDung set " + _tableNeedUpdate.ToString() + " = N'"
                        + DateTime.Parse(_input.ToString()) + "' where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");

                        break;
                    case "bool":
                        SQL.ListData.GetDataFromSQL.ExecuteNonQuery(
                        @"update NguoiDung set " + _tableNeedUpdate.ToString() + " = "
                        + (bool.Parse(_input.ToString()) ? "'True'" : "'False'") + " where " + _tableCheck.ToString() + " = N'" + _DataCheck + "'");


                        break;
                    default:
                        break;
                }
                // MessageBox.Show("Update success!");
                return;
        }

        public static bool Update_NguoiDung(Struct.NguoiDung _NV)
        {
            try
            {
                bool bhelp = false;
                string cmd = @"update NguoiDung set ";

                if (_NV.SoCMND != null)
                {
                    cmd += "SoCMND = N'" + _NV.SoCMND + "'";
                    bhelp = true;
                }
                if (_NV.MatKhau != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "MatKhau = N'" + _NV.MatKhau + "'";
                    bhelp = true;

                }
                if (_NV.HoTen != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "HoTen = N'" + _NV.HoTen + "'";
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
                if (_NV.DiaChiThuongTru != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "DiaChiThuongTru = N'" + _NV.DiaChiThuongTru + "'";
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
                if (_NV.TenNguoiBaoHo != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "TenNguoiBaoHo = N'" + _NV.TenNguoiBaoHo + "'";
                    bhelp = true;

                }
                if (_NV.SDTNguoiBaoHo != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "SDTNguoiBaoHo = N'" + _NV.SDTNguoiBaoHo + "'";
                    bhelp = true;

                }
                if (_NV.DiaChiNguoiBaoHo != null)
                {
                    if (bhelp)
                    {
                        cmd += ", ";
                    }
                    cmd += "DiaChiNguoiBaoHo = N'" + _NV.DiaChiNguoiBaoHo + "'";
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
                cmd += " where TenDangNhap = N'" + _NV.TenDangNhap + "'";

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
