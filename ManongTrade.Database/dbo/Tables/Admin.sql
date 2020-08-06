CREATE TABLE [dbo].[Admin] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [CustomerId]  INT      NOT NULL,
    [CreatedDate] DATETIME CONSTRAINT [DF_Admin_CreateDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   INT      NOT NULL,
    CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Admin_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);

