CREATE TABLE [dbo].[Contact] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [CustomerId]  INT          NOT NULL,
    [Phone]       VARCHAR (20) NOT NULL,
    [Address]     VARCHAR (50) NOT NULL,
    [CreatedDate] DATETIME     CONSTRAINT [DF_Contact_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   INT          NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contact_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);

