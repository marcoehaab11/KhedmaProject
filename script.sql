USE [master]
GO
/****** Object:  Database [KhedmaDB]    Script Date: 20-Nov-24 3:58:34 PM ******/
CREATE DATABASE [KhedmaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KhedmaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\KhedmaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KhedmaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\KhedmaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [KhedmaDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KhedmaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KhedmaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KhedmaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KhedmaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KhedmaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KhedmaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [KhedmaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KhedmaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KhedmaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KhedmaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KhedmaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KhedmaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KhedmaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KhedmaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KhedmaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KhedmaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KhedmaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KhedmaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KhedmaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KhedmaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KhedmaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KhedmaDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [KhedmaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KhedmaDB] SET RECOVERY FULL 
GO
ALTER DATABASE [KhedmaDB] SET  MULTI_USER 
GO
ALTER DATABASE [KhedmaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KhedmaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KhedmaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KhedmaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KhedmaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KhedmaDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'KhedmaDB', N'ON'
GO
ALTER DATABASE [KhedmaDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [KhedmaDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [KhedmaDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20-Nov-24 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alhan]    Script Date: 20-Nov-24 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alhan](
	[MakhdoumID] [int] NOT NULL,
	[StageID] [int] NOT NULL,
 CONSTRAINT [PK_Alhan] PRIMARY KEY CLUSTERED 
(
	[MakhdoumID] ASC,
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BooksAndSaves]    Script Date: 20-Nov-24 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksAndSaves](
	[MakhdoumID] [int] NOT NULL,
	[StageID] [int] NOT NULL,
 CONSTRAINT [PK_BooksAndSaves] PRIMARY KEY CLUSTERED 
(
	[MakhdoumID] ASC,
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coptic]    Script Date: 20-Nov-24 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coptic](
	[MakhdoumID] [int] NOT NULL,
	[StageID] [int] NOT NULL,
 CONSTRAINT [PK_Coptic] PRIMARY KEY CLUSTERED 
(
	[MakhdoumID] ASC,
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ForSingle]    Script Date: 20-Nov-24 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForSingle](
	[MakhdoumID] [int] NOT NULL,
	[StageID] [int] NOT NULL,
 CONSTRAINT [PK_ForSingle] PRIMARY KEY CLUSTERED 
(
	[MakhdoumID] ASC,
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Learning]    Script Date: 20-Nov-24 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Learning](
	[MakhdoumID] [int] NOT NULL,
	[StageID] [int] NOT NULL,
 CONSTRAINT [PK_Learning] PRIMARY KEY CLUSTERED 
(
	[MakhdoumID] ASC,
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbkoral]    Script Date: 20-Nov-24 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbkoral](
	[MakhdoumID] [int] NOT NULL,
	[StageID] [int] NOT NULL,
 CONSTRAINT [PK_Tbkoral] PRIMARY KEY CLUSTERED 
(
	[MakhdoumID] ASC,
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBMakhdoum]    Script Date: 20-Nov-24 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBMakhdoum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](200) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
 CONSTRAINT [PK_TBMakhdoum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBTheStage]    Script Date: 20-Nov-24 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBTheStage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[StartFrom] [date] NULL,
	[EndFrom] [date] NULL,
 CONSTRAINT [PK_TBTheStage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Theater]    Script Date: 20-Nov-24 3:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Theater](
	[MakhdoumID] [int] NOT NULL,
	[StageID] [int] NOT NULL,
 CONSTRAINT [PK_Theater] PRIMARY KEY CLUSTERED 
(
	[MakhdoumID] ASC,
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241118120400_MakhdoumAndKoralAndStage', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241118130949_convertDateToStringinMakhdoum', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241118132502_convertDateToStringinMakhdoum2', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241120072151_AlhanTable', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241120080135_CopticAndLearningAndTheradTable', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241120123045_addBookTable', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241120131153_addForSingle', N'9.0.0')
GO
INSERT [dbo].[Alhan] ([MakhdoumID], [StageID]) VALUES (263, 3)
INSERT [dbo].[Alhan] ([MakhdoumID], [StageID]) VALUES (264, 3)
INSERT [dbo].[Alhan] ([MakhdoumID], [StageID]) VALUES (523, 3)
INSERT [dbo].[Alhan] ([MakhdoumID], [StageID]) VALUES (264, 5)
INSERT [dbo].[Alhan] ([MakhdoumID], [StageID]) VALUES (523, 5)
INSERT [dbo].[Alhan] ([MakhdoumID], [StageID]) VALUES (270, 7)
INSERT [dbo].[Alhan] ([MakhdoumID], [StageID]) VALUES (523, 8)
INSERT [dbo].[Alhan] ([MakhdoumID], [StageID]) VALUES (268, 9)
INSERT [dbo].[Alhan] ([MakhdoumID], [StageID]) VALUES (263, 10)
INSERT [dbo].[Alhan] ([MakhdoumID], [StageID]) VALUES (523, 10)
GO
INSERT [dbo].[BooksAndSaves] ([MakhdoumID], [StageID]) VALUES (523, 8)
GO
INSERT [dbo].[Coptic] ([MakhdoumID], [StageID]) VALUES (263, 9)
GO
INSERT [dbo].[ForSingle] ([MakhdoumID], [StageID]) VALUES (264, 12)
INSERT [dbo].[ForSingle] ([MakhdoumID], [StageID]) VALUES (265, 12)
INSERT [dbo].[ForSingle] ([MakhdoumID], [StageID]) VALUES (266, 14)
INSERT [dbo].[ForSingle] ([MakhdoumID], [StageID]) VALUES (267, 14)
GO
INSERT [dbo].[Learning] ([MakhdoumID], [StageID]) VALUES (523, 9)
INSERT [dbo].[Learning] ([MakhdoumID], [StageID]) VALUES (263, 10)
GO
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (261, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (264, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (265, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (266, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (267, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (268, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (269, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (270, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (275, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (278, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (279, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (280, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (289, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (290, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (291, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (292, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (300, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (303, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (319, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (329, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (332, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (333, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (337, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (338, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (461, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (480, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (481, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (492, 1)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (272, 2)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (480, 2)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (523, 2)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (263, 3)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (264, 3)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (266, 3)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (523, 3)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (523, 4)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (264, 5)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (265, 5)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (523, 5)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (270, 8)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (523, 8)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (523, 9)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (523, 10)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (266, 11)
INSERT [dbo].[Tbkoral] ([MakhdoumID], [StageID]) VALUES (267, 11)
GO
SET IDENTITY_INSERT [dbo].[TBMakhdoum] ON 

INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (257, N'كيرلس سامي فوزي', N'01007277097', CAST(N'2012-07-19' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (259, N'بيشوي هاني', N'01207882090', CAST(N'2005-02-08' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (260, N'هايدي عماد', N'01226830185', CAST(N'1999-05-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (261, N'هيلين سامح فهمي', N'01274500835', CAST(N'2005-08-02' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (262, N'فيرنا فاريده فكري', N'01206475394', CAST(N'2002-05-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (263, N'أميره حلمي عبده إبراهيم', N'01503305220', CAST(N'1990-04-29' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (264, N'أندرو سمير جورجي اسرائيل', N'01228979700', CAST(N'1993-11-07' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (265, N'أنطونيوس عيد مبارك ناشد', N'01554345406', CAST(N'2012-07-20' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (266, N'إلسا بيتر بان ب عوض الله', N'01067278457', CAST(N'2016-11-30' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (267, N'إلسا بيتر بشير بانوب', N'01090956225', CAST(N'2016-11-30' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (268, N'إيلاريا رضا سعد رزق', N'01223596729', CAST(N'1999-09-24' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (269, N'إيلي مينا نسان عبد الملاك', N'01221316608', CAST(N'2017-06-30' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (270, N'ابانوب أسامه رضا لطفى', N'0120 130 8584?', CAST(N'2014-09-10' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (272, N'ابانوب رضا عزت لبيب', N'01002801895', CAST(N'2015-06-17' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (273, N'ابانوب سرور قزمان صالح', N'01015853516', CAST(N'1989-02-05' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (274, N'ابانوب عماد سمير يوسف', N'01154349486', CAST(N'2010-02-04' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (275, N'ابانوب عماد منير حنا', N'01033415065', CAST(N'2007-12-27' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (276, N'ادم وائل سعد بسطا', N'01275993372', CAST(N'2010-02-24' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (277, N'استيڤن وسام بشري يوسف', N'01004961018', CAST(N'2009-08-04' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (278, N'افرايم امير يحيي زكريا', N'01004539554', CAST(N'2009-10-28' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (279, N'البير بشري عبد المسيح حنا', N'01208549266', CAST(N'2003-10-20' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (280, N'الفريد جورجي فريد جورجي', N'0 1278493812', CAST(N'2004-02-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (282, N'امل ميشيل سعد حبيب', N'01080620310', CAST(N'1985-06-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (283, N'انجي حلمي عبده ابراهيم', N'01004457019', CAST(N'1986-12-07' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (284, N'انجيل موريس فهيم عزيز', N'01000677786', CAST(N'1979-04-23' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (285, N'اندرو وائل رمزي نجيب', N'01211632127', CAST(N'2010-09-16' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (286, N'انطونيوس قاسم خلف رشدى', N'01153076194', CAST(N'2004-10-15' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (287, N'ايريني عزيز ابراهيم سعد', N'01069346796', CAST(N'1990-09-29' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (288, N'ايريني قاسم خلف رشدي', N'01148020124', CAST(N'2015-02-19' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (289, N'ايريني وديع عزيز جرجس', N'01283665466', CAST(N'1987-01-14' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (290, N'ايمي بيشوي عادل عوض', N'01022048048', CAST(N'2014-07-14' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (291, N'ايناس يونان صليب منقريوس', N'01281494522', CAST(N'1977-11-27' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (292, N'باتي عاطف ذكي ميخائيل', N'01279663151', CAST(N'2004-04-22' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (293, N'بارثينيا تامر شفيق مرقص', N'01281802957', CAST(N'2013-09-17' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (294, N'بريسكلا هاني ناشد ميخائيل', N'0127882146', CAST(N'2008-02-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (295, N'بسمه جميل خوراس كميل', N'01272264003', CAST(N'2015-02-19' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (296, N'بسنت ماجد سعد واصف', N'01556271751', CAST(N'2005-07-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (297, N'بسنت ياسر رمزي موسي', N'01280151028', CAST(N'2006-03-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (298, N'بنيامين بولا نصر كامل', N'01280605543', CAST(N'2006-04-21' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (299, N'بوسي هاني سمير يعقوب', N'01278732815', CAST(N'2002-09-25' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (300, N'بولس عادل بشري فؤاد', N'01224349803', CAST(N'2012-05-22' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (301, N'بيشوي چورچ مرقص ذكي', N'01284820734', CAST(N'2001-08-15' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (302, N'بيشوي رامي حلمي لمعي', N'01145528302', CAST(N'2017-07-15' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (303, N'بيشوي رامي ملاك ميخائيل', N'01200302932', CAST(N'2006-09-06' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (304, N'بيشوي فادي بشرى عوض', N'01212651876', CAST(N'2016-11-03' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (305, N'بيشوي ناجي سلامه مرقس', N'01555775071', CAST(N'2018-09-04' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (306, N'بيمن جورج إبراهيم ذكي', N'01064269900', CAST(N'2017-10-22' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (307, N'بيير ابانوب سرور قزمان', N'01032650107', CAST(N'2017-12-23' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (308, N'تريزه رضا نظير سيف', N'01207619898', CAST(N'1991-11-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (309, N'توكاس ملاك تادرس يعقوب', N'01224362285', CAST(N'2019-10-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (310, N'توماس رأفت أنور يوشع', N'01212651175', CAST(N'2007-10-28' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (311, N'توماس مجدي عزمي امين', N'01558955922', CAST(N'2010-01-10' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (312, N'توماس ياسر رمزى موسي', N'01093386022', CAST(N'2002-08-07' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (313, N'جاسمين جورج إبراهيم زكى', N'01271388192', CAST(N'2006-10-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (314, N'جني عفيفي مملوك شفيق', N'01123517341', CAST(N'2015-07-11' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (315, N'جورج حبيب رؤوف حبيب', N'01272655351', CAST(N'2010-05-24' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (316, N'جورج عماد جورج فرج', N'01227427747', CAST(N'2011-01-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (317, N'جورج فرانسيس جورج رياض', N'01550421601', CAST(N'1993-09-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (318, N'جورج وهيب يعقوب جرجس', N'01204742838', CAST(N'1981-09-14' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (319, N'جورجونيا عماد جورجي فرج', N'01206636506', CAST(N'2008-05-13' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (320, N'جورجينا وهيب يعقوب جرجس', N'01210164404', CAST(N'1982-09-03' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (321, N'جوفانا مينا محروس تادرس', N'01550927865', CAST(N'2011-05-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (322, N'جوفاني ماركو جرجس توفيق', N'01225727100', CAST(N'2011-07-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (323, N'جومانا عزت ابراهيم صفوت', N'01275555728', CAST(N'2009-10-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (324, N'جومانا فادي صبري خليل', N'01222857759', CAST(N'2012-02-20' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (325, N'جومانا كمال متري كمال', N'01220343450', CAST(N'2010-07-18' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (326, N'جونير باسم عوض سعد', N'01212479981', CAST(N'2018-10-28' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (327, N'جونير جورج كمال رزق', N'01276803933', CAST(N'2012-11-03' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (328, N'جيرمينا جورج ملاك ميخائيل', N'01284656678', CAST(N'2006-03-11' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (329, N'جيسيكا عماد روماني وصفي', N'01281737797', CAST(N'2021-07-25' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (330, N'چاسمين چورچ ابراهيم ذكي', N'+20 127 138 8192', CAST(N'2006-10-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (331, N'چاسمين رضا سعد رزق', N'01274244884', CAST(N'2003-05-07' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (332, N'چاسي مينا نادر جورجي', N'01091841851', CAST(N'2014-12-04' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (333, N'چنا رامي حلمي لمعي', N'011455283020', CAST(N'2012-02-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (334, N'چورچيو مينا فوزي فخري', N'01283581549', CAST(N'2020-12-06' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (335, N'چوفانا مينا محروس تادرس', N'01550927867', CAST(N'2011-05-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (336, N'چويسي مايكل جورج فوزي', N'01285158258', CAST(N'2015-08-06' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (337, N'رفقه عاطف عوض الله جرجس', N'0 1010919518', CAST(N'2000-09-28' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (338, N'رنين يسري شوقي توفيق', N'01026309616', CAST(N'2003-02-16' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (339, N'روزاليندا امير يحي ذكريا', N'01068433200', CAST(N'2011-12-02' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (340, N'روزاليندا امير يحيي زكريا', N'01210908654', CAST(N'2011-12-02' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (341, N'روفائيل رضا ابراهيم صاموئيل', N'01017823310', CAST(N'2015-11-12' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (342, N'روفينا فادي عوض سعد', N'01067054047', CAST(N'2011-08-29' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (343, N'روماني سامر سمير', N'01028471621', CAST(N'2008-05-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (344, N'روماني سامر سمير موريس', N'01278277519', CAST(N'2008-05-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (345, N'روميل بولا روميل لطفي', N'01277695080', CAST(N'2012-11-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (346, N'ساره باهر وليم عطا الله', N'01272830202', CAST(N'2010-05-25' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (347, N'ساره باهر وليم عطاالله', N'01272830802', CAST(N'2016-05-25' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (348, N'ساره جرجس فتحي عطيه', N'01271446266', CAST(N'2016-10-15' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (349, N'ساره سمير سلامه مرقس', N'01020344309', CAST(N'2010-08-03' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (350, N'ساره كامل وديد كامل', N'01282387755', CAST(N'2000-02-06' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (351, N'سامر نور شاكر مرقص', N'01204246141', CAST(N'2005-08-04' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (352, N'ساندرا مرقس امين مراد', N'01144031773', CAST(N'2000-10-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (353, N'ستيفن ابانوب رضا نظير', N'01204417778', CAST(N'2016-07-20' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (354, N'سلفانا عوض عوض بدوي', N'01207627390', CAST(N'1984-04-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (355, N'سلفيا امير يونس طرابلسي', N'1090956225', CAST(N'1991-12-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (356, N'سمير امير يونس طرابلس', N'01004266308', CAST(N'1994-03-18' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (357, N'سمير عيد مبارك ناشد', N'01557582722', CAST(N'2010-08-14' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (358, N'سيسيل ماجد حبيب برهوم', N'01094473173', CAST(N'2012-01-26' AS Date))
GO
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (359, N'شادى محسن صالح مشرقى', N'01285417982', CAST(N'1991-02-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (360, N'شريف نعيم يوسف فرج', N'01061666611', CAST(N'1976-09-10' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (361, N'شنودة جورج ابراهيم', N'01008334439', CAST(N'2013-03-13' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (362, N'شنوده سمير سلامه مرقس', N'01203741740', CAST(N'2016-12-07' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (363, N'شيرى سرور قزمان صالح', N'01021904512', CAST(N'1987-06-19' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (364, N'شيري إبراهيم ناجي وليم', N'01229617628', CAST(N'1984-05-12' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (365, N'عماد فرانسوا قلدس عبد المسيح', N'01067044425', CAST(N'1985-02-17' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (366, N'فادي مايكل فؤاد ميخائيل', N'01277283014', CAST(N'2014-10-24' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (367, N'فادي مجدي يوسف حلمي', N'01285219909', CAST(N'2011-09-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (368, N'فام فادي فتحي عطيه', N'01225577315', CAST(N'2017-06-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (369, N'فريده رجائي راغب ايوب', N'01026460293', CAST(N'1990-03-12' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (370, N'فلوباتير جميل فكري ميخائيل', N'01220322126', CAST(N'2009-07-16' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (371, N'فوزي ابراهيم فوزي صليب', N'01068352631', CAST(N'1998-09-29' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (372, N'فيبي جميل سليم ابراهيم', N'0122478935', CAST(N'1985-07-16' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (373, N'فيرونيا وسام سمير جورجي', N'01222654891', CAST(N'2014-05-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (374, N'فيرونيكا سامح سمير عبده', N'01284802325', CAST(N'2013-04-14' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (376, N'فيرينا نادي ناجي نجيب', N'01286028215', CAST(N'2011-09-12' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (377, N'فيلوباتير شفيق شاكر مرقص', N'01201928213', CAST(N'2013-06-08' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (378, N'فيلومينا صبحي طلعت صبحي', N'01097050212', CAST(N'2015-09-12' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (379, N'فيلومينا فادي جرانت فؤاد', N'1210164404', CAST(N'2016-09-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (380, N'ڤيرينا نادي ناجي نجيب', N'01123171725', CAST(N'2011-09-12' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (381, N'كاترين تامر شفيق مرقس', N'01277962207', CAST(N'2009-11-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (382, N'كاتي أندراوس عطيه يعقوب', N'01000105096', CAST(N'2020-02-20' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (383, N'كاراس رماني فتوح عبده', N'01210940707', CAST(N'2016-08-10' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (384, N'كاراس سامح رضا لطفي', N'01210108187', CAST(N'2009-04-17' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (386, N'كاراس عماد مهني عبدالله', N'01224346126', CAST(N'2016-11-17' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (387, N'كاراس مايكل نشأت شوقي', N'01275646364', CAST(N'2010-08-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (388, N'كاراس مرقس امين مراد', N'0 1158885020', CAST(N'2004-04-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (389, N'كاراس مينا نسان عبدالملاك', N'01223316608', CAST(N'2014-05-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (390, N'كارلا مايكل مكرم عدلي', N'01276707658', CAST(N'2014-10-27' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (391, N'كارولين معوض صبري', N'01283657220', CAST(N'2019-05-21' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (392, N'كارين جورج كمال روفائيل', N'01554930135', CAST(N'2009-08-03' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (393, N'كاميليا عزيز فريد جورجي', N'01092212156', CAST(N'2009-02-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (394, N'كرستي اندراوس عطية يعقوب', N'01019067001', CAST(N'2007-03-03' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (395, N'كريمان كمال تادرس رفله', N'01280207888', CAST(N'1982-07-23' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (396, N'كيرلس اسحاق سمير مرقص', N'01226507188', CAST(N'2008-02-18' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (397, N'كيرلس جورج بسخرون مينا', N'01277975640', CAST(N'2009-06-02' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (398, N'كيرلس صبحي ناجي صبحي', N'01200076663', CAST(N'2011-05-15' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (399, N'كيرلس عيد يونان عوني', N'01156524126', CAST(N'2014-05-13' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (400, N'كيرلس هاني مجدي فوزي', N'01006773559', CAST(N'2015-09-06' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (401, N'كيرلس وجيه فرانسوا قلدس', N'01556446105', CAST(N'2007-06-28' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (402, N'كيرمينا كمال متري كمال', N'01201496939', CAST(N'2013-02-19' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (403, N'كيفن شريف نعيم يوسف', N'01553713235', CAST(N'2009-07-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (405, N'كيفين عماد لولي صبحي', N'01223862396', CAST(N'2013-11-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (406, N'لوساندا عماد مهني عبدالله', N'01284303014', CAST(N'2010-01-23' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (407, N'ليليان صبري خليل مسيحه', N'01203762280', CAST(N'1983-07-04' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (408, N'ماثيو مجدي مهني عبدالله', N'01280983315', CAST(N'2015-11-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (409, N'ماجي جادالله بسيط مسعد', N'01224515863', CAST(N'1990-07-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (410, N'مادونا امير الشحات حليم', N'01280029383', CAST(N'2008-09-16' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (411, N'مادونا جورج إبراهيم زكي', N'01032261300', CAST(N'2008-06-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (412, N'مادونا مجدي رمزي', N'01221630096', CAST(N'2002-09-16' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (415, N'مارتن عماد بشرى يوسف', N'01559958732', CAST(N'2010-04-12' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (416, N'مارتن محب جرجس قزمان', N'1556022980', CAST(N'2008-07-07' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (417, N'مارتن هاني وسيم شوقي', N'01559698338', CAST(N'2010-01-29' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (418, N'مارتيروس سامح سمير عبده', N'01554930636', CAST(N'2009-08-14' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (420, N'مارتينا شادي عوض سعد', N'01224510863', CAST(N'2020-04-02' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (421, N'مارتينا كامل شوقى كامل', N'01203358253', CAST(N'2001-05-10' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (422, N'مارتينا مجدى نظير سيف', N'01221149905', CAST(N'2006-09-02' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (423, N'مارتينا محب جرجس قزمان', N'01200288118', CAST(N'2015-02-15' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (424, N'مارتينا نبيل امير جرجس', N'01554091835', CAST(N'2008-10-17' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (425, N'مارثا ادوارد إبراهيم واصف', N'01212130289', CAST(N'1977-10-04' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (426, N'مارسلينو عماد فرنسوا قلدس', N'0153305220', CAST(N'2015-08-24' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (427, N'مارك حبيب رؤؤف حبيب', N'01555961706?', CAST(N'2014-07-25' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (428, N'مارك حبيب رؤوف', N'01555961706', CAST(N'2014-07-25' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (429, N'مارك كميل سعد مشرقي', N'01014169125', CAST(N'2004-02-16' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (430, N'مارك هاني وسيم شوقي', N'01099266196', CAST(N'2005-07-18' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (431, N'ماركو عماد سمير يوسف', N'01128065134', CAST(N'2024-06-25' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (432, N'ماركو مجدى مهنى عبد الله', N'01224304940', CAST(N'2007-07-04' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (433, N'ماروسكا جرجس مبارك ناشد', N'01212030707', CAST(N'2017-09-23' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (434, N'مارى إبراهيم ابو الحصين', N'0128 365 7220?', CAST(N'1999-11-15' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (435, N'مارى رياض جورج رياض', N'01212921881', CAST(N'1998-07-08' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (436, N'مارى نبيل ملاك مسيحة', N'01210506478', CAST(N'1995-08-20' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (437, N'ماريا اسحاق سمير مرقس', N'01226677463', CAST(N'2010-08-22' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (438, N'ماريا مينا فريد اسكندر', N'9•66566E+11', CAST(N'2010-04-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (439, N'ماريا وجيه يونين فوزي', N'01228980018', CAST(N'2012-07-21' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (440, N'ماريام اشرف ادوارد', N'01200017687', CAST(N'2004-04-17' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (441, N'ماريان فرنسيس جورج رياض', N'01200303100', CAST(N'1999-09-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (442, N'مارينا امير الشحات حليم', N'01276258770', CAST(N'2005-10-25' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (443, N'مارينا شادي عوض سعد', N'+20 1224515863', CAST(N'2015-08-04' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (444, N'مارينا عماد منير حنا', N'01011647977', CAST(N'2013-07-13' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (445, N'مارينا مجدى رمزى سلامة', N'01206780125', CAST(N'1999-12-14' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (446, N'مارينا هاني سمير فهمي', N'01503124973', CAST(N'2005-02-07' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (447, N'مارينا وائل رمزي نجيب', N'01229285571', CAST(N'2012-07-28' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (448, N'مايفن مايكل جورج فوزي', N'01101583888', CAST(N'2011-07-07' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (449, N'مايڤل مايكل ممدوح عوض الله', N'01204796885', CAST(N'2006-12-03' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (450, N'مايكل نجيب رمزي نجيب', N'01278642177', CAST(N'2010-09-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (451, N'مرقس مكرم عدلى نجيب', N'1212300110', CAST(N'1988-07-02' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (452, N'مركوري مايكل سمير عزيز', N'01281433653', CAST(N'2012-01-30' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (453, N'مريم اميل مرقص حنا', N'01226599868', CAST(N'1984-04-24' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (454, N'مريم ايهاب حلمي نقولا', N'01220809032', CAST(N'1999-06-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (455, N'مريم جميل فكرى ميخائيل', N'01550755034', CAST(N'2006-11-16' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (457, N'مريم سمير شكري ميخائيل', N'01200298117', CAST(N'2002-05-05' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (458, N'مريم شادي عوض سعد', N'01224515803', CAST(N'2012-12-10' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (459, N'مريم شنوده كمال نجيب', N'01557045518', CAST(N'2014-08-11' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (461, N'مريم عماد لولي صبحي', N'01222233065', CAST(N'2010-09-20' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (462, N'مريم كامل وديد كامل', N'01211041566', CAST(N'2003-03-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (463, N'مريم ناجى حبيب مرقريوس', N'01201689616', CAST(N'1991-02-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (464, N'مريم هاني سمير فهمي', N'01064720760', CAST(N'2010-03-15' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (465, N'مهرائيل مجدى رمزى سلامة', N'01279152133', CAST(N'2002-09-16' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (466, N'مونيكا مينا رمزي نجيب', N'01222855525', CAST(N'2016-09-13' AS Date))
GO
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (467, N'ميان جورج بسخرون مينا', N'+20 128 975 2880', CAST(N'2005-09-08' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (469, N'ميرا وجيه فرانسوا', N'155644613', CAST(N'2011-01-27' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (470, N'ميرا وجيه فرانسوا قلدس', N'01556446103', CAST(N'2011-01-27' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (471, N'ميراي كيرلس منير شوقي', N'01016230050', CAST(N'2018-08-20' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (472, N'ميرنا مجدى نظير سيف', N'012024853534', CAST(N'2003-02-21' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (474, N'ميرولا ابراهيم ناجي ابراهيم', N'01285026017', CAST(N'2018-08-10' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (475, N'ميرولا ايهاب فكري بدير', N'01099911607', CAST(N'2009-11-11' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (477, N'ميرولا مينا رمزي نجيب', N'1222855525', CAST(N'2013-08-27' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (478, N'ميريت كامل شوقى كامل', N'01288186070', CAST(N'1998-12-21' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (479, N'مينا رامي مجدي فهمي', N'01210050556', CAST(N'2015-04-18' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (480, N'مينا سامح فهمي عبدالله', N'01204149354', CAST(N'2001-01-12' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (481, N'مينا عاطف ذكي ميخائيل', N'01206665162', CAST(N'2008-04-22' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (482, N'مينا فوزى فخرى عبد الملاك', N'01220206837', CAST(N'1991-01-22' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (483, N'مينا مايكل ممدوح عوض الله', N'01279608043', CAST(N'2010-10-11' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (484, N'مينا مجدي مهني عبد الله', N'01211226807', CAST(N'2003-07-19' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (485, N'مينا ناجى فهيم ميخائيل', N'0122 946 4798?', CAST(N'1982-09-25' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (486, N'مينا ناصر حنا ميخائيل', N'01111329820', CAST(N'2008-04-06' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (487, N'ناديه فكري بدير إبراهيم', N'01223047041', CAST(N'1983-12-12' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (488, N'نانسي رزق نصيف صليب', N'01274538378', CAST(N'1982-08-08' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (489, N'نانسي سامح منير كراس تاوضروس', N'01029821369', CAST(N'2007-06-14' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (490, N'نيقولاوس ايهاب يونس طرابسلي', N'01227088629', CAST(N'2013-10-26' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (492, N'هايدي جوده جيد صالح', N'01065245096', CAST(N'2001-10-30' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (493, N'يوأنا شنوده كمال نجيب', N'01557045528', CAST(N'2011-11-05' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (494, N'يوأنا نجيب رمزي نجيب', N'01225170024', CAST(N'2009-07-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (495, N'يوساب يوسف سيدراك نسيم', N'01289121205', CAST(N'1997-06-01' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (496, N'يوستينا ايمن البير سعد', N'01211844245', CAST(N'2002-07-27' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (497, N'يوستينا جورج فريد جورجى', N'01208972320', CAST(N'2005-11-09' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (498, N'يوستينا عماد اميل جرجس', N'01009899866', CAST(N'1999-03-07' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (499, N'يوسف إيهاب الشحات عجايبي', N'01012765725', CAST(N'2010-12-12' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (500, N'يوسف بنيامين سلامه انيس', N'01018279135', CAST(N'2017-04-02' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (501, N'يوسف بولا شاكر مرقص', N'01012084765', CAST(N'2015-07-23' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (502, N'يوسف تادرس رفله تادرس', N'01276463043', CAST(N'2013-10-10' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (503, N'يوسف عماد إميل جرجس', N'01273737780', CAST(N'2012-09-13' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (504, N'يوسف مايكل  فؤاد ميخائل', N'01288105742', CAST(N'2010-04-14' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (505, N'يوسف مجدي يوسف حلمي', N'01551750190', CAST(N'2009-04-15' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (506, N'يوسف نور شاكر مرقس', N'01205101817', CAST(N'2009-04-14' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (519, N'فغعفغ', N'6666', CAST(N'2024-11-21' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (521, N'فثسف', N'666', CAST(N'7657-05-06' AS Date))
INSERT [dbo].[TBMakhdoum] ([Id], [Name], [PhoneNumber], [DateOfBirth]) VALUES (523, N'4564234124', N'456456', CAST(N'0456-05-04' AS Date))
SET IDENTITY_INSERT [dbo].[TBMakhdoum] OFF
GO
SET IDENTITY_INSERT [dbo].[TBTheStage] ON 

INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (1, N'حضانه', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (2, N'ابتدائي', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (3, N'اعدادي', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (4, N'ثانوي', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (5, N'جامعه', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (6, N'خرجين', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (7, N'قانا الجليل', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (8, N'اولي و تانيه', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (9, N'ثالته و رابعه', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (10, N'خامسه و سادسه', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (11, N'مجمع', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (12, N'عزف فردي', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (13, N'عزف جماعي', NULL, NULL)
INSERT [dbo].[TBTheStage] ([Id], [Name], [StartFrom], [EndFrom]) VALUES (14, N'الحان موهبين', NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBTheStage] OFF
GO
INSERT [dbo].[Theater] ([MakhdoumID], [StageID]) VALUES (263, 8)
INSERT [dbo].[Theater] ([MakhdoumID], [StageID]) VALUES (523, 8)
INSERT [dbo].[Theater] ([MakhdoumID], [StageID]) VALUES (277, 10)
INSERT [dbo].[Theater] ([MakhdoumID], [StageID]) VALUES (480, 10)
GO
/****** Object:  Index [IX_Alhan_StageID]    Script Date: 20-Nov-24 3:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Alhan_StageID] ON [dbo].[Alhan]
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BooksAndSaves_StageID]    Script Date: 20-Nov-24 3:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_BooksAndSaves_StageID] ON [dbo].[BooksAndSaves]
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Coptic_StageID]    Script Date: 20-Nov-24 3:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Coptic_StageID] ON [dbo].[Coptic]
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ForSingle_StageID]    Script Date: 20-Nov-24 3:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_ForSingle_StageID] ON [dbo].[ForSingle]
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Learning_StageID]    Script Date: 20-Nov-24 3:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Learning_StageID] ON [dbo].[Learning]
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tbkoral_StageID]    Script Date: 20-Nov-24 3:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tbkoral_StageID] ON [dbo].[Tbkoral]
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Theater_StageID]    Script Date: 20-Nov-24 3:58:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Theater_StageID] ON [dbo].[Theater]
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TBMakhdoum] ADD  DEFAULT ('0001-01-01') FOR [DateOfBirth]
GO
ALTER TABLE [dbo].[Alhan]  WITH CHECK ADD  CONSTRAINT [FK_Alhan_TBMakhdoum_MakhdoumID] FOREIGN KEY([MakhdoumID])
REFERENCES [dbo].[TBMakhdoum] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Alhan] CHECK CONSTRAINT [FK_Alhan_TBMakhdoum_MakhdoumID]
GO
ALTER TABLE [dbo].[Alhan]  WITH CHECK ADD  CONSTRAINT [FK_Alhan_TBTheStage_StageID] FOREIGN KEY([StageID])
REFERENCES [dbo].[TBTheStage] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Alhan] CHECK CONSTRAINT [FK_Alhan_TBTheStage_StageID]
GO
ALTER TABLE [dbo].[BooksAndSaves]  WITH CHECK ADD  CONSTRAINT [FK_BooksAndSaves_TBMakhdoum_MakhdoumID] FOREIGN KEY([MakhdoumID])
REFERENCES [dbo].[TBMakhdoum] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BooksAndSaves] CHECK CONSTRAINT [FK_BooksAndSaves_TBMakhdoum_MakhdoumID]
GO
ALTER TABLE [dbo].[BooksAndSaves]  WITH CHECK ADD  CONSTRAINT [FK_BooksAndSaves_TBTheStage_StageID] FOREIGN KEY([StageID])
REFERENCES [dbo].[TBTheStage] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BooksAndSaves] CHECK CONSTRAINT [FK_BooksAndSaves_TBTheStage_StageID]
GO
ALTER TABLE [dbo].[Coptic]  WITH CHECK ADD  CONSTRAINT [FK_Coptic_TBMakhdoum_MakhdoumID] FOREIGN KEY([MakhdoumID])
REFERENCES [dbo].[TBMakhdoum] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Coptic] CHECK CONSTRAINT [FK_Coptic_TBMakhdoum_MakhdoumID]
GO
ALTER TABLE [dbo].[Coptic]  WITH CHECK ADD  CONSTRAINT [FK_Coptic_TBTheStage_StageID] FOREIGN KEY([StageID])
REFERENCES [dbo].[TBTheStage] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Coptic] CHECK CONSTRAINT [FK_Coptic_TBTheStage_StageID]
GO
ALTER TABLE [dbo].[ForSingle]  WITH CHECK ADD  CONSTRAINT [FK_ForSingle_TBMakhdoum_MakhdoumID] FOREIGN KEY([MakhdoumID])
REFERENCES [dbo].[TBMakhdoum] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ForSingle] CHECK CONSTRAINT [FK_ForSingle_TBMakhdoum_MakhdoumID]
GO
ALTER TABLE [dbo].[ForSingle]  WITH CHECK ADD  CONSTRAINT [FK_ForSingle_TBTheStage_StageID] FOREIGN KEY([StageID])
REFERENCES [dbo].[TBTheStage] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ForSingle] CHECK CONSTRAINT [FK_ForSingle_TBTheStage_StageID]
GO
ALTER TABLE [dbo].[Learning]  WITH CHECK ADD  CONSTRAINT [FK_Learning_TBMakhdoum_MakhdoumID] FOREIGN KEY([MakhdoumID])
REFERENCES [dbo].[TBMakhdoum] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Learning] CHECK CONSTRAINT [FK_Learning_TBMakhdoum_MakhdoumID]
GO
ALTER TABLE [dbo].[Learning]  WITH CHECK ADD  CONSTRAINT [FK_Learning_TBTheStage_StageID] FOREIGN KEY([StageID])
REFERENCES [dbo].[TBTheStage] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Learning] CHECK CONSTRAINT [FK_Learning_TBTheStage_StageID]
GO
ALTER TABLE [dbo].[Tbkoral]  WITH CHECK ADD  CONSTRAINT [FK_Tbkoral_TBMakhdoum_MakhdoumID] FOREIGN KEY([MakhdoumID])
REFERENCES [dbo].[TBMakhdoum] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tbkoral] CHECK CONSTRAINT [FK_Tbkoral_TBMakhdoum_MakhdoumID]
GO
ALTER TABLE [dbo].[Tbkoral]  WITH CHECK ADD  CONSTRAINT [FK_Tbkoral_TBTheStage_StageID] FOREIGN KEY([StageID])
REFERENCES [dbo].[TBTheStage] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tbkoral] CHECK CONSTRAINT [FK_Tbkoral_TBTheStage_StageID]
GO
ALTER TABLE [dbo].[Theater]  WITH CHECK ADD  CONSTRAINT [FK_Theater_TBMakhdoum_MakhdoumID] FOREIGN KEY([MakhdoumID])
REFERENCES [dbo].[TBMakhdoum] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Theater] CHECK CONSTRAINT [FK_Theater_TBMakhdoum_MakhdoumID]
GO
ALTER TABLE [dbo].[Theater]  WITH CHECK ADD  CONSTRAINT [FK_Theater_TBTheStage_StageID] FOREIGN KEY([StageID])
REFERENCES [dbo].[TBTheStage] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Theater] CHECK CONSTRAINT [FK_Theater_TBTheStage_StageID]
GO
USE [master]
GO
ALTER DATABASE [KhedmaDB] SET  READ_WRITE 
GO
