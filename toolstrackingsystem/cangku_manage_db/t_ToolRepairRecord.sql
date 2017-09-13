CREATE TABLE [dbo].[t_ToolRepairRecord]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeName] VARCHAR(64) NOT NULL, 
    [ChildTypeName] VARCHAR(64) NOT NULL, 
    [PackCode] VARCHAR(24) NULL, 
    [PackName] VARCHAR(64) NULL, 
    [ToolCode] VARCHAR(24) NOT NULL, 
    [ToolName] VARCHAR(64) NOT NULL, 
    [ToRepairedTime] DATETIME NULL, 
    [ToRepairedPerCode] VARCHAR(50) NULL, 
    [ToRepairedPerName] VARCHAR(50) NULL, 
    [ReceiveTime] DATETIME NULL, 
    [ReceivePerCode] VARCHAR(50) NULL, 
    [ReceivePerName] VARCHAR(50) NULL, 
    [HandleTime] DATETIME NULL, 
    [HandlePerCode] VARCHAR(50) NULL, 
    [HandlePerName] VARCHAR(50) NULL, 
    [PullTime] DATETIME NULL, 
    [PullPerCode] VARCHAR(50) NULL, 
    [PullPerName] VARCHAR(50) NULL, 
    [ToRepairMemo] VARCHAR(200) NULL, 
    [ScrapMemo] VARCHAR(200) NULL, 
    [ToolStatus] INT NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'维修报废表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具配属',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'TypeName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具类别',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ChildTypeName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'包编码',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'PackCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'包名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'PackName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具编号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ToolCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'工具名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ToolName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'送修时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = 'ToRepairedTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'送修人编号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ToRepairedPerCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'送修人名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ToRepairedPerName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'接收时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ReceiveTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'接收人编号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ReceivePerCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'接收人姓名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ReceivePerName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'处理时间（维修或者报废）',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'HandleTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'处理人或者报废人编号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'HandlePerCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'处理人或者报废人姓名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'HandlePerName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'领取时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'PullTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'领取人',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'PullPerCode'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'领取人',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'PullPerName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'送修备注',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ToRepairMemo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'报废备注',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ScrapMemo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'1：已送修   2：已接收 3：已修复   4：已领回   5：已报废',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_ToolRepairRecord',
    @level2type = N'COLUMN',
    @level2name = N'ToolStatus'