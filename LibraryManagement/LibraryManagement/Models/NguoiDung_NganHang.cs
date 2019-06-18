namespace LibraryManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NguoiDung_NganHang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string SoCMND { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string MaNganHang { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string SoTaiKhoanNganHang { get; set; }

        public virtual NganHang NganHang { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
