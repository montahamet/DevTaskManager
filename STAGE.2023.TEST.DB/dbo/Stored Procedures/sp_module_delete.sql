CREATE PROCEDURE [dbo].[sp_module_delete]
	@module_id int
AS
BEGIN

	DELETE FROM
		dbo.[def_module]
	WHERE 
		module_id = @module_id

END
