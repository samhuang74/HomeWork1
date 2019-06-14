USE [Customer]
GO

/****** Object:  Table [dbo].[�Ȥ��p���H]    Script Date: 2019/6/10 �W�� 08:37:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[�Ȥ��p���H](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[�Ȥ�Id] [int] NOT NULL,
	[¾��] [nvarchar](50) NOT NULL,
	[�m�W] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[���] [nvarchar](50) NULL,
	[�q��] [nvarchar](50) NULL,
	[�O�_�w�R��] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[�Ȥ��p���H] ADD  CONSTRAINT [DF_�Ȥ��p���H_�O�_�w�R��]  DEFAULT ((0)) FOR [�O�_�w�R��]
GO

ALTER TABLE [dbo].[�Ȥ��p���H]  WITH CHECK ADD  CONSTRAINT [FK_�Ȥ��p���H_�Ȥ���] FOREIGN KEY([�Ȥ�Id])
REFERENCES [dbo].[�Ȥ���] ([Id])
GO

ALTER TABLE [dbo].[�Ȥ��p���H] CHECK CONSTRAINT [FK_�Ȥ��p���H_�Ȥ���]
GO


