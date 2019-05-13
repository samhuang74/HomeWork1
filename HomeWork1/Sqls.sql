

----------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [Customer]
GO

/****** Object:  Table [dbo].[客戶聯絡人]    Script Date: 2019/5/13 下午 02:25:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[客戶聯絡人](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[客戶Id] [int] NOT NULL,
	[職稱] [nvarchar](50) NOT NULL,
	[姓名] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[手機] [nvarchar](50) NULL,
	[電話] [nvarchar](50) NULL,
	[是否已刪除] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[客戶聯絡人] ADD  CONSTRAINT [DF_客戶聯絡人_是否已刪除]  DEFAULT ((0)) FOR [是否已刪除]
GO

ALTER TABLE [dbo].[客戶聯絡人]  WITH CHECK ADD  CONSTRAINT [FK_客戶聯絡人_客戶資料] FOREIGN KEY([客戶Id])
REFERENCES [dbo].[客戶資料] ([Id])
GO

ALTER TABLE [dbo].[客戶聯絡人] CHECK CONSTRAINT [FK_客戶聯絡人_客戶資料]
GO

----------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [Customer]
GO

/****** Object:  Table [dbo].[客戶資料]    Script Date: 2019/5/13 下午 02:26:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[客戶資料](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[客戶名稱] [nvarchar](50) NOT NULL,
	[統一編號] [char](8) NOT NULL,
	[電話] [nvarchar](50) NOT NULL,
	[傳真] [nvarchar](50) NULL,
	[地址] [nvarchar](100) NULL,
	[Email] [nvarchar](250) NULL,
	[是否已刪除] [bit] NOT NULL,
	[客戶分類] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[客戶資料] ADD  CONSTRAINT [DF_客戶資料_是否已刪除]  DEFAULT ((0)) FOR [是否已刪除]
GO

----------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [Customer]
GO

/****** Object:  Table [dbo].[客戶銀行資訊]    Script Date: 2019/5/13 下午 02:26:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[客戶銀行資訊](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[客戶Id] [int] NOT NULL,
	[銀行名稱] [nvarchar](50) NOT NULL,
	[銀行代碼] [int] NOT NULL,
	[分行代碼] [int] NULL,
	[帳戶名稱] [nvarchar](50) NOT NULL,
	[帳戶號碼] [nvarchar](20) NOT NULL,
	[是否已刪除] [bit] NOT NULL,
 CONSTRAINT [PK_客戶銀行資訊] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[客戶銀行資訊] ADD  CONSTRAINT [DF_客戶銀行資訊_是否已刪除]  DEFAULT ((0)) FOR [是否已刪除]
GO

ALTER TABLE [dbo].[客戶銀行資訊]  WITH CHECK ADD  CONSTRAINT [FK_客戶銀行資訊_客戶資料] FOREIGN KEY([客戶Id])
REFERENCES [dbo].[客戶資料] ([Id])
GO

ALTER TABLE [dbo].[客戶銀行資訊] CHECK CONSTRAINT [FK_客戶銀行資訊_客戶資料]
GO


----------------------------------------------------------------------------------------------------------------------------------------------------------------

SELECT          Id, 客戶名稱,
                                (SELECT          COUNT(*) AS Expr1
                                  FROM               dbo.客戶聯絡人
                                  WHERE           (客戶Id = dbo.客戶資料.Id) AND (是否已刪除 = 0)) AS 聯絡人數量,
                                (SELECT          COUNT(*) AS Expr1
                                  FROM               dbo.客戶銀行資訊
                                  WHERE           (客戶Id = dbo.客戶資料.Id) AND (是否已刪除 = 0)) AS 銀行帳戶數量
FROM              dbo.客戶資料

----------------------------------------------------------------------------------------------------------------------------------------------------------------