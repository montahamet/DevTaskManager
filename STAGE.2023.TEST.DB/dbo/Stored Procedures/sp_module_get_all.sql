CREATE PROCEDURE [dbo].[sp_module_get_all]
@module_id int
AS
BEGIN


	SELECT 
	    m.module_id,
		m.module_name
		
	FROM
		dbo.[def_module] m
		
		
	ORDER BY
		m.module_id ASC

END
