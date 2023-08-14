CREATE PROCEDURE [dbo].[sp_user_get_all] 
AS

BEGIN

	SELECT 
		u.user_id,
		u.role_id,
		ISNULL(dr.role_code, '') AS role_code,
		ISNULL(dr.role_name, '') AS role_name,
		ISNULL(u.user_full_name, '') AS user_full_name,
		ISNULL(u.user_url_image, '') AS user_url_image,
		u.user_login,
		u.user_password,
		ISNULL(u.user_email, '') AS user_email,
		ISNULL(u.user_phone, '') AS user_phone,
		ISNULL(u.user_is_active, 0) AS user_is_active,
		u.user_birth_date,
		u.user_creation_date
	FROM
		dbo.[app_user] u
		INNER JOIN dbo.[def_user_role] dr ON dr.role_id = u.role_id
	WHERE
		u.user_login <> 'admin'
	ORDER BY
		u.user_id ASC

END