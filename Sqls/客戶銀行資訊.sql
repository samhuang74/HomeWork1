USE [Customer]
GO

/****** Object:  Table [dbo].[�Ȥ�Ȧ��T]    Script Date: 2019/6/10 �W�� 08:38:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[�Ȥ�Ȧ��T](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[�Ȥ�Id] [int] NOT NULL,
	[�Ȧ�W��] [nvarchar](50) NOT NULL,
	[�Ȧ�N�X] [int] NOT NULL,
	[����N�X] [int] NULL,
	[�b��W��] [nvarchar](50) NOT NULL,
	[�b�ḹ�X] [nvarchar](20) NOT NULL,
	[�O�_�w�R��] [bit] NOT NULL,
 CONSTRAINT [PK_�Ȥ�Ȧ��T] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[�Ȥ�Ȧ��T] ADD  CONSTRAINT [DF_�Ȥ�Ȧ��T_�O�_�w�R��]  DEFAULT ((0)) FOR [�O�_�w�R��]
GO

ALTER TABLE [dbo].[�Ȥ�Ȧ��T]  WITH CHECK ADD  CONSTRAINT [FK_�Ȥ�Ȧ��T_�Ȥ���] FOREIGN KEY([�Ȥ�Id])
REFERENCES [dbo].[�Ȥ���] ([Id])
GO

ALTER TABLE [dbo].[�Ȥ�Ȧ��T] CHECK CONSTRAINT [FK_�Ȥ�Ȧ��T_�Ȥ���]
GO


