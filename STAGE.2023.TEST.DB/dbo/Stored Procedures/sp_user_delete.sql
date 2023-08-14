CREATE PROCEDURE [dbo].[sp_user_delete]
	@userId int
AS
BEGIN

	DELETE FROM
		dbo.[app_user] 
	WHERE 
		user_id = @userId

END
