/*
    Used to get column descriptions where the description is not null.
    In some cases the description may be the same as the column name.

    Query comes from
    https://github.com/karenpayneoregon/DataGridViewColumnHeaderFromSqlServer
*/

USE NorthWind2020

DECLARE @TableName SYSNAME= 'Customers';

SELECT COLUMN_NAME AS ColumnName, 
       ORDINAL_POSITION AS Postion, 
       prop.value AS Description
FROM INFORMATION_SCHEMA.TABLES AS tbl
     INNER JOIN INFORMATION_SCHEMA.COLUMNS AS col ON col.TABLE_NAME = tbl.TABLE_NAME
     INNER JOIN sys.columns AS sc ON sc.object_id = OBJECT_ID(tbl.TABLE_SCHEMA + '.' + tbl.TABLE_NAME)
                                     AND sc.name = col.COLUMN_NAME
     LEFT JOIN sys.extended_properties prop ON prop.major_id = sc.object_id
                                               AND prop.minor_id = sc.column_id
                                               AND prop.name = 'MS_Description'
WHERE tbl.TABLE_NAME = @TableName AND prop.value is not null
ORDER BY col.ORDINAL_POSITION;