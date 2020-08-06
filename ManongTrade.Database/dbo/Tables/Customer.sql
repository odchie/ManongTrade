CREATE TABLE [dbo].[Customer] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Username]    VARCHAR (15) NOT NULL,
    [Firstname]   VARCHAR (30) NOT NULL,
    [Lastname]    VARCHAR (30) NOT NULL,
    [CreatedDate] DATETIME     CONSTRAINT [DF_Customer_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   INT          CONSTRAINT [DF_Customer_CreatedBy] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_Customer_Username] UNIQUE ([Username])
);

