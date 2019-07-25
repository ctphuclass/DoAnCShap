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
CREATE PROCEDURE [dbo].[usp_USER_ActiveUser] 
	-- Add the parameters for the stored procedure here
	@pUserID int,
	@pKeyCode varchar(8),
	@pResult int out,
	@pResultID int out,
	@pResultMessage varchar(50) out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @lUserStatus int = 1 -- Status active
			,@lActionTypeActive int = 1 -- ActionType Active
			,@lActionTypeStatusActive int = 1 -- ActionTypeStatus for Status Active
			,@lActionTypeStatusNotActive int = 0 -- ActionTypeStatus for Status Not Active
	IF(EXISTS(SELECT ID FROM UserAction WHERE UserID = @pUserID AND KeyCode = @pKeyCode AND ActionType = @lActionTypeActive AND Status = @lActionTypeStatusNotActive ) )		
	BEGIN
		BEGIN TRAN
			UPDATE UserAction SET Status = @lActionTypeStatusActive
				WHERE UserID = @pUserID AND KeyCode = @pKeyCode AND ActionType = @lActionTypeActive AND Status = @lActionTypeStatusNotActive 
			UPDATE dbo.[User] SET Status = @lUserStatus WHERE UserID = @pUserID
		COMMIT TRAN
		SELECT @pResult = 1, @pResultID = @pUserID, @pResultMessage = 'USER_ACTIVED'
	END
	ELSE
	BEGIN
		SELECT @pResult = -1, @pResultID = 0, @pResultMessage = 'USER_NOT_EXIST'
		RETURN
	END

END
