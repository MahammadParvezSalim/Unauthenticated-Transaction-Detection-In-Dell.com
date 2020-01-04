USE [Parvez_db]
GO

/****** Object:  StoredProcedure [dbo].[InsertUpdateUserInfo]    Script Date: 10/17/2019 7:04:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[InsertUpdateUserInfo]
	@arg_MCMID varchar(50)
	,@arg_sessionID varchar(50)
	,@arg_FirstName varchar(50)=''
	,@arg_LastName varchar(50)=''
	,@arg_MiddleName varchar(150)=''
	,@arg_StreetAddress varchar(500)=''
    ,@arg_City varchar(100)=''
	,@arg_State varchar(100)=''
	,@arg_PostalCode varchar(50)=''
	,@arg_EmailAddress varchar(100)=''
    ,@arg_TimeStamp datetime 
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
		
			BEGIN
				insert into dbo.[UserInfo] (sessionID
														,[MCMID]
													    ,FirstName
														,LastName
														,MiddleName 
														,StreetAddress
														,City
														,State
											            ,PostalCode
														,EmailAddress
														,TimeStamp
														,lastModifiedUser
														,lastModifiedDateTime)


				select  @arg_sessionID
						,@arg_MCMID
						,@arg_FirstName
						,@arg_LastName
						,@arg_MiddleName 
						,@arg_StreetAddress
						,@arg_City
						,@arg_State
						,@arg_PostalCode
						,@arg_EmailAddress
						,@arg_TimeStamp
						,@arg_lastModifiedUser
						,@arg_lastModifiedDateTime
			END
	
	
	END TRY
	BEGIN CATCH
		select @var_error_num = ERROR_NUMBER(), @var_error_message = ERROR_MESSAGE()
	END CATCH

	select @var_error_num ERROR_NUMBER, @var_error_message ERROR_MESSAGE
END

GO

