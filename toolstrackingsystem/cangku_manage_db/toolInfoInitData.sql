	  truncate table [dbo].[t_ToolCategoryInfo]

    truncate table [dbo].[t_ToolInfo]
	
	INSERT INTO [t_ToolCategoryInfo]([CategoryName],[OperatorUserId],[OperatorUserName],[ParentId],[Level] ,[Classification],[AddTime])
     VALUES('本属',1,'admin',0,1,1,GETDATE())

	 INSERT INTO [t_ToolCategoryInfo]([CategoryName],[OperatorUserId],[OperatorUserName],[ParentId],[Level] ,[Classification],[AddTime])
     VALUES('工具包',1,'admin',0,1,1,GETDATE())

	 
	INSERT INTO [t_ToolCategoryInfo]([CategoryName],[OperatorUserId],[OperatorUserName],[ParentId],[Level] ,[Classification],[AddTime])
     VALUES('锤子',1,'admin',0,1,2,GETDATE())

	 INSERT INTO [t_ToolCategoryInfo]([CategoryName],[OperatorUserId],[OperatorUserName],[ParentId],[Level] ,[Classification],[AddTime])
     VALUES('电器',1,'admin',0,1,2,GETDATE())

	  INSERT INTO [t_ToolCategoryInfo]([CategoryName],[OperatorUserId],[OperatorUserName],[ParentId],[Level] ,[Classification],[AddTime])
     VALUES('扭力扳手',1,'admin',0,1,2,GETDATE())
	 	  INSERT INTO [t_ToolCategoryInfo]([CategoryName],[OperatorUserId],[OperatorUserName],[ParentId],[Level] ,[Classification],[AddTime])
     VALUES('钳子',1,'admin',0,1,2,GETDATE())
	 	  INSERT INTO [t_ToolCategoryInfo]([CategoryName],[OperatorUserId],[OperatorUserName],[ParentId],[Level] ,[Classification],[AddTime])
     VALUES('通用类',1,'admin',0,1,2,GETDATE())
	 	  INSERT INTO [t_ToolCategoryInfo]([CategoryName],[OperatorUserId],[OperatorUserName],[ParentId],[Level] ,[Classification],[AddTime])
     VALUES('一般扳手',1,'admin',0,1,2,GETDATE())


INSERT INTO [cangku_manage_db].[dbo].[t_ToolInfo]
           ([ToolBelongId]
           ,[ToolBelongName]
           ,[ToolCategoryId]
           ,[ToolCategoryName]
           ,[PackCode]
           ,[PackName]
           ,[ToolCode]
           ,[ToolName]
           ,[ToolModels]
           ,[ToolRemarks]
           ,[CheckTime]
           ,[Location]
           ,[IsDelete]
           ,[OperatorUserId]
           ,[OperatorUserName]
           ,[AddTime]
           ,[ModifyTime]) 
		   select 0,TypeName,3,ChildTypeName,PackCode,PackName,[ToolCode],[ToolName],[Models]
		   , [Remarks],[CheckTime],[Location],[IsActive],1,'admin',getdate(),null from  [ToolInfo].[dbo].[t_ToolInfo] 

		   update [dbo].[t_ToolInfo] set [CheckTime]=null where [CheckTime]='1900-01-01 00:00:00.000'



		    UPDATE t
SET t.[ToolBelongId] = tc.[CategoryId] 
FROM [t_ToolInfo] AS t    
INNER JOIN [t_ToolCategoryInfo] AS tc ON t.[ToolBelongName] = tc.CategoryName

 UPDATE t
SET t.[ToolCategoryId] = tc.[CategoryId] 
FROM [t_ToolInfo] AS t    
INNER JOIN [t_ToolCategoryInfo] AS tc ON t.[ToolCategoryName] = tc.CategoryName
