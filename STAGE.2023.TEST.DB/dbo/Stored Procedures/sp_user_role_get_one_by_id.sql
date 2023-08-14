CREATE PROCEDURE [dbo].[sp_user_role_get_one_by_id]
@userRoleId int
AS
BEGIN
SELECT 
		role_id,
		ISNULL(role_code, '') AS role_code,
		ISNULL(role_name, '') AS role_name
	FROM
		dbo.[def_user_role] 
	WHERE
		role_id = @userRoleId

END
