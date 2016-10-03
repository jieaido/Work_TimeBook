
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/03/2016 22:01:05
-- Generated from EDMX file: C:\Users\jieai\Source\Repos\Work_TimeBook\Work_TimeBook\ConsoleApplication1\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [test1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_PermissEntities_dbo_FunctionEntities_FunctionEntity_FuntionEntityId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermissEntities] DROP CONSTRAINT [FK_dbo_PermissEntities_dbo_FunctionEntities_FunctionEntity_FuntionEntityId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_PermissEntities_dbo_MenuEntities_MenuEntity_MenuEntityId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PermissEntities] DROP CONSTRAINT [FK_dbo_PermissEntities_dbo_MenuEntities_MenuEntity_MenuEntityId];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleEntityPermissEntities_PermissEntities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleEntityPermissEntities] DROP CONSTRAINT [FK_RoleEntityPermissEntities_PermissEntities];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleEntityPermissEntities_RoleEntities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleEntityPermissEntities] DROP CONSTRAINT [FK_RoleEntityPermissEntities_RoleEntities];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoEntitiesTeamEntities_UserInfoEntities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoEntitiesTeamEntities] DROP CONSTRAINT [FK_UserInfoEntitiesTeamEntities_UserInfoEntities];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoEntitiesTeamEntities_TeamEntities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoEntitiesTeamEntities] DROP CONSTRAINT [FK_UserInfoEntitiesTeamEntities_TeamEntities];
GO
IF OBJECT_ID(N'[dbo].[FK_StationEntitiesTeamEntities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StationEntities] DROP CONSTRAINT [FK_StationEntitiesTeamEntities];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkTimeEntitiesStationEntities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkTimeEntities] DROP CONSTRAINT [FK_WorkTimeEntitiesStationEntities];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FunctionEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FunctionEntities];
GO
IF OBJECT_ID(N'[dbo].[MenuEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MenuEntities];
GO
IF OBJECT_ID(N'[dbo].[PermissEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PermissEntities];
GO
IF OBJECT_ID(N'[dbo].[RoleEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleEntities];
GO
IF OBJECT_ID(N'[dbo].[StationEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StationEntities];
GO
IF OBJECT_ID(N'[dbo].[TeamEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamEntities];
GO
IF OBJECT_ID(N'[dbo].[UserInfoEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoEntities];
GO
IF OBJECT_ID(N'[dbo].[WorkTimeEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkTimeEntities];
GO
IF OBJECT_ID(N'[dbo].[RoleEntityPermissEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleEntityPermissEntities];
GO
IF OBJECT_ID(N'[dbo].[UserInfoEntitiesTeamEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoEntitiesTeamEntities];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FunctionEntities'
CREATE TABLE [dbo].[FunctionEntities] (
    [FuntionEntityId] int IDENTITY(1,1) NOT NULL,
    [FuntionName] nvarchar(max)  NULL,
    [ControllerName] nvarchar(max)  NULL,
    [ActionName] nvarchar(max)  NULL
);
GO

-- Creating table 'MenuEntities'
CREATE TABLE [dbo].[MenuEntities] (
    [MenuEntityId] int IDENTITY(1,1) NOT NULL,
    [ParentMenuId] int  NOT NULL,
    [MenuName] nvarchar(max)  NULL,
    [MenuDisplayName] nvarchar(max)  NULL,
    [ControllerName] nvarchar(max)  NULL,
    [ActionName] nvarchar(max)  NULL,
    [SortId] int  NOT NULL
);
GO

-- Creating table 'PermissEntities'
CREATE TABLE [dbo].[PermissEntities] (
    [PermissEntityId] int IDENTITY(1,1) NOT NULL,
    [PermissName] nvarchar(max)  NULL,
    [FunctionEntity_FuntionEntityId] int  NULL,
    [MenuEntity_MenuEntityId] int  NULL
);
GO

-- Creating table 'RoleEntities'
CREATE TABLE [dbo].[RoleEntities] (
    [RoleEntityId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NULL
);
GO

-- Creating table 'StationEntities'
CREATE TABLE [dbo].[StationEntities] (
    [StationId] int IDENTITY(1,1) NOT NULL,
    [StationName] nvarchar(max)  NULL,
    [Derscpion] nvarchar(max)  NULL,
    [TeamEntities_TeamEntityId] int  NULL
);
GO

-- Creating table 'TeamEntities'
CREATE TABLE [dbo].[TeamEntities] (
    [TeamEntityId] int IDENTITY(1,1) NOT NULL,
    [TeamName] nvarchar(max)  NULL
);
GO

-- Creating table 'UserInfoEntities'
CREATE TABLE [dbo].[UserInfoEntities] (
    [UserInfoEntityId] int IDENTITY(1,1) NOT NULL,
    [LoginName] nvarchar(max)  NOT NULL,
    [LoginPwd] nvarchar(max)  NOT NULL,
    [RealName] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'WorkTimeEntities'
CREATE TABLE [dbo].[WorkTimeEntities] (
    [WorkTimeId] int IDENTITY(1,1) NOT NULL,
    [WtStartDateTime] datetime  NOT NULL,
    [WtOverDateTime] datetime  NOT NULL,
    [WtValue] real  NOT NULL,
    [WtContent] nvarchar(max)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [CreateTime] datetime  NOT NULL,
    [StationEntities_StationId] int  NULL
);
GO

-- Creating table 'RoleEntityPermissEntities'
CREATE TABLE [dbo].[RoleEntityPermissEntities] (
    [PermissEntities_PermissEntityId] int  NOT NULL,
    [RoleEntities_RoleEntityId] int  NOT NULL
);
GO

-- Creating table 'UserInfoEntitiesTeamEntities'
CREATE TABLE [dbo].[UserInfoEntitiesTeamEntities] (
    [UserInfoEntities_UserInfoEntityId] int  NOT NULL,
    [TeamEntities_TeamEntityId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FuntionEntityId] in table 'FunctionEntities'
ALTER TABLE [dbo].[FunctionEntities]
ADD CONSTRAINT [PK_FunctionEntities]
    PRIMARY KEY CLUSTERED ([FuntionEntityId] ASC);
GO

-- Creating primary key on [MenuEntityId] in table 'MenuEntities'
ALTER TABLE [dbo].[MenuEntities]
ADD CONSTRAINT [PK_MenuEntities]
    PRIMARY KEY CLUSTERED ([MenuEntityId] ASC);
GO

-- Creating primary key on [PermissEntityId] in table 'PermissEntities'
ALTER TABLE [dbo].[PermissEntities]
ADD CONSTRAINT [PK_PermissEntities]
    PRIMARY KEY CLUSTERED ([PermissEntityId] ASC);
GO

-- Creating primary key on [RoleEntityId] in table 'RoleEntities'
ALTER TABLE [dbo].[RoleEntities]
ADD CONSTRAINT [PK_RoleEntities]
    PRIMARY KEY CLUSTERED ([RoleEntityId] ASC);
GO

-- Creating primary key on [StationId] in table 'StationEntities'
ALTER TABLE [dbo].[StationEntities]
ADD CONSTRAINT [PK_StationEntities]
    PRIMARY KEY CLUSTERED ([StationId] ASC);
GO

-- Creating primary key on [TeamEntityId] in table 'TeamEntities'
ALTER TABLE [dbo].[TeamEntities]
ADD CONSTRAINT [PK_TeamEntities]
    PRIMARY KEY CLUSTERED ([TeamEntityId] ASC);
GO

-- Creating primary key on [UserInfoEntityId] in table 'UserInfoEntities'
ALTER TABLE [dbo].[UserInfoEntities]
ADD CONSTRAINT [PK_UserInfoEntities]
    PRIMARY KEY CLUSTERED ([UserInfoEntityId] ASC);
GO

-- Creating primary key on [WorkTimeId] in table 'WorkTimeEntities'
ALTER TABLE [dbo].[WorkTimeEntities]
ADD CONSTRAINT [PK_WorkTimeEntities]
    PRIMARY KEY CLUSTERED ([WorkTimeId] ASC);
GO

-- Creating primary key on [PermissEntities_PermissEntityId], [RoleEntities_RoleEntityId] in table 'RoleEntityPermissEntities'
ALTER TABLE [dbo].[RoleEntityPermissEntities]
ADD CONSTRAINT [PK_RoleEntityPermissEntities]
    PRIMARY KEY CLUSTERED ([PermissEntities_PermissEntityId], [RoleEntities_RoleEntityId] ASC);
GO

-- Creating primary key on [UserInfoEntities_UserInfoEntityId], [TeamEntities_TeamEntityId] in table 'UserInfoEntitiesTeamEntities'
ALTER TABLE [dbo].[UserInfoEntitiesTeamEntities]
ADD CONSTRAINT [PK_UserInfoEntitiesTeamEntities]
    PRIMARY KEY CLUSTERED ([UserInfoEntities_UserInfoEntityId], [TeamEntities_TeamEntityId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FunctionEntity_FuntionEntityId] in table 'PermissEntities'
ALTER TABLE [dbo].[PermissEntities]
ADD CONSTRAINT [FK_dbo_PermissEntities_dbo_FunctionEntities_FunctionEntity_FuntionEntityId]
    FOREIGN KEY ([FunctionEntity_FuntionEntityId])
    REFERENCES [dbo].[FunctionEntities]
        ([FuntionEntityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_PermissEntities_dbo_FunctionEntities_FunctionEntity_FuntionEntityId'
CREATE INDEX [IX_FK_dbo_PermissEntities_dbo_FunctionEntities_FunctionEntity_FuntionEntityId]
ON [dbo].[PermissEntities]
    ([FunctionEntity_FuntionEntityId]);
GO

-- Creating foreign key on [MenuEntity_MenuEntityId] in table 'PermissEntities'
ALTER TABLE [dbo].[PermissEntities]
ADD CONSTRAINT [FK_dbo_PermissEntities_dbo_MenuEntities_MenuEntity_MenuEntityId]
    FOREIGN KEY ([MenuEntity_MenuEntityId])
    REFERENCES [dbo].[MenuEntities]
        ([MenuEntityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_PermissEntities_dbo_MenuEntities_MenuEntity_MenuEntityId'
CREATE INDEX [IX_FK_dbo_PermissEntities_dbo_MenuEntities_MenuEntity_MenuEntityId]
ON [dbo].[PermissEntities]
    ([MenuEntity_MenuEntityId]);
GO

-- Creating foreign key on [PermissEntities_PermissEntityId] in table 'RoleEntityPermissEntities'
ALTER TABLE [dbo].[RoleEntityPermissEntities]
ADD CONSTRAINT [FK_RoleEntityPermissEntities_PermissEntities]
    FOREIGN KEY ([PermissEntities_PermissEntityId])
    REFERENCES [dbo].[PermissEntities]
        ([PermissEntityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleEntities_RoleEntityId] in table 'RoleEntityPermissEntities'
ALTER TABLE [dbo].[RoleEntityPermissEntities]
ADD CONSTRAINT [FK_RoleEntityPermissEntities_RoleEntities]
    FOREIGN KEY ([RoleEntities_RoleEntityId])
    REFERENCES [dbo].[RoleEntities]
        ([RoleEntityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleEntityPermissEntities_RoleEntities'
CREATE INDEX [IX_FK_RoleEntityPermissEntities_RoleEntities]
ON [dbo].[RoleEntityPermissEntities]
    ([RoleEntities_RoleEntityId]);
GO

-- Creating foreign key on [UserInfoEntities_UserInfoEntityId] in table 'UserInfoEntitiesTeamEntities'
ALTER TABLE [dbo].[UserInfoEntitiesTeamEntities]
ADD CONSTRAINT [FK_UserInfoEntitiesTeamEntities_UserInfoEntities]
    FOREIGN KEY ([UserInfoEntities_UserInfoEntityId])
    REFERENCES [dbo].[UserInfoEntities]
        ([UserInfoEntityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TeamEntities_TeamEntityId] in table 'UserInfoEntitiesTeamEntities'
ALTER TABLE [dbo].[UserInfoEntitiesTeamEntities]
ADD CONSTRAINT [FK_UserInfoEntitiesTeamEntities_TeamEntities]
    FOREIGN KEY ([TeamEntities_TeamEntityId])
    REFERENCES [dbo].[TeamEntities]
        ([TeamEntityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoEntitiesTeamEntities_TeamEntities'
CREATE INDEX [IX_FK_UserInfoEntitiesTeamEntities_TeamEntities]
ON [dbo].[UserInfoEntitiesTeamEntities]
    ([TeamEntities_TeamEntityId]);
GO

-- Creating foreign key on [TeamEntities_TeamEntityId] in table 'StationEntities'
ALTER TABLE [dbo].[StationEntities]
ADD CONSTRAINT [FK_StationEntitiesTeamEntities]
    FOREIGN KEY ([TeamEntities_TeamEntityId])
    REFERENCES [dbo].[TeamEntities]
        ([TeamEntityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StationEntitiesTeamEntities'
CREATE INDEX [IX_FK_StationEntitiesTeamEntities]
ON [dbo].[StationEntities]
    ([TeamEntities_TeamEntityId]);
GO

-- Creating foreign key on [StationEntities_StationId] in table 'WorkTimeEntities'
ALTER TABLE [dbo].[WorkTimeEntities]
ADD CONSTRAINT [FK_WorkTimeEntitiesStationEntities]
    FOREIGN KEY ([StationEntities_StationId])
    REFERENCES [dbo].[StationEntities]
        ([StationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkTimeEntitiesStationEntities'
CREATE INDEX [IX_FK_WorkTimeEntitiesStationEntities]
ON [dbo].[WorkTimeEntities]
    ([StationEntities_StationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------