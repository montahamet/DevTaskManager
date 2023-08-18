CREATE PROCEDURE [dbo].[sp_module_update]
    @module_id int,
	@module_name VARCHAR(100)
AS
BEGIN

	UPDATE
		dbo.[def_module] 
	SET
	    module_id=@module_id,
		module_name = @module_name
		
	WHERE
		module_id = @module_id

END