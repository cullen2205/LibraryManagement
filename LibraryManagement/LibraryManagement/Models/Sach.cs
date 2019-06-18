namespace LibraryManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            MuonSaches = new HashSet<MuonSach>();
            NhanSaches = new HashSet<NhanSach>();
            TheLoais = new HashSet<TheLoai>();
        }

        [Key]
        [StringLength(40)]
        public string MaSach { get; set; }

        [StringLength(100)]
        public string TenSach { get; set; }

        [StringLength(100)]
        public string TacGia { get; set; }

        public int? NamXuatBan { get; set; }

        public int? Gia { get; set; }

        [StringLength(100)]
        public string NhaXuatBan { get; set; }

        public int? GioiHanTuoi { get; set; }

        [StringLength(200)]
        public string DuongDanAnhDaiDien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonSach> MuonSaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanSach> NhanSaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheLoai> TheLoais { get; set; }
    }
}
