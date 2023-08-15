CREATE PROCEDURE [dbo].[sp_module_get_one_by_name]

	@module_name VARCHAR(100)
AS
BEGIN

	SELECT 
		m.module_name,
		m.module_name,
		m.id_project,
		ppp.project_name,
		m.id_TypeDev,
		tddd.TypeDev_name,
		ISNULL(module_details, '') AS module_details,
		ISNULL(posting_date, '') AS posting_date,
		ISNULL(posted_by, '') AS posted_by,
		ISNULL(due_date, '') AS due_date,
		m.id_PriorityDev,
		pddd.PriorityDev_name,
		m.id_StatusDev,
		sddd.StatusDev_name,
		m.user_id ,
        appp.user_full_name,
		ISNULL(module_notes, '') AS module_notes
	   
	 
	FROM
		
		dbo.[def_module] m
		INNER JOIN dbo.[def_type_dev] tddd ON tddd.id_TypeDev = m.id_TypeDev
		INNER JOIN dbo.[def_priority_dev] pddd ON pddd.id_PriorityDev = m.id_PriorityDev
		INNER JOIN dbo.[def_status_dev] sddd ON sddd.id_StatusDev = m.id_StatusDev
		INNER JOIN dbo.[def_project] ppp ON ppp.id_project = m.id_project 
		INNER JOIN dbo.[app_user] appp ON appp.user_id = m.user_id
		
	WHERE
		m.module_name = @module_name

END

