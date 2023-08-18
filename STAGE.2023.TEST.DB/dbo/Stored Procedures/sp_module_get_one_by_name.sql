CREATE PROCEDURE [dbo].[sp_module_get_one_by_name]

	@module_name VARCHAR(100)
AS
BEGIN

	SELECT 
	    m.module_id,
		m.module_name
	   
	FROM
		
		dbo.[def_module] m
		
	WHERE
		m.module_name = @module_name

END

