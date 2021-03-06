USE [QuanLyKho_CS]
GO
/****** Object:  Table [dbo].[ActitvityLog]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActitvityLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](50) NULL,
	[OldData] [nvarchar](max) NULL,
	[NewData] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_ActitvityLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietChuyenKho]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietChuyenKho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdChuyenKho] [int] NULL,
	[IdVatTu] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
	[ThanhTien] [decimal](18, 0) NULL,
	[LyDo] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_ChiTietChuyenKho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietKho]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietKho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdKho] [int] NULL,
	[IdVatTu] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietKho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietNhapKho]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietNhapKho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdNhapKho] [int] NULL,
	[IdVatTu] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
	[ThanhTien] [decimal](18, 0) NULL,
	[GhiChu] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_ChiTietNhapKho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietXuatKho]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietXuatKho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdXuatKho] [int] NULL,
	[IdVatTu] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
	[ThanhTien] [decimal](18, 0) NULL,
	[GhiChu] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_ChiTietXuatKho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuyenKho]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenKho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[NgayChuyen] [datetime] NULL,
	[IdNhanVien] [int] NULL,
	[TongTien] [decimal](18, 0) NULL,
	[GhiChu] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[IdKhoCu] [int] NULL,
	[IdKhoMoi] [int] NULL,
 CONSTRAINT [PK_ChuyenKho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kho]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[IdQuanLy] [int] NULL,
	[GhiChu] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Kho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[SDT] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[NguoiDaiDien] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](250) NULL,
	[CMND] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[NgayVaoLam] [date] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhapKho]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhapKho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[NgayNhap] [datetime] NULL,
	[IdNhaCungCap] [int] NULL,
	[IdNhanVien] [int] NULL,
	[TongTien] [decimal](18, 0) NULL,
	[GhiChu] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[IdKho] [int] NULL,
 CONSTRAINT [PK_NhapKho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhomVatTu]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomVatTu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_NhomVatTu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TokenLists]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TokenLists](
	[RefreshToken] [nvarchar](max) NULL,
	[AccessToken] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[IdRole] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VatTu]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VatTu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[DonGia] [decimal](18, 0) NULL,
	[IdNhomVatTu] [int] NULL,
	[IdNhaCungCap] [int] NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[IsActive] [bit] NULL,
	[DonGiaNhap] [decimal](18, 0) NULL,
 CONSTRAINT [PK_VatTu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[XuatKho]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XuatKho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[NgayXuat] [datetime] NULL,
	[IdNhanVien] [int] NULL,
	[DiaChi] [nvarchar](250) NULL,
	[TongTien] [decimal](18, 0) NULL,
	[GhiChu] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[IdKho] [int] NULL,
 CONSTRAINT [PK_XuatKho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ChiTietChuyenKho] ON 

INSERT [dbo].[ChiTietChuyenKho] ([Id], [IdChuyenKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [LyDo], [CreatedAt], [UpdatedAt]) VALUES (1, 1, 1, 50, CAST(3800 AS Decimal(18, 0)), CAST(190000 AS Decimal(18, 0)), N'Chuyển tạm 50 chiếc', CAST(N'2020-04-14 22:00:39.080' AS DateTime), CAST(N'2020-04-14 22:00:39.080' AS DateTime))
INSERT [dbo].[ChiTietChuyenKho] ([Id], [IdChuyenKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [LyDo], [CreatedAt], [UpdatedAt]) VALUES (2, 1, 2, 100, CAST(5000 AS Decimal(18, 0)), CAST(500000 AS Decimal(18, 0)), N'Chuyển tạm 100 chiếc', CAST(N'2020-04-14 22:00:39.080' AS DateTime), CAST(N'2020-04-14 22:00:39.080' AS DateTime))
INSERT [dbo].[ChiTietChuyenKho] ([Id], [IdChuyenKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [LyDo], [CreatedAt], [UpdatedAt]) VALUES (3, 2, 2, 200, CAST(5000 AS Decimal(18, 0)), CAST(1000000 AS Decimal(18, 0)), N'Chuyển tạm 200 chiếc', CAST(N'2020-04-14 22:01:25.440' AS DateTime), CAST(N'2020-04-14 22:01:25.440' AS DateTime))
INSERT [dbo].[ChiTietChuyenKho] ([Id], [IdChuyenKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [LyDo], [CreatedAt], [UpdatedAt]) VALUES (4, 2, 1, 150, CAST(3800 AS Decimal(18, 0)), CAST(570000 AS Decimal(18, 0)), N'Chuyển tạm 150 chiếc', CAST(N'2020-04-14 22:01:25.440' AS DateTime), CAST(N'2020-04-14 22:01:25.440' AS DateTime))
INSERT [dbo].[ChiTietChuyenKho] ([Id], [IdChuyenKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [LyDo], [CreatedAt], [UpdatedAt]) VALUES (5, 3, 2, 400, CAST(5000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), N'Chuyển tạm 400 chiếc', CAST(N'2020-04-14 22:05:45.620' AS DateTime), CAST(N'2020-04-14 22:05:45.620' AS DateTime))
INSERT [dbo].[ChiTietChuyenKho] ([Id], [IdChuyenKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [LyDo], [CreatedAt], [UpdatedAt]) VALUES (6, 3, 1, 250, CAST(3800 AS Decimal(18, 0)), CAST(950000 AS Decimal(18, 0)), N'Chuyển tạm 250 chiếc', CAST(N'2020-04-14 22:05:45.620' AS DateTime), CAST(N'2020-04-14 22:05:45.620' AS DateTime))
INSERT [dbo].[ChiTietChuyenKho] ([Id], [IdChuyenKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [LyDo], [CreatedAt], [UpdatedAt]) VALUES (7, 4, 1, 250, CAST(3800 AS Decimal(18, 0)), CAST(950000 AS Decimal(18, 0)), N'Chuyển tạm 250 chiếc', CAST(N'2020-04-14 22:05:46.060' AS DateTime), CAST(N'2020-04-14 22:05:46.060' AS DateTime))
INSERT [dbo].[ChiTietChuyenKho] ([Id], [IdChuyenKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [LyDo], [CreatedAt], [UpdatedAt]) VALUES (8, 4, 2, 400, CAST(5000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), N'Chuyển tạm 400 chiếc', CAST(N'2020-04-14 22:05:46.060' AS DateTime), CAST(N'2020-04-14 22:05:46.060' AS DateTime))
SET IDENTITY_INSERT [dbo].[ChiTietChuyenKho] OFF
SET IDENTITY_INSERT [dbo].[ChiTietKho] ON 

INSERT [dbo].[ChiTietKho] ([Id], [IdKho], [IdVatTu], [SoLuong]) VALUES (49, 1, 1, 700)
INSERT [dbo].[ChiTietKho] ([Id], [IdKho], [IdVatTu], [SoLuong]) VALUES (50, 1, 2, 1700)
INSERT [dbo].[ChiTietKho] ([Id], [IdKho], [IdVatTu], [SoLuong]) VALUES (51, 2, 5, 450)
INSERT [dbo].[ChiTietKho] ([Id], [IdKho], [IdVatTu], [SoLuong]) VALUES (52, 2, 6, 900)
INSERT [dbo].[ChiTietKho] ([Id], [IdKho], [IdVatTu], [SoLuong]) VALUES (53, 2, 1, 700)
INSERT [dbo].[ChiTietKho] ([Id], [IdKho], [IdVatTu], [SoLuong]) VALUES (54, 2, 2, 1100)
SET IDENTITY_INSERT [dbo].[ChiTietKho] OFF
SET IDENTITY_INSERT [dbo].[ChiTietNhapKho] ON 

INSERT [dbo].[ChiTietNhapKho] ([Id], [IdNhapKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [GhiChu], [CreatedAt], [UpdatedAt]) VALUES (54, 26, 1, 1000, CAST(3800 AS Decimal(18, 0)), CAST(3800000 AS Decimal(18, 0)), N'Làm nghìn viên cho vui', CAST(N'2020-04-14 15:36:15.517' AS DateTime), CAST(N'2020-04-14 15:36:15.517' AS DateTime))
INSERT [dbo].[ChiTietNhapKho] ([Id], [IdNhapKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [GhiChu], [CreatedAt], [UpdatedAt]) VALUES (55, 26, 2, 2000, CAST(5000 AS Decimal(18, 0)), CAST(10000000 AS Decimal(18, 0)), N'Làm hai nghìn viên cho vui', CAST(N'2020-04-14 15:36:15.540' AS DateTime), CAST(N'2020-04-14 15:36:15.540' AS DateTime))
INSERT [dbo].[ChiTietNhapKho] ([Id], [IdNhapKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [GhiChu], [CreatedAt], [UpdatedAt]) VALUES (56, 27, 1, 500, CAST(3800 AS Decimal(18, 0)), CAST(1900000 AS Decimal(18, 0)), N'Làm 5 trăm viên cho vui', CAST(N'2020-04-14 15:38:25.790' AS DateTime), CAST(N'2020-04-14 15:38:25.790' AS DateTime))
INSERT [dbo].[ChiTietNhapKho] ([Id], [IdNhapKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [GhiChu], [CreatedAt], [UpdatedAt]) VALUES (57, 27, 2, 1000, CAST(5000 AS Decimal(18, 0)), CAST(5000000 AS Decimal(18, 0)), N'Làm nghìn viên cho vui', CAST(N'2020-04-14 15:38:25.790' AS DateTime), CAST(N'2020-04-14 15:38:25.790' AS DateTime))
INSERT [dbo].[ChiTietNhapKho] ([Id], [IdNhapKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [GhiChu], [CreatedAt], [UpdatedAt]) VALUES (58, 28, 5, 500, CAST(15000 AS Decimal(18, 0)), CAST(7500000 AS Decimal(18, 0)), N'Làm 5 trăm viên cho vui', CAST(N'2020-04-14 15:43:35.300' AS DateTime), CAST(N'2020-04-14 16:28:34.800' AS DateTime))
INSERT [dbo].[ChiTietNhapKho] ([Id], [IdNhapKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [GhiChu], [CreatedAt], [UpdatedAt]) VALUES (59, 28, 6, 1000, CAST(18000 AS Decimal(18, 0)), CAST(18000000 AS Decimal(18, 0)), N'Làm nghìn viên cho vui', CAST(N'2020-04-14 15:43:35.300' AS DateTime), CAST(N'2020-04-14 16:28:34.800' AS DateTime))
SET IDENTITY_INSERT [dbo].[ChiTietNhapKho] OFF
SET IDENTITY_INSERT [dbo].[ChiTietXuatKho] ON 

INSERT [dbo].[ChiTietXuatKho] ([Id], [IdXuatKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [GhiChu], [CreatedAt], [UpdatedAt]) VALUES (5, 4, 6, 100, CAST(22000 AS Decimal(18, 0)), CAST(2200000 AS Decimal(18, 0)), N'Làm nghìn viên cho vui', CAST(N'2020-04-14 21:41:04.020' AS DateTime), CAST(N'2020-04-14 21:41:04.020' AS DateTime))
INSERT [dbo].[ChiTietXuatKho] ([Id], [IdXuatKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [GhiChu], [CreatedAt], [UpdatedAt]) VALUES (6, 4, 5, 50, CAST(18000 AS Decimal(18, 0)), CAST(900000 AS Decimal(18, 0)), N'Làm 5 trăm viên cho vui', CAST(N'2020-04-14 21:41:04.020' AS DateTime), CAST(N'2020-04-14 21:41:04.020' AS DateTime))
INSERT [dbo].[ChiTietXuatKho] ([Id], [IdXuatKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [GhiChu], [CreatedAt], [UpdatedAt]) VALUES (7, 5, 1, 100, CAST(4200 AS Decimal(18, 0)), CAST(420000 AS Decimal(18, 0)), N'Làm 5 trăm viên cho vui', CAST(N'2020-04-14 21:42:28.543' AS DateTime), CAST(N'2020-04-14 21:45:01.190' AS DateTime))
INSERT [dbo].[ChiTietXuatKho] ([Id], [IdXuatKho], [IdVatTu], [SoLuong], [DonGia], [ThanhTien], [GhiChu], [CreatedAt], [UpdatedAt]) VALUES (8, 5, 2, 200, CAST(5600 AS Decimal(18, 0)), CAST(1120000 AS Decimal(18, 0)), N'Làm nghìn viên cho vui', CAST(N'2020-04-14 21:42:28.543' AS DateTime), CAST(N'2020-04-14 21:45:01.190' AS DateTime))
SET IDENTITY_INSERT [dbo].[ChiTietXuatKho] OFF
SET IDENTITY_INSERT [dbo].[ChuyenKho] ON 

INSERT [dbo].[ChuyenKho] ([Id], [Ma], [NgayChuyen], [IdNhanVien], [TongTien], [GhiChu], [CreatedAt], [UpdatedAt], [IdKhoCu], [IdKhoMoi]) VALUES (1, N'PC1', CAST(N'2020-03-18 00:00:00.000' AS DateTime), 2, CAST(690000 AS Decimal(18, 0)), N'Test chuyển kho', CAST(N'2020-04-14 22:00:39.047' AS DateTime), CAST(N'2020-04-14 22:00:39.047' AS DateTime), 1, 2)
INSERT [dbo].[ChuyenKho] ([Id], [Ma], [NgayChuyen], [IdNhanVien], [TongTien], [GhiChu], [CreatedAt], [UpdatedAt], [IdKhoCu], [IdKhoMoi]) VALUES (2, N'PC2', CAST(N'2020-03-20 00:00:00.000' AS DateTime), 2, CAST(1570000 AS Decimal(18, 0)), N'Test chuyển kho 2', CAST(N'2020-04-14 22:01:25.367' AS DateTime), CAST(N'2020-04-14 22:01:25.367' AS DateTime), 1, 2)
INSERT [dbo].[ChuyenKho] ([Id], [Ma], [NgayChuyen], [IdNhanVien], [TongTien], [GhiChu], [CreatedAt], [UpdatedAt], [IdKhoCu], [IdKhoMoi]) VALUES (3, N'PC3', CAST(N'2020-03-25 00:00:00.000' AS DateTime), 2, CAST(2950000 AS Decimal(18, 0)), N'Test chuyển kho 3', CAST(N'2020-04-14 22:05:45.577' AS DateTime), CAST(N'2020-04-14 22:05:45.577' AS DateTime), 1, 2)
INSERT [dbo].[ChuyenKho] ([Id], [Ma], [NgayChuyen], [IdNhanVien], [TongTien], [GhiChu], [CreatedAt], [UpdatedAt], [IdKhoCu], [IdKhoMoi]) VALUES (4, N'PC3', CAST(N'2020-03-25 00:00:00.000' AS DateTime), 2, CAST(2950000 AS Decimal(18, 0)), N'Test chuyển kho 3', CAST(N'2020-04-14 22:05:46.057' AS DateTime), CAST(N'2020-04-14 22:05:46.057' AS DateTime), 1, 2)
SET IDENTITY_INSERT [dbo].[ChuyenKho] OFF
SET IDENTITY_INSERT [dbo].[Kho] ON 

INSERT [dbo].[Kho] ([Id], [Ma], [Ten], [DiaChi], [SDT], [IdQuanLy], [GhiChu], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, N'K1', N'Kho vật tư Hà Nam', N'Hà Nam', N'0232323211', 1, N'Test thêm kho', CAST(N'2020-04-14 11:20:34.000' AS DateTime), CAST(N'2020-04-14 11:20:34.000' AS DateTime), 1)
INSERT [dbo].[Kho] ([Id], [Ma], [Ten], [DiaChi], [SDT], [IdQuanLy], [GhiChu], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, N'K2', N'Kho vật tư Quảng Ninh', N'Quảng Ninh', N'0232322211', 2, N'Test thêm kho', CAST(N'2020-04-14 11:21:31.577' AS DateTime), CAST(N'2020-04-14 11:21:31.577' AS DateTime), 1)
INSERT [dbo].[Kho] ([Id], [Ma], [Ten], [DiaChi], [SDT], [IdQuanLy], [GhiChu], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (3, N'K3', N'Kho vật tư Hà Nội', N'Hà Nội', N'0232322222', 1, N'Test sửa kho', CAST(N'2020-04-14 11:22:00.070' AS DateTime), CAST(N'2020-04-14 11:26:28.793' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Kho] OFF
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([Id], [Ma], [Ten], [DiaChi], [SDT], [Email], [NguoiDaiDien], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, N'P1', N'Xí nghiệp vật tư Hà Nam', N'Hà Nam', N'0366666665', N'xinghiep1@gmail.com', N'Hoàng Văn Tuyền', CAST(N'2020-04-14 10:37:12.630' AS DateTime), CAST(N'2020-04-14 10:37:12.630' AS DateTime), 1)
INSERT [dbo].[NhaCungCap] ([Id], [Ma], [Ten], [DiaChi], [SDT], [Email], [NguoiDaiDien], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, N'P2', N'Nhà máy xi măng Cẩm Phả', N'Quảng Ninh', N'0366664343', N'xm.campha@gmail.com', N'Trần Lan Anh', CAST(N'2020-04-14 10:38:17.500' AS DateTime), CAST(N'2020-04-14 10:38:17.500' AS DateTime), 1)
INSERT [dbo].[NhaCungCap] ([Id], [Ma], [Ten], [DiaChi], [SDT], [Email], [NguoiDaiDien], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (3, N'P3', N'Gang thép Nhung Đức', N'Quảng Ninh', N'0365344343', N'nhungduc.2001@yahoo.com', N'Nguyễn Thành Đô', CAST(N'2020-04-14 10:38:55.747' AS DateTime), CAST(N'2020-04-14 10:38:55.747' AS DateTime), 1)
INSERT [dbo].[NhaCungCap] ([Id], [Ma], [Ten], [DiaChi], [SDT], [Email], [NguoiDaiDien], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (4, N'P3', N'Tạp hóa Thanh Thao', N'Quảng Ninh', N'0322244343', N'nobody.know@gmail.com', N'Dương Thị Minh Nguyệt', CAST(N'2020-04-14 10:39:34.863' AS DateTime), CAST(N'2020-04-14 10:39:34.863' AS DateTime), 1)
INSERT [dbo].[NhaCungCap] ([Id], [Ma], [Ten], [DiaChi], [SDT], [Email], [NguoiDaiDien], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (5, N'P3', N'Nhà máy gạch Đông Triều', N'Quảng Ninh', N'0322123343', N'dongtrieu_vodoi@gmail.com', N'Trần Thị Hoài Thương', CAST(N'2020-04-14 10:40:12.850' AS DateTime), CAST(N'2020-04-14 10:40:12.850' AS DateTime), 0)
INSERT [dbo].[NhaCungCap] ([Id], [Ma], [Ten], [DiaChi], [SDT], [Email], [NguoiDaiDien], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (6, N'P6', N'Tôn Đông Á', N'Hà Nội', N'0322123112', N'donga.4ever@gmail', N'Đoàn Thị Hồng Ngọc', CAST(N'2020-04-14 10:41:19.427' AS DateTime), CAST(N'2020-04-14 10:43:45.973' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([Id], [Ma], [Ten], [GioiTinh], [NgaySinh], [DiaChi], [CMND], [SDT], [Email], [NgayVaoLam], [CreatedAt], [UpdatedAt], [UserId]) VALUES (1, N'NV01', N'Hoàng Văn Tuyền', 0, CAST(N'1998-06-16' AS Date), N'Quảng Ninh', N'101291257', N'0963566703', N'a5lhp.swift@gmail.com', CAST(N'2020-03-18' AS Date), NULL, NULL, 1)
INSERT [dbo].[NhanVien] ([Id], [Ma], [Ten], [GioiTinh], [NgaySinh], [DiaChi], [CMND], [SDT], [Email], [NgayVaoLam], [CreatedAt], [UpdatedAt], [UserId]) VALUES (2, N'NV02', N'Trần Lan Anh', 1, CAST(N'1998-01-16' AS Date), N'Quảng Ninh', N'122221544', N'0355555555', N'lananhh.98@gmail.com', CAST(N'2020-03-18' AS Date), NULL, NULL, 6)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[NhapKho] ON 

INSERT [dbo].[NhapKho] ([Id], [Ma], [NgayNhap], [IdNhaCungCap], [IdNhanVien], [TongTien], [GhiChu], [CreatedAt], [UpdatedAt], [IdKho]) VALUES (26, N'PN1', CAST(N'2020-04-14 00:00:00.000' AS DateTime), 1, 2, CAST(13800000 AS Decimal(18, 0)), N'Silence is golden', CAST(N'2020-04-14 15:36:15.440' AS DateTime), CAST(N'2020-04-14 15:36:15.440' AS DateTime), 1)
INSERT [dbo].[NhapKho] ([Id], [Ma], [NgayNhap], [IdNhaCungCap], [IdNhanVien], [TongTien], [GhiChu], [CreatedAt], [UpdatedAt], [IdKho]) VALUES (27, N'PN2', CAST(N'2020-04-13 00:00:00.000' AS DateTime), 1, 1, CAST(6900000 AS Decimal(18, 0)), N'Silence is golden', CAST(N'2020-04-14 15:38:25.750' AS DateTime), CAST(N'2020-04-14 15:38:25.750' AS DateTime), 1)
INSERT [dbo].[NhapKho] ([Id], [Ma], [NgayNhap], [IdNhaCungCap], [IdNhanVien], [TongTien], [GhiChu], [CreatedAt], [UpdatedAt], [IdKho]) VALUES (28, N'PN4', CAST(N'2020-04-10 00:00:00.000' AS DateTime), 3, 1, CAST(25500000 AS Decimal(18, 0)), N'Lan Anh 98', CAST(N'2020-04-14 15:43:35.267' AS DateTime), CAST(N'2020-04-14 16:28:34.770' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[NhapKho] OFF
SET IDENTITY_INSERT [dbo].[NhomVatTu] ON 

INSERT [dbo].[NhomVatTu] ([Id], [Ma], [Ten], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, N'N1', N'Gạch đỏ', CAST(N'2020-04-14 10:21:43.357' AS DateTime), CAST(N'2020-04-14 10:21:43.357' AS DateTime), 1)
INSERT [dbo].[NhomVatTu] ([Id], [Ma], [Ten], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, N'N2', N'Dây điện', CAST(N'2020-04-14 10:22:02.290' AS DateTime), CAST(N'2020-04-14 10:22:02.290' AS DateTime), 1)
INSERT [dbo].[NhomVatTu] ([Id], [Ma], [Ten], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (3, N'N3', N'Xi măng', CAST(N'2020-04-14 10:22:11.020' AS DateTime), CAST(N'2020-04-14 10:22:11.020' AS DateTime), 1)
INSERT [dbo].[NhomVatTu] ([Id], [Ma], [Ten], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (4, N'N4', N'Cát', CAST(N'2020-04-14 10:22:20.063' AS DateTime), CAST(N'2020-04-14 10:22:20.063' AS DateTime), 1)
INSERT [dbo].[NhomVatTu] ([Id], [Ma], [Ten], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (5, N'N5', N'Thép', CAST(N'2020-04-14 10:22:30.070' AS DateTime), CAST(N'2020-04-14 10:22:30.070' AS DateTime), 1)
INSERT [dbo].[NhomVatTu] ([Id], [Ma], [Ten], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (6, N'N6', N'Găng tay bảo hộ', CAST(N'2020-04-14 10:22:44.973' AS DateTime), CAST(N'2020-04-14 10:22:44.973' AS DateTime), 1)
INSERT [dbo].[NhomVatTu] ([Id], [Ma], [Ten], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (7, N'N7', N'Quần bảo hộ', CAST(N'2020-04-14 10:22:56.860' AS DateTime), CAST(N'2020-04-14 10:22:56.860' AS DateTime), 1)
INSERT [dbo].[NhomVatTu] ([Id], [Ma], [Ten], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (8, N'N8', N'Áo bảo hộ', CAST(N'2020-04-14 10:23:03.460' AS DateTime), CAST(N'2020-04-14 10:23:03.460' AS DateTime), 1)
INSERT [dbo].[NhomVatTu] ([Id], [Ma], [Ten], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (9, N'N9', N'Thước mét', CAST(N'2020-04-14 10:23:16.580' AS DateTime), CAST(N'2020-04-14 10:23:16.580' AS DateTime), 1)
INSERT [dbo].[NhomVatTu] ([Id], [Ma], [Ten], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (10, N'N11', N'Xẻng xây dựng', CAST(N'2020-04-14 10:23:30.820' AS DateTime), CAST(N'2020-04-14 10:25:54.290' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[NhomVatTu] OFF
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Employee')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY3OTY5NzMsImV4cCI6MTkwMjE1Njk3M30.X5nxakxWdxMGDeHSnB62wrfz-08OB0z6o1XvJ5NXevE', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY3OTY5NzMsImV4cCI6MTU4NjgwMDU3M30.WC8ylmkkjoXTc8v43uV0BJmcf0AnXXpsVxQAG3nFvdE')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY3OTcyMzQsImV4cCI6MTkwMjE1NzIzNH0.rkXYjQmRM6XifZrAQWKwABF64hVF41Rt7XJxbsCkGsI', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY3OTcyMzQsImV4cCI6MTU4NjgwMDgzNH0.eiVDXBDVKonJ8T_vl3wUE_XlbWJhVtavn8bfvsvuEJ4')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1ODY3OTc0ODgsImV4cCI6MTkwMjE1NzQ4OH0.J3emZK4S2ck5FE3D9KK6LxYU3liIBtgULDWb6-eS9oU', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1ODY3OTc0ODgsImV4cCI6MTU4NjgwMTA4OH0.RK_MURSzV-uOe9S4lp8kfNgqF--n5sLZsnHOL5DS85s')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1ODY3OTc1ODIsImV4cCI6MTkwMjE1NzU4Mn0.XfriNsiS5LqwbDVtvpMbazbYZPjdNiQ5x781KNfi9gI', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1ODY3OTc1ODIsImV4cCI6MTU4NjgwMTE4Mn0.ezmj7v3jaRinf3Yo7zz3O9-x6eNrnYi1KVMVsIo5TgI')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1ODY3OTc2NDksImV4cCI6MTkwMjE1NzY0OX0.mpXpiE0oCi44Bz_f9mVnJDslMA-MzwaiUeI7Pj6GnNI', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1ODY3OTc2NDksImV4cCI6MTU4NjgwMTI0OX0.5YuwK0wwLlrVNQYkJx4uPaRi4RUep28uFMfPoW5c_88')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1ODY3OTc3NDMsImV4cCI6MTkwMjE1Nzc0M30.zF4Jas3ATeCpDzRNjCkojexlfjXpIUOTWcWJIjRtJLU', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpYXQiOjE1ODY3OTc3NDMsImV4cCI6MTU4NjgwMTM0M30.oBbQNfy5XXPQSRf1yFpRvMZbKe1-XEXrgIiyGRMGnYA')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY3OTc3NzMsImV4cCI6MTkwMjE1Nzc3M30.ReLDa32t1SCJ6vEFwZgeJ4_47Oxv0bd6PsXOOmbkwOg', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY3OTc3NzMsImV4cCI6MTU4NjgwMTM3M30.boGpjmxpFgbXuqya7zDVjbadNAIeN1FtPfhp-SnDAEA')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6NiwiVXNlcm5hbWUiOiJhZG1pbjEyMyIsIk5oYW5WaWVuSWQiOjIsIk1hTmhhblZpZW4iOiJOVjAyIiwiVGVuTmhhblZpZW4iOiJUcuG6p24gTGFuIEFuaCIsIkdpb2lUaW5oIjp0cnVlLCJOZ2F5U2luaCI6IjE5OTgtMDEtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjAzNTU1NTU1NTUiLCJDTU5EIjoiMTIyMjIxNTQ0IiwiRW1haWwiOiJsYW5hbmhoLjk4QGdtYWlsLmNvbSIsIk5nYXlWYW9MYW0iOiIyMDIwLTAzLTE4VDAwOjAwOjAwLjAwMFoiLCJSb2xlTmFtZSI6IkVtcGxveWVlIn0sImlhdCI6MTU4Njc5NzgyOSwiZXhwIjoxOTAyMTU3ODI5fQ.76R02SXfyt3gZzJuhWwCawCtXsc8_4wsBdM4VnItGFM', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6NiwiVXNlcm5hbWUiOiJhZG1pbjEyMyIsIk5oYW5WaWVuSWQiOjIsIk1hTmhhblZpZW4iOiJOVjAyIiwiVGVuTmhhblZpZW4iOiJUcuG6p24gTGFuIEFuaCIsIkdpb2lUaW5oIjp0cnVlLCJOZ2F5U2luaCI6IjE5OTgtMDEtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjAzNTU1NTU1NTUiLCJDTU5EIjoiMTIyMjIxNTQ0IiwiRW1haWwiOiJsYW5hbmhoLjk4QGdtYWlsLmNvbSIsIk5nYXlWYW9MYW0iOiIyMDIwLTAzLTE4VDAwOjAwOjAwLjAwMFoiLCJSb2xlTmFtZSI6IkVtcGxveWVlIn0sImlhdCI6MTU4Njc5NzgyOSwiZXhwIjoxNTg2ODAxNDI5fQ.xOuzOEBG1Wvudend0ADaQfCpOMlPTNVRNnxuXJXq88g')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY3OTc5MDEsImV4cCI6MTkwMjE1NzkwMX0.juDQQG5X6MjC7MYZTCQ_1Rxwcm47tEONa_DkxkBdGps', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY3OTc5MDEsImV4cCI6MTU4NjgwMTUwMX0.O_hCjom4MQZK79FURbpP1KCExH-In5Er3aH9lKS8_Ms')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4MzQ0NDMsImV4cCI6MTkwMjE5NDQ0M30.xpEbW07XZCn7gfpvNMOx9b-XIkhmG8qH3A5kGFsicMQ', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4MzQ0NDMsImV4cCI6MTU4NjgzODA0M30.7gQ097Tgoi-to7_h9VVqDDTOnn8cQacze4YiLFUqf5g')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4MzgwNzgsImV4cCI6MTkwMjE5ODA3OH0.yUZ8Fu933FD_oAX1y0byXW3GFe8tsE12UXiY5v58y8A', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4MzgwNzgsImV4cCI6MTU4Njg0MTY3OH0.UL0Qq3_qTP_gPsD_EM1PeQjYzpUkmePvUEGzd0MV8NI')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4NDUxMTgsImV4cCI6MTkwMjIwNTExOH0.bvJMudVnks2ufuGH0TpEBDLikzYciDVI1BpgqaITD0o', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4NDUxMTcsImV4cCI6MTU4Njg0ODcxN30.wwJz06cSYEDw2qTPmd-Inop0xPi2SU6HHYTYT5zvTx0')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4NDg4NjYsImV4cCI6MTkwMjIwODg2Nn0.QL1BRtlliuKlo_6ByqUjfj_DvPal-7ql1vWERWl5qBM', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4NDg4NjYsImV4cCI6MTU4Njg1MjQ2Nn0.tqbgstwlJi3Vn9HZxcNmR7E42LG69vmErTu-m5ne3zM')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4NTMxNjgsImV4cCI6MTkwMjIxMzE2OH0.zXShxfN4JPHkEqhXnidawcQ9lXAP3ALlSV658DjGpek', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4NTMxNjgsImV4cCI6MTU4Njg1Njc2OH0.tiGnpoqqCbgufsMaUthf41dEAn62wetN1PeW_ZOwms4')
INSERT [dbo].[TokenLists] ([RefreshToken], [AccessToken]) VALUES (N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4NzQwOTQsImV4cCI6MTkwMjIzNDA5NH0.979BeIeNqIyFlIr_rnQdEB2a1omIUTIuMNUsPjZ_-RM', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7IlVzZXJJZCI6MSwiVXNlcm5hbWUiOiJhZG1pbiIsIk5oYW5WaWVuSWQiOjEsIk1hTmhhblZpZW4iOiJOVjAxIiwiVGVuTmhhblZpZW4iOiJIb8OgbmcgVsSDbiBUdXnhu4FuIiwiR2lvaVRpbmgiOmZhbHNlLCJOZ2F5U2luaCI6IjE5OTgtMDYtMTZUMDA6MDA6MDAuMDAwWiIsIkRpYUNoaSI6IlF14bqjbmcgTmluaCIsIlNEVCI6IjA5NjM1NjY3MDMiLCJDTU5EIjoiMTAxMjkxMjU3IiwiRW1haWwiOiJhNWxocC5zd2lmdEBnbWFpbC5jb20iLCJOZ2F5VmFvTGFtIjoiMjAyMC0wMy0xOFQwMDowMDowMC4wMDBaIiwiUm9sZU5hbWUiOiJBZG1pbiJ9LCJpYXQiOjE1ODY4NzQwOTQsImV4cCI6MTU4Njg3NzY5NH0.HLUOZS9tXCYXiTkKgTN0XNMyrZLDfKSz-JD8WbQ7SBA')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [CreatedAt], [UpdatedAt], [IdRole]) VALUES (1, N'admin', N'$2b$07$KieALq9ZG3X7GHmBhpGdWeEZBeGmyYMzhomFfLrHi6QsTaMT5tSsG', CAST(N'2020-04-13 23:35:58.210' AS DateTime), CAST(N'2020-04-13 23:35:58.210' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [CreatedAt], [UpdatedAt], [IdRole]) VALUES (6, N'admin123', N'$2b$07$qIsX6/jii5296/fjT0K6YuffbsDvmFM1P4b82U96oFnJ2clC814US', CAST(N'2020-04-13 23:42:34.720' AS DateTime), CAST(N'2020-04-14 00:01:03.230' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[VatTu] ON 

INSERT [dbo].[VatTu] ([Id], [Ma], [Ten], [DonGia], [IdNhomVatTu], [IdNhaCungCap], [DonViTinh], [CreatedAt], [UpdatedAt], [IsActive], [DonGiaNhap]) VALUES (1, N'VT1', N'Gạch hai lỗ', CAST(4200 AS Decimal(18, 0)), 1, 1, N'Viên', CAST(N'2020-04-14 10:50:40.020' AS DateTime), CAST(N'2020-04-14 10:50:40.020' AS DateTime), 1, CAST(3800 AS Decimal(18, 0)))
INSERT [dbo].[VatTu] ([Id], [Ma], [Ten], [DonGia], [IdNhomVatTu], [IdNhaCungCap], [DonViTinh], [CreatedAt], [UpdatedAt], [IsActive], [DonGiaNhap]) VALUES (2, N'VT2', N'Gạch bốn lỗ', CAST(5600 AS Decimal(18, 0)), 1, 1, N'Viên', CAST(N'2020-04-14 10:51:34.580' AS DateTime), CAST(N'2020-04-14 10:51:34.580' AS DateTime), 1, CAST(5000 AS Decimal(18, 0)))
INSERT [dbo].[VatTu] ([Id], [Ma], [Ten], [DonGia], [IdNhomVatTu], [IdNhaCungCap], [DonViTinh], [CreatedAt], [UpdatedAt], [IsActive], [DonGiaNhap]) VALUES (3, N'VT3', N'Cát loại I', CAST(1200000 AS Decimal(18, 0)), 4, 1, N'Mét khối', CAST(N'2020-04-14 10:53:00.330' AS DateTime), CAST(N'2020-04-14 10:53:00.330' AS DateTime), 1, CAST(1080000 AS Decimal(18, 0)))
INSERT [dbo].[VatTu] ([Id], [Ma], [Ten], [DonGia], [IdNhomVatTu], [IdNhaCungCap], [DonViTinh], [CreatedAt], [UpdatedAt], [IsActive], [DonGiaNhap]) VALUES (4, N'VT4', N'Cát loại II', CAST(1050000 AS Decimal(18, 0)), 4, 1, N'Mét khối', CAST(N'2020-04-14 10:53:32.133' AS DateTime), CAST(N'2020-04-14 10:53:32.133' AS DateTime), 1, CAST(920000 AS Decimal(18, 0)))
INSERT [dbo].[VatTu] ([Id], [Ma], [Ten], [DonGia], [IdNhomVatTu], [IdNhaCungCap], [DonViTinh], [CreatedAt], [UpdatedAt], [IsActive], [DonGiaNhap]) VALUES (5, N'VT5', N'Thép phi 16', CAST(18000 AS Decimal(18, 0)), 5, 3, N'Mét', CAST(N'2020-04-14 10:54:58.140' AS DateTime), CAST(N'2020-04-14 10:54:58.140' AS DateTime), 1, CAST(15000 AS Decimal(18, 0)))
INSERT [dbo].[VatTu] ([Id], [Ma], [Ten], [DonGia], [IdNhomVatTu], [IdNhaCungCap], [DonViTinh], [CreatedAt], [UpdatedAt], [IsActive], [DonGiaNhap]) VALUES (6, N'VT6', N'Thép phi 20', CAST(22000 AS Decimal(18, 0)), 5, 3, N'Mét', CAST(N'2020-04-14 10:55:12.827' AS DateTime), CAST(N'2020-04-14 10:55:12.827' AS DateTime), 1, CAST(18000 AS Decimal(18, 0)))
INSERT [dbo].[VatTu] ([Id], [Ma], [Ten], [DonGia], [IdNhomVatTu], [IdNhaCungCap], [DonViTinh], [CreatedAt], [UpdatedAt], [IsActive], [DonGiaNhap]) VALUES (7, N'VT17', N'Xi măng trắng', CAST(5900 AS Decimal(18, 0)), 3, 2, N'Cân', CAST(N'2020-04-14 10:56:51.440' AS DateTime), CAST(N'2020-04-14 10:59:26.980' AS DateTime), 0, CAST(4800 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[VatTu] OFF
SET IDENTITY_INSERT [dbo].[XuatKho] ON 

INSERT [dbo].[XuatKho] ([Id], [Ma], [NgayXuat], [IdNhanVien], [DiaChi], [TongTien], [GhiChu], [CreatedAt], [UpdatedAt], [IdKho]) VALUES (4, N'PN3', CAST(N'2020-04-12 00:00:00.000' AS DateTime), 1, N'Cẩm Thịnh, Cẩm Phả, Quảng Ninh', CAST(3100000 AS Decimal(18, 0)), N'Unknown', CAST(N'2020-04-14 21:41:03.983' AS DateTime), CAST(N'2020-04-14 21:41:03.983' AS DateTime), 2)
INSERT [dbo].[XuatKho] ([Id], [Ma], [NgayXuat], [IdNhanVien], [DiaChi], [TongTien], [GhiChu], [CreatedAt], [UpdatedAt], [IdKho]) VALUES (5, N'PX5', CAST(N'2020-03-14 00:00:00.000' AS DateTime), 2, N'Hoàng Quốc Việt, Bắc Từ Liêm, Hà Nội', CAST(1540000 AS Decimal(18, 0)), N'HihiHehe', CAST(N'2020-04-14 21:42:28.507' AS DateTime), CAST(N'2020-04-14 21:45:01.153' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[XuatKho] OFF
ALTER TABLE [dbo].[ActitvityLog]  WITH CHECK ADD  CONSTRAINT [FK_ActitvityLog_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ActitvityLog] CHECK CONSTRAINT [FK_ActitvityLog_Users]
GO
ALTER TABLE [dbo].[ChiTietChuyenKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietChuyenKho_ChuyenKho] FOREIGN KEY([IdChuyenKho])
REFERENCES [dbo].[ChuyenKho] ([Id])
GO
ALTER TABLE [dbo].[ChiTietChuyenKho] CHECK CONSTRAINT [FK_ChiTietChuyenKho_ChuyenKho]
GO
ALTER TABLE [dbo].[ChiTietChuyenKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietChuyenKho_VatTu] FOREIGN KEY([IdVatTu])
REFERENCES [dbo].[VatTu] ([Id])
GO
ALTER TABLE [dbo].[ChiTietChuyenKho] CHECK CONSTRAINT [FK_ChiTietChuyenKho_VatTu]
GO
ALTER TABLE [dbo].[ChiTietKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietKho_Kho] FOREIGN KEY([IdKho])
REFERENCES [dbo].[Kho] ([Id])
GO
ALTER TABLE [dbo].[ChiTietKho] CHECK CONSTRAINT [FK_ChiTietKho_Kho]
GO
ALTER TABLE [dbo].[ChiTietKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietKho_VatTu] FOREIGN KEY([IdVatTu])
REFERENCES [dbo].[VatTu] ([Id])
GO
ALTER TABLE [dbo].[ChiTietKho] CHECK CONSTRAINT [FK_ChiTietKho_VatTu]
GO
ALTER TABLE [dbo].[ChiTietNhapKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietNhapKho_NhapKho] FOREIGN KEY([IdNhapKho])
REFERENCES [dbo].[NhapKho] ([Id])
GO
ALTER TABLE [dbo].[ChiTietNhapKho] CHECK CONSTRAINT [FK_ChiTietNhapKho_NhapKho]
GO
ALTER TABLE [dbo].[ChiTietNhapKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietNhapKho_VatTu] FOREIGN KEY([IdVatTu])
REFERENCES [dbo].[VatTu] ([Id])
GO
ALTER TABLE [dbo].[ChiTietNhapKho] CHECK CONSTRAINT [FK_ChiTietNhapKho_VatTu]
GO
ALTER TABLE [dbo].[ChiTietXuatKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietXuatKho_VatTu] FOREIGN KEY([IdVatTu])
REFERENCES [dbo].[VatTu] ([Id])
GO
ALTER TABLE [dbo].[ChiTietXuatKho] CHECK CONSTRAINT [FK_ChiTietXuatKho_VatTu]
GO
ALTER TABLE [dbo].[ChiTietXuatKho]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietXuatKho_XuatKho] FOREIGN KEY([IdXuatKho])
REFERENCES [dbo].[XuatKho] ([Id])
GO
ALTER TABLE [dbo].[ChiTietXuatKho] CHECK CONSTRAINT [FK_ChiTietXuatKho_XuatKho]
GO
ALTER TABLE [dbo].[ChuyenKho]  WITH CHECK ADD  CONSTRAINT [FK_ChuyenKho_Kho] FOREIGN KEY([IdKhoCu])
REFERENCES [dbo].[Kho] ([Id])
GO
ALTER TABLE [dbo].[ChuyenKho] CHECK CONSTRAINT [FK_ChuyenKho_Kho]
GO
ALTER TABLE [dbo].[ChuyenKho]  WITH CHECK ADD  CONSTRAINT [FK_ChuyenKho_Kho1] FOREIGN KEY([IdKhoMoi])
REFERENCES [dbo].[Kho] ([Id])
GO
ALTER TABLE [dbo].[ChuyenKho] CHECK CONSTRAINT [FK_ChuyenKho_Kho1]
GO
ALTER TABLE [dbo].[ChuyenKho]  WITH CHECK ADD  CONSTRAINT [FK_ChuyenKho_NhanVien] FOREIGN KEY([IdNhanVien])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[ChuyenKho] CHECK CONSTRAINT [FK_ChuyenKho_NhanVien]
GO
ALTER TABLE [dbo].[Kho]  WITH CHECK ADD  CONSTRAINT [FK_Kho_NhanVien] FOREIGN KEY([IdQuanLy])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[Kho] CHECK CONSTRAINT [FK_Kho_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_Users]
GO
ALTER TABLE [dbo].[NhapKho]  WITH CHECK ADD  CONSTRAINT [FK_NhapKho_Kho] FOREIGN KEY([IdKho])
REFERENCES [dbo].[Kho] ([Id])
GO
ALTER TABLE [dbo].[NhapKho] CHECK CONSTRAINT [FK_NhapKho_Kho]
GO
ALTER TABLE [dbo].[NhapKho]  WITH CHECK ADD  CONSTRAINT [FK_NhapKho_NhaCungCap] FOREIGN KEY([IdNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([Id])
GO
ALTER TABLE [dbo].[NhapKho] CHECK CONSTRAINT [FK_NhapKho_NhaCungCap]
GO
ALTER TABLE [dbo].[NhapKho]  WITH CHECK ADD  CONSTRAINT [FK_NhapKho_NhanVien] FOREIGN KEY([IdNhanVien])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[NhapKho] CHECK CONSTRAINT [FK_NhapKho_NhanVien]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[VatTu]  WITH CHECK ADD  CONSTRAINT [FK_VatTu_NhaCungCap] FOREIGN KEY([IdNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([Id])
GO
ALTER TABLE [dbo].[VatTu] CHECK CONSTRAINT [FK_VatTu_NhaCungCap]
GO
ALTER TABLE [dbo].[VatTu]  WITH CHECK ADD  CONSTRAINT [FK_VatTu_NhomVatTu] FOREIGN KEY([IdNhomVatTu])
REFERENCES [dbo].[NhomVatTu] ([Id])
GO
ALTER TABLE [dbo].[VatTu] CHECK CONSTRAINT [FK_VatTu_NhomVatTu]
GO
ALTER TABLE [dbo].[XuatKho]  WITH CHECK ADD  CONSTRAINT [FK_XuatKho_Kho] FOREIGN KEY([IdKho])
REFERENCES [dbo].[Kho] ([Id])
GO
ALTER TABLE [dbo].[XuatKho] CHECK CONSTRAINT [FK_XuatKho_Kho]
GO
ALTER TABLE [dbo].[XuatKho]  WITH CHECK ADD  CONSTRAINT [FK_XuatKho_NhanVien] FOREIGN KEY([IdNhanVien])
REFERENCES [dbo].[NhanVien] ([Id])
GO
ALTER TABLE [dbo].[XuatKho] CHECK CONSTRAINT [FK_XuatKho_NhanVien]
GO
/****** Object:  StoredProcedure [dbo].[prc_Insert_SaveToken]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[prc_Insert_SaveToken]
@RefreshToken NVARCHAR(MAX),
@AccessToken NVARCHAR(MAX)
AS
	DECLARE @isExisted INT
	SELECT @isExisted = COUNT(*) FROM TokenLists WHERE RefreshToken = @RefreshToken
	IF @isExisted > 0
		BEGIN
			UPDATE TokenLists SET AccessToken = @AccessToken WHERE RefreshToken = @RefreshToken
		END
	ELSE
		BEGIN
			INSERT TokenLists (RefreshToken, AccessToken)
			VALUES (@RefreshToken, @AccessToken)
		END
GO
/****** Object:  StoredProcedure [dbo].[Usp_AddNewCategory]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddNewCategory]
	@Ma NVARCHAR(50),
	@Ten NVARCHAR(50),
	@Id INT OUTPUT
AS 
	INSERT dbo.NhomVatTu
	        ( Ma ,
	          Ten ,
	          CreatedAt ,
	          UpdatedAt ,
	          IsActive
	        )
	VALUES  ( @Ma , -- Ma - nvarchar(50)
	          @Ten , -- Ten - nvarchar(50)
	          GETDATE() , -- CreatedAt - datetime
	          GETDATE() , -- UpdatedAt - datetime
	          1  -- IsActive - bit
	        )
	SET @Id = @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Usp_AddNewEmployee]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddNewEmployee]
  @Ma NVARCHAR(50),
  @Ten NVARCHAR(50),
  @GioiTinh BIT,
  @NgaySinh DATE,
  @DiaChi NVARCHAR(250),
  @CMND NVARCHAR(50),
  @SDT NVARCHAR(50),
  @Email NVARCHAR(50),
  @NgayVaoLam DATE,
  @Id INT OUTPUT
  AS
	INSERT dbo.NhanVien
	        ( Ma ,
	          Ten ,
	          GioiTinh ,
	          NgaySinh ,
	          DiaChi ,
	          CMND ,
	          SDT ,
	          Email ,
	          NgayVaoLam ,
	          CreatedAt ,
	          UpdatedAt ,
	          UserId
	        )
	VALUES  ( @Ma , -- Ma - nvarchar(50)
	          @Ten , -- Ten - nvarchar(50)
	          @GioiTinh , -- GioiTinh - bit
	          @NgaySinh , -- NgaySinh - date
	          @DiaChi , -- DiaChi - nvarchar(250)
	          @CMND , -- CMND - nvarchar(50)
	          @SDT , -- SDT - nvarchar(50)
	          @Email , -- Email - nvarchar(50)
	          @NgayVaoLam , -- NgayVaoLam - date
	          GETDATE() , -- CreatedAt - datetime
	          GETDATE() , -- UpdatedAt - datetime
	          NULL  -- UserId - int
	        )
	SET @Id = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Usp_AddNewExchangeGoodReceipt]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddNewExchangeGoodReceipt]
	@Ma NVARCHAR(50),
	@NgayChuyen DATETIME,
	@IdNhanVien INT,
	@IdKhoCu INT,
	@IdKhoMoi INT,
	@GhiChu NVARCHAR(250),
	@Id INT OUT
AS
	SET XACT_ABORT ON
	BEGIN TRAN
	BEGIN TRY
		 INSERT dbo.ChuyenKho
		         ( Ma ,
		           NgayChuyen ,
		           IdNhanVien ,
		           TongTien ,
		           GhiChu ,
		           CreatedAt ,
		           UpdatedAt ,
				   IdKhoCu ,
				   IdKhoMoi
		         )
		 VALUES  ( @Ma , -- Ma - nvarchar(50)
		           @NgayChuyen , -- NgayChuyen - datetime
		           @IdNhanVien , -- IdNhanVien - int
		           0 , -- TongTien - decimal
		           @GhiChu , -- GhiChu - nvarchar(250)
		           GETDATE() , -- CreatedAt - datetime
		           GETDATE() , -- UpdatedAt - datetime
				   @IdKhoCu ,
				   @IdKhoMoi
		         )
		SET @Id = @@IDENTITY
	COMMIT
	END TRY
	BEGIN CATCH
	   ROLLBACK
	   DECLARE @ErrorMessage VARCHAR(2000)
	   SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
	   RAISERROR(@ErrorMessage, 16, 1)
	END CATCH

GO
/****** Object:  StoredProcedure [dbo].[Usp_AddNewExportGoodReceipt]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddNewExportGoodReceipt]
	@Ma NVARCHAR(50),
	@NgayXuat DATETIME,
	@DiaChi NVARCHAR(250),
	@IdNhanVien INT,
	@IdKho INT,
	@GhiChu NVARCHAR(250),
	@Id INT OUT
AS
	SET XACT_ABORT ON
	BEGIN TRAN
	BEGIN TRY
		 INSERT dbo.XuatKho
		         ( Ma ,
		           NgayXuat ,
		           IdNhanVien ,
		           DiaChi ,
		           TongTien ,
		           GhiChu ,
		           CreatedAt ,
		           UpdatedAt ,
				   IdKho
		         )
		 VALUES  ( @Ma , -- Ma - nvarchar(50)
		           @NgayXuat , -- NgayXuat - datetime
		           @IdNhanVien , -- IdNhanVien - int
		           @DiaChi , -- DiaChi - nvarchar(250)
		           0 , -- TongTien - decimal
		           @GhiChu , -- GhiChu - nvarchar(250)
		           GETDATE() , -- CreatedAt - datetime
		           GETDATE() , -- UpdatedAt - datetime
				   @IdKho
		         )
		SET @Id = @@IDENTITY
	COMMIT
	END TRY
	BEGIN CATCH
	   ROLLBACK
	   DECLARE @ErrorMessage VARCHAR(2000)
	   SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
	   RAISERROR(@ErrorMessage, 16, 1)
	END CATCH

GO
/****** Object:  StoredProcedure [dbo].[Usp_AddNewImportGoodReceipt]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddNewImportGoodReceipt]
	@Ma NVARCHAR(50),
	@NgayNhap DATETIME,
	@IdNhaCungCap INT,
	@IdNhanVien INT,
	@IdKho INT,
	@GhiChu NVARCHAR(250),
	@Id INT OUT
AS
	SET XACT_ABORT ON
	BEGIN TRAN
	BEGIN TRY
		 INSERT dbo.NhapKho
				 ( Ma ,
				   NgayNhap ,
				   IdNhaCungCap ,
				   IdNhanVien ,
				   TongTien ,
				   GhiChu ,
				   CreatedAt ,
				   UpdatedAt ,
				   IdKho
				 )
		 VALUES  ( @Ma , -- Ma - nvarchar(50)
				   @NgayNhap , -- NgayNhap - datetime
				   @IdNhaCungCap , -- IdNhaCungCap - int
				   @IdNhanVien , -- IdNhanVien - int
				   0 , -- TongTien - decimal
				   @GhiChu , -- GhiChu - nvarchar(250)
				   GETDATE() , -- CreatedAt - datetime
				   GETDATE() , -- UpdatedAt - datetime
				   @IdKho  -- IdKho - int
				 )
		SET @Id = @@IDENTITY
	COMMIT
	END TRY
	BEGIN CATCH
	   ROLLBACK
	   DECLARE @ErrorMessage VARCHAR(2000)
	   SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
	   RAISERROR(@ErrorMessage, 16, 1)
	END CATCH

GO
/****** Object:  StoredProcedure [dbo].[Usp_AddNewProduct]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddNewProduct]
	@Ma NVARCHAR(50),
	@Ten NVARCHAR(50),
	@DonGia DECIMAL(18, 0),
	@DonGiaNhap DECIMAL(18, 0),
	@IdNhomVatTu INT,
	@IdNhaCungCap INT,
	@DonViTinh NVARCHAR(50),
	@Id INT OUTPUT
AS 
	INSERT dbo.VatTu
	        ( Ma ,
	          Ten ,
	          DonGia ,
	          IdNhomVatTu ,
	          IdNhaCungCap ,
	          DonViTinh ,
	          CreatedAt ,
	          UpdatedAt,
			  IsActive,
			  DonGiaNhap
	        )
	VALUES  ( @Ma , -- Ma - nvarchar(50)
	          @Ten , -- Ten - nvarchar(50)
	          @DonGia , -- DonGia - decimal
	          @IdNhomVatTu , -- IdNhomVatTu - int
	          @IdNhaCungCap , -- IdNhaCungCap - int
	          @DonViTinh , -- DonViTinh - nvarchar(50)
	          GETDATE() , -- CreatedAt - datetime
	          GETDATE() ,
			  1,
			  @DonGiaNhap
	        )
	SELECT @Id = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Usp_AddNewProvider]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddNewProvider]
	@Ma NVARCHAR(50),
	@Ten NVARCHAR(50),
	@DiaChi NVARCHAR(250),
	@SDT NVARCHAR(50),
	@Email NVARCHAR(50),
	@NguoiDaiDien NVARCHAR(50),
	@Id INT OUTPUT
AS 
	INSERT dbo.NhaCungCap
	        ( Ma ,
	          Ten ,
	          DiaChi ,
	          SDT ,
	          Email ,
	          NguoiDaiDien ,
	          CreatedAt ,
	          UpdatedAt ,
	          IsActive
	        )
	VALUES  ( @Ma , -- Ma - nvarchar(50)
	          @Ten , -- Ten - nvarchar(50)
	          @DiaChi , -- DiaChi - nvarchar(250)
	          @SDT , -- SDT - nvarchar(50)
	          @Email , -- Email - nvarchar(50)
	          @NguoiDaiDien , -- NguoiDaiDien - nvarchar(50)
	          GETDATE() , -- CreatedAt - datetime
	          GETDATE() , -- UpdatedAt - datetime
	          1  -- IsActive - bit
	        )
	SET @Id = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Usp_AddNewWarehouse]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddNewWarehouse]
	@Ma NVARCHAR(50),
	@Ten NVARCHAR(50),
	@DiaChi NVARCHAR(50),
	@SDT NVARCHAR(50),
	@GhiChu NVARCHAR(250),
	@IdQuanLy INT,
	@Id INT OUTPUT
AS
	INSERT dbo.Kho
	        ( Ma ,
	          Ten ,
	          DiaChi ,
	          SDT ,
	          IdQuanLy ,
	          GhiChu ,
	          CreatedAt ,
	          UpdatedAt ,
	          IsActive
	        )
	VALUES  ( @Ma , -- Ma - nvarchar(50)
	          @Ten , -- Ten - nvarchar(50)
	          @DiaChi , -- DiaChi - nvarchar(50)
	          @SDT , -- SDT - nvarchar(50)
	          @IdQuanLy , -- IdQuanLy - int
	          @GhiChu , -- GhiChu - nvarchar(250)
	          GETDATE() , -- CreatedAt - datetime
	          GETDATE() , -- UpdatedAt - datetime
	          1  -- IsActive - bit
	        )
	SET @Id = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Usp_AddOrUpdateExchangeReceiptDetail]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddOrUpdateExchangeReceiptDetail]
	@IdVatTu INT,
	@IdChuyenKho INT,
	@SoLuong INT,
	@LyDo NVARCHAR(250),
	@TongTien DECIMAL(18, 2) OUT
AS 
	--SET XACT_ABORT ON
	--BEGIN TRAN
	--BEGIN TRY
	--	 IF EXISTS (SELECT * FROM dbo.ChuyenKho WHERE Id = @IdChuyenKho)
	--	 BEGIN
	--	 	DECLARE @IdKhoCu INT, @IdKhoMoi INT, @SoLuongTonKhoCu INT, @SoLuongTonKhoMoi INT
	--		SELECT @IdKhoCu = IdKhoCu, @IdKhoMoi = IdKhoMoi FROM dbo.ChuyenKho WHERE Id = @IdChuyenKho;

	--		IF EXISTS (SELECT * FROM dbo.ChiTietChuyenKho WHERE IdChuyenKho = @IdChuyenKho AND IdVatTu = @IdVatTu)
	--	 	BEGIN
	--	 		UPDATE dbo.ChuyenKho 
	--			SET TongTien = TongTien - (SELECT ThanhTien FROM dbo.ChiTietChuyenKho WHERE IdVatTu = @IdVatTu AND IdChuyenKho = @IdChuyenKho)
	--			WHERE Id = @IdChuyenKho;

	--			UPDATE dbo.ChiTietKho 
	--			SET SoLuong = SoLuong + (SELECT SoLuong FROM dbo.ChiTietChuyenKho WHERE IdVatTu = @IdVatTu AND IdChuyenKho = @IdChuyenKho)
	--			WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu;

	--			UPDATE dbo.ChiTietKho 
	--			SET SoLuong = SoLuong - (SELECT SoLuong FROM dbo.ChiTietChuyenKho WHERE IdVatTu = @IdVatTu AND IdChuyenKho = @IdChuyenKho)
	--			WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu;
				
	--			SELECT @SoLuongTonKhoCu = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu;
	--			SELECT @SoLuongTonKhoMoi = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu;
				
	--			IF (@SoLuongTonKhoCu < @SoLuong)
	--			BEGIN
	--				RAISERROR(N'Số lượng vật tư còn lại không đủ', 16, 1)
	--			END
	--			ELSE
	--			BEGIN
	--				UPDATE dbo.ChiTietChuyenKho
	--				SET 
	--					SoLuong = @SoLuong,
	--					ThanhTien = @SoLuong * (SELECT DonGiaNhap FROM dbo.VatTu WHERE Id = @IdVatTu),
	--					DonGia = (SELECT DonGiaNhap FROM dbo.VatTu WHERE Id = @IdVatTu),
	--					LyDo = @LyDo,
	--					UpdatedAt = GETDATE()
	--				WHERE IdChuyenKho = @IdChuyenKho AND IdVatTu = @IdVatTu
	--			END
	--	 	END
	--		ELSE
	--		BEGIN
	--			SELECT @SoLuongTonKhoCu = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu;
	--			SELECT @SoLuongTonKhoMoi = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu;

	--			IF (@SoLuongTonKhoCu < @SoLuong)
	--			BEGIN
	--				RAISERROR(N'Số lượng vật tư còn lại không đủ', 16, 1)
	--			END
	--			ELSE
	--			BEGIN
	--				INSERT dbo.ChiTietChuyenKho
	--				        ( IdChuyenKho ,
	--				          IdVatTu ,
	--				          SoLuong ,
	--				          DonGia ,
	--				          ThanhTien ,
	--				          LyDo ,
	--				          CreatedAt ,
	--				          UpdatedAt
	--				        )
	--				SELECT
	--					@IdChuyenKho,
	--					@IdVatTu,
	--					@SoLuong,
	--					V.DonGiaNhap,
	--					V.DonGiaNhap * @SoLuong,
	--					@LyDo,
	--					GETDATE(),
	--					GETDATE()
	--				FROM dbo.VatTu V
	--				WHERE V.Id = @IdVatTu;
	--			END
	--		END

	--		UPDATE dbo.ChuyenKho 
	--		SET TongTien = TongTien + (SELECT ThanhTien FROM dbo.ChiTietChuyenKho WHERE IdVatTu = @IdVatTu AND IdChuyenKho = @IdChuyenKho)
	--		WHERE Id = @IdChuyenKho;

	--		UPDATE dbo.ChiTietKho
	--		SET SoLuong = SoLuong - @SoLuong
	--		WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu;

	--		IF @SoLuongTonKhoMoi IS NULL OR @SoLuongTonKhoMoi = 0
	--		BEGIN
	--			INSERT dbo.ChiTietKho
	--				( IdKho, IdVatTu, SoLuong )
	--			VALUES  ( @IdKhoMoi, -- IdKho - int
	--					  @IdVatTu, -- IdVatTu - int
	--					  @SoLuong  -- SoLuong - int
	--					) 
	--		END
	--		ELSE
	--		BEGIN
	--				UPDATE dbo.ChiTietKho
	--				SET SoLuong = SoLuong + @SoLuong
	--				WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu
	--		END

	--		SELECT @TongTien = TongTien FROM dbo.ChuyenKho WHERE Id = @IdChuyenKho;
	--	 END
	--	 ELSE
	--	 BEGIN
	--	 	RAISERROR(N'Không tồn tại IdChuyenKho', 16, 1)
	--	 END
	--COMMIT
	--END TRY
	--BEGIN CATCH
	--   ROLLBACK
	--   DECLARE @ErrorMessage VARCHAR(2000)
	--   SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
	--   RAISERROR(@ErrorMessage, 16, 1)
	--END CATCH

	IF EXISTS (SELECT * FROM dbo.ChuyenKho WHERE Id = @IdChuyenKho)
		 BEGIN
		 	DECLARE @IdKhoCu INT, @IdKhoMoi INT, @SoLuongTonKhoCu INT, @SoLuongTonKhoMoi INT
			SELECT @IdKhoCu = IdKhoCu, @IdKhoMoi = IdKhoMoi FROM dbo.ChuyenKho WHERE Id = @IdChuyenKho;

			IF EXISTS (SELECT * FROM dbo.ChiTietChuyenKho WHERE IdChuyenKho = @IdChuyenKho AND IdVatTu = @IdVatTu)
		 	BEGIN
		 		UPDATE dbo.ChuyenKho 
				SET TongTien = TongTien - (SELECT ThanhTien FROM dbo.ChiTietChuyenKho WHERE IdVatTu = @IdVatTu AND IdChuyenKho = @IdChuyenKho)
				WHERE Id = @IdChuyenKho;

				UPDATE dbo.ChiTietKho 
				SET SoLuong = SoLuong + (SELECT SoLuong FROM dbo.ChiTietChuyenKho WHERE IdVatTu = @IdVatTu AND IdChuyenKho = @IdChuyenKho)
				WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu;

				UPDATE dbo.ChiTietKho 
				SET SoLuong = SoLuong - (SELECT SoLuong FROM dbo.ChiTietChuyenKho WHERE IdVatTu = @IdVatTu AND IdChuyenKho = @IdChuyenKho)
				WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu;
				
				SELECT @SoLuongTonKhoCu = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu;
				SELECT @SoLuongTonKhoMoi = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu;
				
				IF (NOT EXISTS (SELECT * FROM dbo.ChiTietKho WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu)) OR (@SoLuongTonKhoCu < @SoLuong)
				BEGIN
					RAISERROR(N'Số lượng vật tư còn lại không đủ', 16, 1)
				END
				ELSE
				BEGIN
					UPDATE dbo.ChiTietChuyenKho
					SET 
						SoLuong = @SoLuong,
						ThanhTien = @SoLuong * (SELECT DonGiaNhap FROM dbo.VatTu WHERE Id = @IdVatTu),
						DonGia = (SELECT DonGiaNhap FROM dbo.VatTu WHERE Id = @IdVatTu),
						LyDo = @LyDo,
						UpdatedAt = GETDATE()
					WHERE IdChuyenKho = @IdChuyenKho AND IdVatTu = @IdVatTu;

					IF NOT EXISTS (SELECT * FROM dbo.ChiTietKho WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu)
					BEGIN
						INSERT dbo.ChiTietKho
						        ( IdKho, IdVatTu, SoLuong )
						VALUES  ( @IdKhoMoi, -- IdKho - int
						          @IdVatTu, -- IdVatTu - int
						          @SoLuong  -- SoLuong - int
						          );
					END
					ELSE
					BEGIN
						UPDATE dbo.ChiTietKho
						SET SoLuong = SoLuong + @SoLuong
						WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu;
					END

					UPDATE dbo.ChiTietKho
					SET SoLuong = SoLuong - @SoLuong
					WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu;
				END
		 	END
			ELSE
			BEGIN
				SELECT @SoLuongTonKhoCu = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu;
				SELECT @SoLuongTonKhoMoi = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu;

				IF (NOT EXISTS (SELECT * FROM dbo.ChiTietKho WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu)) OR (@SoLuongTonKhoCu < @SoLuong)
				BEGIN
					RAISERROR(N'Số lượng vật tư còn lại không đủ', 16, 1)
				END
				ELSE
				BEGIN
					INSERT dbo.ChiTietChuyenKho
					        ( IdChuyenKho ,
					          IdVatTu ,
					          SoLuong ,
					          DonGia ,
					          ThanhTien ,
					          LyDo ,
					          CreatedAt ,
					          UpdatedAt
					        )
					SELECT
						@IdChuyenKho,
						@IdVatTu,
						@SoLuong,
						V.DonGiaNhap,
						V.DonGiaNhap * @SoLuong,
						@LyDo,
						GETDATE(),
						GETDATE()
					FROM dbo.VatTu V
					WHERE V.Id = @IdVatTu;

					IF NOT EXISTS (SELECT * FROM dbo.ChiTietKho WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu)
					BEGIN
						INSERT dbo.ChiTietKho
						        ( IdKho, IdVatTu, SoLuong )
						VALUES  ( @IdKhoMoi, -- IdKho - int
						          @IdVatTu, -- IdVatTu - int
						          @SoLuong  -- SoLuong - int
						          );
					END
					ELSE
					BEGIN
						UPDATE dbo.ChiTietKho
						SET SoLuong = SoLuong + @SoLuong
						WHERE IdKho = @IdKhoMoi AND IdVatTu = @IdVatTu;
					END

					UPDATE dbo.ChiTietKho
					SET SoLuong = SoLuong - @SoLuong
					WHERE IdKho = @IdKhoCu AND IdVatTu = @IdVatTu;
				END
			END

			UPDATE dbo.ChuyenKho 
			SET TongTien = TongTien + (SELECT ThanhTien FROM dbo.ChiTietChuyenKho WHERE IdVatTu = @IdVatTu AND IdChuyenKho = @IdChuyenKho)
			WHERE Id = @IdChuyenKho;


			SELECT @TongTien = TongTien FROM dbo.ChuyenKho WHERE Id = @IdChuyenKho;
		 END
		 ELSE
		 BEGIN
		 	RAISERROR(N'Không tồn tại IdChuyenKho', 16, 1)
		 END

GO
/****** Object:  StoredProcedure [dbo].[Usp_AddOrUpdateExportReceiptDetail]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddOrUpdateExportReceiptDetail]
	@IdVatTu INT,
	@IdXuatKho INT,
	@SoLuong INT,
	@GhiChu NVARCHAR(250),
	@TongTien DECIMAL(18, 2) OUT
AS 
	--SET XACT_ABORT ON
	--BEGIN TRAN
	--BEGIN TRY
	--	 IF EXISTS (SELECT * FROM dbo.XuatKho WHERE Id = @IdXuatKho)
	--	 BEGIN
	--	 	DECLARE @IdKho INT, @SoLuongTon INT
	--		SELECT @IdKho = IdKho FROM dbo.XuatKho WHERE Id = @IdXuatKho;

	--		IF EXISTS (SELECT * FROM dbo.ChiTietXuatKho WHERE IdXuatKho = @IdXuatKho AND IdVatTu = @IdVatTu)
	--	 	BEGIN
	--	 		UPDATE dbo.XuatKho 
	--			SET TongTien = TongTien - (SELECT ThanhTien FROM dbo.ChiTietXuatKho WHERE IdVatTu = @IdVatTu AND IdXuatKho = @IdXuatKho)
	--			WHERE Id = @IdXuatKho;

	--			UPDATE dbo.ChiTietKho 
	--			SET SoLuong = SoLuong + (SELECT SoLuong FROM dbo.ChiTietXuatKho WHERE IdVatTu = @IdVatTu AND IdXuatKho = @IdXuatKho)
	--			WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
				
	--			SELECT @SoLuongTon = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
				
	--			IF (@SoLuongTon < @SoLuong)
	--			BEGIN
	--				RAISERROR(N'Số lượng vật tư còn lại không đủ', 16, 1)
	--			END
	--			ELSE
	--			BEGIN
	--				UPDATE dbo.ChiTietXuatKho
	--				SET 
	--					SoLuong = @SoLuong,
	--					ThanhTien = @SoLuong * (SELECT DonGia FROM dbo.VatTu WHERE Id = @IdVatTu),
	--					DonGia = (SELECT DonGia FROM dbo.VatTu WHERE Id = @IdVatTu),
	--					GhiChu = @GhiChu,
	--					UpdatedAt = GETDATE()
	--				WHERE IdXuatKho = @IdXuatKho AND IdVatTu = @IdVatTu
	--			END
	--	 	END
	--		ELSE
	--		BEGIN
	--			SELECT @SoLuongTon = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
				
	--			IF (@SoLuongTon < @SoLuong)
	--			BEGIN
	--				RAISERROR(N'Số lượng vật tư còn lại không đủ', 16, 1)
	--			END
	--			ELSE
	--			BEGIN
	--				INSERT INTO dbo.ChiTietXuatKho
	--			        ( IdXuatKho ,
	--			          IdVatTu ,
	--			          SoLuong ,
	--			          DonGia ,
	--			          ThanhTien ,
	--			          GhiChu ,
	--			          CreatedAt ,
	--			          UpdatedAt
	--			        )
	--				SELECT
	--					@IdXuatKho,
	--					@IdVatTu,
	--					@SoLuong,
	--					V.DonGia,
	--					V.DonGia * @SoLuong,
	--					@GhiChu,
	--					GETDATE(),
	--					GETDATE()
	--				FROM dbo.VatTu V
	--				WHERE V.Id = @IdVatTu;
	--			END
	--		END

	--		UPDATE dbo.XuatKho 
	--		SET TongTien = TongTien + (SELECT ThanhTien FROM dbo.ChiTietXuatKho WHERE IdVatTu = @IdVatTu AND IdXuatKho = @IdXuatKho)
	--		WHERE Id = @IdXuatKho;

	--		UPDATE dbo.ChiTietKho
	--		SET SoLuong = SoLuong - @SoLuong
	--		WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;

	--		SELECT @TongTien = TongTien FROM dbo.XuatKho WHERE Id = @IdXuatKho
	--	 END
	--	 ELSE
	--	 BEGIN
	--	 	RAISERROR(N'Không tồn tại IdXuatKho', 16, 1)
	--	 END
	--COMMIT
	--END TRY
	--BEGIN CATCH
	--   ROLLBACK
	--   DECLARE @ErrorMessage VARCHAR(2000)
	--   SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
	--   RAISERROR(@ErrorMessage, 16, 1)
	--END CATCH
	IF EXISTS (SELECT * FROM dbo.XuatKho WHERE Id = @IdXuatKho)
		 BEGIN
		 	DECLARE @IdKho INT, @SoLuongTon INT
			SELECT @IdKho = IdKho FROM dbo.XuatKho WHERE Id = @IdXuatKho;

			IF EXISTS (SELECT * FROM dbo.ChiTietXuatKho WHERE IdXuatKho = @IdXuatKho AND IdVatTu = @IdVatTu)
		 	BEGIN
		 		UPDATE dbo.XuatKho 
				SET TongTien = TongTien - (SELECT ThanhTien FROM dbo.ChiTietXuatKho WHERE IdVatTu = @IdVatTu AND IdXuatKho = @IdXuatKho)
				WHERE Id = @IdXuatKho;

				UPDATE dbo.ChiTietKho 
				SET SoLuong = SoLuong + (SELECT SoLuong FROM dbo.ChiTietXuatKho WHERE IdVatTu = @IdVatTu AND IdXuatKho = @IdXuatKho)
				WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
				
				SELECT @SoLuongTon = SoLuong FROM dbo.ChiTietKho WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
				
				IF (NOT EXISTS (SELECT * FROM dbo.ChiTietKho WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu)) OR  (@SoLuongTon < @SoLuong)
				BEGIN
					RAISERROR(N'Số lượng vật tư còn lại không đủ', 16, 1)
				END
				ELSE
				BEGIN
					UPDATE dbo.ChiTietXuatKho
					SET 
						SoLuong = @SoLuong,
						ThanhTien = @SoLuong * (SELECT DonGia FROM dbo.VatTu WHERE Id = @IdVatTu),
						DonGia = (SELECT DonGia FROM dbo.VatTu WHERE Id = @IdVatTu),
						GhiChu = @GhiChu,
						UpdatedAt = GETDATE()
					WHERE IdXuatKho = @IdXuatKho AND IdVatTu = @IdVatTu;

					UPDATE dbo.ChiTietKho
					SET SoLuong = SoLuong - @SoLuong
					WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
				END
		 	END
			ELSE
			BEGIN
				SELECT @SoLuongTon = IIF(SoLuong IS NULL, 0, SoLuong) FROM dbo.ChiTietKho WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
				
				IF (NOT EXISTS (SELECT * FROM dbo.ChiTietKho WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu)) OR  (@SoLuongTon < @SoLuong)
				BEGIN
					RAISERROR(N'Số lượng vật tư còn lại không đủ', 16, 1)
				END
				ELSE
				BEGIN
					INSERT INTO dbo.ChiTietXuatKho
				        ( IdXuatKho ,
				          IdVatTu ,
				          SoLuong ,
				          DonGia ,
				          ThanhTien ,
				          GhiChu ,
				          CreatedAt ,
				          UpdatedAt
				        )
					SELECT
						@IdXuatKho,
						@IdVatTu,
						@SoLuong,
						V.DonGia,
						V.DonGia * @SoLuong,
						@GhiChu,
						GETDATE(),
						GETDATE()
					FROM dbo.VatTu V
					WHERE V.Id = @IdVatTu;

					UPDATE dbo.ChiTietKho
					SET SoLuong = SoLuong - @SoLuong
					WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
				END
			END

			UPDATE dbo.XuatKho 
			SET TongTien = TongTien + (SELECT ThanhTien FROM dbo.ChiTietXuatKho WHERE IdVatTu = @IdVatTu AND IdXuatKho = @IdXuatKho)
			WHERE Id = @IdXuatKho;

			SELECT @TongTien = TongTien FROM dbo.XuatKho WHERE Id = @IdXuatKho
		 END
		 ELSE
		 BEGIN
		 	RAISERROR(N'Không tồn tại IdXuatKho', 16, 1)
		 END

GO
/****** Object:  StoredProcedure [dbo].[Usp_AddOrUpdateImportReceiptDetail]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_AddOrUpdateImportReceiptDetail]
	@IdVatTu INT,
	@IdNhapKho INT,
	@SoLuong INT,
	@GhiChu NVARCHAR(250),
	@TongTien DECIMAL(18, 2) OUT
AS 
	--SET XACT_ABORT ON
	--BEGIN TRAN
	--BEGIN TRY
	--	 IF EXISTS (SELECT * FROM dbo.NhapKho WHERE Id = @IdNhapKho)
	--	 BEGIN
	--	 	DECLARE @IdKho INT
	--		SELECT @IdKho = IdKho FROM dbo.NhapKho WHERE Id = @IdNhapKho;

	--		IF EXISTS (SELECT * FROM dbo.ChiTietNhapKho WHERE IdNhapKho = @IdNhapKho AND IdVatTu = @IdVatTu)
	--	 	BEGIN
	--	 		UPDATE dbo.NhapKho 
	--			SET TongTien = TongTien - (SELECT ThanhTien FROM dbo.ChiTietNhapKho WHERE IdVatTu = @IdVatTu AND IdNhapKho = @IdNhapKho)
	--			WHERE Id = @IdNhapKho;

	--			UPDATE dbo.ChiTietKho 
	--			SET SoLuong = SoLuong - (SELECT SoLuong FROM dbo.ChiTietNhapKho WHERE IdVatTu = @IdVatTu AND IdNhapKho = @IdNhapKho)
	--			WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;

	--			UPDATE dbo.ChiTietNhapKho
	--			SET 
	--				SoLuong = @SoLuong,
	--				ThanhTien = @SoLuong * (SELECT DonGiaNhap FROM dbo.VatTu WHERE Id = @IdVatTu),
	--				DonGia = (SELECT DonGiaNhap FROM dbo.VatTu WHERE Id = @IdVatTu),
	--				GhiChu = @GhiChu,
	--				UpdatedAt = GETDATE()
	--			WHERE IdNhapKho = @IdNhapKho AND IdVatTu = @IdVatTu

	--			UPDATE dbo.ChiTietKho
	--			SET SoLuong = IIF(SoLuong > 0, SoLuong, 0) + @SoLuong
	--			WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
	--	 	END
	--		ELSE
	--		BEGIN
	--			INSERT INTO dbo.ChiTietNhapKho
	--	 	        ( IdNhapKho ,
	--	 	          IdVatTu ,
	--	 	          SoLuong ,
	--	 	          DonGia ,
	--	 	          ThanhTien ,
	--	 	          GhiChu ,
	--	 	          CreatedAt ,
	--	 	          UpdatedAt
	--	 	        )
	--	 		SELECT
	--				@IdNhapKho,
	--				@IdVatTu,
	--				@SoLuong,
	--				V.DonGiaNhap,
	--				V.DonGiaNhap * @SoLuong,
	--				@GhiChu,
	--				GETDATE(),
	--				GETDATE()
	--			FROM dbo.VatTu V
	--			WHERE V.Id = @IdVatTu;

	--			IF NOT EXISTS (SELECT * FROM dbo.ChiTietKho WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu)
	--			BEGIN
	--				INSERT dbo.ChiTietKho
	--			        ( IdKho, IdVatTu, SoLuong )
	--				VALUES  ( @IdKho, -- IdKho - int
	--			          @IdVatTu, -- IdVatTu - int
	--			          @SoLuong  -- SoLuong - int
	--			          )
	--			END
	--			ELSE
	--			BEGIN
	--				UPDATE dbo.ChiTietKho
	--				SET SoLuong = SoLuong + @SoLuong
	--				WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
	--			END
	--		END

	--		UPDATE dbo.NhapKho 
	--		SET TongTien = TongTien + (SELECT ThanhTien FROM dbo.ChiTietNhapKho WHERE IdVatTu = @IdVatTu AND IdNhapKho = @IdNhapKho)
	--		WHERE Id = @IdNhapKho;


	--		SELECT @TongTien = TongTien FROM dbo.NhapKho WHERE Id = @IdNhapKho
	--	 END
	--	 ELSE
	--	 BEGIN
	--	 	RAISERROR(N'Không tồn tại IdNhapKho', 16, 1)
	--	 END
	--COMMIT
	--END TRY
	--BEGIN CATCH
	--   ROLLBACK
	--   DECLARE @ErrorMessage VARCHAR(2000)
	--   SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
	--   RAISERROR(@ErrorMessage, 16, 1)
	--END CATCH
	
	IF EXISTS (SELECT * FROM dbo.NhapKho WHERE Id = @IdNhapKho)
		 BEGIN
		 	DECLARE @IdKho INT
			SELECT @IdKho = IdKho FROM dbo.NhapKho WHERE Id = @IdNhapKho;

			IF EXISTS (SELECT * FROM dbo.ChiTietNhapKho WHERE IdNhapKho = @IdNhapKho AND IdVatTu = @IdVatTu)
		 	BEGIN
		 		UPDATE dbo.NhapKho 
				SET TongTien = TongTien - (SELECT ThanhTien FROM dbo.ChiTietNhapKho WHERE IdVatTu = @IdVatTu AND IdNhapKho = @IdNhapKho)
				WHERE Id = @IdNhapKho;

				UPDATE dbo.ChiTietKho 
				SET SoLuong = SoLuong - (SELECT SoLuong FROM dbo.ChiTietNhapKho WHERE IdVatTu = @IdVatTu AND IdNhapKho = @IdNhapKho)
				WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;

				UPDATE dbo.ChiTietNhapKho
				SET 
					SoLuong = @SoLuong,
					ThanhTien = @SoLuong * (SELECT DonGiaNhap FROM dbo.VatTu WHERE Id = @IdVatTu),
					DonGia = (SELECT DonGiaNhap FROM dbo.VatTu WHERE Id = @IdVatTu),
					GhiChu = @GhiChu,
					UpdatedAt = GETDATE()
				WHERE IdNhapKho = @IdNhapKho AND IdVatTu = @IdVatTu

				UPDATE dbo.ChiTietKho
				SET SoLuong = IIF(SoLuong > 0, SoLuong, 0) + @SoLuong
				WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
		 	END
			ELSE
			BEGIN
				INSERT INTO dbo.ChiTietNhapKho
		 	        ( IdNhapKho ,
		 	          IdVatTu ,
		 	          SoLuong ,
		 	          DonGia ,
		 	          ThanhTien ,
		 	          GhiChu ,
		 	          CreatedAt ,
		 	          UpdatedAt
		 	        )
		 		SELECT
					@IdNhapKho,
					@IdVatTu,
					@SoLuong,
					V.DonGiaNhap,
					V.DonGiaNhap * @SoLuong,
					@GhiChu,
					GETDATE(),
					GETDATE()
				FROM dbo.VatTu V
				WHERE V.Id = @IdVatTu;

				IF NOT EXISTS (SELECT * FROM dbo.ChiTietKho WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu)
				BEGIN
					INSERT dbo.ChiTietKho
				        ( IdKho, IdVatTu, SoLuong )
					VALUES  ( @IdKho, -- IdKho - int
				          @IdVatTu, -- IdVatTu - int
				          @SoLuong  -- SoLuong - int
				          )
				END
				ELSE
				BEGIN
					UPDATE dbo.ChiTietKho
					SET SoLuong = SoLuong + @SoLuong
					WHERE IdKho = @IdKho AND IdVatTu = @IdVatTu;
				END
			END

			UPDATE dbo.NhapKho 
			SET TongTien = TongTien + (SELECT ThanhTien FROM dbo.ChiTietNhapKho WHERE IdVatTu = @IdVatTu AND IdNhapKho = @IdNhapKho)
			WHERE Id = @IdNhapKho;


			SELECT @TongTien = TongTien FROM dbo.NhapKho WHERE Id = @IdNhapKho
		 END
		 ELSE
		 BEGIN
		 	RAISERROR(N'Không tồn tại IdNhapKho', 16, 1)
		 END

GO
/****** Object:  StoredProcedure [dbo].[Usp_CreateAccount]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_CreateAccount]
@Username NVARCHAR(50),
@EmployeeId INT,
@RoleId INT,
@Password NVARCHAR(250),
@Id INT OUTPUT
AS
	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.Users WHERE Username = @Username
	IF (@count <> 0)
		BEGIN
			SET @Id = 0
		END
	ELSE
		BEGIN TRANSACTION
			INSERT dbo.Users
			        ( Username ,
			          Password ,
			          CreatedAt ,
			          UpdatedAt ,
			          IdRole
			        )
			VALUES  ( @Username , -- Username - nvarchar(50)
			          @Password , -- Password - nvarchar(250)
			          GETDATE() , -- CreatedAt - datetime
			          GETDATE() , -- UpdatedAt - datetime
			          @RoleId  -- IdRole - int
			        )
			SET @Id = @@IDENTITY
			
			IF EXISTS (SELECT * FROM dbo.NhanVien WHERE Id = @EmployeeId)
			BEGIN
			     UPDATE dbo.NhanVien
				 SET UserId = @Id
				 WHERE Id = @EmployeeId
				 COMMIT TRANSACTION                                                 	
			END
			ELSE
			BEGIN
				SET @Id = 0
				ROLLBACK TRANSACTION
			END

GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteEmployee]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Usp_DeleteEmployee]
	@EmployeeId INT
AS 
	BEGIN TRANSACTION
		DECLARE @UserId INT;
		SELECT @UserId = UserId FROM dbo.NhanVien WHERE Id = @EmployeeId;
		DELETE dbo.NhanVien
		WHERE Id = @EmployeeId;
		DELETE dbo.Users
		WHERE Id = @UserId
	COMMIT TRANSACTION

GO
/****** Object:  StoredProcedure [dbo].[Usp_GetListEmployeePaging]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROC [dbo].[Usp_GetListEmployeePaging] 
@pageSize INT, @pageNumber INT, @pageAmount INT OUTPUT
AS
	SELECT [Id]
      ,[Ma]
      ,[Ten]
      ,[GioiTinh]
      ,[NgaySinh]
      ,[DiaChi]
      ,[CMND]
      ,[SDT]
      ,[Email]
      ,[NgayVaoLam]
	 FROM dbo.NhanVien
	 ORDER BY Id DESC
	 OFFSET (@pageNumber - 1) * @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY

	 SELECT @pageAmount = (COUNT(*) / @pageSize) + 1
	 FROM dbo.NhanVien
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetListProductPaging]    Script Date: 4/14/2020 10:10:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROC [dbo].[Usp_GetListProductPaging] 
@pageSize INT, @pageNumber INT, @pageAmount INT OUTPUT
AS
	SELECT 
	V.Id,
	V.Ma,
	V.Ten,
	V.DonGia,
	V.DonGiaNhap,
	V.IdNhomVatTu,
	N.Ten AS TenNhomVatTu,
	V.IdNhaCungCap,
	C.Ten AS TenNhaCungCap,
	C.DiaChi,
	C.SDT,
	IIF(T.SoLuong IS NULL, 0, T.SoLuong) AS SoLuong
FROM dbo.VatTu V
LEFT JOIN dbo.NhomVatTu N ON N.Id = V.IdNhomVatTu
LEFT JOIN dbo.NhaCungCap C ON C.Id = V.IdNhaCungCap
LEFT JOIN (
	SELECT CT.IdVatTu, SUM(CT.SoLuong) AS SoLuong
	FROM ChiTietKho CT
	GROUP BY CT.IdVatTu
) AS T ON T.IdVatTu = V.Id
	WHERE V.IsActive = 1

	 ORDER BY Id DESC
	 OFFSET (@pageNumber - 1) * @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY

	 SELECT @pageAmount = (COUNT(*) / @pageSize) + 1
	 FROM dbo.VatTu
GO
