CREATE PROCEDURE [dbo].[sp_prioritydev_get_all]
	AS
BEGIN

	SELECT 
		pd.id_PriorityDev,
	   ISNULL(PriorityDev_name, '') AS PriorityDev_name
	  
	   
	   
	FROM
		dbo.[def_priority_dev] pd
		
	ORDER BY
		pd.id_PriorityDev ASC

END
