USE [master]
GO
/****** Object:  Database [Institution]    Script Date: 4/14/2018 2:31:33 AM ******/
CREATE DATABASE [Institution]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Institution', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Institution.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Institution_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Institution_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Institution] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Institution].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Institution] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Institution] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Institution] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Institution] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Institution] SET ARITHABORT OFF 
GO
ALTER DATABASE [Institution] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Institution] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Institution] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Institution] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Institution] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Institution] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Institution] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Institution] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Institution] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Institution] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Institution] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Institution] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Institution] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Institution] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Institution] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Institution] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Institution] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Institution] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Institution] SET  MULTI_USER 
GO
ALTER DATABASE [Institution] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Institution] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Institution] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Institution] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Institution] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Institution]
GO
/****** Object:  Table [dbo].[student]    Script Date: 4/14/2018 2:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](250) NOT NULL,
	[lastName] [nvarchar](250) NOT NULL,
	[fatherName] [nvarchar](250) NOT NULL,
	[motherName] [nvarchar](250) NOT NULL,
	[dateOfBirth] [date] NOT NULL CONSTRAINT [DF_student_dateOfBirth]  DEFAULT (getdate()),
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[imageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [Institution] SET  READ_WRITE 
GO
