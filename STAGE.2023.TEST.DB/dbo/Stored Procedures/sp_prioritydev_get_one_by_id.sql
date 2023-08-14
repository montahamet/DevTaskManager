CREATE PROCEDURE [dbo].[sp_prioritydev_get_one_by_id]
	@id_PriorityDev int

	AS
	BEGIN
	SELECT
	pd.id_PriorityDev,
	pd.PriorityDev_name

	From 
			dbo.[def_priority_dev] pd


			where 
			pd.id_PriorityDev= @id_PriorityDev
END
