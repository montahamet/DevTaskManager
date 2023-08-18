IF NOT EXISTS (SELECT 1 FROM dbo.[def_user_role])
BEGIN
	INSERT INTO dbo.[def_user_role]([role_id],[role_code],[role_name]) 
	VALUES 
		(1, N'ADMIN', N'Administrator'),
		(2, N'DEV', N'DEVELOPER')

END

IF NOT EXISTS (SELECT 1 FROM dbo.[app_user])
BEGIN
	INSERT INTO dbo.[app_user]([role_id], [user_full_name], [user_login], [user_password], 
						       [user_email], [user_phone], [user_is_active], [user_birth_date], [user_creation_date]) 
	VALUES 
		                       (1, N'ADMINSTRATOR', N'ADMIN', N'1w7USZx2lywZENk8S0Cv8g==', N'admin@mail.com', N'00 00000000', 1, '19700101', GETDATE()),
							   (2, N'DEVELOPER', N'DEV', N'1w7USZx2lywZENk8S0Cv8g==', N'dev@mail.com', N'00 00000000', 1, '19700101', GETDATE())
END
 
IF NOT EXISTS (SELECT 1 FROM dbo.[def_type_dev])
BEGIN
	INSERT INTO dbo.[def_type_dev]([id_TypeDev], [TypeDev_name]) 
	VALUES 
		(1, 'BUG_FIX'),
		(2, 'NEW_INSTALL'),
		(3, 'NEW_DEV'),
		(4, 'IMPROVEMENT')
		
END

IF NOT EXISTS (SELECT 1 FROM dbo.[def_priority_dev])
BEGIN
	INSERT INTO dbo.[def_priority_dev]([id_PriorityDev], [PriorityDev_name]) 
	VALUES 
		(1, 'LOW'),
		(2, 'NEDIUM'),
		(3, 'HIGH'),
		(4, 'URGENT')
		
END

IF NOT EXISTS (SELECT 1 FROM dbo.[def_status_dev])
BEGIN
	INSERT INTO dbo.[def_status_dev]([id_StatusDev], [StatusDev_name]) 
	VALUES 
		(1, 'NOT_STARTED'),
		(2, 'IN_PROGRESS'),
		(3, 'COMPLETED'),
		(4, 'DELAYED'),
		(5, 'CANCELED'),
		(6, 'ARCHIVED')
		
END

IF NOT EXISTS (SELECT 1 FROM dbo.[def_status_project])
BEGIN
	INSERT INTO dbo.[def_status_project]([id_StatusProject], [StatusProject_name]) 
	VALUES 
		(1, 'IN_PROGRESS'),
		(2, 'ON_HOLD'),
		(3, 'SUCCESS'),
		(4, 'DELAYED'),
		(5, 'CANCELED'),
		(6, 'TESTING'),
		(7, 'READY_FOR_RELEASE'),
		(8, 'APPROVAL_PENDING')
		
END

IF NOT EXISTS (SELECT 1 FROM dbo.[def_module] )
BEGIN
	INSERT INTO dbo.[def_module]([module_id],[module_name])
	VALUES 
		(1, 'HNG'),
		(2, 'MyHotix'),
		(3, 'HH')
		
END

IF NOT EXISTS (SELECT 1 FROM dbo.[def_project] )
BEGIN
	INSERT INTO dbo.[def_project]([id_project],[project_name],[module_id] ,[project_version] ,[project_description],[user_id],[project_estimated_budget],[project_total_amount],[project_estimated_duration],[id_StatusProject] ) 
	VALUES 
		(1, 'CHANNEL_MANAGER',2 , '3.2.0' , 'NONE' ,1,'333844','584466','3months',1)
		
END

IF NOT EXISTS (SELECT 1 FROM dbo.[def_dev_task] )
BEGIN
	INSERT INTO dbo.[def_dev_task]([dev_task_id],[id_project],[id_TypeDev],[details],[source],[posting_date],[posted_by],[due_date],[id_PriorityDev],[id_StatusDev],[user_id],[notes])
	VALUES 
		(1,1,1,'none','Mouradi hotel','18072023','MB','20082023',1,1,2,'no note')
		
END