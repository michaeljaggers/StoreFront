/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.5026)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Suppliers]
GO
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Nicotine]
GO
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Flavors]
GO
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Shippers]
GO
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT [FK_OrderDetail_Products]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[Suppliers]
GO
/****** Object:  Table [dbo].[Shippers]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[Shippers]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[OrderDetail]
GO
/****** Object:  Table [dbo].[Nicotine]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[Nicotine]
GO
/****** Object:  Table [dbo].[Flavors]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[Flavors]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[Employees]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[Categories]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP TABLE [dbo].[__MigrationHistory]
GO
/****** Object:  Database [StoreFront]    Script Date: 5/20/2021 10:11:12 PM ******/
DROP DATABASE [StoreFront]
GO
/****** Object:  Database [StoreFront]    Script Date: 5/20/2021 10:11:12 PM ******/
CREATE DATABASE [StoreFront]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoreFront', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\StoreFront.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StoreFront_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\StoreFront_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StoreFront] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreFront].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreFront] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreFront] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreFront] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreFront] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreFront] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreFront] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StoreFront] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreFront] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreFront] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreFront] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreFront] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreFront] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreFront] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreFront] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreFront] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StoreFront] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreFront] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreFront] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreFront] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreFront] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreFront] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreFront] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreFront] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StoreFront] SET  MULTI_USER 
GO
ALTER DATABASE [StoreFront] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreFront] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreFront] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreFront] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StoreFront] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StoreFront] SET QUERY_STORE = OFF
GO
USE [StoreFront]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](20) NULL,
	[State] [nvarchar](15) NULL,
	[Zip] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Email] [nvarchar](30) NULL,
	[Phone] [nvarchar](24) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Wage] [money] NULL,
	[HireDate] [datetime] NULL,
	[DOB] [datetime] NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](20) NULL,
	[State] [nvarchar](15) NULL,
	[Zip] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Email] [nvarchar](30) NULL,
	[Phone] [nvarchar](24) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flavors]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flavors](
	[FlavorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Flavors] PRIMARY KEY CLUSTERED 
(
	[FlavorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nicotine]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nicotine](
	[NicotineID] [int] IDENTITY(1,1) NOT NULL,
	[StrengthMg] [int] NOT NULL,
 CONSTRAINT [PK_Nicotine] PRIMARY KEY CLUSTERED 
(
	[NicotineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[Discount] [real] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[ShipDate] [datetime] NULL,
	[ShipperID] [int] NULL,
	[Freight] [money] NULL,
	[ShipAddress] [nvarchar](60) NULL,
	[ShipCity] [nvarchar](20) NULL,
	[ShipState] [nvarchar](15) NULL,
	[ShipZip] [nvarchar](10) NULL,
	[ShipCountry] [nvarchar](15) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[NicotineID] [int] NULL,
	[FlavorID] [int] NULL,
	[Price] [money] NOT NULL,
	[InStockCt] [smallint] NOT NULL,
	[OnOrderCt] [smallint] NULL,
	[ReorderCt] [smallint] NULL,
	[SupplierID] [int] NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsFeatured] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shippers]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shippers](
	[ShipperID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[ContactFirst] [nvarchar](30) NULL,
	[ContactLast] [nvarchar](30) NULL,
	[Email] [nvarchar](30) NULL,
	[Phone] [nvarchar](24) NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[ShipperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 5/20/2021 10:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[Company] [nvarchar](40) NOT NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](20) NULL,
	[State] [nvarchar](15) NULL,
	[Zip] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Email] [nvarchar](30) NULL,
	[Phone] [nvarchar](24) NULL,
	[ContactFirst] [nvarchar](30) NULL,
	[ContactLast] [nvarchar](30) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202104142303207_InitialCreate', N'StoreFront.UI.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C5B6FE336167E2FB0FF41D0D36E915AB9EC0CA681DD227592DD6027178C9362DF06B4443BC248942A519904457F591FFA93FA177A2851B278D3C5566CA72850C4E2E1770E0F3F9287E4E1FCF9FB1FE31F9FC3C07AC249EA4764621F8D0E6D0B1337F27CB29CD8195D7CF7C1FEF1877F7C33BEF0C267EBE752EE84C9414D924EEC474AE353C749DD471CA27414FA6E12A5D1828EDC2874901739C78787DF3B47470E06081BB02C6BFC2923D40F71FE037E4E23E2E2986628B88E3C1CA4FC3B94CC7254EB0685388D918B27F68C4609BE4C2242470F57A342DEB6CE021F812D331C2C6C0B11125144C1D2D38714CF28082F67317C40C1FD4B8C416E818214F3169CAEC4BB36E6F09835C659552CA1DC2CA551D813F0E8847BC791ABAFE563BBF21EF8EF02FC4C5F58AB731F4EEC2B0FE79F3E4501384056783A0D12263CB1AF2B1567697C83E9A8AC382A202F1380FB1A255F4675C403AB73BD838A4DC7A343F6DF8135CD029A257842704613141C5877D93CF0DDFFE197FBE80B269393A3F9E2E4C3BBF7C83B79FF6F7CF2AEDE52682BC8091FE0D35D12C53801DBF0A26ABF6D39623D47AE5855ABD529BC025C8281615BD7E8F923264BFA0843E6F8836D5DFACFD82BBF70723D101FC61154A249063F6FB22040F30057E54EA34EF6FF06ADC7EFDE0FA2F5063DF9CBBCEB25FD30701218579F709097A68F7E5C0C2FA1BF3F7331188F21FB2DF2AB28FD3C8BB2C4658D898C22F72859622A5A377656E4ED446906353CAD4BD4FDA736B354A5B7569435689D9150AAD8F66828ED7D5DBD9D197716C7D07939B598479A08A75BAE4652FD034B905AD1E7A82B7D0834EBEF3C1B5E84C80F06980E3B68815864E12721AE5AF95304E443A4B7CD77284D6136F0FE8BD2C706D3E1CF014C9F61374B80A4338AC2F8D5B5DD3D4604DF64E19C717F7BBA06EB9AFBAFD1257261CC5D10566B63BC8F91FB25CAE805F1CE11C50FD42D01D9CF7B3FEC0E30883967AE8BD3F412C88CBD6904A176097845E8C9716F383645ED3A1C9906C80FF5F18834997E2E455731895E42894B0C62BAD8A4C9D48FD1D227DD4C2D45CDA61612ADA672B1BEA632B06E967249B3A1B940AB9D85D460D15EDE43C3877B39ECFEC77B9B2DDEA6B9A0E6C63C2AF90F26388169CCBB4394E284AC7AA0CBBCB18B6021EF3EA6F4D5D7A65CD3CF28C88656B5D668C82781E147430EBBFFA32137133E3FF91E8B4A3A6C824A6180EF24AFDF5FB58F39C9B26D0F07A199DB56BE9D39C0345CCED23472FD7C14688EBFF8E185683FC47056FB4946D11AF934041A0644F7D992075FA06DB64CAA5B728E034CB175E616C7835394BAC853DD080DF27A1856AEA81AC356A722A271DF2A3A81E938619510DB04A530527D42D561E113D78F51D0EA25A966C7258CB5BDD221979CE31813A6B0D5135D94EB0F419801951EA953DA3C34766A8C6B26A2216A35F5795B08BBEA77E56C622B9C6C899D0DBCE4F1DBAB10B3D9635B2067B34BBA18603CD0DB0541F95EA52B01E48DCBBE1154DA311908CA43AAAD1054F4D80E082ABAE4CD11B4D8A276ED7F69BFBA6FF41437CADB5FD61BDDB5036E0AFED8336A16B127D4A15003272A3DCFE7AC103F53CDE60CECE4FBB39487BA324518F80C53F1C86615EF6AE350A71944265113E08A682DA0FC2A50015206540FE3CAB3BC46EB7814D103B63C776B84E573BF045BE3808A5DBF12AD099A2F4E657276DA7D542DABD8A090BCD366A186A321843C79890DEFE014D3B9ACEA982EB1709F68B8D630DE190D0E6A895C0D4E2A1B33B8974A6AB67B491790F509C936F292143E19BC543666702F718EB63B491314F4080B367291B8840F34D8CA938E6AB5A9CAC64E912BC53F8C1D4352D5F81AC5B14F96B5242BFEC59A151956D3EF66FD138FC202C371534DFE51656DA58946095A62A9145483A5977E92D27344D11CB1739EA9172A62DAB5D530FD972AEBCBA7DA89E53A504AB3BFF9CDAAEE025F586DD57084A35C421B4316D3E4181A06E8AB5B2CED0D0528D19CDD4FA3200B8939C432D72E6EF0EAF58B2F2AC2D891EC574228C55F4AA02B3ABF53D7A8C362B06EAA6298F5BBCA0C6172781981D65D6E8A4ACD28E521551DC57470B5B3AE3305333DBB4B8E14FBF7562BC2EB8C2D9E9E5207E09F7A62D4321C14B05A5977543109A58E2996744794324DEA9052510F2BEBF9248291F582B5F00C1ED54B74D7A06690D4D1D5D2EEC89A5C923AB4A6780D6C8DCD725977544DBA491D5853DC1D7B957B224FA37BBC7A19F72F1B2C5FC52677B3F5CB80F13A73E230CB5FED2EBF0E54FBDC138BDFD62B60FCFB5EF2C9B8D3DB804FC5E9C6667C326098671FE11E5C9C7C1A2FEFCD98C2E5B630C1375DEE9BF1FAB1F655B9A16CF564914A7BB5E593B67663BECD6A7F54A3ECBB0A11DB2ADD088C7A49290E474C6034FB2598063E66537929708D88BFC0292D123AECE3C3A363E955CEFEBC9071D2D40B34DB54D33319B1CFB6909B459E50E23EA244CD94D8E015C90A543984BE221E7E9ED8BFE6B54EF3F30CF657FEF9C0BA4A1F88FF4B0605F74986ADDFD4CCCF61B2EA3BBCE3A80CFDED4D3C90E8EEF2ABFF7F2EAA1E58B7090CA753EB5072F43ADD2F3E9BE8654D5175036BD67E4CF176479BF04A418B2A8D96F51F25CC7D3AC88384D2CA7F86E8F95F7D4DD33E3AD80851F3B06028BC415C687A38B00E96F1D180073F69FE68A05F63F58F08D631CDF880C027FDC1E4E703DDA7A1B2E60ED721CD96691B5352EEE7D6F4EB8D723177BD362959DA1B0D743513BB07DCA0D9D69B85286F2C8B79B0A55393A43C18F62E79FFEA99C9FB928CBC0ADA779B83BCCDB4E3866BA5BF55B6F11EE4C769F27D769F53BC6DAE99CE80F73C31B35FE6F09E918D2FF3BBCF0FDE36D94C07C47B4EB65E59C07BC6B55DAD9F3B665AE72574E739BD6A7A92E12E47778ADC96B35B1CB9C3F67F1E01098A88B2786AA94F126B4A706D51B812312B3567A7C98A9581A3E855249AD5F66B2B5FF01B1BCB659AD51A723A9B74F3F9BF51379769D66DC894DC45B6B13657519701DE328F352551BDA5EC62A1252DC9EC6D316BE3C5FC5B4A261EC429C2E831DC2EBF9DDCE1415C32E4D0E9912BAC5E14C3DA59FB371A61FD4EFDE50A82FD8B8D04BBC2AA59C95C9145542EDE9245A5887442738D29F260493D4BA8BF402E856276009DBF15CF0FF5D835C81C7B57E436A37146A1C9389C07C281170B029AF4E709D1A2CDE3DB98FD4A87680298E9B383FB5BF253E6075E65F7A5E64CC800C1A20B7EDCCBFA92B263DFE54B857413918E40DC7D5550748FC33800B0F496CCD0135EC736A0DF47BC44EECBEA04D004D2DE11A2DBC7E73E5A26284C39C6AA3EFC040E7BE1F30F7F01C036D8B9AA540000, N'6.2.0-61023')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6ece08b3-2568-4932-9865-17a1f61d87b6', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bc891a60-6f74-4e79-8d42-47365516b39d', N'Anonymous')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'180c1a21-0544-440d-9d94-31bd10a8ae35', N'User')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e8498e25-6c8a-4d1d-bcef-6cf969a4faad', N'6ece08b3-2568-4932-9865-17a1f61d87b6')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e8498e25-6c8a-4d1d-bcef-6cf969a4faad', N'admin@michaeljaggers.net', 0, N'AL0EBzIP78HLbtMciNypaVbXKIVeaKlMW31PdRJMPHlxvSSdD8J6vGHQCA8eQ+5wTg==', N'e7798478-961a-406c-a4f0-5843cea31351', NULL, 0, 0, NULL, 1, 0, N'admin@michaeljaggers.net')
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [Name], [Image], [Description]) VALUES (0, N'Starter Kits', N'0cdd6746-e646-41f0-a088-ced655a97756.jpg', NULL)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Image], [Description]) VALUES (1, N'Accessories', N'19a60ef3-d015-4fac-91fc-082a440f3b77.jpg', NULL)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Image], [Description]) VALUES (2, N'Cartridges', N'dc8c0207-a1d4-47e0-8ac2-14663581835f.jpg', NULL)
INSERT [dbo].[Categories] ([CategoryID], [Name], [Image], [Description]) VALUES (3, N'E-Liquid', N'60c8b48d-7d04-43cf-ad15-ba6496b621c1.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Flavors] ON 

INSERT [dbo].[Flavors] ([FlavorID], [Name], [Image], [Description]) VALUES (0, N'Tobacco', N'8cb17632-269b-4250-8b7a-c25f2372c3a4.jpg', N'Sweet, smooth, flavorful tobacco straight from the farm.')
INSERT [dbo].[Flavors] ([FlavorID], [Name], [Image], [Description]) VALUES (1, N'Menthol', N'4eab3431-4d4b-47e9-b44a-8d975bd0ddd6.jpg', N'The crisp refreshing flavor of cool menthol.')
INSERT [dbo].[Flavors] ([FlavorID], [Name], [Image], [Description]) VALUES (2, N'Vanilla', N'b527ed06-1737-4455-b637-e48cdf627183.jpg', N'A dessert worth waiting for.  Nothing but ordinary.')
INSERT [dbo].[Flavors] ([FlavorID], [Name], [Image], [Description]) VALUES (3, N'Cherry', N'49aff844-869e-479b-be8b-776b41f2fb5e.jpg', N'The taste of fresh cherries in every drag.')
INSERT [dbo].[Flavors] ([FlavorID], [Name], [Image], [Description]) VALUES (4, N'Coffee', N'55016b08-302c-4835-ba41-d59cbacf48fa.jpg', N'There''s nothing like a fresh cup of joe.')
SET IDENTITY_INSERT [dbo].[Flavors] OFF
SET IDENTITY_INSERT [dbo].[Nicotine] ON 

INSERT [dbo].[Nicotine] ([NicotineID], [StrengthMg]) VALUES (0, 0)
INSERT [dbo].[Nicotine] ([NicotineID], [StrengthMg]) VALUES (1, 8)
INSERT [dbo].[Nicotine] ([NicotineID], [StrengthMg]) VALUES (2, 12)
INSERT [dbo].[Nicotine] ([NicotineID], [StrengthMg]) VALUES (3, 16)
SET IDENTITY_INSERT [dbo].[Nicotine] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [NicotineID], [FlavorID], [Price], [InStockCt], [OnOrderCt], [ReorderCt], [SupplierID], [Image], [Description], [IsFeatured]) VALUES (1, N'Smōk Starter Kit', 0, NULL, NULL, 59.9900, 2000, 0, 500, 1, N'SmokStarterKit.jpg', N'The Smok Starter Kit come with everything you need to get started vaping quickly.', 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [NicotineID], [FlavorID], [Price], [InStockCt], [OnOrderCt], [ReorderCt], [SupplierID], [Image], [Description], [IsFeatured]) VALUES (2, N'SmōkPak', 1, NULL, NULL, 11.9900, 800, 0, 200, 1, N'SmokPak.jpg', N'The original SmōkPak.  Charge your batteries on the go, up to 3 times and keep a few spare cartridges on hand.  Don''t go a night without it.', 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [NicotineID], [FlavorID], [Price], [InStockCt], [OnOrderCt], [ReorderCt], [SupplierID], [Image], [Description], [IsFeatured]) VALUES (3, N'Smōk Battery', 1, NULL, NULL, 9.9900, 1000, 1000, 500, 1, N'SmokBattery.jpg', N'Light up the night.  Featuring a 2500mAh battery and signature white LED tip.  It''ll last as long as you do.', 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Shippers] ON 

INSERT [dbo].[Shippers] ([ShipperID], [Name], [ContactFirst], [ContactLast], [Email], [Phone]) VALUES (1, N'USPS', NULL, NULL, NULL, NULL)
INSERT [dbo].[Shippers] ([ShipperID], [Name], [ContactFirst], [ContactLast], [Email], [Phone]) VALUES (2, N'FedEx', NULL, NULL, NULL, NULL)
INSERT [dbo].[Shippers] ([ShipperID], [Name], [ContactFirst], [ContactLast], [Email], [Phone]) VALUES (3, N'UPS', NULL, NULL, NULL, NULL)
INSERT [dbo].[Shippers] ([ShipperID], [Name], [ContactFirst], [ContactLast], [Email], [Phone]) VALUES (4, N'DHL', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Shippers] OFF
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([SupplierID], [Company], [Address], [City], [State], [Zip], [Country], [Email], [Phone], [ContactFirst], [ContactLast]) VALUES (1, N'JieShiBao Technology Co.', NULL, N'Shenzen', NULL, NULL, N'China', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/20/2021 10:11:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/20/2021 10:11:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/20/2021 10:11:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 5/20/2021 10:11:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 5/20/2021 10:11:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/20/2021 10:11:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Products]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Shippers] FOREIGN KEY([ShipperID])
REFERENCES [dbo].[Shippers] ([ShipperID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Shippers]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Flavors] FOREIGN KEY([FlavorID])
REFERENCES [dbo].[Flavors] ([FlavorID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Flavors]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Nicotine] FOREIGN KEY([NicotineID])
REFERENCES [dbo].[Nicotine] ([NicotineID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Nicotine]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers]
GO
ALTER DATABASE [StoreFront] SET  READ_WRITE 
GO
