USE [master]
GO
/****** Object:  Database [Mani]    Script Date: 2024/8/9 上午 11:07:29 ******/
CREATE DATABASE [Mani]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mani', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Mani.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mani_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Mani_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Mani] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mani].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mani] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mani] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mani] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mani] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mani] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mani] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mani] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mani] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mani] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mani] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mani] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mani] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mani] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mani] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mani] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mani] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mani] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mani] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mani] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mani] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mani] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mani] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mani] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mani] SET  MULTI_USER 
GO
ALTER DATABASE [Mani] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mani] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mani] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mani] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mani] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Mani] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Mani] SET QUERY_STORE = ON
GO
ALTER DATABASE [Mani] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Mani]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 2024/8/9 上午 11:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[BlogID] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [nvarchar](30) NOT NULL,
	[BlogContent] [nvarchar](max) NOT NULL,
	[BlogImg] [nvarchar](max) NULL,
	[BlogImgg] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[BlogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 2024/8/9 上午 11:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms](
	[FormID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[CheckIn] [nvarchar](50) NOT NULL,
	[CheckOut] [nvarchar](50) NOT NULL,
	[OwnerName] [nvarchar](30) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[CatsName] [nvarchar](max) NOT NULL,
	[CatsNum] [int] NOT NULL,
	[RoomName] [nvarchar](20) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Forms] PRIMARY KEY CLUSTERED 
(
	[FormID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 2024/8/9 上午 11:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Managers](
	[ManagerID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[PassWord] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[ManagerImg] [nvarchar](max) NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[level] [int] NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[ManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 2024/8/9 上午 11:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[PassWord] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2024/8/9 上午 11:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[OrderProduct] [nvarchar](max) NOT NULL,
	[Price] [decimal](10, 0) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2024/8/9 上午 11:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductImg] [nvarchar](max) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductPrice] [nvarchar](20) NOT NULL,
	[UnitInStock] [int] NOT NULL,
	[ProductDesc] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 2024/8/9 上午 11:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](20) NOT NULL,
	[RoomSize] [nvarchar](max) NOT NULL,
	[CatsLimit] [nvarchar](20) NOT NULL,
	[SunTime] [nvarchar](20) NOT NULL,
	[OverTime] [nvarchar](20) NOT NULL,
	[AddCats] [nvarchar](20) NOT NULL,
	[Price] [nvarchar](20) NOT NULL,
	[RoomImg] [nvarchar](max) NULL,
	[RoomImgg] [nvarchar](max) NULL,
	[RoomImggg] [nvarchar](max) NULL,
	[RoomDesc] [nvarchar](max) NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([BlogID], [BlogTitle], [BlogContent], [BlogImg], [BlogImgg], [CreatedDate]) VALUES (1, N'午後的喵喵', N'每次喵喵來的時候，
都會在中午後，
來到向日葵花瓶前，
愜意的享受午後陽光。', N'1.jpg', NULL, CAST(N'2024-07-16T05:26:21.823' AS DateTime))
INSERT [dbo].[Blogs] ([BlogID], [BlogTitle], [BlogContent], [BlogImg], [BlogImgg], [CreatedDate]) VALUES (2, N'相親相愛的貓兄妹', N'大橘是照顧妹妹的大哥哥，
小白和阿灰總會黏在哥哥身邊，
時常互相舔毛玩耍，
或像這樣倒在一起進入夢鄉。', N'2.jpg', NULL, CAST(N'2024-07-16T05:27:09.260' AS DateTime))
INSERT [dbo].[Blogs] ([BlogID], [BlogTitle], [BlogContent], [BlogImg], [BlogImgg], [CreatedDate]) VALUES (3, N'搗蛋鬼姊妹', N'小貍和小花是一對活潑的姊妹，
每次來住宿總是各種跑跳，
像這樣安靜的畫面太難得了。', N'3.jpg', NULL, CAST(N'2024-07-16T05:27:23.343' AS DateTime))
INSERT [dbo].[Blogs] ([BlogID], [BlogTitle], [BlogContent], [BlogImg], [BlogImgg], [CreatedDate]) VALUES (4, N'漂亮的小斑', N'小斑是一個很漂亮的小貓，
照片中可以感覺到小斑在說，
人類，
我美嗎?', N'4.jpg', NULL, CAST(N'2024-07-16T08:14:25.130' AS DateTime))
SET IDENTITY_INSERT [dbo].[Blogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Forms] ON 

INSERT [dbo].[Forms] ([FormID], [Email], [CheckIn], [CheckOut], [OwnerName], [PhoneNumber], [CatsName], [CatsNum], [RoomName], [Status], [CreatedDate]) VALUES (1, N'fish@gmail.com', N'2024-07-18', N'2024-07-19', N'游小魚', N'0912345678', N'小貓、小咪', 2, N'森林房', N'已入住', CAST(N'2024-07-16T05:20:13.133' AS DateTime))
INSERT [dbo].[Forms] ([FormID], [Email], [CheckIn], [CheckOut], [OwnerName], [PhoneNumber], [CatsName], [CatsNum], [RoomName], [Status], [CreatedDate]) VALUES (2, N'fish@gmail.com', N'2024-07-23', N'2024-07-25', N'游小魚', N'0912345678', N'小貓、小咪', 2, N'森林房', N'未入住', CAST(N'2024-07-16T08:13:07.730' AS DateTime))
INSERT [dbo].[Forms] ([FormID], [Email], [CheckIn], [CheckOut], [OwnerName], [PhoneNumber], [CatsName], [CatsNum], [RoomName], [Status], [CreatedDate]) VALUES (3, N'fish@gmail.com', N'2024-07-16', N'2024-07-17', N'游小魚', N'0912345678', N'小貓、小咪', 2, N'經典房', N'已入住', CAST(N'2024-07-19T10:12:42.557' AS DateTime))
INSERT [dbo].[Forms] ([FormID], [Email], [CheckIn], [CheckOut], [OwnerName], [PhoneNumber], [CatsName], [CatsNum], [RoomName], [Status], [CreatedDate]) VALUES (4, N'fish@gmail.com', N'2024-07-17', N'2024-07-18', N'游小魚', N'0912345678', N'小貓、小咪', 2, N'尊爵房', N'未入住', CAST(N'2024-07-19T10:13:17.487' AS DateTime))
INSERT [dbo].[Forms] ([FormID], [Email], [CheckIn], [CheckOut], [OwnerName], [PhoneNumber], [CatsName], [CatsNum], [RoomName], [Status], [CreatedDate]) VALUES (5, N'fish@gmail.com', N'2024-08-10', N'2024-08-11', N'游小魚', N'0912345678', N'小貓、小咪', 2, N'森林房', N'未入住', CAST(N'2024-08-09T10:05:11.193' AS DateTime))
SET IDENTITY_INSERT [dbo].[Forms] OFF
GO
SET IDENTITY_INSERT [dbo].[Managers] ON 

INSERT [dbo].[Managers] ([ManagerID], [UserName], [PassWord], [Name], [PhoneNumber], [ManagerImg], [Status], [CreatedDate], [Email], [level]) VALUES (1, N'hyunbin', N'1234', N'hyunbin', N'0912345678', N'manager1.jpg', N'正常', CAST(N'2024-07-16T04:21:24.187' AS DateTime), N'hyunbin@gmail.com', 1)
INSERT [dbo].[Managers] ([ManagerID], [UserName], [PassWord], [Name], [PhoneNumber], [ManagerImg], [Status], [CreatedDate], [Email], [level]) VALUES (2, N'yejin', N'1234', N'yejin', N'0912345678', N'manager2.jpg', N'正常', CAST(N'2024-07-16T04:23:28.303' AS DateTime), N'yejin@gmail.com', 1)
INSERT [dbo].[Managers] ([ManagerID], [UserName], [PassWord], [Name], [PhoneNumber], [ManagerImg], [Status], [CreatedDate], [Email], [level]) VALUES (3, N'dohyun', N'1234', N'dohyun', N'0912345678', N'manager3.jpg', N'正常', CAST(N'2024-07-16T04:30:14.647' AS DateTime), N'dohyun@gmail.com', 2)
INSERT [dbo].[Managers] ([ManagerID], [UserName], [PassWord], [Name], [PhoneNumber], [ManagerImg], [Status], [CreatedDate], [Email], [level]) VALUES (4, N'jiyeon', N'1234', N'jiyeon', N'0912345678', N'manager4.jpg', N'正常', CAST(N'2024-07-16T06:36:38.210' AS DateTime), N'jiyeon@gmail.com', 2)
INSERT [dbo].[Managers] ([ManagerID], [UserName], [PassWord], [Name], [PhoneNumber], [ManagerImg], [Status], [CreatedDate], [Email], [level]) VALUES (5, N'joohyuk', N'1234', N'joohyuk', N'0912345678', N'manager5.jpg', N'正常', CAST(N'2024-07-16T06:37:23.010' AS DateTime), N'joohyuk@gmail.com', 2)
INSERT [dbo].[Managers] ([ManagerID], [UserName], [PassWord], [Name], [PhoneNumber], [ManagerImg], [Status], [CreatedDate], [Email], [level]) VALUES (6, N'minsi', N'1234', N'minsi', N'0912345678', N'manager6.jpg', N'正常', CAST(N'2024-07-16T06:38:26.757' AS DateTime), N'minsi@gmail.com', 2)
INSERT [dbo].[Managers] ([ManagerID], [UserName], [PassWord], [Name], [PhoneNumber], [ManagerImg], [Status], [CreatedDate], [Email], [level]) VALUES (7, N'sueji', N'1234', N'sueji', N'0912345678', N'manager7.jpg', N'正常', CAST(N'2024-07-16T06:38:57.190' AS DateTime), N'sueji@gmail.com', 2)
INSERT [dbo].[Managers] ([ManagerID], [UserName], [PassWord], [Name], [PhoneNumber], [ManagerImg], [Status], [CreatedDate], [Email], [level]) VALUES (8, N'yeeun', N'1234', N'yeeun', N'0912345678', N'manager8.jpg', N'正常', CAST(N'2024-07-16T06:39:27.733' AS DateTime), N'yeeun@gmail.com', 2)
INSERT [dbo].[Managers] ([ManagerID], [UserName], [PassWord], [Name], [PhoneNumber], [ManagerImg], [Status], [CreatedDate], [Email], [level]) VALUES (9, N'eunbi', N'1234', N'eunbi', N'0912345678', N'manager9.jpg', N'正常', CAST(N'2024-07-16T06:40:16.480' AS DateTime), N'eunbi@gmail.com', 2)
SET IDENTITY_INSERT [dbo].[Managers] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([MemberID], [UserName], [PassWord], [Name], [PhoneNumber], [Email], [Address], [Status], [CreatedDate]) VALUES (1, N'fish', N'abcd1234', N'游小魚', N'0912345678', N'fish@gmail.com', N'台北市信義區', N'正常', CAST(N'2024-06-16T02:01:57.107' AS DateTime))
INSERT [dbo].[Members] ([MemberID], [UserName], [PassWord], [Name], [PhoneNumber], [Email], [Address], [Status], [CreatedDate]) VALUES (2, N'mani', N'abcd1234', N'曾小尼', N'0912345678', N'tzeng2991yu@outlook.com', N'台北市大同區', N'正常', CAST(N'2024-06-16T02:02:57.010' AS DateTime))
INSERT [dbo].[Members] ([MemberID], [UserName], [PassWord], [Name], [PhoneNumber], [Email], [Address], [Status], [CreatedDate]) VALUES (3, N'ming', N'abcd1234', N'曾小明', N'0912345678', N'ming@gmail.com', NULL, N'正常', CAST(N'2024-07-16T06:28:55.000' AS DateTime))
INSERT [dbo].[Members] ([MemberID], [UserName], [PassWord], [Name], [PhoneNumber], [Email], [Address], [Status], [CreatedDate]) VALUES (4, N'molly', N'abcd1234', N'盧小苓', N'0912345678', N'molly@gmail.com', NULL, N'正常', CAST(N'2024-07-16T06:29:25.890' AS DateTime))
INSERT [dbo].[Members] ([MemberID], [UserName], [PassWord], [Name], [PhoneNumber], [Email], [Address], [Status], [CreatedDate]) VALUES (5, N'xing', N'abcd1234', N'鄧小星', N'0912345678', N'xing@gmail.com', NULL, N'正常', CAST(N'2024-07-16T06:30:02.313' AS DateTime))
INSERT [dbo].[Members] ([MemberID], [UserName], [PassWord], [Name], [PhoneNumber], [Email], [Address], [Status], [CreatedDate]) VALUES (6, N'linnn', N'abcd1234', N'杜小霖', N'0912345678', N'linnn@gmail.com', NULL, N'正常', CAST(N'2024-07-16T06:30:42.600' AS DateTime))
INSERT [dbo].[Members] ([MemberID], [UserName], [PassWord], [Name], [PhoneNumber], [Email], [Address], [Status], [CreatedDate]) VALUES (7, N'becky', N'abcd1234', N'戴小琪', N'0912345678', N'becky@gmail.com', NULL, N'正常', CAST(N'2024-07-16T06:31:08.297' AS DateTime))
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [Name], [PhoneNumber], [Email], [Address], [OrderProduct], [Price], [Status], [CreatedDate]) VALUES (1, N'王小盼', N'0912345678', N'panpan@gmail.com', N'台北市松山區', N'Go! 74%高肉量無穀系列 全貓配方海洋鲑鱈 3LB*1', CAST(1099 AS Decimal(10, 0)), N'已出貨', CAST(N'2024-07-16T06:24:51.380' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [Name], [PhoneNumber], [Email], [Address], [OrderProduct], [Price], [Status], [CreatedDate]) VALUES (2, N'游小魚', N'0912345678', N'fish@gmail.com', N'台北市信義區', N'CIAO 寒天肉泥(雞肉海鮮)15gx20條*2', CAST(636 AS Decimal(10, 0)), N'未出貨', CAST(N'2024-07-16T06:25:53.173' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [Name], [PhoneNumber], [Email], [Address], [OrderProduct], [Price], [Status], [CreatedDate]) VALUES (3, N'曾小尼', N'0912345678', N'mani@gmail.com', N'台北市大同區', N'日本 Petio 貓咪皮革踢踢啃咬玩具-蝦子*1', CAST(450 AS Decimal(10, 0)), N'未出貨', CAST(N'2024-07-16T07:38:25.937' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [Name], [PhoneNumber], [Email], [Address], [OrderProduct], [Price], [Status], [CreatedDate]) VALUES (4, N'曾小尼', N'0912345678', N'mani@gmail.com', N'台北市大同區', N'Go! 皮毛保健無穀系列 全貓配方野生鮭魚 3LB*1', CAST(1150 AS Decimal(10, 0)), N'未出貨', CAST(N'2024-07-16T08:15:30.463' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [Name], [PhoneNumber], [Email], [Address], [OrderProduct], [Price], [Status], [CreatedDate]) VALUES (5, N'曾小尼', N'0912345678', N'tzeng2991yu@outlook.com', N'台北市大同區', N'CIAO 寒天肉泥(雞肉海鮮)15gx20條*5', CAST(1440 AS Decimal(10, 0)), N'未出貨', CAST(N'2024-07-19T10:16:39.813' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [Name], [PhoneNumber], [Email], [Address], [OrderProduct], [Price], [Status], [CreatedDate]) VALUES (6, N'曾小尼', N'0912345678', N'tzeng2991yu@outlook.com', N'台北市大同區', N'Go! 高含肉量無穀系列 四種肉無穀貓糧 3LB*1', CAST(1150 AS Decimal(10, 0)), N'未出貨', CAST(N'2024-08-05T13:01:51.320' AS DateTime))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (1, N'catfood1.jpg', N'Go! 74%高肉量無穀系列 全貓配方海洋鲑鱈 3LB', N'1099', 19, N'◆74%高含量肉類蛋白
◆富含Omega脂肪酸.保健貓貓的毛色與視力
◆高肉類蛋白質營養好吸收
◆天然牛磺酸，保健視力與心臟
◆內含益生菌/膳食纖維健康腸胃get!', N'貓飼料')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (2, N'catfood2.jpg', N'Go! 高含肉量無穀系列 四種肉無穀貓糧 3LB', N'1150', 19, N'◆ 雞肉+火雞肉+鴨肉+鮭魚四種肉製作
◆ 高含肉量零穀物，專為貓咪營養需求打造
◆ 添加益生菌和益菌生，促進腸胃消化機能
◆ 高含肉量，肌肉發展第一選擇', N'貓飼料')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (3, N'catfood3.jpg', N'Go! 皮毛保健無穀系列 全貓配方野生鮭魚 3LB', N'1150', 19, N'◆無穀配方
◆單一肉質,富含Omega油脂.提升貓貓的毛色亮麗
◆豐富益生菌與膳食纖維，保健腸胃
◆優質蛋白質易吸收與絲蘭，異味掰掰
◆內含益生菌/膳食纖維健康腸胃get!', N'貓飼料')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (4, N'catcannedfood1.jpg', N'CIAO 北海道燒鰹魚凍罐-鰹魚高湯風味 80g', N'45', 30, N'◆燒鰹魚片，配上貓咪喜歡的食材
◆使用正宗北海道產扇貝高湯
◆添加綠茶消臭成分，有助減少貓咪糞便的異味
◆產地：日本', N'貓罐頭')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (5, N'catcannedfood2.jpg', N'CIAO 北海道燒鰹魚凍罐 - 鰹魚 + 銀魚 80g', N'45', 30, N'◆燒鰹魚片，配上貓咪喜歡的食材
◆使用正宗北海道產扇貝高湯
◆添加綠茶消臭成分，有助減少貓咪糞便的異味
◆產地：日本', N'貓罐頭')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (6, N'catcannedfood3.jpg', N'CIAO 北海道燒鰹魚凍罐 - 鰹魚 + 扇貝 80g', N'45', 30, N'◆燒鰹魚片，配上貓咪喜歡的食材
◆使用正宗北海道產扇貝高湯
◆添加綠茶消臭成分，有助減少貓咪糞便的異味
◆產地：日本', N'貓罐頭')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (7, N'catcannedfood4.jpg', N'CIAO 綜合營養乳酸菌罐-鮪魚+蟹肉棒 80g', N'45', 30, N'◆全面的營養食品，含有貓咪所需的均衡營養組合
◆質地厚實，連挑嘴貓都喜歡
◆含有100億個乳酸菌
◆產地：日本', N'貓罐頭')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (8, N'cattreats1.jpg', N'CIAO 寒天肉泥(鰹魚鰹魚片)15gx20條', N'288', 35, N'◆添加綠茶消臭成分，有助減少貓咪糞便的異味
◆條狀包裝，增加餵食方便性
◆可增加與貓咪的互動性零食
◆可加水調和，增加貓咪喝水量
◆依貓咪各成長階段需求調配的專屬配方', N'貓零食')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (9, N'cattreats2.jpg', N'CIAO 寒天肉泥(雞肉海鮮)15gx20條', N'288', 28, N'◆添加綠茶消臭成分，有助減少貓咪糞便的異味
◆條狀包裝，增加餵食方便性
◆可增加與貓咪的互動性零食
◆可加水調和，增加貓咪喝水量
◆依貓咪各成長階段需求調配的專屬配方', N'貓零食')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (10, N'cattreats3.jpg', N'CIAO 寒天肉泥(鮪魚)15gx20條', N'288', 35, N'◆添加綠茶消臭成分，有助減少貓咪糞便的異味
◆條狀包裝，增加餵食方便性
◆可增加與貓咪的互動性零食
◆可加水調和，增加貓咪喝水量
◆依貓咪各成長階段需求調配的專屬配方', N'貓零食')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (11, N'cattoys1.jpg', N'MISSPET 達摩大福貓草玩具(四款可選)', N'199', 16, N'◆內有添加貓咪最愛的貓草
◆讓貓咪可以盡情的熊抱、啃咬、抓踢
◆有多款不同大福貓種供選擇
◆超柔棉布，不傷牙齦、嘴脣
◆適當紓壓、增進與寵物之間的互動與感情', N'貓玩具')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (12, N'cattoys2.jpg', N'MARUKAN 貓型蓄熱棉枕', N'290', 17, N'◆可以看到貓咪踏踏的可愛動作
◆含有蓄熱棉，具有適度的彈性和保暖性
◆主體尺寸：約W200xD360xH60mm', N'貓玩具')
INSERT [dbo].[Products] ([ProductID], [ProductImg], [ProductName], [ProductPrice], [UnitInStock], [ProductDesc], [Type]) VALUES (13, N'cattoys3.jpg', N'日本 Petio 貓咪皮革踢踢啃咬玩具-蝦子', N'390', 17, N'◆採用天然材料製成皮革的氣味很吸引人！
◆是在SNS上很受歡迎的皮革型蝦子
◆據JIS標準的撕裂強度測試，其強度是傳統產品的四倍
◆因此即使撕破也可以使用
◆與山崎動物護理大學，共同開發商品', N'貓玩具')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([RoomID], [RoomName], [RoomSize], [CatsLimit], [SunTime], [OverTime], [AddCats], [Price], [RoomImg], [RoomImgg], [RoomImggg], [RoomDesc], [Type]) VALUES (1, N'經典房', N'寬 105cm * 深 145cm * 高 300cm', N'3', N'最低 15 分鐘', N'150', N'300', N'900', N'classic1.jpg', NULL, NULL, N'基本舒適房型，
擁有五組樓梯跳台，
垂直奔跑滿足好動細胞。', 1)
INSERT [dbo].[Rooms] ([RoomID], [RoomName], [RoomSize], [CatsLimit], [SunTime], [OverTime], [AddCats], [Price], [RoomImg], [RoomImgg], [RoomImggg], [RoomDesc], [Type]) VALUES (2, N'尊爵房', N'寬 155cm * 深 145cm * 高 300cm', N'4', N'最低 15 分鐘', N'200', N'300', N'1150', N'premium1.jpg', NULL, NULL, N'多層樓閣交錯，埋伏躲藏樂趣多，合適愛躲藏的貓。', 2)
INSERT [dbo].[Rooms] ([RoomID], [RoomName], [RoomSize], [CatsLimit], [SunTime], [OverTime], [AddCats], [Price], [RoomImg], [RoomImgg], [RoomImggg], [RoomDesc], [Type]) VALUES (3, N'森林房', N'寬 210cm * 深 145cm * 高 300cm', N'5', N'擁有房內專屬對外窗', N'300', N'300', N'2600', N'forest1.jpg', NULL, NULL, N'專屬對外窗，徜徉陽光與森林公園美景，最頂級的外宿享受。', 3)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
USE [master]
GO
ALTER DATABASE [Mani] SET  READ_WRITE 
GO
