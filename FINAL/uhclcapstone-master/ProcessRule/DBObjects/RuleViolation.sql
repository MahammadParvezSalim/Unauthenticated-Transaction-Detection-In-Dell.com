USE [CapStone]
GO

/****** Object:  Table [dbo].[RuleViolation]    Script Date: 10/22/2019 7:29:19 PM ******/
DROP TABLE [dbo].[RuleViolation]
GO

/****** Object:  Table [dbo].[RuleViolation]    Script Date: 10/22/2019 7:29:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RuleViolation](
	[RuleViolationID] [int] IDENTITY(1,1) NOT NULL,
	[MCMID] [varchar](100) NULL,
	[SessionID] [varchar](100) NULL,
	[RuleID] [varchar](50) NULL,
	[Violation] [varchar](500) NULL,
	[LastModifiedUserID] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO


