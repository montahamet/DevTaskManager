CREATE PROCEDURE [dbo].[sp_statusproject_delete]
	@id_StatusProject int
AS
BEGIN

	DELETE FROM
		dbo.[def_status_project] 
	WHERE 
		id_StatusProject = @id_StatusProject

END
