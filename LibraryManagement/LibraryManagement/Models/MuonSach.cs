namespace LibraryManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MuonSach")]
    public partial class MuonSach
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string MaSach { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime NgayMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        public bool? TinhTrang { get; set; }

        [StringLength(40)]
        public string SoCMND { get; set; }

        [StringLength(40)]
        public string MaNhanVien { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
