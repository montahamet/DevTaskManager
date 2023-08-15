CREATE PROCEDURE [dbo].[sp_module_delete]
	@dev_task_id int
AS
BEGIN

	DELETE FROM
		dbo.[def_module]
	WHERE 
		dev_task_id = @dev_task_id

END
