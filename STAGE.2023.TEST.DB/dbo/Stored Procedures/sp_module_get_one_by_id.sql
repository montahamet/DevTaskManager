CREATE PROCEDURE [dbo].[sp_module_get_one_by_id]
	@module_id int 

	AS
	BEGIN
	SELECT

	m.module_id,
	m.module_name
	
	FROM 
	dbo.[def_module] m
	Where 
    m.module_id=@module_id
    END
