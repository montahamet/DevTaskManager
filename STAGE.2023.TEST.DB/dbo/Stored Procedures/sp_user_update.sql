CREATE PROCEDURE [dbo].[sp_user_update]
	@userId int,
	@roleId int,
	@fullName VARCHAR(300),
	@urlImage VARCHAR(Max),
	@login VARCHAR(100),
	@password VARCHAR(250),
	@email VARCHAR(100),
	@phone VARCHAR(30), 
	@isActive BIT, 
	@birthDate DATE
AS
BEGIN

	UPDATE
		dbo.[app_user] 
	SET
		role_id = @roleId,
		user_full_name = @fullName,
		user_url_image= @urlImage,
		user_login = @login,
		user_password = @password,
		user_email = @email,
		user_phone = @phone,
		user_is_active = @isActive,
		user_birth_date = @birthDate
	WHERE
		user_id = @userId

END