using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL.Struct
{
    public class NguoiDung
    {
        /* create table NguoiDung(
           SoCMND varchar(40),
           TenDangNhap varchar(40),
           MatKhau varchar(100),
           HoTen nvarchar(100),
           SoDienThoai varchar(40),
           DiaChiThuongTru nvarchar(100),
           GioiTinh bit,
           NgaySinh date,
           TenNguoiBaoHo nvarchar(100),
           SDTNguoiBaoHo varchar(40),
           DiaChiNguoiBaoHo nvarchar(100),

           primary key (SoCMND)
           )
        */
        public string SoCMND { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChiThuongTru { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string TenNguoiBaoHo { get; set; }
        public string SDTNguoiBaoHo { get; set; }
        public string DiaChiNguoiBaoHo { get; set; }
        public string DuongDanAnhDaiDien { get; set; }
        public string ToString(eNguoiDung e)
        {
            switch (e)
            {
                case eNguoiDung.SoCMND:
                    return SoCMND;
                case eNguoiDung.TenDangNhap:
                    return TenDangNhap;
                case eNguoiDung.MatKhau:
                    return MatKhau;
                case eNguoiDung.HoTen:
                    return HoTen;
                case eNguoiDung.SoDienThoai:
                    return SoDienThoai;
                case eNguoiDung.DiaChiThuongTru:
                    return DiaChiThuongTru;
                case eNguoiDung.GioiTinh:
                    return (GioiTinh ? "Nam" : "Nữ");
                case eNguoiDung.NgaySinh:
                    return NgaySinh.ToShortDateString();
                case eNguoiDung.TenNguoiBaoHo:
                    return TenNguoiBaoHo;
                case eNguoiDung.SDTNguoiBaoHo:
                    return SDTNguoiBaoHo;
                case eNguoiDung.DiaChiNguoiBaoHo:
                    return DiaChiNguoiBaoHo;
                case eNguoiDung.DuongDanAnhDaiDien:
                    return DuongDanAnhDaiDien;
                default:
                    return "";
            }
        }
        public enum eNguoiDung
        {
            SoCMND,
            TenDangNhap,
            MatKhau,
            HoTen,
            SoDienThoai,
            DiaChiThuongTru,
            GioiTinh,
            NgaySinh,
            TenNguoiBaoHo,
            SDTNguoiBaoHo,
            DiaChiNguoiBaoHo,
            DuongDanAnhDaiDien,
        }
    }
}
