CREATE PROCEDURE [dbo].[sp_statusdev_update]
	@id_StatusDev int,
	@StatusDev_name VARCHAR(100)
	
	
AS
BEGIN

	UPDATE
		dbo.[def_status_dev] 
	SET
		id_StatusDev = @id_StatusDev,
		StatusDev_name = @StatusDev_name
		
		
	WHERE
		id_StatusDev= @id_StatusDev

END
