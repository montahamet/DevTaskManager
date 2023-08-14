CREATE PROCEDURE [dbo].[sp_statusdev_insert]
	@StatusDev_name VARCHAR(100) 
	
AS
BEGIN

	INSERT INTO
		dbo.[def_status_dev] (id_StatusDev, StatusDev_name )
					
	VALUES 
		((SELECT ISNULL(MAX(id_StatusDev),0) FROM def_status_dev) + 1, @StatusDev_name)
		 

END
