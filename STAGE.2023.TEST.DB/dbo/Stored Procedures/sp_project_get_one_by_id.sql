CREATE PROCEDURE [dbo].[sp_project_get_one_by_id]
	@id_project int 

	AS
	BEGIN
	SELECT

	p.id_project,
	ISNULL(p.project_name, '') AS project_name,
	p.module_id,
	mm.module_name,
	ISNULL(p.project_version,'')AS project_version,
	ISNull(p.project_description,'')AS project_description,
	u.user_id,
	u.user_full_name,
	ISNULL(p.project_estimated_budget,0)AS project_estimated_budget,
	ISNULL(p.project_total_amount,0)AS project_total_amount,
	ISNULL(p.project_estimated_duration,'')AS project_estimated_duration,
	p.id_StatusProject,
	stpp.StatusProject_name
	
	FROM 
	dbo.[def_project] p
	INNER JOIN dbo.[def_status_project] stpp ON stpp.id_StatusProject = p.id_StatusProject
	INNER JOIN dbo.[def_module] mm ON mm.module_id = p.module_id
	INNER JOIN dbo.[app_user] u ON u.user_id = p.user_id
	Where 
    p.id_project=@id_project
    END
