create database Quanlybanhang
go

use Quanlybanhang
go

create table tblChatLieu
(
	MaChatLieu varchar(10) not null primary key,
	TenChatLieu nvarchar(50)
)
go

create table tblKhach
(
	MaKhach varchar(10) not null primary key,
	TenChatLieu nvarchar(50),
	DiaChi nvarchar(50),
	DienThoai varchar(15),
	Email varchar(50) null
)
go

create table tblHang
(
	MaHang varchar(10)not null primary key,
	TenHang nvarchar(50),
	MaChatLieu varchar(10) foreign key references tblChatLieu(MaChatLieu),
	SoLuong float check(SoLuong >= 0),
	DonGiaNhap float check(DonGiaNhap > 0),
	DonGiaBan float check(DonGiaBan > 0),
	Anh varchar(200),
	GhiChu nvarchar(200) null
)
go

create table tblNhanVien
(
	MaNhanVien varchar(10) not null primary key,
	TenNhanVien nvarchar(50),
	GioiTinh nvarchar(10),
	DiaChi nvarchar(200),
	DienThoai varchar(15),
	NgaySinh datetime
)
go

create table tblHDBan
(
	MaHDBan varchar(10) not null primary key,
	MaNhanVien varchar(10) foreign key references tblNhanVien(MaNhanVien),
	NgayBan datetime,
	MaKhach varchar(10) foreign key references tblKhach(MaKhach),
	TongTien float check(TongTien > 0)
)
go

create table tblCTHDBan
(
	MaHDBan varchar(10),
	MaHang varchar(10),
	SoLuong float check(Soluong > 0),
	DonGia float check(DonGia > 0),
	GiamGia float check(GiamGia >= 0),
	ThanhTien float check(ThanhTien > 0)
	primary key(MaHDBan,MaHang),
	foreign key(MaHDBan) references tblHDBan(MaHDBan),
	foreign key(MaHang) references tblHang(MaHang)
)
go

insert into tblChatLieu values('CL01', N'Gỗ')
insert into tblChatLieu values('CL02', N'Sắt')
insert into tblChatLieu values('CL03', N'Vải')