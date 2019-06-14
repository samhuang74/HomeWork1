USE [Customer]
GO

/****** Object:  Table [dbo].[客戶資料]    Script Date: 2019/6/10 上午 08:37:38 ******/
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
	[帳號] [nvarchar](50) NOT NULL,
	[密碼] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[客戶資料] ADD  CONSTRAINT [DF_客戶資料_是否已刪除]  DEFAULT ((0)) FOR [是否已刪除]
GO


