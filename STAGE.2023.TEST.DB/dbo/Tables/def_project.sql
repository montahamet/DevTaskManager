CREATE TABLE [dbo].[def_project]
(
	[id_project] INT NOT NULL PRIMARY KEY,
	[project_name] VARCHAR(100) NULL,
	[project_module] VARCHAR(100) NULL,
	[project_version] VARCHAR(50) NULL,
	[project_description] VARCHAR(MAX) NULL,
	[project_leader] VARCHAR(70) NULL,
	[project_estimated_budget] DECIMAL NULL,
	[project_total_amount] DECIMAL NULL,
	[project_estimated_duration] VARCHAR(30) NULL,
	[id_StatusProject] INT NOT NULL
    CONSTRAINT [FK_project_To_def_status_project] FOREIGN KEY ([id_StatusProject]) REFERENCES [def_status_project]([id_StatusProject])
)
