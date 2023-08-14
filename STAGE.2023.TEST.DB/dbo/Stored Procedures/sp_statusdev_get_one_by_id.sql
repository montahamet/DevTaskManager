CREATE PROCEDURE [dbo].[sp_statusdev_get_one_by_id]
	@id_StatusDev int

	AS
	BEGIN
	SELECT
	sd.id_StatusDev,
	sd.StatusDev_name

	From 
			dbo.[def_status_dev] sd


			where 
			sd.id_StatusDev= @id_StatusDev
END
