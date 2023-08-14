CREATE PROCEDURE [dbo].[sp_typedev_insert]
	@TypeDev_name VARCHAR(100) 
	
AS
BEGIN

	INSERT INTO
		dbo.[def_type_dev] (id_TypeDev, TypeDev_name )
					
	VALUES 
		((SELECT ISNULL(MAX(id_TypeDev),0) FROM def_type_dev ) + 1, @TypeDev_name)
		 

END
