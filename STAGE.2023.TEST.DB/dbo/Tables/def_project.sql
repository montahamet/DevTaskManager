CREATE TABLE [dbo].[def_project]
(
	[id_project] INT NOT NULL PRIMARY KEY,
	[project_name] VARCHAR(100) NULL,
	[module_id] INT NOT NULL,
    CONSTRAINT [FK_project_To_def_module] FOREIGN KEY ([module_id]) REFERENCES [def_module]([module_id]),
	[project_version] VARCHAR(50) NULL,
	[project_description] VARCHAR(MAX) NULL,
	[user_id] int,
	CONSTRAINT [FK_project_To_app_user] FOREIGN KEY ([user_id]) REFERENCES [app_user]([user_id]),
	[project_estimated_budget] DECIMAL NULL,
	[project_total_amount] DECIMAL NULL,
	[project_estimated_duration] VARCHAR(30) NULL,
	[id_StatusProject] INT NOT NULL,
    CONSTRAINT [FK_project_To_def_status_project] FOREIGN KEY ([id_StatusProject]) REFERENCES [def_status_project]([id_StatusProject])
)
