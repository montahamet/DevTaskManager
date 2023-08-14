CREATE PROCEDURE [dbo].[sp_statusproject_update]
	@id_StatusProject int,
	@StatusProject_name VARCHAR(100)
	
	
AS
BEGIN

	UPDATE
		dbo.[def_status_project] 
	SET
		id_StatusProject = @id_StatusProject,
		StatusProject_name = @StatusProject_name
		
		
	WHERE
		id_StatusProject= @id_StatusProject

END
