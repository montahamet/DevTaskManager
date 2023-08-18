CREATE PROCEDURE [dbo].[sp_module_insert]
    @module_id int,
	@module_name VARCHAR(100)
	
AS
BEGIN

	INSERT INTO
		dbo.[def_module](module_id,module_name)
				
	VALUES 
	(@module_id,@module_name)

		 

END
