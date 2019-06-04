using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL.Struct
{
    public class NhanVien
    {
        /*
         *  create table NhanVien(
            MaNhanVien int,
            MatKhau varchar(100),
            TenNhanVien nvarchar(100),
            SoCMND varchar(40),
            GioiTinh bit,
            NgaySinh date,

            primary key (MaNhanVien)
            )
         */
        public string MaNhanVien { get; set; }
        public string MatKhau { get; set; }
        public string TenNhanVien { get; set; }
        public string SoCMND { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool LaQuanTriVien { get; set; }
        public string DuongDanAnhDaiDien { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                MaNhanVien, MatKhau, TenNhanVien, SoCMND, DiaChi, SoDienThoai,
                GioiTinh ? "Nam" : "Nữ", NgaySinh.ToShortDateString(),LaQuanTriVien ? "Có" : "Không", DuongDanAnhDaiDien);
        }
        public enum eNhanVien
        {
            // string type only

            MaNhanVien,
            MatKhau,
            TenNhanVien,
            SoCMND,
            DiaChi,
            SoDienThoai,
            GioiTinh,
            NgaySinh,
            LaQuanTriVien,
            DuongDanAnhDaiDien
        }
    }
}
