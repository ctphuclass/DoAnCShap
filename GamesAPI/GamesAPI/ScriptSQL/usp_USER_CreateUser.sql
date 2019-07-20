-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ctphu
-- Create date: 2019-07-20
-- Description:	Create User
-- =============================================
CREATE PROCEDURE usp_USER_CreateUser 
	-- Add the parameters for the stored procedure here
	@pUserName varchar(50), 
	@pPassword varchar(50),
	@pEmail varchar(255),
	@pAddress nvarchar(max),
	@pPhone varchar(50),
	@pResult int out,
	@pResultID int out,
	@pResultMessage varchar(50) out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @lUserStatus int = 0 -- Status create but not active
			,@lUserPoint int = 100 -- Start up Point,
			,@lUserRank int = 1-- Start up Rank
			,@lActionTypeActive int = 1 -- ActionType Active
			,@lActionTypeStatusNotActive int = 0 -- ActionTypeStatus for Status Not Active

	DECLARE @pUserID int, @pKeyCode varchar(50)
	-- Neu ton tai it nhat mot user co username = @pUserName thi bao loi
	IF EXISTS(SELECT UserID FROM dbo.[User] WHERE UserName = @pUserName)
	BEGIN
		SELECT @pResult = -1, @pResultID = NULL, @pResultMessage = 'USERNAME_EXISTS'
		RETURN
	END

	-- Neu ton tai it nhat mot user co Email = @pEmail thi bao loi
	IF EXISTS(SELECT UserID FROM dbo.[User] WHERE Email = @pEmail)
	BEGIN
		SELECT @pResult = -1, @pResultID = NULL, @pResultMessage = 'EMAIL_EXISTS'
		RETURN
	END

	BEGIN TRAN
		SELECT @pPassword = HASHBYTES('SHA', @pPassword);

		INSERT INTO dbo.[User](UserName, Password, Email, Address, Phone, Status, Point, Rank)
		VALUES(@pUserName, @pPassword, @pEmail, @pAddress, @pPhone, @lUserStatus, @lUserPoint, @lUserRank);
		SELECT @pUserID = SCOPE_IDENTITY()

		SELECT @pKeyCode = LEFT(NEWID(),8)
		INSERT INTO dbo.UserAction(UserID, ActionType, KeyCode, Status)
		VALUES(@pUserID, @lActionTypeActive,@pKeyCode, @lActionTypeStatusNotActive)

		SELECT @pResult = 1, @pResultID = @pUserID, @pResultMessage = @pKeyCode

	COMMIT TRAN
END
GO
