﻿CREATE TABLE Products(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
[Price] Money NOT NULL
)
GO
INSERT INTO Products([Name],[Price])
VALUES('Apple',1200),
('Samsung' , 1155)