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
CREATE PROCEDURE [dbo].[usp_USER_JoinRoom] 
	-- Add the parameters for the stored procedure here
	@pUserID int,
	@pRoomID bigint,
	@pResult int out,
	@pResultID int out,
	@pResultMessage varchar(50) out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @ROOM_STATUS_ACTIVE int = 0
	/*
	
	*/
	
	IF EXISTS(SELECT TOP 1 RoomID FROM Room WHERE RoomID = @pRoomID AND CreatedUserID IS NULL AND RoomStatus = 0)
		UPDATE Room SET CreatedUserID = @pUserID WHERE RoomID = @pRoomID 
	ELSE IF EXISTS(SELECT TOP 1 RoomID FROM Room WHERE RoomID = @pRoomID AND JoinUserID IS NULL AND RoomStatus = 0)
		UPDATE Room SET JoinUserID = @pUserID WHERE RoomID = @pRoomID 
	
	IF EXISTS(SELECT TOP 1 RoomID FROM Room WHERE RoomID = @pRoomID AND (JoinUserID = @pUserID OR CreatedUserID = @pUserID) AND RoomStatus = 0)
		SELECT @pResult = 1, @pResultID = @pRoomID, @pResultMessage = 'ROOM_JOINED'
	ELSE
		SELECT @pResult = -1, @pResultID = 0, @pResultMessage = 'ROOM_NOT_EXISTS'
END
