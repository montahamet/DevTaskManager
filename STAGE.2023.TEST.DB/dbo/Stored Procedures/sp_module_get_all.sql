CREATE PROCEDURE [dbo].[sp_module_get_all]
@id_project int
AS
BEGIN


	SELECT 
	    m.dev_task_id,
		m.module_name,
		m.id_project,
		p.project_name,
		m.id_TypeDev,
		td.TypeDev_name,
		ISNULL(module_details, '') AS module_details,
		ISNULL(posting_date, '') AS posting_date,
		ISNULL(posted_by, '') AS posted_by,
		ISNULL(due_date, '') AS due_date,
		m.id_PriorityDev,
		pd.PriorityDev_name,
		m.id_StatusDev,
		sd.StatusDev_name,
		m.user_id ,
        ap.user_full_name,
		ISNULL(module_notes, '') AS module_notes
	   
	   
	FROM
		dbo.[def_module] m
		INNER JOIN dbo.[def_type_dev] td ON td.id_TypeDev = m.id_TypeDev
		INNER JOIN dbo.[def_priority_dev] pd ON pd.id_PriorityDev = m.id_PriorityDev
		INNER JOIN dbo.[def_status_dev] sd ON sd.id_StatusDev = m.id_StatusDev
		INNER JOIN dbo.[def_project] p ON p.id_project = m.id_project AND ((@id_project = -1) OR (@id_project = p.id_project))
		INNER JOIN dbo.[app_user] ap ON ap.user_id = m.user_id
		
		
		
	ORDER BY
		m.due_date ASC

END
