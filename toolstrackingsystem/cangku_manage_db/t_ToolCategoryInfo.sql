CREATE TABLE [dbo].[t_ToolCategoryInfo]
(
	[CategoryId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryName] VARCHAR(100) NOT NULL, 
    [OperatorUserId] BIGINT NOT NULL, 
    [OperatorUserName] VARCHAR(50) NOT NULL, 
    [ParentId] BIGINT NULL, 
    [Level] INT NOT NULL, 
    [Classification] INT NOT NULL, 
    [AddTime] DATETIME NOT NULL, 
    [ModifyTime] DATETIME NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'分类id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolCategoryInfo',
    @level2type = N'COLUMN',
    @level2name = N'CategoryId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'分类名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolCategoryInfo',
    @level2type = N'COLUMN',
    @level2name = N'CategoryName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'操作人id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolCategoryInfo',
    @level2type = N'COLUMN',
    @level2name = N'OperatorUserId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'操作人名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolCategoryInfo',
    @level2type = N'COLUMN',
    @level2name = N'OperatorUserName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'父级分类',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolCategoryInfo',
    @level2type = N'COLUMN',
    @level2name = N'ParentId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'级别：1,2,3',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolCategoryInfo',
    @level2type = N'COLUMN',
    @level2name = N'Level'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'类别 1：配属分类2：工具分类',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolCategoryInfo',
    @level2type = N'COLUMN',
    @level2name = N'Classification'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'增加时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolCategoryInfo',
    @level2type = N'COLUMN',
    @level2name = N'AddTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'修改时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolCategoryInfo',
    @level2type = N'COLUMN',
    @level2name = N'ModifyTime'