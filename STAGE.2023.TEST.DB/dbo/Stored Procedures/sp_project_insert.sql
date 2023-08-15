CREATE PROCEDURE [dbo].[sp_project_insert]

    @id_project int,
	@project_name VARCHAR(100) NULL,
	@project_module VARCHAR(100) NULL,
	@project_version VARCHAR(50) NULL,
	@project_description VARCHAR(MAX) NULL,
	@project_leader VARCHAR(70) NULL,
	@project_estimated_budget DECIMAL NULL,
	@project_total_amount DECIMAL NULL,
	@project_estimated_duration VARCHAR(30) NULL,
	@id_StatusProject int
AS
BEGIN
    INSERT INTO
		dbo.[def_project] (id_project,project_name,project_module, project_version, project_description,project_leader, project_estimated_budget,project_total_amount,project_estimated_duration,id_StatusProject)
					
	VALUES 
		( @id_project,@project_name,@project_module, @project_version, @project_description,@project_leader, @project_estimated_budget,@project_total_amount,@project_estimated_duration,@id_StatusProject)
END;
