truncate table  [dbo].[t_InStore]
truncate table  [dbo].[t_OutBackStore]


truncate table  [dbo].[t_CurrentCountInfo]
truncate table  [dbo].[t_PersonCreditRecord]

truncate table [dbo].[t_ScrapToolInfo] 
truncate table  [dbo].[t_ToolInfo]



insert into [dbo].[Sys_Menu_Info] values('配属管理','1001','配属管理',4,0,'','FrmBlongManage',1,4,1);
insert into [dbo].[Sys_Menu_Info] values('分类管理','1001','分类管理',5,0,'','FrmCategoryManage',1,5,1);