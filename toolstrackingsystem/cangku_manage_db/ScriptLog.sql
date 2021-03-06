﻿truncate table  [dbo].[t_InStore]
truncate table  [dbo].[t_OutBackStore]


truncate table  [dbo].[t_CurrentCountInfo]
truncate table  [dbo].[t_PersonCreditRecord]

truncate table [dbo].[t_ScrapToolInfo] 
truncate table  [dbo].[t_ToolInfo]
truncate table  t_ToolType

insert into [dbo].[Sys_Menu_Info] values('配属管理','1001','配属管理',4,0,'','FrmBlongManage',1,4,1);
insert into [dbo].[Sys_Menu_Info] values('分类管理','1001','分类管理',5,0,'','FrmCategoryManage',1,5,1);










ALTER TABLE [dbo].[t_ToolInfo] ADD [IsBack] varchar(2) null default '1'; -- 是否归还  0：已借出未归还
drop table [dbo].[t_InStore];
ALTER TABLE [dbo].[t_ToolInfo] ADD IsRepaired int not null default 0 ; -- 送修状态  1：已送修  



update t_ToolInfo set IsBack=0 where ToolCode in (select ToolCode from t_OutBackStore where IsBack='0'); -- 更新新增字段

-- 新增菜单信息
insert into [dbo].[Sys_Menu_Info] values('送修工具接收','1002','送修工具接收',23,0,'','ToolRepairManageNew',1,5,1);
insert into [dbo].[Sys_Menu_Info] values('送修工具待完成','1002','送修工具待完成',24,0,'','FrmToolRepairedComlete',1,6,1);
insert into [dbo].[Sys_Menu_Info] values('送修工具领取','1002','送修工具领取',25,0,'','FrmToolRepairedComlete',1,7,1);
insert into [dbo].[Sys_Menu_Info] values('报废工具补充说明','1002','报废工具补充说明',26,0,'','FrmScrapToolManageDescribe',1,8,1);





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


   ---------------------------------------10月18日后
   use [toolInfo_NanSuo];
   -- 添加扫码登录角色
   INSERT INTO [dbo].[Sys_User_Role]
           ([RoleCode]
           ,[RoleName]
           ,[MenuID])
     VALUES
           ('scanRole'
           ,'扫码登录角色'
           ,'FrmOutTool,FrmReturnTool,FrmQueryBorrow,FrmQueryReturn,FrmCurrentCountManage,FrmRepairScrapQuery');
	delete from [t_ToolType] where [TypeID] not in (select max([TypeID]) from [t_ToolType] group by [TypeName]); 

		      use [toolInfo_XiSuo];
   -- 添加扫码登录角色
   INSERT INTO [dbo].[Sys_User_Role]
           ([RoleCode]
           ,[RoleName]
           ,[MenuID])
     VALUES
           ('scanRole'
           ,'扫码登录角色'
           ,'FrmOutTool,FrmReturnTool,FrmQueryBorrow,FrmQueryReturn,FrmCurrentCountManage,FrmRepairScrapQuery');
	delete from [t_ToolType] where [TypeID] not in (select max([TypeID]) from [t_ToolType] group by [TypeName]); 

		         use [toolInfo_ShiJiaZhuang];
   -- 添加扫码登录角色
   INSERT INTO [dbo].[Sys_User_Role]
           ([RoleCode]
           ,[RoleName]
           ,[MenuID])
     VALUES
           ('scanRole'
           ,'扫码登录角色'
           ,'FrmOutTool,FrmReturnTool,FrmQueryBorrow,FrmQueryReturn,FrmCurrentCountManage,FrmRepairScrapQuery');
	delete from [t_ToolType] where [TypeID] not in (select max([TypeID]) from [t_ToolType] group by [TypeName]); 


		         use [toolInfo_DongSuo];
   -- 添加扫码登录角色
   INSERT INTO [dbo].[Sys_User_Role]
           ([RoleCode]
           ,[RoleName]
           ,[MenuID])
     VALUES
           ('scanRole'
           ,'扫码登录角色'
           ,'FrmOutTool,FrmReturnTool,FrmQueryBorrow,FrmQueryReturn,FrmCurrentCountManage,FrmRepairScrapQuery');
	delete from [t_ToolType] where [TypeID] not in (select max([TypeID]) from [t_ToolType] group by [TypeName])
	use [toolInfo_NanSuo];
	-- 更新送修工具领取菜单名称
	update Sys_Menu_Info set FileName = 'FrmlPullRepairedTool' where MenuName='送修工具领取';
	update Sys_User_Role set MenuID = 'ToolRepairManageNew,FrmToolRepairedComlete,FrmlPullRepairedTool,FrmScrapToolManageDescribe,FrmRepairScrapQuery,frmEditUserinfo,FrmEditRoleInfo' where RoleCode='ServerRole';
	use [toolInfo_XiSuo];
	-- 更新送修工具领取菜单名称
	update Sys_Menu_Info set FileName = 'FrmlPullRepairedTool' where MenuName='送修工具领取';
	update Sys_User_Role set MenuID = 'ToolRepairManageNew,FrmToolRepairedComlete,FrmlPullRepairedTool,FrmScrapToolManageDescribe,FrmRepairScrapQuery,frmEditUserinfo,FrmEditRoleInfo' where RoleCode='ServerRole';
	use [toolInfo_ShiJiaZhuang];
	-- 更新送修工具领取菜单名称
	update Sys_Menu_Info set FileName = 'FrmlPullRepairedTool' where MenuName='送修工具领取';
	update Sys_User_Role set MenuID = 'ToolRepairManageNew,FrmToolRepairedComlete,FrmlPullRepairedTool,FrmScrapToolManageDescribe,FrmRepairScrapQuery,frmEditUserinfo,FrmEditRoleInfo' where RoleCode='ServerRole';
	use [toolInfo_DongSuo];
	-- 更新送修工具领取菜单名称
	update Sys_Menu_Info set FileName = 'FrmlPullRepairedTool' where MenuName='送修工具领取';
	update Sys_User_Role set MenuID = 'ToolRepairManageNew,FrmToolRepairedComlete,FrmlPullRepairedTool,FrmScrapToolManageDescribe,FrmRepairScrapQuery,frmEditUserinfo,FrmEditRoleInfo' where RoleCode='ServerRole';




--查找工具编码和包编码相同的数据
SELECT t.ToolCode,t.ToolName,t1.[PackCode],t1.toolname  from [t_ToolInfo] as t join [t_ToolInfo] as t1 on t.[ToolCode]=t1.[PackCode]




