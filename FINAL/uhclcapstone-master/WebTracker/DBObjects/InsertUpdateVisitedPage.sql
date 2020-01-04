USE [CapStone]
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateVisitedPage]    Script Date: 10/21/2019 7:40:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

ALTER PROCEDURE [dbo].[InsertUpdateVisitedPage]
	@arg_MCMID varchar(50)
	,@arg_sessionID varchar(150)
	,@arg_pathName varchar(100)=''
    ,@arg_url varchar(500)=''
	,@arg_referer varchar(500)=''
    ,@arg_visitStartDateTime datetime
    ,@arg_visitEndDateTime datetime
	,@arg_lastModifiedUser varchar(100)
	,@arg_lastModifiedDateTime datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @var_error_num int = 0
			,@var_error_message varchar(max) = ''
	BEGIN TRY

				insert into dbo.[VisitedPage] (sessionID
														,[MCMID]
														,[pathName]
														,url
														,referer
														,visitStartDateTime
														,visitEndDateTime
														,lastModifiedUser
														,lastModifiedDateTime)
				select  @arg_sessionID
						,@arg_MCMID
						,@arg_pathName
						,@arg_url
						,@arg_referer
						,@arg_visitStartDateTime
						,@arg_visitEndDateTime
						,@arg_lastModifiedUser
						,@arg_lastModifiedDateTime

	
	END TRY
	BEGIN CATCH
		select @var_error_num = ERROR_NUMBER(), @var_error_message = ERROR_MESSAGE()
	END CATCH

	select @var_error_num ERROR_NUMBER, @var_error_message ERROR_MESSAGE
END
