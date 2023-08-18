CREATE PROCEDURE [dbo].[sp_dev_task_delete]
	@dev_task_id int
AS
BEGIN

	DELETE FROM
		dbo.[def_dev_task]
	WHERE 
		dev_task_id = @dev_task_id

END
