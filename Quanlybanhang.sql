USE [master]
GO
/****** Object:  Database [Quanlybanhang]    Script Date: 10/11/2022 2:04:58 PM ******/
CREATE DATABASE [Quanlybanhang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Quanlybanhang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Quanlybanhang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Quanlybanhang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Quanlybanhang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Quanlybanhang] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Quanlybanhang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Quanlybanhang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Quanlybanhang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Quanlybanhang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Quanlybanhang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Quanlybanhang] SET ARITHABORT OFF 
GO
ALTER DATABASE [Quanlybanhang] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Quanlybanhang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Quanlybanhang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Quanlybanhang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Quanlybanhang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Quanlybanhang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Quanlybanhang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Quanlybanhang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Quanlybanhang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Quanlybanhang] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Quanlybanhang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Quanlybanhang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Quanlybanhang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Quanlybanhang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Quanlybanhang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Quanlybanhang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Quanlybanhang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Quanlybanhang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Quanlybanhang] SET  MULTI_USER 
GO
ALTER DATABASE [Quanlybanhang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Quanlybanhang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Quanlybanhang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Quanlybanhang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Quanlybanhang] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Quanlybanhang] SET QUERY_STORE = OFF
GO
USE [Quanlybanhang]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Quanlybanhang]
GO
/****** Object:  Table [dbo].[tblChatLieu]    Script Date: 10/11/2022 2:04:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChatLieu](
	[MaChatLieu] [varchar](10) NOT NULL,
	[TenChatLieu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChatLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCTHDBan]    Script Date: 10/11/2022 2:04:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCTHDBan](
	[MaHDBan] [varchar](50) NOT NULL,
	[MaHang] [varchar](10) NOT NULL,
	[SoLuong] [float] NULL,
	[DonGia] [float] NULL,
	[GiamGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK__tblCTHDB__828C639B46FEEDAF] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC,
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHang]    Script Date: 10/11/2022 2:04:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHang](
	[MaHang] [varchar](10) NOT NULL,
	[TenHang] [nvarchar](50) NULL,
	[MaChatLieu] [varchar](10) NULL,
	[SoLuong] [float] NULL,
	[DonGiaNhap] [float] NULL,
	[DonGiaBan] [float] NULL,
	[Anh] [varchar](200) NULL,
	[GhiChu] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHDBan]    Script Date: 10/11/2022 2:04:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHDBan](
	[MaHDBan] [varchar](50) NOT NULL,
	[MaNhanVien] [varchar](10) NULL,
	[NgayBan] [datetime] NULL,
	[MaKhach] [varchar](10) NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [PK__tblHDBan__43106E2AD5017D22] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKhach]    Script Date: 10/11/2022 2:04:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhach](
	[MaKhach] [varchar](10) NOT NULL,
	[TenKhach] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 10/11/2022 2:04:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[MaNhanVien] [varchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[DienThoai] [varchar](15) NULL,
	[NgaySinh] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblChatLieu] ([MaChatLieu], [TenChatLieu]) VALUES (N'CL01', N'Gỗ')
INSERT [dbo].[tblChatLieu] ([MaChatLieu], [TenChatLieu]) VALUES (N'CL02', N'Sắt 1')
INSERT [dbo].[tblChatLieu] ([MaChatLieu], [TenChatLieu]) VALUES (N'CL03', N'Đồng 2')
INSERT [dbo].[tblChatLieu] ([MaChatLieu], [TenChatLieu]) VALUES (N'CL04', N'Vàng 2')
GO
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_214823', N'HH01', 1, 3500, 0, 3500)
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_214823', N'HH02', 1, 2220, 0, 2220)
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_215327', N'HH01', 3, 3500, 10, 9450)
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_215327', N'HH02', 2, 2220, 0, 4440)
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_224305', N'HH01', 1, 3500, 10, 3150)
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_224305', N'HH02', 1, 2220, 0, 2220)
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_224523', N'HH01', 1, 3500, 1, 3465)
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_224523', N'HH02', 1, 2220, 0, 2220)
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_224735', N'HH01', 1, 3500, 0, 3500)
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_224827', N'HH01', 1, 3500, 0, 3500)
INSERT [dbo].[tblCTHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB10102022_224827', N'HH02', 1, 2220, 0, 2220)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaChatLieu], [SoLuong], [DonGiaNhap], [DonGiaBan], [Anh], [GhiChu]) VALUES (N'HH01', N'Iphone 14 pro max', N'CL04', 81, 3000, 3500, N'C:\Users\ASUS\Downloads\post-2.jpg', N'Hàng mới')
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaChatLieu], [SoLuong], [DonGiaNhap], [DonGiaBan], [Anh], [GhiChu]) VALUES (N'HH02', N'Samsung S20', N'CL03', 185, 1900, 2220, N'C:\Users\ASUS\Downloads\samsung-galaxy-z-flip4.jpg', N'Hàng mới')
GO
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB10102022_214823', N'NV01', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'KH01', 5720)
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB10102022_215327', N'NV01', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'KH01', 13890)
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB10102022_224305', N'NV01', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'KH01', 8870)
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB10102022_224523', N'NV01', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'KH01', 16185)
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB10102022_224626', N'NV01', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'KH01', 3500)
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB10102022_224735', N'NV01', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'KH01', 3500)
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB10102022_224827', N'NV01', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'KH01', 5720)
GO
INSERT [dbo].[tblKhach] ([MaKhach], [TenKhach], [DiaChi], [DienThoai], [Email]) VALUES (N'KH01', N'Nguyễn Kim Chí', N'Đường 339, quận 9, TPHCM', N'(033) 629-3669', NULL)
GO
INSERT [dbo].[tblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [NgaySinh]) VALUES (N'NV01', N'Nguyễn Kim Chí', N'Nam', N'Đường 339, quận 9, TPHCM', N'(033) 629-3669', CAST(N'2003-10-11T23:32:57.000' AS DateTime))
GO
ALTER TABLE [dbo].[tblCTHDBan]  WITH CHECK ADD  CONSTRAINT [FK__tblCTHDBa__MaHan__4BAC3F29] FOREIGN KEY([MaHang])
REFERENCES [dbo].[tblHang] ([MaHang])
GO
ALTER TABLE [dbo].[tblCTHDBan] CHECK CONSTRAINT [FK__tblCTHDBa__MaHan__4BAC3F29]
GO
ALTER TABLE [dbo].[tblCTHDBan]  WITH CHECK ADD  CONSTRAINT [FK__tblCTHDBa__MaHDB__4AB81AF0] FOREIGN KEY([MaHDBan])
REFERENCES [dbo].[tblHDBan] ([MaHDBan])
GO
ALTER TABLE [dbo].[tblCTHDBan] CHECK CONSTRAINT [FK__tblCTHDBa__MaHDB__4AB81AF0]
GO
ALTER TABLE [dbo].[tblHang]  WITH CHECK ADD FOREIGN KEY([MaChatLieu])
REFERENCES [dbo].[tblChatLieu] ([MaChatLieu])
GO
ALTER TABLE [dbo].[tblHDBan]  WITH CHECK ADD  CONSTRAINT [FK__tblHDBan__MaKhac__4316F928] FOREIGN KEY([MaKhach])
REFERENCES [dbo].[tblKhach] ([MaKhach])
GO
ALTER TABLE [dbo].[tblHDBan] CHECK CONSTRAINT [FK__tblHDBan__MaKhac__4316F928]
GO
ALTER TABLE [dbo].[tblHDBan]  WITH CHECK ADD  CONSTRAINT [FK__tblHDBan__MaNhan__4222D4EF] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[tblNhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[tblHDBan] CHECK CONSTRAINT [FK__tblHDBan__MaNhan__4222D4EF]
GO
ALTER TABLE [dbo].[tblCTHDBan]  WITH CHECK ADD  CONSTRAINT [CK__tblCTHDBa__DonGi__47DBAE45] CHECK  (([DonGia]>(0)))
GO
ALTER TABLE [dbo].[tblCTHDBan] CHECK CONSTRAINT [CK__tblCTHDBa__DonGi__47DBAE45]
GO
ALTER TABLE [dbo].[tblCTHDBan]  WITH CHECK ADD  CONSTRAINT [CK__tblCTHDBa__GiamG__48CFD27E] CHECK  (([GiamGia]>=(0)))
GO
ALTER TABLE [dbo].[tblCTHDBan] CHECK CONSTRAINT [CK__tblCTHDBa__GiamG__48CFD27E]
GO
ALTER TABLE [dbo].[tblCTHDBan]  WITH CHECK ADD  CONSTRAINT [CK__tblCTHDBa__SoLuo__46E78A0C] CHECK  (([Soluong]>(0)))
GO
ALTER TABLE [dbo].[tblCTHDBan] CHECK CONSTRAINT [CK__tblCTHDBa__SoLuo__46E78A0C]
GO
ALTER TABLE [dbo].[tblCTHDBan]  WITH CHECK ADD  CONSTRAINT [CK__tblCTHDBa__Thanh__49C3F6B7] CHECK  (([ThanhTien]>(0)))
GO
ALTER TABLE [dbo].[tblCTHDBan] CHECK CONSTRAINT [CK__tblCTHDBa__Thanh__49C3F6B7]
GO
ALTER TABLE [dbo].[tblHang]  WITH CHECK ADD CHECK  (([DonGiaBan]>(0)))
GO
ALTER TABLE [dbo].[tblHang]  WITH CHECK ADD CHECK  (([DonGiaNhap]>(0)))
GO
ALTER TABLE [dbo].[tblHang]  WITH CHECK ADD CHECK  (([SoLuong]>=(0)))
GO
ALTER TABLE [dbo].[tblHDBan]  WITH CHECK ADD  CONSTRAINT [CK__tblHDBan__TongTi__440B1D61] CHECK  (([TongTien]>(0)))
GO
ALTER TABLE [dbo].[tblHDBan] CHECK CONSTRAINT [CK__tblHDBan__TongTi__440B1D61]
GO
USE [master]
GO
ALTER DATABASE [Quanlybanhang] SET  READ_WRITE 
GO
