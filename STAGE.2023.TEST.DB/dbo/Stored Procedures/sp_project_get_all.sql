CREATE PROCEDURE [dbo].[sp_project_get_all]
	
	@id_project int 

	AS
	BEGIN
	SELECT

	p.id_project,
	ISNULL(p.project_name, '') AS project_name,
	ISNULL(p.project_module,'')AS project_module,
	ISNULL(p.project_version,'')AS project_version,
	ISNull(p.project_description,'')AS project_description,
	ISNULL(p.project_leader,'')AS project_leader,
	ISNULL(p.project_estimated_budget,0)AS project_estimated_budget,
	ISNULL(p.project_total_amount,0)AS project_total_amount,
	ISNULL(p.project_estimated_duration,'')AS project_estimated_duration,
	p.id_StatusProject,
	stp.StatusProject_name

	FROM 
	dbo.[def_project] p 
	INNER JOIN dbo.[def_status_project] stp ON stp.id_StatusProject = p.id_StatusProject
	ORDER BY
		p.id_project ASC

    END