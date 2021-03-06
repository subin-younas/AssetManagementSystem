USE [master]
GO
/****** Object:  Database [AssetManagement]    Script Date: 27-11-2021 17:57:15 ******/
CREATE DATABASE [AssetManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AssetManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AssetManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AssetManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AssetManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AssetManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AssetManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AssetManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AssetManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AssetManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AssetManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AssetManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [AssetManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AssetManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AssetManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AssetManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AssetManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AssetManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AssetManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AssetManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AssetManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AssetManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AssetManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AssetManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AssetManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AssetManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AssetManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AssetManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AssetManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AssetManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AssetManagement] SET  MULTI_USER 
GO
ALTER DATABASE [AssetManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AssetManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AssetManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AssetManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AssetManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AssetManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AssetManagement] SET QUERY_STORE = OFF
GO
USE [AssetManagement]
GO
/****** Object:  Table [dbo].[AssetDefinition]    Script Date: 27-11-2021 17:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetDefinition](
	[ad_id] [int] IDENTITY(1,1) NOT NULL,
	[ad_name] [varchar](20) NULL,
	[ad_type_id] [int] NULL,
	[ad_class] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ad_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetMaster]    Script Date: 27-11-2021 17:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetMaster](
	[am_id] [int] IDENTITY(1,1) NOT NULL,
	[am_model] [varchar](20) NULL,
	[am_snumber] [varchar](20) NULL,
	[am_type_id] [int] NULL,
	[am_make_id] [int] NULL,
	[am_ad_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[am_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetType]    Script Date: 27-11-2021 17:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetType](
	[at_id] [int] IDENTITY(1,1) NOT NULL,
	[at_name] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[at_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 27-11-2021 17:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[l_id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
	[UserType] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[l_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRegistration]    Script Date: 27-11-2021 17:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRegistration](
	[u_id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](20) NULL,
	[LastName] [varchar](20) NULL,
	[Age] [int] NULL,
	[Gender] [varchar](20) NULL,
	[Address] [varchar](20) NULL,
	[PhoneNumber] [int] NULL,
	[l_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[u_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 27-11-2021 17:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[vd_id] [int] IDENTITY(1,1) NOT NULL,
	[vd_name] [varchar](20) NULL,
	[vd_type] [varchar](20) NULL,
	[vd_atype_id] [int] NULL,
	[vd_from] [date] NULL,
	[vd_to] [date] NULL,
	[vd_addr] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[vd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssetDefinition]  WITH CHECK ADD FOREIGN KEY([ad_type_id])
REFERENCES [dbo].[AssetType] ([at_id])
GO
ALTER TABLE [dbo].[AssetMaster]  WITH CHECK ADD FOREIGN KEY([am_ad_id])
REFERENCES [dbo].[AssetDefinition] ([ad_id])
GO
ALTER TABLE [dbo].[AssetMaster]  WITH CHECK ADD FOREIGN KEY([am_make_id])
REFERENCES [dbo].[Vendor] ([vd_id])
GO
ALTER TABLE [dbo].[AssetMaster]  WITH CHECK ADD FOREIGN KEY([am_type_id])
REFERENCES [dbo].[AssetType] ([at_id])
GO
ALTER TABLE [dbo].[UserRegistration]  WITH CHECK ADD FOREIGN KEY([l_id])
REFERENCES [dbo].[Login] ([l_id])
GO
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD FOREIGN KEY([vd_atype_id])
REFERENCES [dbo].[AssetType] ([at_id])
GO
USE [master]
GO
ALTER DATABASE [AssetManagement] SET  READ_WRITE 
GO
