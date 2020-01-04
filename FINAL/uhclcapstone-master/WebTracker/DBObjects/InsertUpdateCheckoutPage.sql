USE [Parvez_db]
GO

/****** Object:  StoredProcedure [dbo].[InsertUpdateCheckoutPage]    Script Date: 10/17/2019 7:03:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[InsertUpdateCheckoutPage]
	@arg_MCMID varchar(50)
	,@arg_sessionID varchar(50)
	,@arg_CreditNumber varchar(100)=''
    ,@arg_ExpiryMonth int
	,@arg_ExpiryYear int
	,@arg_SecurityCode varchar(5)=''
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
				insert into dbo.[CheckOutPage] (sessionID
														,[MCMID]
													    ,CreditNumber
														,ExpiryMonth
														,ExpiryYear
														,SecurityCode
														,TimeStamp
														,lastModifiedUser
														,lastModifiedDateTime)


				select  @arg_sessionID
						,@arg_MCMID
						,@arg_CreditNumber
						,@arg_ExpiryMonth
						,@arg_ExpiryYear
						,@arg_SecurityCode
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

