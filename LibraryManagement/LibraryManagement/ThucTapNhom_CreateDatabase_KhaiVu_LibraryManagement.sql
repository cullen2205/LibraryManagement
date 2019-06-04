
use master
go

create database ThucTapNhom_Khai
go
-- drop database ThucTapNhom_Khai
use ThucTapNhom_Khai
go

------------------------------- Tạo bảng ngân hàng ------------
--if not exists (select name from sysobjects where name = 'NganHang')
create table NganHang(
MaNganHang varchar(40),
TenNganHang nvarchar(100),
DiaChi nvarchar(100),

primary key (MaNganHang),
)
go

------------------------------- Tạo bảng người dùng ------------
create table NguoiDung(
SoCMND varchar(40),
TenDangNhap varchar(40),
MatKhau varchar(100),
HoTen nvarchar(100),
SoDienThoai varchar(40),
DiaChiThuongTru nvarchar(100),
GioiTinh bit,
NgaySinh date,
TenNguoiBaoHo nvarchar(100),
SDTNguoiBaoHo varchar(40),
DiaChiNguoiBaoHo nvarchar(100),
DuongDanAnhDaiDien nvarchar(200),

primary key (SoCMND)
)
go
------------------------------- Tạo bảng người dùng + ngân hàng ------------
create table NguoiDung_NganHang(
SoCMND varchar(40) references NguoiDung(SoCMND),
MaNganHang varchar(40) references NganHang(MaNganHang),
SoTaiKhoanNganHang varchar(40),

primary key (SoCMND, MaNganHang, SoTaiKhoanNganHang)
)
go

------------------------------- Tạo bảng nhân viên ------------
create table NhanVien(
MaNhanVien varchar(40),
MatKhau varchar(100),
TenNhanVien nvarchar(100),
SoCMND varchar(40),
DiaChi nvarchar(100),
SoDienThoai varchar(40),
GioiTinh bit,
NgaySinh date,
LaQuanTriVien bit,
DuongDanAnhDaiDien nvarchar(200),

primary key (MaNhanVien)
)
go

------------------------------- Tạo bảng nhân viên + ngân hàng ------------
create table NhanVien_NganHang(
MaNhanVien varchar(40) references NhanVien(MaNhanVien),
MaNganHang varchar(40) references NganHang(MaNganHang),
SoTaiKhoanNganHang varchar(40),
 
primary key (MaNhanVien, MaNganHang, SoTaiKhoanNganHang)
)
go

------------------------------- Tạo bảng sách ------------
create table Sach(
MaSach varchar(40),
TenSach nvarchar(100),
TacGia nvarchar(100),
NamXuatBan int,
Gia int,
NhaXuatBan nvarchar(100),
GioiHanTuoi int,
DuongDanAnhDaiDien nvarchar(200),

primary key (MaSach)
)
go

------------------------------- Tạo bảng thể loại ------------
create table TheLoai(
MaTheLoai varchar(40),
TenTheLoai nvarchar(40),

primary key (MaTheLoai)
)
go

------------------------------- Tạo bảng sách + thể loại ------------
create table Sach_TheLoai(
MaSach varchar(40) references Sach(MaSach),
MaTheLoai varchar(40) references TheLoai(MaTheLoai),

primary key (MaSach, MaTheLoai)
)
go

------------------------------- Tạo bảng mượn sách ------------
create table MuonSach(
MaSach varchar(40) references Sach(MaSach),
NgayMuon date,
NgayTra date,
TinhTrang bit,
SoCMND varchar(40) references NguoiDung(SoCMND),
MaNhanVien varchar(40) references NhanVien(MaNhanVien),


primary key (MaSach, NgayMuon)
)
go

------------------------------- Tạo bảng nhận sách (nhận sách đã mượn) ------------
create table NhanSach(
MaSach varchar(40) references Sach(MaSach),
MaNhanVien varchar(40) references NhanVien(MaNhanVien),
NgayNhanSach date,
NgayTreHan int,

primary key (MaSach, NgayNhanSach)
)
go