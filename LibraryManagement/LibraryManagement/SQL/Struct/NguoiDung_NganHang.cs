using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL.Struct
{
    public class NguoiDung_NganHang
    {
        /*  create table NguoiDung_NganHang(
            SoCMND varchar(40) references NguoiDung(SoCMND),
            MaNganHang varchar(40) references NganHang(MaNganHang),
            SoTaiKhoanNganHang varchar(40),

            primary key (SoCMND, MaNganHang, SoTaiKhoanNganHang)
            )
         */
        public string SoCMND { get; set; }
        public string MaNganHang { get; set; }
        public string SoTaiKhoanNganHang { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}",
                SoCMND, MaNganHang, SoTaiKhoanNganHang);
        }
        public enum eNguoiDung_NganHang
        {
            SoCMND,
            MaNganHang,
            SoTaiKhoanNganHang,
        }
    }
}
