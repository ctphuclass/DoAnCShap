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
CREATE PROCEDURE [dbo].[usp_USER_GetUserIDByUserName] 
	-- Add the parameters for the stored procedure here
	@pUserName varchar(50),
	@pUserID int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(EXISTS(SELECT UserID FROM dbo.[User] WHERE UserName = @pUserName) )		
	BEGIN
		SELECT @pUserID = UserID FROM dbo.[User] WHERE UserName = @pUserName
	END
	ELSE
	BEGIN
		SELECT @pUserID = 0
	END

END
