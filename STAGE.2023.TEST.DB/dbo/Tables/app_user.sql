CREATE TABLE [dbo].[app_user]
(
	[user_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [role_id] INT NULL DEFAULT 2, 
    [user_full_name] NCHAR(300) NULL, 
    [user_login] NCHAR(100) NULL, 
    [user_password] NCHAR(250) NULL, 
    [user_email] NCHAR(100) NULL, 
    [user_phone] NCHAR(30) NULL, 
    [user_url_image] NCHAR(1000) DEFAULT 'user2.png',                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
    [user_is_active] BIT NULL, 
    [user_birth_date] DATETIME NULL, 
    [user_creation_date] DATETIME NULL, 
    [user_is_valid] BIT NULL , 
    CONSTRAINT [FK_AppUser_To_DefUserRole] FOREIGN KEY ([role_id]) REFERENCES [def_user_role]([role_id]) 
)
