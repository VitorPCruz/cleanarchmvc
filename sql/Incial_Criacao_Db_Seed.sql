IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [Price] decimal(10,2) NOT NULL,
    [Stock] int NOT NULL,
    [Image] nvarchar(max) NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] ON;
INSERT INTO [Categories] ([Id], [Name])
VALUES (1, N'Material Escolar'),
(2, N'Eletrônicos'),
(3, N'Acessórios');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] OFF;
GO

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230128153227_Inicial', N'7.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)VALUES('Caderno Espiral','Caderno espiral 100 folhas',7.45,50,'caderno1.jpg',1)
GO

INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)VALUES('Estojo escolar','Estojo escolar cinza',5.65,70,'estojo1.jpg',1)
GO

INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)VALUES('Borracha escolar','Borracha branca pequena',3.25,80,'borracha1.jpg',1)
GO

INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)VALUES('Calculadora escolar','Calculadora escolar cinza',15.39,20,'calculadora1.jpg',1)
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230128153729_SeedProducts', N'7.0.2');
GO

COMMIT;
GO

