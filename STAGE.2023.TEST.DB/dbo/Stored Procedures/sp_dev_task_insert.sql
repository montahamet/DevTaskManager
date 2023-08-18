CREATE PROCEDURE [dbo].[sp_dev_task_insert]
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

	INSERT INTO
		dbo.[def_dev_task](dev_task_id,id_project, id_TypeDev,details,source,posting_date,posted_by,due_date,id_PriorityDev,id_StatusDev,user_id,notes)
				
	VALUES 
	(@dev_task_id, @id_project, @id_TypeDev, @details,@source, @posting_date,@posted_by ,@due_date ,@id_PriorityDev  ,@id_StatusDev,@user_id,@notes)

		 

END

