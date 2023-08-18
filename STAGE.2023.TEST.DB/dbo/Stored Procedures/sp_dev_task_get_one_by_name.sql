CREATE PROCEDURE [dbo].[sp_dev_task_get_one_by_name]
	@project_name VARCHAR(100)

	AS
	BEGIN
	SELECT

	    v.dev_task_id,
		v.id_project,
		pjj.project_name,
		v.id_TypeDev,
		tdevv.TypeDev_name,
		ISNULL(details, '') AS details,
		ISNULL(source, '') AS source,
		ISNULL(posting_date, '') AS posting_date,
	    ISNULL(posted_by, '') AS posted_by,
		ISNULL(due_date, '') AS due_date,
		v.id_PriorityDev,
		pdevv.PriorityDev_name,
		v.id_StatusDev,
		sdevv.StatusDev_name,
		v.user_id ,
        apuu.user_full_name,
		ISNULL(notes, '') AS notes
	
	FROM 
	    dbo.[def_dev_task] v
	    INNER JOIN dbo.[def_type_dev] tdevv ON tdevv.id_TypeDev = v.id_TypeDev
		INNER JOIN dbo.[def_priority_dev] pdevv ON pdevv.id_PriorityDev = v.id_PriorityDev
		INNER JOIN dbo.[def_status_dev] sdevv ON sdevv.id_StatusDev = v.id_StatusDev
		INNER JOIN dbo.[def_project] pjj ON pjj.id_project = v.id_project 
		INNER JOIN dbo.[app_user] apuu ON apuu.user_id = v.user_id
	Where 
    pjj.project_name=@project_name
    END
