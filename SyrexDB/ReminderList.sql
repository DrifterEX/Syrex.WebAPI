CREATE TABLE [dbo].[ReminderList]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [ReminderDate] DATETIME NULL, 
    [Status] INT NOT NULL
)
