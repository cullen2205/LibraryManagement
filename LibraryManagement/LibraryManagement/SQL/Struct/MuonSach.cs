using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.SQL.Struct
{
    public class MuonSach
    {
        /*
            create table MuonSach(
            MaSach varchar(40) references Sach(MaSach),
            NgayMuon date,
            NgayTra date,
            TinhTrang bit,
            SoCMND varchar(40) references NguoiDung(SoCMND),
            MaNhanVien int references NhanVien(MaNhanVien),


            primary key (MaSach, NgayMuon)
            )
        */
        public string MaSach { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public bool TinhTrang { get; set; }
        public string SoCMND { get; set; }
        public string MaNhanVien { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", 
                    MaSach, NgayMuon.ToShortDateString(), NgayTra.ToShortDateString(),
                    TinhTrang ? "Nam" : "Nữ", SoCMND, MaNhanVien);
        }
        public enum eMuonSach
        {
            MaSach,
            NgayMuon,
            NgayTra,
            TinhTrang,
            SoCMND,
            MaNhanVien,
        }
    }
}
