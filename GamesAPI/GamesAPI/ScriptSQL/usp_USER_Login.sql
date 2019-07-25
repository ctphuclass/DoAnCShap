USE [i_APP_GAMES]
GO
/****** Object:  StoredProcedure [dbo].[usp_USER_CreateUser]    Script Date: 25/07/2019 8:57:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ctphu
-- Create date: 2019-07-20
-- Description:	Active User
-- =============================================
CREATE PROCEDURE [dbo].[usp_USER_Login] 
	-- Add the parameters for the stored procedure here
	@pUserName varchar(50), 
	@pPassword varchar(50),
	@pResult int out,
	@pResultID int out,
	@pResultMessage varchar(50) out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @lUserStatusActive int = 1 -- UserStatusActive for Status Active
			,@pUserID int
	SELECT @pPassword = HASHBYTES('SHA', @pPassword);

	IF(EXISTS(SELECT UserID FROM dbo.[User] WHERE UserName = @pUserName AND Password = @pPassword AND Status = @lUserStatusActive) )		
	BEGIN
		SELECT @pUserID = UserID FROM dbo.[User] WHERE UserName = @pUserName
		SELECT @pResult = 1, @pResultID = @pUserID, @pResultMessage = 'USER_LOGIN_OK'
	END
	ELSE
	BEGIN
		SELECT @pUserID = 0
		SELECT @pResult = -1, @pResultID = @pUserID, @pResultMessage = 'USER_LOGIN_FAIL'
	END

END
