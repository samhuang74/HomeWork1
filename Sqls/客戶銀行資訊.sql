USE [Customer]
GO

/****** Object:  Table [dbo].[客戶銀行資訊]    Script Date: 2019/6/10 上午 08:38:00 ******/
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


