USE [master]
GO
/****** Object:  Database [STMDotNetCore]    Script Date: 4/29/2024 10:57:36 AM ******/
CREATE DATABASE [STMDotNetCore] ON  PRIMARY 
( NAME = N'STMDotNetCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER2022\MSSQL\DATA\STMDotNetCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'STMDotNetCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER2022\MSSQL\DATA\STMDotNetCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STMDotNetCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STMDotNetCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STMDotNetCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STMDotNetCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STMDotNetCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STMDotNetCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [STMDotNetCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STMDotNetCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STMDotNetCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STMDotNetCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STMDotNetCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STMDotNetCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STMDotNetCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STMDotNetCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STMDotNetCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STMDotNetCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [STMDotNetCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STMDotNetCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STMDotNetCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STMDotNetCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STMDotNetCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STMDotNetCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STMDotNetCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STMDotNetCore] SET RECOVERY FULL 
GO
ALTER DATABASE [STMDotNetCore] SET  MULTI_USER 
GO
ALTER DATABASE [STMDotNetCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STMDotNetCore] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'STMDotNetCore', N'ON'
GO
USE [STMDotNetCore]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 4/29/2024 10:57:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (5, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (7, N'T1', N'A1', N'C1')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (10, N'test title 8', N'test author 8', N'test content 8')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (11, N'T2', N'A2', N'C2')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
GO
USE [master]
GO
ALTER DATABASE [STMDotNetCore] SET  READ_WRITE 
GO
