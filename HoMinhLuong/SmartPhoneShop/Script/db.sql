USE [HoMinhLuong]
GO
/****** Object:  Table [dbo].[Categorys]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[ParentId] [int] NULL,
	[Orders] [int] NOT NULL,
	[MetaKey] [nvarchar](max) NOT NULL,
	[MetaDesc] [nvarchar](max) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Categorys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[ReplayDetail] [nvarchar](max) NULL,
	[ReplayID] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Links]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Links](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[TypeLink] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Links] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[TableId] [int] NULL,
	[Orders] [int] NULL,
	[Position] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Menus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [real] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Amount] [real] NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ExportDate] [datetime] NULL,
	[DeliveryAddress] [nvarchar](max) NULL,
	[DeliveryName] [nvarchar](max) NULL,
	[DeliveryPhone] [nvarchar](max) NULL,
	[DeliveryEmail] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopId] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NOT NULL,
	[MetaKey] [nvarchar](max) NOT NULL,
	[MetaDesc] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Img] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Number] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[PriceSale] [decimal](18, 0) NOT NULL,
	[MetaKey] [nvarchar](max) NOT NULL,
	[MetaDesc] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Silders]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Silders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[Position] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](max) NOT NULL,
	[Orders] [int] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Silders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[ParentId] [int] NULL,
	[MetaKey] [nvarchar](max) NOT NULL,
	[MetaDesc] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/16/2021 8:11:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[PassWord] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Role] [int] NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorys] ON 

INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (5, N'IPHONE', N'ip', 0, 1, N'dsds', N'sds', NULL, NULL, 1, CAST(N'2021-05-05T21:03:28.463' AS DateTime), 1)
INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (7, N'SAMSUNG', N'ss', 0, 2, N'hfh', N'gfg', NULL, NULL, 1, CAST(N'2021-05-03T15:15:09.233' AS DateTime), 1)
INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (8, N'OPPO', N'op', 0, 3, N'hfh', N'gfg', NULL, NULL, 1, CAST(N'2021-05-03T15:15:11.217' AS DateTime), 1)
INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (17, N'XIAOMI', N'mi', 0, 4, N'cácgvdsvdsvdsv', N'dsvdsvdsvsdvs', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (18, N'ssxsx', NULL, 5, 5, N'cscs', N'scscs', 1, CAST(N'2021-05-03T14:51:05.483' AS DateTime), 1, CAST(N'2021-05-03T15:11:37.900' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Categorys] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Detail], [ReplayDetail], [ReplayID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (4, N'Hồ Minh Lượng', N'hml@gmail.com', N'0338085817', N'luong', N'mua ip12', NULL, NULL, NULL, CAST(N'2021-05-05T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-05T23:36:03.610' AS DateTime), 1)
INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Detail], [ReplayDetail], [ReplayID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (5, N'Lượng', N'luong@gmail.com', N'0338085818', N'luong', N'chủ shop đẹp trai quá', NULL, NULL, NULL, CAST(N'2021-05-05T00:00:00.000' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Detail], [ReplayDetail], [ReplayID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (6, N'', N'hominhluong2018@gmail.com', N'0987654321', N'Liên Hệ', N'aa', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Detail], [ReplayDetail], [ReplayID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (7, N'nan', N'hominhluong2018@gmail.com', N'0987654321', N'Liên Hệ', N'sdss', NULL, NULL, NULL, CAST(N'2021-05-16T20:04:19.330' AS DateTime), NULL, CAST(N'2021-05-16T20:04:19.330' AS DateTime), NULL)
INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Detail], [ReplayDetail], [ReplayID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (8, N'test', N'hominhluong2018@gmail.com', N'0987654321', N'Liên Hệ', N'sss', NULL, NULL, NULL, CAST(N'2021-05-16T20:06:35.423' AS DateTime), NULL, CAST(N'2021-05-16T20:06:35.423' AS DateTime), NULL)
INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Detail], [ReplayDetail], [ReplayID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (9, N'nan', N'hominhluong2018@gmail.com', N'0987654321', N'Liên Hệ', N'sdss', NULL, NULL, NULL, CAST(N'2021-05-16T20:07:32.407' AS DateTime), NULL, CAST(N'2021-05-16T20:07:32.407' AS DateTime), NULL)
INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Detail], [ReplayDetail], [ReplayID], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (10, N'Lượng Lém Lĩnh', N'khachhang2@gmail.com', N'0123456789', N'Liên Hệ', N'noi', NULL, NULL, NULL, CAST(N'2021-05-16T20:07:44.390' AS DateTime), NULL, CAST(N'2021-05-16T20:07:44.390' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Links] ON 

INSERT [dbo].[Links] ([Id], [TableId], [Slug], [TypeLink]) VALUES (1, 5, N'ip', N'category')
INSERT [dbo].[Links] ([Id], [TableId], [Slug], [TypeLink]) VALUES (2, 7, N'ss', N'category')
INSERT [dbo].[Links] ([Id], [TableId], [Slug], [TypeLink]) VALUES (3, 8, N'op', N'category')
INSERT [dbo].[Links] ([Id], [TableId], [Slug], [TypeLink]) VALUES (4, 17, N'mi', N'category')
SET IDENTITY_INSERT [dbo].[Links] OFF
GO
SET IDENTITY_INSERT [dbo].[Menus] ON 

INSERT [dbo].[Menus] ([Id], [ParentId], [Name], [Link], [Type], [TableId], [Orders], [Position], [Status], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, 0, N'TRANG CHỦ', N'/', N'custom', NULL, 1, N'mainmenu', 1, NULL, NULL, 1, CAST(N'2021-05-03T21:01:50.957' AS DateTime))
INSERT [dbo].[Menus] ([Id], [ParentId], [Name], [Link], [Type], [TableId], [Orders], [Position], [Status], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (8, 0, N'SẢN PHẨM', N'/san-pham', N'sanpham', NULL, 2, N'mainmenu', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Menus] ([Id], [ParentId], [Name], [Link], [Type], [TableId], [Orders], [Position], [Status], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (18, 0, N'TIN TỨC', N'/bai-viet', N'tintuc', NULL, 4, N'mainmenu', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Menus] ([Id], [ParentId], [Name], [Link], [Type], [TableId], [Orders], [Position], [Status], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (19, 0, N'LIÊN HỆ', N'/lien-he', N'lienhe', NULL, 5, N'mainmenu', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Menus] ([Id], [ParentId], [Name], [Link], [Type], [TableId], [Orders], [Position], [Status], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (20, 0, N'GIỚI THIỆU', N'/gioi-thieu', N'gioithieu', NULL, 3, N'mainmenu', 1, NULL, NULL, 1, CAST(N'2021-05-03T21:01:52.140' AS DateTime))
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [Code], [UserId], [CreateDate], [ExportDate], [DeliveryAddress], [DeliveryName], [DeliveryPhone], [DeliveryEmail], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (2, N'21', 4, CAST(N'2021-05-05T00:00:00.000' AS DateTime), NULL, N'18/5', N'Iphone 12', N'0312312322', NULL, NULL, CAST(N'2021-05-05T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-05T23:42:02.380' AS DateTime), 1)
INSERT [dbo].[Orders] ([Id], [Code], [UserId], [CreateDate], [ExportDate], [DeliveryAddress], [DeliveryName], [DeliveryPhone], [DeliveryEmail], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (3, N'22', 5, CAST(N'2021-05-05T00:00:00.000' AS DateTime), NULL, N'23/5', N'Samsung s21', N'0123123126', NULL, NULL, CAST(N'2021-05-05T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-05T20:55:22.153' AS DateTime), 1)
INSERT [dbo].[Orders] ([Id], [Code], [UserId], [CreateDate], [ExportDate], [DeliveryAddress], [DeliveryName], [DeliveryPhone], [DeliveryEmail], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (4, N'23', 3, CAST(N'2021-05-05T00:00:00.000' AS DateTime), NULL, N'23/5', N'Iphone 8 Plus', N'0333333333', NULL, NULL, CAST(N'2021-05-05T00:00:00.000' AS DateTime), 1, CAST(N'2021-05-05T20:55:22.153' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [TopId], [Title], [Slug], [Detail], [Img], [Type], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (6, 1, N'Thông tin', N'thong-tin', N' thông tin <b>haha</b>', NULL, N'gt', N'1', N'1', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Posts] ([Id], [TopId], [Title], [Slug], [Detail], [Img], [Type], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (7, 6, N'Thông tin 1', N'thong-tin1', N'húadasdasdas', NULL, N'gt', N'1', N'1', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Posts] ([Id], [TopId], [Title], [Slug], [Detail], [Img], [Type], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (8, 6, N'Thông tin 2', N'thong-tin2', N'húadasdasdas', NULL, N'gt', N'1', N'1', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Posts] ([Id], [TopId], [Title], [Slug], [Detail], [Img], [Type], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (9, 6, N'Thông tin 3', N'thong-tin3', N'húadasdasdas', NULL, N'gt', N'1', N'1', NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (8, 5, N'IPHONE 8 PLUS', N'ip-7p', N'8plus.jpg', N'ip', 1, CAST(20000000 AS Decimal(18, 0)), CAST(6000000 AS Decimal(18, 0)), N'12', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), 1, CAST(N'2021-05-03T14:51:35.783' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (9, 5, N'IPHONE X', N'ip-x', N'x.jpg', N'ip', 1, CAST(8000000 AS Decimal(18, 0)), CAST(7000000 AS Decimal(18, 0)), N'12', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (10, 5, N'IPHONE XS', N'ip-xs', N'xs.jpg', N'ip', 1, CAST(9000000 AS Decimal(18, 0)), CAST(8000000 AS Decimal(18, 0)), N'12', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (11, 5, N'IPHONE XR', N'ip-xr', N'xr.jpg', N'ip', 1, CAST(9500000 AS Decimal(18, 0)), CAST(9000000 AS Decimal(18, 0)), N'12', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (12, 5, N'IPHONE 11', N'ip-11', N'11.jpg', N'ip', 1, CAST(9800000 AS Decimal(18, 0)), CAST(9500000 AS Decimal(18, 0)), N'12', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (14, 5, N'IPHONE 12', N'ip-12', N'12.jpg', N'Đây là điện thoại hot nhất 2021  Với kiểu dáng thời thượng', 1, CAST(9500000 AS Decimal(18, 0)), CAST(9000000 AS Decimal(18, 0)), N'12', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (16, 7, N'SAMSUNG NOTE 20', N'ss-n20', N'n20.jpg', N'ss', 1, CAST(3000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (17, 7, N'SAMSUNG S8 PLUS', N'ss-s8p', N's8plus.jpg', N'ss', 1, CAST(4000000 AS Decimal(18, 0)), CAST(3000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (18, 7, N'SAMSUNG S9 PLUS', N'ss-s8p', N's9plus.jpg', N'ss', 1, CAST(5000000 AS Decimal(18, 0)), CAST(4000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (19, 7, N'SAMSUNG S10 PLUS', N'ss-s10p', N's10plus.jpg', N'ss', 1, CAST(6000000 AS Decimal(18, 0)), CAST(5000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (20, 7, N'SAMSUNG S20', N'ss-s20', N's20.jpg', N'ss', 1, CAST(7000000 AS Decimal(18, 0)), CAST(6000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (21, 7, N'SAMSUNG S21', N'ss-s21', N's21.jpg', N'ss', 1, CAST(9000000 AS Decimal(18, 0)), CAST(8000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (22, 8, N'OPPO A93', N'op-a93', N'a93.jpg', N'op', 1, CAST(3000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (23, 8, N'OPPO A92', N'op-a92', N'a92.jpg', N'op', 1, CAST(2000000 AS Decimal(18, 0)), CAST(1000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (24, 8, N'OPPO A94', N'op-a94', N'a94.jpg', N'op', 1, CAST(4000000 AS Decimal(18, 0)), CAST(3000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (25, 8, N'OPPO RENO 4', N'op-rn4', N'rn4.jpg', N'op', 1, CAST(5000000 AS Decimal(18, 0)), CAST(4000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (26, 8, N'OPPO RENO 5', N'op-rn5', N'rn5.jpg', N'op', 1, CAST(6000000 AS Decimal(18, 0)), CAST(5000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (27, 8, N'OPPO A15', N'op-a15', N'a15.jpg', N'op', 1, CAST(3000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1014, 17, N'MI 11 LITE', N'mi11-lite', N'mi11lite.jpg', N'mi', 1, CAST(9000000 AS Decimal(18, 0)), CAST(8000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1015, 17, N'MI 11', N'mi11', N'mi11.jpg', N'mi', 1, CAST(9000000 AS Decimal(18, 0)), CAST(8000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1016, 17, N'MI 10T', N'mi10t', N'mi10t.jpg', N'mi', 1, CAST(8000000 AS Decimal(18, 0)), CAST(7500000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1017, 17, N'MI 9', N'mi9', N'mi9.jpg', N'mi', 1, CAST(7500000 AS Decimal(18, 0)), CAST(7000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1018, 17, N'MI 9T', N'm9t', N'mi9t.jpg', N'mi', 1, CAST(7000000 AS Decimal(18, 0)), CAST(6000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1019, 17, N'MI NOTE 10', N'minote10', N'minote10.jpg', N'mi', 1, CAST(8200000 AS Decimal(18, 0)), CAST(7900000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1020, 17, N'MI X3', N'mĩ3', N'pocox3.jpg', N'mi', 1, CAST(6000000 AS Decimal(18, 0)), CAST(5500000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1021, 5, N'IPHONE 6 PLUS', N'ip-6p', N'ip6p.jpg', N'ip', 1, CAST(3000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), N'12', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), 1, CAST(N'2021-05-03T14:51:35.783' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1022, 5, N'IPHONE 6', N'ip-6', N'ip6.jpg', N'ip', 1, CAST(2500000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), N'12', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), 1, CAST(N'2021-05-03T14:51:35.783' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1023, 7, N'SAMSUNG S7', N'ss-s7', N's7.jpg', N'ss', 1, CAST(3000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1024, 7, N'SAMSUNG S6', N'ss-s6', N's6.jpg', N'ss', 1, CAST(3000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1025, 8, N'OPPO A12', N'op-a12', N'opa12.jpg', N'op', 1, CAST(3000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1026, 8, N'OPPO A15', N'op-a15', N'opa15.jpg', N'op', 1, CAST(3000000 AS Decimal(18, 0)), CAST(2200000 AS Decimal(18, 0)), N'sds', NULL, NULL, CAST(N'2021-05-03T15:08:50.783' AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Silders] ON 

INSERT [dbo].[Silders] ([Id], [Name], [Link], [Position], [Img], [Orders], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1, N'slider1', N'#', N'slideshow', N'slider1.png', 1, 1, NULL, 1, CAST(N'2021-05-03T22:19:58.613' AS DateTime), 1)
INSERT [dbo].[Silders] ([Id], [Name], [Link], [Position], [Img], [Orders], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (2, N'slider2', N'#', N'slideshow', N'slider2.png', 1, 1, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Silders] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FullName], [UserName], [PassWord], [Email], [Role], [Phone], [Img], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (1, N'Minh Lượng', N'Admin', N'4QrcOUm6Wau+VuBX8g+IPg==', N'hominhluong2018@gmail.com', 1, N'0338085817', NULL, 1, CAST(N'2021-05-16T15:31:41.867' AS DateTime), 1, CAST(N'2021-05-16T15:31:41.867' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FullName], [UserName], [PassWord], [Email], [Role], [Phone], [Img], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (2, N'Hồ Minh Lượng', N'luongdeptrai', N'4QrcOUm6Wau+VuBX8g+IPg==', N'hominhluong2000', 2, N'03333333', NULL, 1, CAST(N'2021-05-03T21:45:51.000' AS DateTime), 1, CAST(N'2021-05-03T21:54:16.207' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FullName], [UserName], [PassWord], [Email], [Role], [Phone], [Img], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (3, N'Hồ Diên Lợi', N'khachhang', N'4QrcOUm6Wau+VuBX8g+IPg==', N'khachhang@gmail.com', 2, N'0987654321', NULL, 1, CAST(N'2021-05-04T09:32:46.193' AS DateTime), 1, CAST(N'2021-05-04T09:32:46.193' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FullName], [UserName], [PassWord], [Email], [Role], [Phone], [Img], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (4, N'Lượng Lém Lĩnh', N'khachhang1', N'4QrcOUm6Wau+VuBX8g+IPg==', N'khachhang1@gmail.com', 2, N'0334455667', NULL, 1, CAST(N'2021-05-05T23:45:17.743' AS DateTime), 1, CAST(N'2021-05-05T23:45:17.743' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FullName], [UserName], [PassWord], [Email], [Role], [Phone], [Img], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (5, N'Lượng Đẹp Trai', N'khachhang2', N'4QrcOUm6Wau+VuBX8g+IPg==', N'khachhang2@gmail.com', 2, N'034567890', NULL, 1, CAST(N'2021-05-05T23:46:03.557' AS DateTime), 1, CAST(N'2021-05-05T23:46:03.557' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FullName], [UserName], [PassWord], [Email], [Role], [Phone], [Img], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Status]) VALUES (6, N'Lượng Đại Gia', N'khachhang3', N'4QrcOUm6Wau+VuBX8g+IPg==', N'khachhang3@gmail.com', 2, N'0123456789', NULL, 1, CAST(N'2021-05-05T23:47:25.140' AS DateTime), 1, CAST(N'2021-05-05T23:47:25.140' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
