using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL.Struct
{
    public class TheLoai
    {
        /*
            create table TheLoai(
            MaTheLoai varchar(40),
            TenTheLoai nvarchar(40),

            primary key (MaTheLoai)
            )
         */
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}",
                MaTheLoai, TenTheLoai);
        }
        public enum eTheLoai
        {
            MaTheLoai,
            TenTheLoai,
        }
    }
}
