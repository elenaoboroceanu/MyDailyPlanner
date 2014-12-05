CREATE TABLE [dbo].[Pill] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (100) NOT NULL,
	[Quantity]		 INT            NOT NULL,
	[UnitOfMeasure]	 INT            NOT NULL,
	[Days]			 INT            NOT NULL,
    [Comment]		 NVARCHAR (400) NULL   
    CONSTRAINT [PK_dbo.Pill] PRIMARY KEY CLUSTERED ([Id] ASC),
    
);


GO
