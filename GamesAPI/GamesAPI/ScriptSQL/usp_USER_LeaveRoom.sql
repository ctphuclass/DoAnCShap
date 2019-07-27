USE [i_APP_GAMES]
GO
/****** Object:  StoredProcedure [dbo].[usp_USER_GetUserIDByUserName]    Script Date: 27/07/2019 8:42:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ctphu
-- Create date: 2019-07-20
-- Description:	Leave Room
-- =============================================
CREATE PROCEDURE [dbo].[usp_USER_LeaveRoom] 
	-- Add the parameters for the stored procedure here
	@pUserID int
	,@pRoomID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @pGameID bigint
	IF(EXISTS(SELECT ID FROM Room WHERE ID = @pRoomID AND (CreatedUserID = @pUserID OR JoinUserID = @pUserID)))
	BEGIN
		SELECT @pGameID = GameID FROM Room WHERE ID = @pRoomID
		BEGIN TRAN
		IF @pGameID IS NOT NULL
		BEGIN
			EXEC dbo.usp_USER_LeaveGame @pUserID, @pGameID
		END
		UPDATE Room SET CreatedUserID = NULL WHERE ID = @pRoomID AND CreatedUserID = @pUserID
		UPDATE Room SET JoinUserID = NULL WHERE ID = @pRoomID AND JoinUserID = @pUserID
		UPDATE Room SET RoomStatus = 1 WHERE ID = @pRoomID AND JoinUserID IS NULL AND CreatedUserID IS NULL
		COMMIT TRAN
	END

END
