CREATE PROCEDURE [dbo].[sp_prioritydev_insert]
	@PriorityDev_name VARCHAR(100) 
	
AS
BEGIN

	INSERT INTO
		dbo.[def_priority_dev] (id_PriorityDev, PriorityDev_name )
					
	VALUES 
		((SELECT ISNULL(MAX(id_PriorityDev),0) FROM def_priority_dev ) + 1, @PriorityDev_name)
		 

END
