CREATE TABLE [dbo].[def_module]
(
	[dev_task_id] int  NOT NULL PRIMARY KEY,
	[module_name] VARCHAR(100) NOT NULL,
	[id_project] INT NOT NULL, 
	CONSTRAINT [FK_module_To_project] FOREIGN KEY ([id_project]) REFERENCES [def_project]([id_project]),
	[id_TypeDev] INT NOT NULL, 
	CONSTRAINT [FK_module_To_type_dev] FOREIGN KEY ([id_project]) REFERENCES [def_type_dev]([id_TypeDev]),
	[module_details] VARCHAR(500) NULL,
	[posting_date] VARCHAR(50) NULL,
	[posted_by] VARCHAR(100) NULL,
	[due_date] VARCHAR(50) NULL,
	[id_PriorityDev] INT NOT NULL, 
	CONSTRAINT [FK_module_To_priority_dev] FOREIGN KEY ([id_PriorityDev]) REFERENCES [def_priority_dev]([id_PriorityDev]),
	[id_StatusDev] INT NOT NULL, 
	CONSTRAINT [FK_module_To_status_dev] FOREIGN KEY ([id_StatusDev]) REFERENCES [def_status_dev]([id_StatusDev]),
	[user_id] INT NOT NULL, 
    CONSTRAINT [FK_parc_To_user_] FOREIGN KEY ([user_id]) REFERENCES [app_user]([user_id]),
	[module_notes] VARCHAR(500) NULL,
	

)
