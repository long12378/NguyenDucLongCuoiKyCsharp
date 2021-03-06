USE [master]
GO
/****** Object:  Database [NguyenDucLongDB]    Script Date: 6/21/2021 12:18:40 AM ******/
CREATE DATABASE [NguyenDucLongDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NguyenDucLongDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NguyenDucLongDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NguyenDucLongDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NguyenDucLongDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NguyenDucLongDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NguyenDucLongDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NguyenDucLongDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [NguyenDucLongDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NguyenDucLongDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NguyenDucLongDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NguyenDucLongDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NguyenDucLongDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NguyenDucLongDB] SET  MULTI_USER 
GO
ALTER DATABASE [NguyenDucLongDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NguyenDucLongDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NguyenDucLongDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NguyenDucLongDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [NguyenDucLongDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/21/2021 12:18:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Decription] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/21/2021 12:18:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[UnitCost] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
	[Image] [nvarchar](100) NULL,
	[Decription] [nvarchar](500) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 6/21/2021 12:18:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Decription]) VALUES (2, N'Sách Văn Học', N'123456')
INSERT [dbo].[Category] ([ID], [Name], [Decription]) VALUES (4, N'Sách thiếu nhi', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Decription]) VALUES (5, N'sách khoa học', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [UnitCost], [Quantity], [Image], [Decription], [Status]) VALUES (2, 4, N'Truyện Ngụ Ngôn', CAST(10000 AS Decimal(18, 0)), 20, N'Truyện ngụ ngôn.jpg', N'Truyện cười trẻ em', 0)
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [UnitCost], [Quantity], [Image], [Decription], [Status]) VALUES (3, 5, N'Nguồn gốc xã hội của trí khôn', CAST(50000 AS Decimal(18, 0)), 60, N'Nguồn gốc xã hội của trí khôn.jpg', N'sách khoa học xã hội', 0)
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [UnitCost], [Quantity], [Image], [Decription], [Status]) VALUES (4, 2, N'Biệt thự Longbourn', CAST(40000 AS Decimal(18, 0)), 30, N'Biệt thự longbourn.png', N'sách văn học', 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (2, N'admin', N'admin', 1)
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (3, N'longtk', N'123', 0)
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__UserAcco__C9F28456BEEF5593]    Script Date: 6/21/2021 12:18:40 AM ******/
ALTER TABLE [dbo].[UserAccount] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [NguyenDucLongDB] SET  READ_WRITE 
GO
