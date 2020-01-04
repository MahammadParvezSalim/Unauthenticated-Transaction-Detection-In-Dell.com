USE [Parvez_db]
GO

/****** Object:  Table [dbo].[UserInfo]    Script Date: 10/17/2019 7:02:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MCMID] [varchar](50) NULL,
	[sessionID] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[MiddleName] [varchar](150) NULL,
	[StreetAddress] [varchar](500) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[PostalCode] [varchar](50) NULL,
	[EmailAddress] [varchar](100) NULL,
	[TimeStamp] [varchar](500) NULL,
	[lastModifiedUser] [varchar](100) NULL,
	[lastModifiedDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

