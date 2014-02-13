
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/06/2014 14:55:22
-- Generated from EDMX file: C:\SolutionServer\fundgrid\Fundgrid.Data\fundgrid.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [fundgrid];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_grid_item_grid]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[grid_item] DROP CONSTRAINT [FK_grid_item_grid];
GO
IF OBJECT_ID(N'[dbo].[FK_grid_projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[grid] DROP CONSTRAINT [FK_grid_projects];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[grid]', 'U') IS NOT NULL
    DROP TABLE [dbo].[grid];
GO
IF OBJECT_ID(N'[dbo].[grid_item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[grid_item];
GO
IF OBJECT_ID(N'[dbo].[projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[projects];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'grids'
CREATE TABLE [dbo].[grids] (
    [id] int  NOT NULL,
    [name] varchar(50)  NULL,
    [description] varchar(50)  NULL,
    [dimension_rows] int  NULL,
    [dimension_column] int  NULL,
    [project_id] int  NULL,
    [item_value] decimal(18,2)  NULL,
    [increment_value] decimal(18,2)  NULL,
    [status] varchar(10)  NULL
);
GO

-- Creating table 'grid_item'
CREATE TABLE [dbo].[grid_item] (
    [id] int IDENTITY(1,1) NOT NULL,
    [number] int  NULL,
    [owner] varchar(50)  NULL,
    [amount] decimal(18,2)  NULL,
    [grid_id] int  NULL
);
GO

-- Creating table 'projects'
CREATE TABLE [dbo].[projects] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(50)  NULL,
    [description] varchar(50)  NULL,
    [image] varbinary(max)  NULL,
    [owner_id] char(38)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'grids'
ALTER TABLE [dbo].[grids]
ADD CONSTRAINT [PK_grids]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'grid_item'
ALTER TABLE [dbo].[grid_item]
ADD CONSTRAINT [PK_grid_item]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'projects'
ALTER TABLE [dbo].[projects]
ADD CONSTRAINT [PK_projects]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [grid_id] in table 'grid_item'
ALTER TABLE [dbo].[grid_item]
ADD CONSTRAINT [FK_grid_item_grid]
    FOREIGN KEY ([grid_id])
    REFERENCES [dbo].[grids]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_grid_item_grid'
CREATE INDEX [IX_FK_grid_item_grid]
ON [dbo].[grid_item]
    ([grid_id]);
GO

-- Creating foreign key on [project_id] in table 'grids'
ALTER TABLE [dbo].[grids]
ADD CONSTRAINT [FK_grid_projects]
    FOREIGN KEY ([project_id])
    REFERENCES [dbo].[projects]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_grid_projects'
CREATE INDEX [IX_FK_grid_projects]
ON [dbo].[grids]
    ([project_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------