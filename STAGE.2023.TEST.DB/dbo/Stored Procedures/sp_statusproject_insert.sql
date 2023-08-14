CREATE PROCEDURE [dbo].[sp_statusproject_insert]
	@StatusProject_name VARCHAR(100) 
	
AS
BEGIN

	INSERT INTO
		dbo.[def_status_project] (id_StatusProject, StatusProject_name )
					
	VALUES 
		((SELECT ISNULL(MAX(id_StatusProject),0) FROM def_status_project ) + 1, @StatusProject_name)
		 

END
