USE [Customer]
GO

/****** Object:  Table [dbo].[�Ȥ���]    Script Date: 2019/6/10 �W�� 08:37:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[�Ȥ���](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[�Ȥ�W��] [nvarchar](50) NOT NULL,
	[�Τ@�s��] [char](8) NOT NULL,
	[�q��] [nvarchar](50) NOT NULL,
	[�ǯu] [nvarchar](50) NULL,
	[�a�}] [nvarchar](100) NULL,
	[Email] [nvarchar](250) NULL,
	[�O�_�w�R��] [bit] NOT NULL,
	[�Ȥ����] [nvarchar](50) NULL,
	[�b��] [nvarchar](50) NOT NULL,
	[�K�X] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[�Ȥ���] ADD  CONSTRAINT [DF_�Ȥ���_�O�_�w�R��]  DEFAULT ((0)) FOR [�O�_�w�R��]
GO


