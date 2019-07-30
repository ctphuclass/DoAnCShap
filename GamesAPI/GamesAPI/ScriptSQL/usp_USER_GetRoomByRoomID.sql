﻿USE [i_APP_GAMES]
GO
/****** Object:  StoredProcedure [dbo].[usp_USER_GetUserByUserID]    Script Date: 29/07/2019 9:04:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ctphu
-- Create date: 2019-07-20
-- Description:	Active User
-- =============================================
CREATE PROCEDURE [dbo].[usp_USER_GetRoomByRoomID] 
	-- Add the parameters for the stored procedure here
	@pRoomID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM dbo.[Room] WHERE RoomID = @pRoomID

END
