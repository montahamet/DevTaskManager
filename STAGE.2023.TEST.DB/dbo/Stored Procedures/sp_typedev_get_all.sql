CREATE PROCEDURE [dbo].[sp_typedev_get_all]
	AS
BEGIN

	SELECT 
		td.id_TypeDev,
	   ISNULL(TypeDev_name, '') AS TypeDev_name
	  
	   
	   
	FROM
		dbo.[def_type_dev] td
		
	ORDER BY
		td.id_TypeDev ASC

END
