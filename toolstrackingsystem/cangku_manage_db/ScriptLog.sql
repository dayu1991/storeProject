truncate table  [dbo].[t_InStore]
truncate table  [dbo].[t_OutBackStore]


truncate table  [dbo].[t_CurrentCountInfo]
truncate table  [dbo].[t_PersonCreditRecord]

truncate table [dbo].[t_ScrapToolInfo] 
truncate table  [dbo].[t_ToolInfo]



insert into [dbo].[Sys_Menu_Info] values('配属管理','1001','配属管理',4,0,'','FrmBlongManage',1,4,1);
insert into [dbo].[Sys_Menu_Info] values('分类管理','1001','分类管理',5,0,'','FrmCategoryManage',1,5,1);








ALTER TABLE [dbo].[t_ToolInfo] ADD [IsBack] varchar(2) null default '1'; -- 是否归还  0：已借出未归还
drop table [dbo].[t_InStore];
ALTER TABLE [dbo].[t_ToolInfo] ADD IsRepaired int not null default 0 ; -- 送修状态  1：已送修  


update t_ToolInfo set IsBack=0 where ToolCode in (select ToolCode from t_OutBackStore where IsBack='0'); -- 更新新增字段



INSERT INTO [dbo].[Sys_Menu_Info]
           ([MenuName]
           ,[GroupCode]
           ,[NavigationTitle]
           ,[MenuICON]
           ,[IsMain]
           ,[ShortKey]
           ,[FileName]
           ,[AddTools]
           ,[MenuOrder]
           ,[IsActive])
     VALUES
           ('送修查询'
           ,'1003'
           ,'送修查询'
           ,'25'
           ,0
           ,null
           ,'FrmRepairScrapQuery'
           ,'1'
           ,7
           ,1)

		   
  update [Sys_User_Role] set menuid='FrmWorkerManager,ToolInfoManage,FrmDeleteData,FrmToolPackManage,FrmOutTool,FrmReturnTool,FrmScrapToolManage,FrmToolRepair,ToolRepairManageNew,FrmInStoreManage,FrmQueryBorrow,FrmQueryReturn,FrmCurrentCountManage,FrmStockInfo,FrmNotBackTool,FrmCreditQuery,frmEditUserinfo,FrmEditRoleInfo,FrmRepairScrapQuery'
   where rolecode = 'ServerRole';





