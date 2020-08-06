CREATE TABLE [dbo].[Cart] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [CustomerId]  INT      NOT NULL,
    [ProductId]   INT      NOT NULL,
    [CreatedDate] DATETIME CONSTRAINT [DF_Cart_CreateDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   INT      NOT NULL,
    CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cart_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_Cart_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

