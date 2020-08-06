CREATE TABLE [dbo].[Order] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [CustomerId]  INT      NOT NULL,
    [ProductId]   INT      NOT NULL,
    [ContactId]   INT      NOT NULL,
    [Status]      SMALLINT NOT NULL,
    [CreatedDate] DATETIME CONSTRAINT [DF_Order_CreatedDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_Order_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

