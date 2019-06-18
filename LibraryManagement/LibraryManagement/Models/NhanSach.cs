namespace LibraryManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanSach")]
    public partial class NhanSach
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string MaSach { get; set; }

        [StringLength(40)]
        public string MaNhanVien { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime NgayNhanSach { get; set; }

        public int? NgayTreHan { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
