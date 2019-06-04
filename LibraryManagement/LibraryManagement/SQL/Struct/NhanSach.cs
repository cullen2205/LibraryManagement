using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL.Struct
{
    public class NhanSach
    {
        /*
            create table NhanSach(
            MaSach varchar(40) references Sach(MaSach),
            MaNhanVien int references NhanVien(MaNhanVien),
            NgayNhanSach date,
            NgayTreHan int,

            primary key (MaSach, NgayNhanSach)
            )
         */
        public string MaSach { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayNhanSach { get; set; }
        public int NgayTreHan { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}",
                MaSach, MaNhanVien, NgayNhanSach.ToShortDateString(), NgayTreHan);
        }
        public enum eNhanSach
        {
            MaSach,
            MaNhanVien,
            NgayNhanSach,
            NgayTreHan,
        }
    }
}
