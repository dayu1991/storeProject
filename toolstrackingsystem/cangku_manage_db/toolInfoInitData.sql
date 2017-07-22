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
           ,[ModifyTime]) select 1,'本属',3,'锤子',null,null,[ToolCode],[ToolName],[Models]
		   , [Remarks],[CheckTime],[Location],[IsActive],1,'admin',getdate(),null from  [ToolInfo].[dbo].[t_ToolInfo]
