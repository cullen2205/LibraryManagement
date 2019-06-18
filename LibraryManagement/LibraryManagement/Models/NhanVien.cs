namespace LibraryManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            MuonSaches = new HashSet<MuonSach>();
            NhanSaches = new HashSet<NhanSach>();
            NhanVien_NganHang = new HashSet<NhanVien_NganHang>();
        }

        [Key]
        [StringLength(40)]
        public string MaNhanVien { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string TenNhanVien { get; set; }

        [StringLength(40)]
        public string SoCMND { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(40)]
        public string SoDienThoai { get; set; }

        public bool? GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public bool? LaQuanTriVien { get; set; }

        [StringLength(200)]
        public string DuongDanAnhDaiDien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonSach> MuonSaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanSach> NhanSaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien_NganHang> NhanVien_NganHang { get; set; }
    }
}
