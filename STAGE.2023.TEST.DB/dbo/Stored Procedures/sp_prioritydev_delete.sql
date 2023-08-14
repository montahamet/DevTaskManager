CREATE PROCEDURE [dbo].[sp_prioritydev_delete]
	@id_PriorityDev int
AS
BEGIN

	DELETE FROM
		dbo.[def_priority_dev] 
	WHERE 
		id_PriorityDev = @id_PriorityDev

END
