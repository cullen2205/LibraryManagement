namespace LibraryManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            MuonSaches = new HashSet<MuonSach>();
            NguoiDung_NganHang = new HashSet<NguoiDung_NganHang>();
        }

        [Key]
        [StringLength(40)]
        public string SoCMND { get; set; }

        [StringLength(40)]
        public string TenDangNhap { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(40)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string DiaChiThuongTru { get; set; }

        public bool? GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(100)]
        public string TenNguoiBaoHo { get; set; }

        [StringLength(40)]
        public string SDTNguoiBaoHo { get; set; }

        [StringLength(100)]
        public string DiaChiNguoiBaoHo { get; set; }

        [StringLength(200)]
        public string DuongDanAnhDaiDien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonSach> MuonSaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguoiDung_NganHang> NguoiDung_NganHang { get; set; }
    }
}
