CREATE PROCEDURE [dbo].[sp_dev_task_get_all]
@id_project int
AS
BEGIN


	SELECT 
	    d.dev_task_id,
		d.id_project,
		p.project_name,
		d.id_TypeDev,
		td.TypeDev_name,
		ISNULL(details, '') AS details,
		ISNULL(source, '') AS source,
		ISNULL(posting_date, '') AS posting_date,
		ISNULL(posted_by, '') AS posted_by,
		ISNULL(due_date, '') AS due_date,
		d.id_PriorityDev,
		pd.PriorityDev_name,
		d.id_StatusDev,
		sd.StatusDev_name,
		d.user_id ,
        ap.user_full_name,
		ISNULL(notes, '') AS notes
	   
	   
	FROM
		dbo.[def_dev_task] d
		INNER JOIN dbo.[def_type_dev] td ON td.id_TypeDev = d.id_TypeDev
		INNER JOIN dbo.[def_priority_dev] pd ON pd.id_PriorityDev = d.id_PriorityDev
		INNER JOIN dbo.[def_status_dev] sd ON sd.id_StatusDev = d.id_StatusDev
		INNER JOIN dbo.[def_project] p ON p.id_project = d.id_project AND ((@id_project = -1) OR (@id_project = d.id_project))
		INNER JOIN dbo.[app_user] ap ON ap.user_id = d.user_id
		
		
		
	ORDER BY
		d.dev_task_id ASC

END
