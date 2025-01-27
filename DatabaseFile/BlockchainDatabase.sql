USE [master]
GO
/****** Object:  Database [Blockchain]    Script Date: 3/11/2024 8:07:23 PM ******/
CREATE DATABASE [Blockchain]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Blockchain', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\Blockchain.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Blockchain_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\Blockchain_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Blockchain] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Blockchain].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Blockchain] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Blockchain] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Blockchain] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Blockchain] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Blockchain] SET ARITHABORT OFF 
GO
ALTER DATABASE [Blockchain] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Blockchain] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Blockchain] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Blockchain] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Blockchain] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Blockchain] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Blockchain] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Blockchain] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Blockchain] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Blockchain] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Blockchain] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Blockchain] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Blockchain] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Blockchain] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Blockchain] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Blockchain] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Blockchain] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Blockchain] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Blockchain] SET  MULTI_USER 
GO
ALTER DATABASE [Blockchain] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Blockchain] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Blockchain] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Blockchain] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Blockchain] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Blockchain] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Blockchain] SET QUERY_STORE = ON
GO
ALTER DATABASE [Blockchain] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Blockchain]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/11/2024 8:07:23 PM ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 3/11/2024 8:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[PublicKey] [nvarchar](26) NOT NULL,
	[Nickname] [nvarchar](max) NULL,
	[PrivateKey] [nvarchar](26) NOT NULL,
	[Balance] [float] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[PublicKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nfts]    Script Date: 3/11/2024 8:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nfts](
	[Name] [nvarchar](max) NOT NULL,
	[CollectionKey] [nvarchar](26) NOT NULL,
	[OwnerKey] [nvarchar](26) NOT NULL,
	[Identificator] [uniqueidentifier] NOT NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Nfts] PRIMARY KEY CLUSTERED 
(
	[Identificator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SmartContracts]    Script Date: 3/11/2024 8:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmartContracts](
	[PublicKey] [nvarchar](26) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[OwnerId] [nvarchar](26) NOT NULL,
	[MaxSupply] [int] NOT NULL,
	[SupplySold] [int] NOT NULL,
	[FirstAvailableNftId] [int] NOT NULL,
	[Funds] [float] NOT NULL,
	[CollectionImageURL] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SmartContracts] PRIMARY KEY CLUSTERED 
(
	[PublicKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionContracts]    Script Date: 3/11/2024 8:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionContracts](
	[Id] [uniqueidentifier] NOT NULL,
	[FromAddress] [nvarchar](26) NOT NULL,
	[ToAddress] [nvarchar](26) NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TransactionContracts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionPurchases]    Script Date: 3/11/2024 8:07:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionPurchases](
	[Id] [uniqueidentifier] NOT NULL,
	[FromAddress] [nvarchar](26) NOT NULL,
	[ToAddress] [nvarchar](26) NOT NULL,
	[AmountExchanged] [float] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[nftId] [int] NOT NULL,
 CONSTRAINT [PK_TransactionPurchases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Nfts_CollectionKey]    Script Date: 3/11/2024 8:07:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_Nfts_CollectionKey] ON [dbo].[Nfts]
(
	[CollectionKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Nfts_OwnerKey]    Script Date: 3/11/2024 8:07:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_Nfts_OwnerKey] ON [dbo].[Nfts]
(
	[OwnerKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SmartContracts_OwnerId]    Script Date: 3/11/2024 8:07:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_SmartContracts_OwnerId] ON [dbo].[SmartContracts]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TransactionContracts_FromAddress]    Script Date: 3/11/2024 8:07:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransactionContracts_FromAddress] ON [dbo].[TransactionContracts]
(
	[FromAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TransactionContracts_ToAddress]    Script Date: 3/11/2024 8:07:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransactionContracts_ToAddress] ON [dbo].[TransactionContracts]
(
	[ToAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TransactionPurchases_FromAddress]    Script Date: 3/11/2024 8:07:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransactionPurchases_FromAddress] ON [dbo].[TransactionPurchases]
(
	[FromAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TransactionPurchases_ToAddress]    Script Date: 3/11/2024 8:07:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransactionPurchases_ToAddress] ON [dbo].[TransactionPurchases]
(
	[ToAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Nfts] ADD  DEFAULT (N'') FOR [OwnerKey]
GO
ALTER TABLE [dbo].[Nfts] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [Identificator]
GO
ALTER TABLE [dbo].[Nfts] ADD  DEFAULT ((0)) FOR [Id]
GO
ALTER TABLE [dbo].[SmartContracts] ADD  DEFAULT ((0)) FOR [FirstAvailableNftId]
GO
ALTER TABLE [dbo].[SmartContracts] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Funds]
GO
ALTER TABLE [dbo].[SmartContracts] ADD  DEFAULT (N'') FOR [CollectionImageURL]
GO
ALTER TABLE [dbo].[TransactionPurchases] ADD  DEFAULT ((0)) FOR [nftId]
GO
ALTER TABLE [dbo].[Nfts]  WITH CHECK ADD  CONSTRAINT [FK_Nfts_Accounts_OwnerKey] FOREIGN KEY([OwnerKey])
REFERENCES [dbo].[Accounts] ([PublicKey])
GO
ALTER TABLE [dbo].[Nfts] CHECK CONSTRAINT [FK_Nfts_Accounts_OwnerKey]
GO
ALTER TABLE [dbo].[Nfts]  WITH CHECK ADD  CONSTRAINT [FK_Nfts_SmartContracts_CollectionKey] FOREIGN KEY([CollectionKey])
REFERENCES [dbo].[SmartContracts] ([PublicKey])
GO
ALTER TABLE [dbo].[Nfts] CHECK CONSTRAINT [FK_Nfts_SmartContracts_CollectionKey]
GO
ALTER TABLE [dbo].[SmartContracts]  WITH CHECK ADD  CONSTRAINT [FK_SmartContracts_Accounts_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Accounts] ([PublicKey])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SmartContracts] CHECK CONSTRAINT [FK_SmartContracts_Accounts_OwnerId]
GO
ALTER TABLE [dbo].[TransactionContracts]  WITH CHECK ADD  CONSTRAINT [FK_TransactionContracts_Accounts_FromAddress] FOREIGN KEY([FromAddress])
REFERENCES [dbo].[Accounts] ([PublicKey])
GO
ALTER TABLE [dbo].[TransactionContracts] CHECK CONSTRAINT [FK_TransactionContracts_Accounts_FromAddress]
GO
ALTER TABLE [dbo].[TransactionContracts]  WITH CHECK ADD  CONSTRAINT [FK_TransactionContracts_SmartContracts_ToAddress] FOREIGN KEY([ToAddress])
REFERENCES [dbo].[SmartContracts] ([PublicKey])
GO
ALTER TABLE [dbo].[TransactionContracts] CHECK CONSTRAINT [FK_TransactionContracts_SmartContracts_ToAddress]
GO
ALTER TABLE [dbo].[TransactionPurchases]  WITH CHECK ADD  CONSTRAINT [FK_TransactionPurchases_Accounts_ToAddress] FOREIGN KEY([ToAddress])
REFERENCES [dbo].[Accounts] ([PublicKey])
GO
ALTER TABLE [dbo].[TransactionPurchases] CHECK CONSTRAINT [FK_TransactionPurchases_Accounts_ToAddress]
GO
ALTER TABLE [dbo].[TransactionPurchases]  WITH CHECK ADD  CONSTRAINT [FK_TransactionPurchases_SmartContracts_FromAddress] FOREIGN KEY([FromAddress])
REFERENCES [dbo].[SmartContracts] ([PublicKey])
GO
ALTER TABLE [dbo].[TransactionPurchases] CHECK CONSTRAINT [FK_TransactionPurchases_SmartContracts_FromAddress]
GO
USE [master]
GO
ALTER DATABASE [Blockchain] SET  READ_WRITE 
GO
