CREATE PROCEDURE [dbo].[sp_statusproject_get_one_by_id]
	@id_StatusProject int

	AS
	BEGIN
	SELECT
	sp.id_StatusProject,
	sp.StatusProject_name

	From 
			dbo.[def_status_project] sp


			where 
			sp.id_StatusProject= @id_StatusProject
END
