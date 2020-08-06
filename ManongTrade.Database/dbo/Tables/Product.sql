CREATE TABLE [dbo].[Product] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    [Stock]       SMALLINT     CONSTRAINT [DF_Product_Stock] DEFAULT ((0)) NOT NULL,
    [Price]       MONEY        CONSTRAINT [DF_Product_Price] DEFAULT ((0)) NOT NULL,
    [CreatedDate] DATETIME     CONSTRAINT [DF_Product_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   INT          NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_Product_Name] UNIQUE ([Name])
);

