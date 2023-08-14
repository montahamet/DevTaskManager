CREATE PROCEDURE [dbo].[sp_prioritydev_update]
	@id_PriorityDev int,
	@PriorityDev_name VARCHAR(100)
	
	
AS
BEGIN

	UPDATE
		dbo.[def_priority_dev] 
	SET
		id_PriorityDev = @id_PriorityDev,
		PriorityDev_name = @PriorityDev_name
		
		
	WHERE
		id_PriorityDev= @id_PriorityDev

END
