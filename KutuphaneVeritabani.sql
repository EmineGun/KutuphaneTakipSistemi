USE [master]
GO
/****** Object:  Database [kutuphane]    Script Date: 27.05.2016 17:45:38 ******/
CREATE DATABASE [kutuphane]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kutuphane', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\kutuphane.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'kutuphane_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\kutuphane_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [kutuphane] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kutuphane].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kutuphane] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kutuphane] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kutuphane] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kutuphane] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kutuphane] SET ARITHABORT OFF 
GO
ALTER DATABASE [kutuphane] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kutuphane] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [kutuphane] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kutuphane] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kutuphane] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kutuphane] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kutuphane] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kutuphane] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kutuphane] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kutuphane] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kutuphane] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kutuphane] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kutuphane] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kutuphane] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kutuphane] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kutuphane] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kutuphane] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kutuphane] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kutuphane] SET RECOVERY FULL 
GO
ALTER DATABASE [kutuphane] SET  MULTI_USER 
GO
ALTER DATABASE [kutuphane] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kutuphane] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kutuphane] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kutuphane] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'kutuphane', N'ON'
GO
USE [kutuphane]
GO
/****** Object:  StoredProcedure [dbo].[arama]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[arama] 
@Ad varchar(50),
@Soyad varchar(50),
@Sinif varchar(50)

as
begin
select *from kisiler where ad  LIKE '%' + @Ad + '%' and  soyad  LIKE '%' + @Soyad + '%' and sinif  LIKE '%' + @Sinif + '%' 

end
GO
/****** Object:  StoredProcedure [dbo].[aramaKitap]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[aramaKitap]
@barkodNo varchar(50),
@kitapAdi varchar(255),
@kitapYazari varchar(255),
@yayinEvi varchar(255)
as
begin
select *from kitaplar where barkod_no  LIKE '%' + @barkodNo + '%' and  kitap_adi  LIKE '%' + @kitapAdi + '%' and yazar_adi  LIKE '%' + @kitapYazari + '%' and yayin_evi  LIKE '%' + @yayinEvi + '%' 

end
GO
/****** Object:  StoredProcedure [dbo].[emanetArama]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[emanetArama]
@Ad varchar(50),

@kitapAdi varchar(255)

as
begin
select*from emanetkitaplar where ad like '%' + @Ad + '%' and kitap_adi like '%' + @kitapAdi + '%'

end
GO
/****** Object:  StoredProcedure [dbo].[emanetAramaDeneme]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[emanetAramaDeneme]
@Ad varchar(50),

@kitapAdi varchar(255),
@yazarAdi varchar(255)
as
begin
select kisiler.ad,kisiler.okul_no,kitaplar.kitap_adi,kitaplar.yazar_adi from emanetkitaplar left join kisiler   on kisiler.ad like '%' + @Ad + '%'  left join kitaplar on ( kitaplar.kitap_adi like '%' + @kitapAdi + '%' and  kitaplar.yazar_adi like '%' + @yazarAdi + '%')

end
GO
/****** Object:  StoredProcedure [dbo].[emanetkitapEkleme]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[emanetkitapEkleme]

@ad varchar(50),

@kitapAdi varchar(255),
@baslangicTarihi datetime,
@bitisTarihi datetime,
@okuduguKitap int,
@emanetKitap int
as
begin
insert into emanetkitaplar(ad,kitap_adi,baslangic_tarihi,bitistarihi,okuduguKitapSayisi,emanetKitapSayisi) values(@ad,@kitapAdi,@baslangicTarihi,@bitisTarihi,@okuduguKitap,@emanetKitap)
end
GO
/****** Object:  StoredProcedure [dbo].[emanetTarihiGecenKitaplar]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[emanetTarihiGecenKitaplar]

as
begin
select * from emanetkitaplar where bitistarihi- baslangic_tarihi>15
end
GO
/****** Object:  StoredProcedure [dbo].[kisiekleme]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[kisiekleme]
@tc int,
@ad varchar(50),
@soyad varchar(50),
@okulno int,
@sinif varchar(50),
@dogumtarihi datetime,
@dogumyeri varchar(50),
@tel varchar(50),
@eposta varchar(50),
@uyeliktarih datetime,
@cinsiyet varchar(50),
@adres varchar(255),
@resimyolu varchar(255)
as
begin
IF (SELECT COUNT(*) FROM kisiler WHERE TC= @tc) < 1 begin
insert into kisiler(TC,ad,soyad,okul_no,sinif,dogum_tarihi,dogum_yeri,telefon,eposta,uyelik_tarihi,cinsiyet,adres,resim_yolu)
values(@tc,@ad,@soyad,@okulno,@sinif,@dogumtarihi,@dogumyeri,@tel,@eposta,@uyeliktarih,@cinsiyet,@adres,@resimyolu)

end
end

GO
/****** Object:  StoredProcedure [dbo].[kitapekleme]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[kitapekleme]
@barkod varchar(50),
@kitap_adi varchar(255),
@yazar_adi varchar(255),
@yayin_evi varchar(255),
@kitap_turu varchar(255),
@temin_bicimi varchar(255),
@temin_tarihi datetime,
@stok_sayisi int ,

@dosyayolu varchar(50)
as
begin
IF (SELECT COUNT(*) FROM kitaplar WHERE barkod_no= @barkod) < 1 begin
insert into kitaplar(barkod_no,kitap_adi,yazar_adi,yayin_evi,kitap_turu,temin_bicimi,temin_tarihi,stok_sayisi,dosyayolu)
values(@barkod,@kitap_adi,@yazar_adi,@yayin_evi,@kitap_turu,@temin_bicimi,@temin_tarihi,@stok_sayisi,@dosyayolu)


end
end
GO
/****** Object:  StoredProcedure [dbo].[resimGetir]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[resimGetir]
@ID int
as
begin
select resim_yolu from kisiler where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[teslim]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[teslim]
@AdSoyad varchar(255),
@kitapAdi varchar(50),
@teslimTarihi datetime,
@hasarDurum varchar(50)

as
begin
insert into teslimalma(AdSoyad,kitapAdi,teslimTarih,hasarDurum)values(@AdSoyad,@kitapAdi,@teslimTarihi,@hasarDurum)
end
GO
/****** Object:  StoredProcedure [dbo].[teslimAlmaEmanetAzaltma]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[teslimAlmaEmanetAzaltma]
@ad varchar(50),

@kitapAdi varchar(255)
as
begin 
delete from emanetkitaplar where ad=@ad and kitap_adi=@kitapAdi
end
GO
/****** Object:  StoredProcedure [dbo].[tumTablolarGetir]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tumTablolarGetir]

@no int

as
begin 
select ks.ad,ks.soyad,ks.okul_no,kp.kitap_adi,kp.yazar_adi from emanetkitaplar as e left join kisiler as ks on e.ad=ks.ad  left join kitaplar as kp on(e.kitap_adi=kp.kitap_adi) where  ks.okul_no=@no 

end

GO
/****** Object:  Table [dbo].[emanetkitaplar]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[emanetkitaplar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [varchar](50) NULL,
	[kitap_adi] [varchar](255) NULL,
	[baslangic_tarihi] [datetime] NULL,
	[bitistarihi] [datetime] NULL,
	[okuduguKitapSayisi] [int] NULL,
	[emanetKitapSayisi] [int] NULL,
 CONSTRAINT [PK_emanetkitaplar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kisiler]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kisiler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TC] [int] NULL,
	[ad] [varchar](50) NULL,
	[soyad] [varchar](50) NULL,
	[okul_no] [int] NULL,
	[sinif] [varchar](50) NULL,
	[dogum_tarihi] [datetime] NULL,
	[dogum_yeri] [varchar](50) NULL,
	[telefon] [varchar](50) NULL,
	[eposta] [varchar](50) NULL,
	[uyelik_tarihi] [datetime] NULL,
	[cinsiyet] [varchar](50) NULL,
	[adres] [varchar](255) NULL,
	[resim] [image] NULL,
	[resim_yolu] [varchar](255) NULL,
 CONSTRAINT [PK_kisiler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kitaplar]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kitaplar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[barkod_no] [varchar](50) NOT NULL,
	[kitap_adi] [varchar](255) NULL,
	[yazar_adi] [varchar](255) NULL,
	[yayin_evi] [varchar](255) NULL,
	[kitap_turu] [varchar](255) NULL,
	[temin_bicimi] [varchar](255) NULL,
	[temin_tarihi] [datetime] NULL,
	[stok_sayisi] [int] NOT NULL,
	[resim] [image] NULL,
	[dosyayolu] [varchar](50) NULL,
 CONSTRAINT [PK_kitaplar_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kitapsayisi]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kitapsayisi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[kitapsayisi] [int] NULL,
 CONSTRAINT [PK_kitapsayisi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[teslimalma]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[teslimalma](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](255) NULL,
	[kitapAdi] [varchar](50) NULL,
	[teslimTarih] [datetime] NULL,
	[hasarDurum] [varchar](50) NULL,
 CONSTRAINT [PK_teslimalma] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[uyesayisi]    Script Date: 27.05.2016 17:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uyesayisi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[uyeSayisi] [int] NULL,
 CONSTRAINT [PK_uyesayisi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [kutuphane] SET  READ_WRITE 
GO
