USE NorthWind2020

DECLARE @TableName SYSNAME= 'Customers';
DECLARE @SQL NVARCHAR(MAX);
SELECT @SQL = STUFF(
(
    SELECT '
UNION ALL 
select ' + QUOTENAME(Column_Name, '''') + ' AS ColumnName, MAX(LEN(LTRIM(' + QUOTENAME(Column_Name) + '))) as [Max Length], ' + QUOTENAME(C.DATA_TYPE, '''') + ' AS Data_Type, ' + CAST(COALESCE(C.CHARACTER_MAXIMUM_LENGTH, C.NUMERIC_SCALE) AS VARCHAR(10)) + '  AS Data_Width FROM ' + QUOTENAME(Table_Name)
    FROM INFORMATION_SCHEMA.COLUMNS C
    WHERE TABLE_NAME = @TableName
          AND DATA_TYPE NOT LIKE '%text' FOR XML PATH(''), TYPE
).value('.', 'varchar(max)'), 1, 11, '');  

EXECUTE (@SQL);