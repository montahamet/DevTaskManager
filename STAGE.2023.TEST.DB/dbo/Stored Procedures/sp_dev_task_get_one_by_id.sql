CREATE PROCEDURE [dbo].[sp_dev_task_get_one_by_id]
	@dev_task_id int 

	AS
	BEGIN
	SELECT

	    dev.dev_task_id,
		dev.id_project,
		pj.project_name,
		dev.id_TypeDev,
		tdev.TypeDev_name,
		ISNULL(details, '') AS details,
		ISNULL(source, '') AS source,
		ISNULL(posting_date, '') AS posting_date,
	    ISNULL(posted_by, '') AS posted_by,
		ISNULL(due_date, '') AS due_date,
		dev.id_PriorityDev,
		pdev.PriorityDev_name,
		dev.id_StatusDev,
		sdev.StatusDev_name,
		dev.user_id ,
        apu.user_full_name,
		ISNULL(notes, '') AS notes
	
	FROM 
	    dbo.[def_dev_task] dev
	    INNER JOIN dbo.[def_type_dev] tdev ON tdev.id_TypeDev = dev.id_TypeDev
		INNER JOIN dbo.[def_priority_dev] pdev ON pdev.id_PriorityDev = dev.id_PriorityDev
		INNER JOIN dbo.[def_status_dev] sdev ON sdev.id_StatusDev = dev.id_StatusDev
		INNER JOIN dbo.[def_project] pj ON pj.id_project = dev.id_project 
		INNER JOIN dbo.[app_user] apu ON apu.user_id = dev.user_id
	Where 
    dev.dev_task_id=@dev_task_id
    END
