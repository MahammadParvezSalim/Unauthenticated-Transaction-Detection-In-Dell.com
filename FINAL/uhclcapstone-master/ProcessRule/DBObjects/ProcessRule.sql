/****** Object:  Table [dbo].[ProcessRule]    Script Date: 10/30/2019 7:18:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProcessRule](
	[RuleID] [int] IDENTITY(1,1) NOT NULL,
	[RuleDescription] [varchar](50) NULL,
	[RuleProcedure] [varchar](50) NULL,
	[ExecutionOrder] [int] NULL,
	[LastModifiedUserID] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL
) ON [PRIMARY]
GO


