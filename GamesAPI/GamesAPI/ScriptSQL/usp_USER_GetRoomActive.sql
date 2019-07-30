USE [i_APP_GAMES]
GO
/****** Object:  StoredProcedure [dbo].[usp_USER_GetRoomByRoomID]    Script Date: 30/07/2019 1:44:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ctphu
-- Create date: 2019-07-20
-- Description:	Active User
-- =============================================
CREATE PROCEDURE [dbo].[usp_USER_GetRoomActive] 
	-- Add the parameters for the stored procedure here
	--@pRoomID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT U.UserName AS CreatedUserName,R.* FROM dbo.[Room] R JOIN dbo.[User] U ON R.CreatedUserID = U.UserID
	WHERE RoomStatus = 0

END
