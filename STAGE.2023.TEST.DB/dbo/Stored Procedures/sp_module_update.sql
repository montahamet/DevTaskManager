CREATE PROCEDURE [dbo].[sp_module_update]
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

	UPDATE
		dbo.[def_module] 
	SET
	    dev_task_id=@dev_task_id,
		module_name = @module_name,
		id_project = @id_project,
		id_TypeDev = @id_TypeDev,
		module_details = @module_details,
	    posting_date= @posting_date,
		posted_by=@posted_by,
		due_date=@due_date,
		id_PriorityDev=@id_PriorityDev,
		id_StatusDev=@id_StatusDev,
		user_id=@user_id,
		module_notes=@module_notes
		
	WHERE
		module_name = @module_name

END