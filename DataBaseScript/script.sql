USE [master]
GO
/****** Object:  Database [RomashkaDB]    Script Date: 25.09.2020 1:28:20 ******/
CREATE DATABASE [RomashkaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RomashkaDB', FILENAME = N'C:\Users\iliyp\RomashkaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RomashkaDB_log', FILENAME = N'C:\Users\iliyp\RomashkaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RomashkaDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RomashkaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RomashkaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RomashkaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RomashkaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RomashkaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RomashkaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RomashkaDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RomashkaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RomashkaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RomashkaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RomashkaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RomashkaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RomashkaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RomashkaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RomashkaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RomashkaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RomashkaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RomashkaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RomashkaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RomashkaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RomashkaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RomashkaDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [RomashkaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RomashkaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RomashkaDB] SET  MULTI_USER 
GO
ALTER DATABASE [RomashkaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RomashkaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RomashkaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RomashkaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RomashkaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RomashkaDB] SET QUERY_STORE = OFF
GO
USE [RomashkaDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [RomashkaDB]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 25.09.2020 1:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ContractStatusStatus] [nvarchar](450) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractStatuses]    Script Date: 25.09.2020 1:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractStatuses](
	[Status] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ContractStatuses] PRIMARY KEY CLUSTERED 
(
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.09.2020 1:28:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Login] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([Id], [Name], [ContractStatusStatus]) VALUES (1016, N'Моя Компания', N'Расторгнут')
GO
INSERT [dbo].[Companies] ([Id], [Name], [ContractStatusStatus]) VALUES (1017, N'Моя Компания1', N'Расторгнут')
GO
INSERT [dbo].[Companies] ([Id], [Name], [ContractStatusStatus]) VALUES (1018, N'Еще одна компания', N'Еще не заключен')
GO
INSERT [dbo].[Companies] ([Id], [Name], [ContractStatusStatus]) VALUES (1019, N'Снова еще компания', N'Расторгнут')
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
INSERT [dbo].[ContractStatuses] ([Status]) VALUES (N'Еще не заключен')
GO
INSERT [dbo].[ContractStatuses] ([Status]) VALUES (N'Заключен')
GO
INSERT [dbo].[ContractStatuses] ([Status]) VALUES (N'Расторгнут')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [CompanyId]) VALUES (1007, N'Илия', N'iliya', N'iliyaaaaaching1218', 1016)
GO
INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [CompanyId]) VALUES (1008, N'Филипп', N'gera', N'grra12', 1018)
GO
INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [CompanyId]) VALUES (1009, N'Гена', N'fifa', N'fifa1217', 1018)
GO
INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [CompanyId]) VALUES (1010, N'Генорий', N'genov', N'iliy1217', 1017)
GO
INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [CompanyId]) VALUES (1011, N'Настя', N'nasty', N'nasty4092', 1016)
GO
INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [CompanyId]) VALUES (1012, N'Виктор', N'victor', N'vic432', 1016)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Companies_ContractStatusStatus]    Script Date: 25.09.2020 1:28:21 ******/
CREATE NONCLUSTERED INDEX [IX_Companies_ContractStatusStatus] ON [dbo].[Companies]
(
	[ContractStatusStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_CompanyId]    Script Date: 25.09.2020 1:28:21 ******/
CREATE NONCLUSTERED INDEX [IX_Users_CompanyId] ON [dbo].[Users]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_ContractStatuses_ContractStatusStatus] FOREIGN KEY([ContractStatusStatus])
REFERENCES [dbo].[ContractStatuses] ([Status])
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_Companies_ContractStatuses_ContractStatusStatus]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Companies_CompanyId]
GO
USE [master]
GO
ALTER DATABASE [RomashkaDB] SET  READ_WRITE 
GO
