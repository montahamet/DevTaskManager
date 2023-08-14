CREATE PROCEDURE [dbo].[sp_statusdev_get_all]
	AS
BEGIN

	SELECT 
		sd.id_StatusDev,
	   ISNULL(StatusDev_name, '') AS StatusDev_name
	  
	   
	   
	FROM
		dbo.[def_status_dev] sd
		
	ORDER BY
		sd.id_StatusDev ASC

END
