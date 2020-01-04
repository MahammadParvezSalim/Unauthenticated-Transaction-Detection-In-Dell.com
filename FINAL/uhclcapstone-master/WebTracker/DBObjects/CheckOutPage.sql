USE [Parvez_db]
GO

/****** Object:  Table [dbo].[CheckOutPage]    Script Date: 10/17/2019 7:09:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CheckOutPage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MCMID] [varchar](50) NULL,
	[sessionID] [varchar](50) NULL,
	[CreditNumber] [varchar](100) NULL,
	[ExpiryMonth] [int] NULL,
	[ExpiryYear] [int] NULL,
	[SecurityCode] [varchar](5) NULL,
	[TimeStamp] [varchar](500) NULL,
	[lastModifiedUser] [varchar](100) NULL,
	[lastModifiedDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

