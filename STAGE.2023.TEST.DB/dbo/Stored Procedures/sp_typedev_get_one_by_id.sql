CREATE PROCEDURE [dbo].[sp_typedev_get_one_by_id]
	@id_TypeDev int

	AS
	BEGIN
	SELECT
	td.id_TypeDev,
	td.TypeDev_name

	From 
			dbo.[def_type_dev] td


			where 
			td.id_TypeDev= @id_TypeDev
END
