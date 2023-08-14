CREATE PROCEDURE [dbo].[sp_statusproject_get_all]
	AS
BEGIN

	SELECT 
		sp.id_StatusProject,
	   ISNULL(StatusProject_name, '') AS StatusProject_name
	  
	   
	   
	FROM
		dbo.[def_status_project] sp
		
	ORDER BY
		sp.id_StatusProject ASC

END
