/*
    Get columns in database with default values
*/

USE NorthWind2020

SELECT SO.NAME AS "Table Name", 
       SC.NAME AS "Column Name", 
       SM.TEXT AS "Default Value"
FROM dbo.sysobjects SO
     INNER JOIN dbo.syscolumns SC ON SO.id = SC.id
     LEFT JOIN dbo.syscomments SM ON SC.cdefault = SM.id
WHERE SO.xtype = 'U'
      AND SO.NAME <> 'sysdiagrams'
      AND SM.TEXT IS NOT NULL
ORDER BY SO.name, 
         SC.colid;