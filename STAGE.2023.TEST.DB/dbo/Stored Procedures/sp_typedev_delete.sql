CREATE PROCEDURE [dbo].[sp_typedev_delete]
	@id_TypeDev int
AS
BEGIN

	DELETE FROM
		dbo.[def_type_dev] 
	WHERE 
		id_TypeDev = @id_TypeDev

END
