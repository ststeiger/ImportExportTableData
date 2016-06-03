
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_DELDATA_Tables_All]'))
DROP VIEW [dbo].[V_DELDATA_Tables_All]
GO





CREATE VIEW [dbo].[V_DELDATA_Tables_All] 
AS 
WITH CTE_ForeignKeys AS 
( 
	SELECT DISTINCT 
		 OnTableSchema.name OnTableSchema 
		,OnTable.name AS OnTable 
		,AgainstTableSchema.name AS AgainstTableSchema 
		,AgainstTable.name AS AgainstTable 
	FROM sys.foreign_keys AS FKs 
	
	--INNER JOIN sysobjects AS OnTable ON FKs.fkeyid = OnTable.id 
	INNER JOIN sys.objects AS OnTable 
		ON OnTable.object_id = FKs.parent_object_id 
		
	INNER JOIN sys.schemas AS OnTableSchema 
		ON OnTableSchema.schema_id = OnTable.schema_id 
		
	--INNER JOIN sysobjects AS AgainstTable ON fk.rkeyid = AgainstTable.id 
	INNER JOIN sys.objects AS AgainstTable 
		ON AgainstTable.object_id = FKs.referenced_object_id 
		
	INNER JOIN sys.schemas AS AgainstTableSchema 
		ON AgainstTableSchema.schema_id = AgainstTable.schema_id 
		
	WHERE (1=1) 
	AND AgainstTable.TYPE = 'U' 
	AND OnTable.TYPE = 'U' 
	-- ignore self joins; they cause an infinite recursion 
	AND OnTable.Name <> AgainstTable.Name 
) 
,CTE_TableWithDependencies AS 
(
    SELECT 
         AllObjects.name AS OnTable 
        ,OnTableSchema.name AS OnTableSchema 
        ,CTE_ForeignKeys.againstTable AS AgainstTable 
        ,CTE_ForeignKeys.AgainstTableSchema AS AgainstTableSchema 
    FROM sys.objects AS AllObjects 
    
	INNER JOIN sys.schemas AS OnTableSchema 
		ON OnTableSchema.schema_id = AllObjects.schema_id 
        
    LEFT JOIN CTE_ForeignKeys 
		ON CTE_ForeignKeys.onTable = AllObjects.name 
		
    WHERE (1=1) 
	AND AllObjects.type = 'U' 
	AND AllObjects.name NOT LIKE 'sys%' 
) 
,CTE_DependencyResolution AS 
( 
    -- base case 
    SELECT 
         CTE_TableWithDependencies.OnTable AS TableName 
        ,CTE_TableWithDependencies.OnTableSchema AS TableSchema 
        ,1 AS Lvl 
    FROM CTE_TableWithDependencies 
    WHERE (1=1) 
	AND CTE_TableWithDependencies.AgainstTable IS NULL 
	
	
    -- recursive case 
    UNION ALL 
    
    
    SELECT 
         CTE_TableWithDependencies.OnTable AS TableName 
        ,CTE_TableWithDependencies.OnTableSchema AS TableSchema 
        ,CTE_DependencyResolution.Lvl + 1 AS Lvl 
    FROM CTE_TableWithDependencies 
    
	INNER JOIN CTE_DependencyResolution 
		ON CTE_DependencyResolution.TableName = CTE_TableWithDependencies.AgainstTable 
) 
SELECT TOP 999999999999999999 
     MAX(Lvl) AS Lvl 
    ,TableSchema 
    ,TableName 
    ,N'DELETE FROM ' + QUOTENAME(TableSchema) + N'.' + QUOTENAME(TableName) + N'; ' AS DeleteCmd 
    ,N'TRUNCATE TABLE ' + QUOTENAME(TableSchema) + N'.' + QUOTENAME(TableName) + N'; ' AS TruncateCmd -- Only works when no foreign keys 
    ,N'DBCC CHECKIDENT (''' + REPLACE(TableSchema, N'''', N'''''') + '.' + REPLACE(TableName, N'''', N'''''') + N''', RESEED, 0)' AS ReseedCmd 
FROM CTE_DependencyResolution 

GROUP BY 
	 TableSchema 
    ,TableName 
     
     
ORDER BY 
	 lvl DESC 
	,TableSchema 
	,TableName 
	 
	 
GO 

