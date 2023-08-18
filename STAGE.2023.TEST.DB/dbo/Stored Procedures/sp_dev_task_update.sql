CREATE PROCEDURE [dbo].[sp_dev_task_update]
	@dev_task_id int,
	@id_project int,
	@id_TypeDev int,
	@details VARCHAR(500),
	@source VARCHAR(100),
	@posting_date VARCHAR(50),
	@posted_by VARCHAR(100) ,
	@due_date VARCHAR(50) ,
	@id_PriorityDev int ,
	@id_StatusDev int ,
	@user_id int ,
	@notes VARCHAR(500)

AS
BEGIN

	UPDATE
		dbo.[def_dev_task] 
	SET
	    dev_task_id=@dev_task_id,
		id_project = @id_project,
		id_TypeDev = @id_TypeDev,
		details = @details,
		source=@source,
	    posting_date= @posting_date,
		posted_by=@posted_by,
		due_date=@due_date,
		id_PriorityDev=@id_PriorityDev,
		id_StatusDev=@id_StatusDev,
		user_id=@user_id,
		notes=@notes
		
	WHERE
		dev_task_id = @dev_task_id

END
