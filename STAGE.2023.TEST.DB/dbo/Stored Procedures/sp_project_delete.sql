CREATE PROCEDURE [dbo].[sp_project_delete]
	@id_project int
AS
BEGIN

	DELETE FROM
		dbo.[def_project] 
	WHERE 
		id_project = @id_project

END
