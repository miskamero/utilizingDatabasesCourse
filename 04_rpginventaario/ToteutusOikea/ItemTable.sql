CREATE TABLE Item (
    Id INT PRIMARY KEY,
    ItemName NVARCHAR(100) NOT NULL,
    ItemTypeId INT FOREIGN KEY REFERENCES ItemType(Id),
    RarityId INT FOREIGN KEY REFERENCES ItemRarity(Id),
    BaseValue DECIMAL(10, 2),
    AttValue DECIMAL(10, 2),
    DefValue DECIMAL(10, 2)
);
