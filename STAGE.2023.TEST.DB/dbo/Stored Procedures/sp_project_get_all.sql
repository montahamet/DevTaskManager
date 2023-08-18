CREATE PROCEDURE [dbo].[sp_project_get_all]
	
	@mod_id int 

	AS
	BEGIN
	SELECT

	p.id_project,
	ISNULL(p.project_name, '') AS project_name,
	p.module_id,
	m.module_name,
	ISNULL(p.project_version,'')AS project_version,
	ISNull(p.project_description,'')AS project_description,
	p.user_id ,
    ap.user_full_name,
	ISNULL(p.project_estimated_budget,0)AS project_estimated_budget,
	ISNULL(p.project_total_amount,0)AS project_total_amount,
	ISNULL(p.project_estimated_duration,'')AS project_estimated_duration,
	p.id_StatusProject,
	stp.StatusProject_name

	FROM 
	dbo.[def_project] p 
	INNER JOIN dbo.[def_status_project] stp ON stp.id_StatusProject = p.id_StatusProject
	INNER JOIN dbo.[def_module] m ON m.module_id = p.module_id AND ((-1 = @mod_id) OR (m.module_id = @mod_id))
	INNER JOIN dbo.[app_user] ap ON ap.user_id = p.user_id
	ORDER BY
		p.id_project ASC 

    END