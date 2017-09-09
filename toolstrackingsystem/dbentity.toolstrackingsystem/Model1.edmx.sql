
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/09/2017 19:06:52
-- Generated from EDMX file: D:\gitProject\toolstrackingsystem\dbentity.toolstrackingsystem\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [cangku_manage_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Sys_AddressInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sys_AddressInfo];
GO
IF OBJECT_ID(N'[dbo].[Sys_Menu_Info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sys_Menu_Info];
GO
IF OBJECT_ID(N'[dbo].[Sys_User_Info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sys_User_Info];
GO
IF OBJECT_ID(N'[dbo].[Sys_User_Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sys_User_Role];
GO
IF OBJECT_ID(N'[dbo].[t_CurrentCountInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_CurrentCountInfo];
GO
IF OBJECT_ID(N'[dbo].[t_OutBackStore]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_OutBackStore];
GO
IF OBJECT_ID(N'[dbo].[t_PersonCreditRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_PersonCreditRecord];
GO
IF OBJECT_ID(N'[dbo].[t_PersonInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_PersonInfo];
GO
IF OBJECT_ID(N'[dbo].[t_ScrapToolInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_ScrapToolInfo];
GO
IF OBJECT_ID(N'[dbo].[t_ToolCategoryInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_ToolCategoryInfo];
GO
IF OBJECT_ID(N'[dbo].[t_ToolInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_ToolInfo];
GO
IF OBJECT_ID(N'[dbo].[t_ToolPrepairRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_ToolPrepairRecord];
GO
IF OBJECT_ID(N'[dbo].[t_ToolType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_ToolType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Sys_AddressInfo'
CREATE TABLE [dbo].[Sys_AddressInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [MacAddress] varchar(50)  NOT NULL,
    [Address] varchar(50)  NOT NULL,
    [IsActive] int  NOT NULL
);
GO

-- Creating table 'Sys_Menu_Info'
CREATE TABLE [dbo].[Sys_Menu_Info] (
    [MenuID] bigint IDENTITY(1,1) NOT NULL,
    [MenuName] varchar(32)  NOT NULL,
    [GroupCode] varchar(16)  NULL,
    [NavigationTitle] varchar(32)  NULL,
    [MenuICON] int  NULL,
    [IsMain] varchar(1)  NOT NULL,
    [ShortKey] varchar(32)  NULL,
    [FileName] varchar(64)  NULL,
    [AddTools] varchar(1)  NOT NULL,
    [MenuOrder] int  NULL,
    [IsActive] varchar(1)  NOT NULL
);
GO

-- Creating table 'Sys_User_Info'
CREATE TABLE [dbo].[Sys_User_Info] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserCode] varchar(32)  NOT NULL,
    [UserName] varchar(96)  NULL,
    [PassWord] varchar(128)  NULL,
    [UserRole] varchar(50)  NULL,
    [Description] varchar(256)  NULL,
    [IsActive] int  NOT NULL,
    [CreateTime] datetime  NULL
);
GO

-- Creating table 'Sys_User_Role'
CREATE TABLE [dbo].[Sys_User_Role] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [RoleCode] varchar(32)  NOT NULL,
    [RoleName] varchar(50)  NOT NULL,
    [MenuID] varchar(512)  NOT NULL
);
GO

-- Creating table 't_CurrentCountInfo'
CREATE TABLE [dbo].[t_CurrentCountInfo] (
    [CurrentCountID] bigint IDENTITY(1,1) NOT NULL,
    [TypeName] varchar(64)  NOT NULL,
    [ChildTypeName] varchar(64)  NULL,
    [PackCode] varchar(24)  NULL,
    [PackName] varchar(64)  NULL,
    [ToolCode] varchar(24)  NOT NULL,
    [ToolName] varchar(64)  NOT NULL,
    [Models] varchar(32)  NULL,
    [Location] varchar(32)  NULL,
    [Remarks] varchar(1024)  NULL,
    [InStoreTime] varchar(24)  NULL,
    [OutStoreTime] varchar(24)  NULL,
    [BackTime] varchar(24)  NULL,
    [OptionType] varchar(12)  NULL,
    [PersonCode] varchar(64)  NULL,
    [PersonName] varchar(64)  NULL,
    [BackPesonCode] varchar(64)  NULL,
    [BackPersonName] varchar(64)  NULL,
    [describes] varchar(1024)  NULL,
    [OptionPerson] varchar(32)  NULL
);
GO

-- Creating table 't_OutBackStore'
CREATE TABLE [dbo].[t_OutBackStore] (
    [OutBackStoreID] bigint IDENTITY(1,1) NOT NULL,
    [ToolCode] varchar(24)  NOT NULL,
    [ToolName] varchar(64)  NOT NULL,
    [OutStoreTime] varchar(24)  NULL,
    [PersonCode] varchar(64)  NOT NULL,
    [PersonName] varchar(64)  NOT NULL,
    [UserTimeInfo] varchar(24)  NULL,
    [IsBack] varchar(2)  NULL,
    [BackTime] varchar(24)  NULL,
    [BackPesonCode] varchar(64)  NULL,
    [BackPersonName] varchar(64)  NULL,
    [outdescribes] varchar(1024)  NULL,
    [backdescribes] varchar(1024)  NULL,
    [OptionPerson] varchar(32)  NULL,
    [IsCredit] varchar(1)  NOT NULL
);
GO

-- Creating table 't_PersonCreditRecord'
CREATE TABLE [dbo].[t_PersonCreditRecord] (
    [CreditID] bigint IDENTITY(1,1) NOT NULL,
    [PackCode] varchar(24)  NULL,
    [PackName] varchar(64)  NULL,
    [ToolCode] varchar(24)  NOT NULL,
    [ToolName] varchar(64)  NOT NULL,
    [PersonCode] varchar(64)  NULL,
    [PersonName] varchar(64)  NULL,
    [OutStoreTime] varchar(24)  NULL,
    [UserTimeInfo] varchar(24)  NULL,
    [OptionPerson] varchar(32)  NULL,
    [OptionTime] varchar(32)  NULL
);
GO

-- Creating table 't_PersonInfo'
CREATE TABLE [dbo].[t_PersonInfo] (
    [PersonID] bigint IDENTITY(1,1) NOT NULL,
    [PersonCode] varchar(64)  NOT NULL,
    [PersonName] varchar(64)  NOT NULL,
    [RFID] varchar(64)  NULL,
    [Remarks] varchar(512)  NULL,
    [OptionPerson] varchar(32)  NULL,
    [IsReceive] varchar(1)  NOT NULL
);
GO

-- Creating table 't_ToolCategoryInfo'
CREATE TABLE [dbo].[t_ToolCategoryInfo] (
    [CategoryId] bigint IDENTITY(1,1) NOT NULL,
    [CategoryName] varchar(100)  NOT NULL,
    [OperatorUserId] bigint  NOT NULL,
    [OperatorUserName] varchar(50)  NOT NULL,
    [ParentId] bigint  NULL,
    [Level] int  NOT NULL,
    [Classification] int  NOT NULL,
    [AddTime] datetime  NOT NULL,
    [ModifyTime] datetime  NULL
);
GO

-- Creating table 't_ToolInfo'
CREATE TABLE [dbo].[t_ToolInfo] (
    [ToolID] bigint IDENTITY(1,1) NOT NULL,
    [TypeName] varchar(64)  NOT NULL,
    [ChildTypeName] varchar(64)  NULL,
    [PackCode] varchar(24)  NULL,
    [PackName] varchar(64)  NULL,
    [CarGroupInfo] varchar(64)  NULL,
    [ToolCode] varchar(24)  NOT NULL,
    [ToolName] varchar(64)  NOT NULL,
    [Models] varchar(32)  NULL,
    [Location] varchar(32)  NULL,
    [Remarks] varchar(1024)  NULL,
    [CheckTime] varchar(24)  NULL,
    [IsActive] varchar(2)  NULL,
    [OptionPerson] varchar(32)  NULL,
    [IsBack] varchar(2)  NULL
);
GO

-- Creating table 't_ToolType'
CREATE TABLE [dbo].[t_ToolType] (
    [TypeID] bigint IDENTITY(1,1) NOT NULL,
    [TypeName] varchar(64)  NOT NULL,
    [classification] int  NULL,
    [OptionPerson] varchar(32)  NULL,
    [fatherCode] varchar(4)  NULL,
    [childCode] varchar(6)  NULL
);
GO

-- Creating table 't_ToolPrepairRecord'
CREATE TABLE [dbo].[t_ToolPrepairRecord] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [ToolCode] varchar(50)  NOT NULL,
    [ToolName] varchar(50)  NOT NULL,
    [PrepairTime] varchar(50)  NULL,
    [BackTime] varchar(50)  NULL,
    [OptionPerson] varchar(50)  NULL,
    [BackOptionPerson] varchar(50)  NULL,
    [IsActive] int  NOT NULL
);
GO

-- Creating table 't_ScrapToolInfo'
CREATE TABLE [dbo].[t_ScrapToolInfo] (
    [ScrapID] bigint IDENTITY(1,1) NOT NULL,
    [ToolCode] varchar(24)  NOT NULL,
    [ToolName] varchar(64)  NOT NULL,
    [ScrapTime] varchar(24)  NULL,
    [Remarks] varchar(1024)  NULL,
    [OptionPerson] varchar(32)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Sys_AddressInfo'
ALTER TABLE [dbo].[Sys_AddressInfo]
ADD CONSTRAINT [PK_Sys_AddressInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [MenuID] in table 'Sys_Menu_Info'
ALTER TABLE [dbo].[Sys_Menu_Info]
ADD CONSTRAINT [PK_Sys_Menu_Info]
    PRIMARY KEY CLUSTERED ([MenuID] ASC);
GO

-- Creating primary key on [ID] in table 'Sys_User_Info'
ALTER TABLE [dbo].[Sys_User_Info]
ADD CONSTRAINT [PK_Sys_User_Info]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Sys_User_Role'
ALTER TABLE [dbo].[Sys_User_Role]
ADD CONSTRAINT [PK_Sys_User_Role]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [CurrentCountID] in table 't_CurrentCountInfo'
ALTER TABLE [dbo].[t_CurrentCountInfo]
ADD CONSTRAINT [PK_t_CurrentCountInfo]
    PRIMARY KEY CLUSTERED ([CurrentCountID] ASC);
GO

-- Creating primary key on [OutBackStoreID] in table 't_OutBackStore'
ALTER TABLE [dbo].[t_OutBackStore]
ADD CONSTRAINT [PK_t_OutBackStore]
    PRIMARY KEY CLUSTERED ([OutBackStoreID] ASC);
GO

-- Creating primary key on [CreditID] in table 't_PersonCreditRecord'
ALTER TABLE [dbo].[t_PersonCreditRecord]
ADD CONSTRAINT [PK_t_PersonCreditRecord]
    PRIMARY KEY CLUSTERED ([CreditID] ASC);
GO

-- Creating primary key on [PersonCode] in table 't_PersonInfo'
ALTER TABLE [dbo].[t_PersonInfo]
ADD CONSTRAINT [PK_t_PersonInfo]
    PRIMARY KEY CLUSTERED ([PersonCode] ASC);
GO

-- Creating primary key on [CategoryId] in table 't_ToolCategoryInfo'
ALTER TABLE [dbo].[t_ToolCategoryInfo]
ADD CONSTRAINT [PK_t_ToolCategoryInfo]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [ToolCode] in table 't_ToolInfo'
ALTER TABLE [dbo].[t_ToolInfo]
ADD CONSTRAINT [PK_t_ToolInfo]
    PRIMARY KEY CLUSTERED ([ToolCode] ASC);
GO

-- Creating primary key on [TypeID] in table 't_ToolType'
ALTER TABLE [dbo].[t_ToolType]
ADD CONSTRAINT [PK_t_ToolType]
    PRIMARY KEY CLUSTERED ([TypeID] ASC);
GO

-- Creating primary key on [ID] in table 't_ToolPrepairRecord'
ALTER TABLE [dbo].[t_ToolPrepairRecord]
ADD CONSTRAINT [PK_t_ToolPrepairRecord]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ToolCode] in table 't_ScrapToolInfo'
ALTER TABLE [dbo].[t_ScrapToolInfo]
ADD CONSTRAINT [PK_t_ScrapToolInfo]
    PRIMARY KEY CLUSTERED ([ToolCode] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------