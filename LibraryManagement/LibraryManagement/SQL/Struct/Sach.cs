using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL.Struct
{
    public class Sach
    {
        /*
            create table Sach(
            MaSach varchar(40),
            TenSach nvarchar(100),
            TacGia nvarchar(100),
            NamXuatBan int,
            Gia int,
            NhaXuatBan nvarchar(100),
            GioiHanTuoi int,

            primary key (MaSach)
            )
         */
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public int? NamXuatBan { get; set; }
        public int? Gia { get; set; }
        public string NhaXuatBan { get; set; }
        public int? GioiHanTuoi { get; set; }
        public string DuongDanAnhDaiDien { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7}",
                MaSach, TenSach, TacGia, NamXuatBan, Gia,
                NhaXuatBan, GioiHanTuoi, DuongDanAnhDaiDien);
        }
        public enum eSach
        {
            MaSach,
            TenSach,
            TacGia,
            NamXuatBan,
            Gia,
            NhaXuatBan,
            GioiHanTuoi,
            DuongDanAnhDaiDien

        }
    }
}
