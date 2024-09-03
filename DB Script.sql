USE [master]
GO

/****** Object:  Database [PersonDatabase]    Script Date: 25-11-2022 20:32:04 ******/
CREATE DATABASE [PersonDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PersonDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PersonDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PersonDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PersonDatabase] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PersonDatabase] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PersonDatabase] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PersonDatabase] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PersonDatabase] SET ARITHABORT OFF 
GO

ALTER DATABASE [PersonDatabase] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PersonDatabase] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PersonDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PersonDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PersonDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PersonDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PersonDatabase] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PersonDatabase] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PersonDatabase] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PersonDatabase] SET  ENABLE_BROKER 
GO

ALTER DATABASE [PersonDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PersonDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PersonDatabase] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PersonDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PersonDatabase] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PersonDatabase] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [PersonDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PersonDatabase] SET RECOVERY FULL 
GO

ALTER DATABASE [PersonDatabase] SET  MULTI_USER 
GO

ALTER DATABASE [PersonDatabase] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PersonDatabase] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PersonDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [PersonDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [PersonDatabase] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [PersonDatabase] SET QUERY_STORE = OFF
GO

ALTER DATABASE [PersonDatabase] SET  READ_WRITE 
GO

