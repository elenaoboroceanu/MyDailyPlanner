CREATE TABLE [dbo].[Meal] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (100) NOT NULL,
	[Recipe]		 NVARCHAR (400) NULL,
    [Comment]		 NVARCHAR (400) NULL,
  
    CONSTRAINT [PK_dbo.Meal] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO