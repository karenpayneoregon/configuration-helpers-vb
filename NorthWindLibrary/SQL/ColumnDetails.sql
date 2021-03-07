/*
    Column details for table
*/

USE NorthWind2020

DECLARE @TableName sysname = 'Customers';

SELECT	syso.name [Table],
		sysc.name [Field], 
		sysc.colorder [FieldOrder], 
		syst.name [DataType], 
		sysc.[length] [Length], 
		sysc.prec [Precision], 
CASE WHEN sysc.scale IS null THEN '-' ELSE sysc.scale END [Scale], 
CASE WHEN sysc.isnullable = 1 THEN 'True' ELSE 'False' END [AllowNulls], 
CASE WHEN sysc.[status] = 128 THEN 'True' ELSE 'False' END [Identity], 
CASE WHEN sysc.colstat = 1 THEN 'True' ELSE 'False' END [PrimaryKey],
CASE WHEN fkc.parent_object_id is NULL THEN 'False' ELSE 'True' END [ForeignKey?], 
CASE WHEN fkc.parent_object_id is null THEN '-' ELSE obj.name  END [RelatedTable],
CASE WHEN ep.value is NULL THEN '-' ELSE CAST(ep.value as NVARCHAR(500)) END [Description]
FROM [sys].[sysobjects] AS syso
JOIN [sys].[syscolumns] AS sysc on syso.id = sysc.id
LEFT JOIN [sys].[systypes] AS syst ON sysc.xtype = syst.xtype and syst.name != 'sysname'
LEFT JOIN [sys].[foreign_key_columns] AS fkc on syso.id = fkc.parent_object_id and sysc.colid = fkc.parent_column_id    
LEFT JOIN [sys].[objects] AS obj ON fkc.referenced_object_id = obj.[object_id]
LEFT JOIN [sys].[extended_properties] AS ep ON syso.id = ep.major_id and sysc.colid = ep.minor_id and ep.name = 'MS_Description'
WHERE syso.type = 'U' AND  syso.name = @TableName
ORDER BY Field;
--ORDER BY FieldOrder, Field;
