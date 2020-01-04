--USE [VSA]
--GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

if object_id('dbo.[VisitedPage]') is not null
	drop table dbo.[VisitedPage]
	
CREATE TABLE dbo.[VisitedPage](
	ID int identity primary key
	,MCMID varchar(50) not null
	,sessionID varchar(50) not null
    ,[pathName] varchar(100) not null
    ,url varchar(500) not null
	,referer varchar(100) null
    ,visitStartDateTime datetime
    ,visitEndDateTime datetime
	,lastModifiedUser varchar(100)
	,lastModifiedDateTime datetime
)

GO

