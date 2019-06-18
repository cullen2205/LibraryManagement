namespace LibraryManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbLibraryManagement : DbContext
    {
        public DbLibraryManagement()
            : base("name=DbLibraryManagement")
        {
        }

        public virtual DbSet<MuonSach> MuonSaches { get; set; }
        public virtual DbSet<NganHang> NganHangs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NguoiDung_NganHang> NguoiDung_NganHang { get; set; }
        public virtual DbSet<NhanSach> NhanSaches { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhanVien_NganHang> NhanVien_NganHang { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MuonSach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<MuonSach>()
                .Property(e => e.SoCMND)
                .IsUnicode(false);

            modelBuilder.Entity<MuonSach>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NganHang>()
                .Property(e => e.MaNganHang)
                .IsUnicode(false);

            modelBuilder.Entity<NganHang>()
                .HasMany(e => e.NguoiDung_NganHang)
                .WithRequired(e => e.NganHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NganHang>()
                .HasMany(e => e.NhanVien_NganHang)
                .WithRequired(e => e.NganHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SoCMND)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SDTNguoiBaoHo)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.NguoiDung_NganHang)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung_NganHang>()
                .Property(e => e.SoCMND)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung_NganHang>()
                .Property(e => e.MaNganHang)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung_NganHang>()
                .Property(e => e.SoTaiKhoanNganHang)
                .IsUnicode(false);

            modelBuilder.Entity<NhanSach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<NhanSach>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoCMND)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.NhanVien_NganHang)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien_NganHang>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien_NganHang>()
                .Property(e => e.MaNganHang)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien_NganHang>()
                .Property(e => e.SoTaiKhoanNganHang)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.MuonSaches)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.NhanSaches)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.TheLoais)
                .WithMany(e => e.Saches)
                .Map(m => m.ToTable("Sach_TheLoai").MapLeftKey("MaSach").MapRightKey("MaTheLoai"));

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.MaTheLoai)
                .IsUnicode(false);
        }
    }
}
