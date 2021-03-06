USE [master]
GO
/****** Object:  Database [EnterSpaceDB2]    Script Date: 4.6.2015. 3:04:40 ******/
CREATE DATABASE [EnterSpaceDB2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EnterSpaceDB2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EnterSpaceDB2.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EnterSpaceDB2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EnterSpaceDB2_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EnterSpaceDB2] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EnterSpaceDB2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EnterSpaceDB2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET ARITHABORT OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EnterSpaceDB2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EnterSpaceDB2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EnterSpaceDB2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EnterSpaceDB2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EnterSpaceDB2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EnterSpaceDB2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EnterSpaceDB2] SET  MULTI_USER 
GO
ALTER DATABASE [EnterSpaceDB2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EnterSpaceDB2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EnterSpaceDB2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EnterSpaceDB2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EnterSpaceDB2] SET DELAYED_DURABILITY = DISABLED 
GO
USE [EnterSpaceDB2]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Atrakcija]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atrakcija](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NULL,
	[Opis] [nvarchar](max) NULL,
	[Cijena] [decimal](18, 2) NOT NULL,
	[VrijemeDesavanja] [datetime] NOT NULL,
	[Dan] [int] NOT NULL,
	[Ponuda_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Atrakcija] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Izvjestaj]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Izvjestaj](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DatumKreiranja] [datetime] NOT NULL,
	[Kreator_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Izvjestaj] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Karta]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Karta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DatumPlacanja] [datetime] NOT NULL,
	[Rezervacija_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Karta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Klijent]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klijent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](max) NULL,
	[Prezime] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Broj_telefona] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[DatumRegistracije] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Klijent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menadzer]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menadzer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](max) NULL,
	[Prezime] [nvarchar](max) NULL,
	[UserM] [nvarchar](max) NULL,
	[PassM] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Menadzer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Narudzbenica]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Narudzbenica](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime] NOT NULL,
	[Destinacija] [nvarchar](max) NULL,
	[BrojPutnika] [int] NOT NULL,
	[TipOpreme] [nvarchar](max) NULL,
	[PoslovniSaradnik_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Narudzbenica] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OglasZaPosao]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OglasZaPosao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NULL,
	[Opis] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.OglasZaPosao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Planeta]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planeta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Planeta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ponuda]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ponuda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NULL,
	[Opis] [nvarchar](max) NULL,
	[Smjestaj] [nvarchar](max) NULL,
	[TrajanjeDana] [int] NOT NULL,
	[Cijena] [decimal](18, 2) NOT NULL,
	[Kapacitet] [int] NOT NULL,
	[datumPolaska] [datetime] NOT NULL,
	[Planeta_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Ponuda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Poslovnisaradnik]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poslovnisaradnik](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Jib] [nvarchar](max) NULL,
	[Naziv] [nvarchar](max) NULL,
	[TipOpreme] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Poslovnisaradnik] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prijavnica]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prijavnica](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DatumPrijave] [datetime] NOT NULL,
	[Kandidat] [nvarchar](max) NULL,
	[Cv] [nvarchar](max) NULL,
	[Oglas_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Prijavnica] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recenzija]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recenzija](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrojcanaOcjena] [decimal](18, 2) NOT NULL,
	[Tekst] [nvarchar](max) NULL,
	[Ponuda_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Recenzija] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rezervacija]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rezervacija](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DatumRezervacije] [datetime] NOT NULL,
	[DatumPolaska] [datetime] NOT NULL,
	[Klijent_Id] [int] NULL,
	[Ponuda_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Rezervacija] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Uposlenik]    Script Date: 4.6.2015. 3:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uposlenik](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](max) NULL,
	[Prezime] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Broj_telefona] [nvarchar](max) NULL,
	[RadnoMjesto] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Uposlenik] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_Ponuda_Id]    Script Date: 4.6.2015. 3:04:40 ******/
CREATE NONCLUSTERED INDEX [IX_Ponuda_Id] ON [dbo].[Atrakcija]
(
	[Ponuda_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Kreator_Id]    Script Date: 4.6.2015. 3:04:40 ******/
CREATE NONCLUSTERED INDEX [IX_Kreator_Id] ON [dbo].[Izvjestaj]
(
	[Kreator_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rezervacija_Id]    Script Date: 4.6.2015. 3:04:40 ******/
CREATE NONCLUSTERED INDEX [IX_Rezervacija_Id] ON [dbo].[Karta]
(
	[Rezervacija_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PoslovniSaradnik_Id]    Script Date: 4.6.2015. 3:04:40 ******/
CREATE NONCLUSTERED INDEX [IX_PoslovniSaradnik_Id] ON [dbo].[Narudzbenica]
(
	[PoslovniSaradnik_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Planeta_Id]    Script Date: 4.6.2015. 3:04:40 ******/
CREATE NONCLUSTERED INDEX [IX_Planeta_Id] ON [dbo].[Ponuda]
(
	[Planeta_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Oglas_Id]    Script Date: 4.6.2015. 3:04:40 ******/
CREATE NONCLUSTERED INDEX [IX_Oglas_Id] ON [dbo].[Prijavnica]
(
	[Oglas_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ponuda_Id]    Script Date: 4.6.2015. 3:04:40 ******/
CREATE NONCLUSTERED INDEX [IX_Ponuda_Id] ON [dbo].[Recenzija]
(
	[Ponuda_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Klijent_Id]    Script Date: 4.6.2015. 3:04:40 ******/
CREATE NONCLUSTERED INDEX [IX_Klijent_Id] ON [dbo].[Rezervacija]
(
	[Klijent_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ponuda_Id]    Script Date: 4.6.2015. 3:04:40 ******/
CREATE NONCLUSTERED INDEX [IX_Ponuda_Id] ON [dbo].[Rezervacija]
(
	[Ponuda_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Atrakcija]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Atrakcija_dbo.Ponuda_Ponuda_Id] FOREIGN KEY([Ponuda_Id])
REFERENCES [dbo].[Ponuda] ([Id])
GO
ALTER TABLE [dbo].[Atrakcija] CHECK CONSTRAINT [FK_dbo.Atrakcija_dbo.Ponuda_Ponuda_Id]
GO
ALTER TABLE [dbo].[Izvjestaj]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Izvjestaj_dbo.Uposlenik_Kreator_Id] FOREIGN KEY([Kreator_Id])
REFERENCES [dbo].[Uposlenik] ([Id])
GO
ALTER TABLE [dbo].[Izvjestaj] CHECK CONSTRAINT [FK_dbo.Izvjestaj_dbo.Uposlenik_Kreator_Id]
GO
ALTER TABLE [dbo].[Karta]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Karta_dbo.Rezervacija_Rezervacija_Id] FOREIGN KEY([Rezervacija_Id])
REFERENCES [dbo].[Rezervacija] ([Id])
GO
ALTER TABLE [dbo].[Karta] CHECK CONSTRAINT [FK_dbo.Karta_dbo.Rezervacija_Rezervacija_Id]
GO
ALTER TABLE [dbo].[Narudzbenica]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Narudzbenica_dbo.Poslovnisaradnik_PoslovniSaradnik_Id] FOREIGN KEY([PoslovniSaradnik_Id])
REFERENCES [dbo].[Poslovnisaradnik] ([Id])
GO
ALTER TABLE [dbo].[Narudzbenica] CHECK CONSTRAINT [FK_dbo.Narudzbenica_dbo.Poslovnisaradnik_PoslovniSaradnik_Id]
GO
ALTER TABLE [dbo].[Ponuda]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Ponuda_dbo.Planeta_Planeta_Id] FOREIGN KEY([Planeta_Id])
REFERENCES [dbo].[Planeta] ([Id])
GO
ALTER TABLE [dbo].[Ponuda] CHECK CONSTRAINT [FK_dbo.Ponuda_dbo.Planeta_Planeta_Id]
GO
ALTER TABLE [dbo].[Prijavnica]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Prijavnica_dbo.OglasZaPosao_Oglas_Id] FOREIGN KEY([Oglas_Id])
REFERENCES [dbo].[OglasZaPosao] ([Id])
GO
ALTER TABLE [dbo].[Prijavnica] CHECK CONSTRAINT [FK_dbo.Prijavnica_dbo.OglasZaPosao_Oglas_Id]
GO
ALTER TABLE [dbo].[Recenzija]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Recenzija_dbo.Ponuda_Ponuda_Id] FOREIGN KEY([Ponuda_Id])
REFERENCES [dbo].[Ponuda] ([Id])
GO
ALTER TABLE [dbo].[Recenzija] CHECK CONSTRAINT [FK_dbo.Recenzija_dbo.Ponuda_Ponuda_Id]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Rezervacija_dbo.Klijent_Klijent_Id] FOREIGN KEY([Klijent_Id])
REFERENCES [dbo].[Klijent] ([Id])
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [FK_dbo.Rezervacija_dbo.Klijent_Klijent_Id]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Rezervacija_dbo.Ponuda_Ponuda_Id] FOREIGN KEY([Ponuda_Id])
REFERENCES [dbo].[Ponuda] ([Id])
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [FK_dbo.Rezervacija_dbo.Ponuda_Ponuda_Id]
GO
USE [master]
GO
ALTER DATABASE [EnterSpaceDB2] SET  READ_WRITE 
GO
