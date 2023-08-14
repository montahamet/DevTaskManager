CREATE PROCEDURE [dbo].[sp_user_insert]
	
	@fullName VARCHAR(300),
	@urlImage VARCHAR(MAX),
	@login VARCHAR(100),
	@password VARCHAR(250),
	@email VARCHAR(100),
	@isActive BIT, 
	@phone VARCHAR(30), 
	@birthDate DATE,
	@roleId int
AS
BEGIN

	INSERT INTO
		dbo.[app_user] (user_full_name, user_url_image, user_login, user_password,
					user_email, user_phone, user_is_active, user_birth_date, user_creation_date, role_id) 
	VALUES 
		(@fullName, @urlImage, @login, @password,
		 @email, @phone, @isActive, @birthDate, GETDATE(),@roleId)

END
