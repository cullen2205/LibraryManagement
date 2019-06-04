using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL.Struct
{
    public class NhanVien_NganHang
    {
        /*
            create table NhanVien_NganHang(
            MaNhanVien int references NhanVien(MaNhanVien),
            MaNganHang varchar(40) references NganHang(MaNganHang),
            SoTaiKhoanNganHang varchar(40),
 
            primary key (MaNhanVien, MaNganHang, SoTaiKhoanNganHang)
            )
        */
        public string MaNhanVien { get; set; }
        public string MaNganHang { get; set; }
        public string SoTaiKhoanNganHang { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}",
                MaNhanVien, MaNganHang, SoTaiKhoanNganHang);
        }
        public enum eNhanVien_NganHang
        {
            MaNhanVien,
            MaNganHang,
            SoTaiKhoanNganHang,

        }
    }
}
