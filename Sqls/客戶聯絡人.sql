USE [Customer]
GO

/****** Object:  Table [dbo].[客戶聯絡人]    Script Date: 2019/6/10 上午 08:37:15 ******/
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


