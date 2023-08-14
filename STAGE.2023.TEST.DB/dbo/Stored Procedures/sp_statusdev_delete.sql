CREATE PROCEDURE [dbo].[sp_statusdev_delete]
	@id_StatusDev int
AS
BEGIN

	DELETE FROM
		dbo.[def_status_dev] 
	WHERE 
		id_StatusDev = @id_StatusDev

END
