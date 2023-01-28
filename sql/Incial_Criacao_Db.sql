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

