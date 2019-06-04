using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL.Struct
{
    public class Sach_TheLoai
    {
        /*
         * create table Sach_TheLoai(
            MaSach varchar(40) references Sach(MaSach),
            MaTheLoai varchar(40) references TheLoai(MaTheLoai),

            primary key (MaSach, MaTheLoai)
            )
        */
        public string MaSach { get; set; }
        public string MaTheLoai { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}",
                MaSach, MaTheLoai);
        }
        public enum eSach_TheLoai
        {
            MaSach,
            MaTheLoai
        }
    }
}
