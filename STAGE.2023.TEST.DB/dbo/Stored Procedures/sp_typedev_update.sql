CREATE PROCEDURE [dbo].[sp_typedev_update]
	@id_TypeDev int,
	@TypeDev_name VARCHAR(100)
	
	
AS
BEGIN

	UPDATE
		dbo.[def_type_dev] 
	SET
		id_TypeDev = @id_TypeDev,
		TypeDev_name = @TypeDev_name
		
		
	WHERE
		id_TypeDev= @id_TypeDev

END
