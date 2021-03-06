USE [master]
GO
/****** Object:  Database [VehicleStore]    Script Date: 03-Oct-21 18:35:13 ******/
CREATE DATABASE [VehicleStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRetailStore', FILENAME = N'D:\Projekti\Mono\CarRetailStoreTestProject\Database\CarRetailStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRetailStore_log', FILENAME = N'D:\Projekti\Mono\CarRetailStoreTestProject\Database\CarRetailStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [VehicleStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VehicleStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VehicleStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VehicleStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VehicleStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VehicleStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VehicleStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [VehicleStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VehicleStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VehicleStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VehicleStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VehicleStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VehicleStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VehicleStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VehicleStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VehicleStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VehicleStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VehicleStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VehicleStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VehicleStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VehicleStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VehicleStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VehicleStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VehicleStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VehicleStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VehicleStore] SET  MULTI_USER 
GO
ALTER DATABASE [VehicleStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VehicleStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VehicleStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VehicleStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VehicleStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VehicleStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [VehicleStore] SET QUERY_STORE = OFF
GO
USE [VehicleStore]
GO
/****** Object:  Table [dbo].[VehicleMakes]    Script Date: 03-Oct-21 18:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleMakes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](5) NULL,
 CONSTRAINT [PK_VehicleMake] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleModels]    Script Date: 03-Oct-21 18:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleModels](
	[Id] [uniqueidentifier] NOT NULL,
	[MakeId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](5) NULL,
 CONSTRAINT [PK_VehicleModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[VehicleModels]  WITH CHECK ADD FOREIGN KEY([MakeId])
REFERENCES [dbo].[VehicleMakes] ([Id])
GO
USE [master]
GO
ALTER DATABASE [VehicleStore] SET  READ_WRITE 
GO
