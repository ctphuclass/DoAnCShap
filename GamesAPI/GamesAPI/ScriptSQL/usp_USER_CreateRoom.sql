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
-- Description:	Create Room
-- =============================================
CREATE PROCEDURE [dbo].[usp_USER_CreateRoom] 
	-- Add the parameters for the stored procedure here
	@pUserID int,
	@pResult int out,
	@pResultID bigint out,
	@pResultMessage varchar(50) out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @ROOM_STATUS_ACTIVE int = 0
	DECLARE @pRoomID bigint, @pRoomNo int
	/*
	Neu co room nao ma user nay co lien quan thi LeaveRoom
	*/
	WHILE EXISTS((SELECT TOP 1 RoomID FROM Room WHERE CreatedUserID = @pUserID OR JoinUserID = @pUserID AND RoomStatus = 0))
	BEGIN
		SELECT TOP 1 @pRoomID = RoomID FROM Room WHERE CreatedUserID = @pUserID OR JoinUserID = @pUserID AND RoomStatus = 0
		EXEC usp_USER_LeaveRoom @pUserID, @pRoomID
	END
	SET @pRoomNo = 1
	WHILE EXISTS(SELECT RoomID FROM Room WHERE RoomNo = @pRoomNo AND RoomStatus = 0)
	BEGIN
		SET @pRoomNo = @pRoomNo + 1
	END
	INSERT INTO Room(RoomNo, CreatedUserID, RoomStatus, CreatedDateTime)
		VALUES(@pRoomNo, @pUserID, @ROOM_STATUS_ACTIVE, GETDATE())
	SELECT @pRoomID = SCOPE_IDENTITY()
	SELECT @pResult = 1, @pResultID = @pRoomID, @pResultMessage = 'ROOM_CREATED'
END
