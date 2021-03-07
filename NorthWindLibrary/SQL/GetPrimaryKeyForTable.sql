USE NorthWind2020
/*
    Get Constraint name for configuring EF Core
*/
DECLARE @TableName nvarchar(50) = 'Customers'

SELECT c.CONSTRAINT_SCHEMA AS ConstraintSchema, 
       c.TABLE_NAME AS TableName, 
       p.CONSTRAINT_NAME AS ConstraintName, 
       c.COLUMN_NAME AS ColumnName, 
       cls.DATA_TYPE AS DataType, 
       p.CONSTRAINT_TYPE
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS p
     INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS c ON c.TABLE_NAME = p.TABLE_NAME
                                                            AND c.CONSTRAINT_NAME = p.CONSTRAINT_NAME
     INNER JOIN INFORMATION_SCHEMA.COLUMNS AS cls ON c.TABLE_NAME = cls.TABLE_NAME
                                                     AND c.COLUMN_NAME = cls.COLUMN_NAME
WHERE p.CONSTRAINT_TYPE = 'PRIMARY KEY'
      AND c.TABLE_NAME = @TableName
ORDER BY TableName;

EXEC sp_fkeys 'Customers'