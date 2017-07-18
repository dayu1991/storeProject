CREATE TABLE [dbo].[t_ToolInfo]
(
	[ToolId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [ToolBelongId] BIGINT NOT NULL , 
	    [ToolBelongName] VARCHAR(100) NOT NULL, 

    [ToolCategoryId] BIGINT NULL, 
    [ToolCategoryName] VARCHAR(100) NULL, 
    [PackCode] VARCHAR(24) NULL, 
    [PackName] VARCHAR(100) NULL, 
    [ToolCode] VARCHAR(24) NOT NULL, 
    [ToolName] VARCHAR(100) NOT NULL, 
    [ToolModels] VARCHAR(50) NULL, 
    [ToolRemarks] VARCHAR(1024) NULL,
	[CheckTime] datetime NULL,
		[Location] varchar(100) NULL,  
  
    [IsDelete] BIT NOT NULL DEFAULT 0, 
    [OperatorUserId] BIGINT NOT NULL, 
    [OperatorUserName] VARCHAR(50) NOT NULL, 
    [AddTime] DATETIME NOT NULL, 
    [ModifyTime] DATETIME NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具表主键',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'ToolId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具所属的分类id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'ToolCategoryId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具所属的分类名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'ToolCategoryName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具所属的包编号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'PackCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具所属的包名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'PackName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具的编号（由程序保证唯一性）',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'ToolCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具的名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'ToolName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具的型号（最小单位）',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'ToolModels'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具的备注',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'ToolRemarks'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否删除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'IsDelete'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'操作人Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'OperatorUserId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'操作人名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'OperatorUserName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'添加时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'AddTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'修改时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'ModifyTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'检验时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'CheckTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'位置',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'Location'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具配属id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'ToolBelongId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具配属名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolInfo',
    @level2type = N'COLUMN',
    @level2name = N'ToolBelongName'