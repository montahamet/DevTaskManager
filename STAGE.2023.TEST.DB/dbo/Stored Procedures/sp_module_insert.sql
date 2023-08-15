CREATE PROCEDURE [dbo].[sp_module_insert]
    @dev_task_id int,
	@module_name VARCHAR(100),
	@id_project int,
	@id_TypeDev int,
	@module_details VARCHAR(500),
	@posting_date VARCHAR(50),
	@posted_by VARCHAR(100) ,
	@due_date VARCHAR(50) ,
	@id_PriorityDev int ,
	@id_StatusDev int ,
	@user_id int ,
	@module_notes VARCHAR(500)
AS
BEGIN

	INSERT INTO
		dbo.[def_module](dev_task_id,module_name, id_project, id_TypeDev,module_details,posting_date,posted_by,due_date,id_PriorityDev,id_StatusDev,user_id,module_notes)
				
	VALUES 
	(@dev_task_id,@module_name, @id_project, @id_TypeDev, @module_details, @posting_date,@posted_by ,@due_date ,@id_PriorityDev  ,@id_StatusDev,@user_id,@module_notes)

		 

END
