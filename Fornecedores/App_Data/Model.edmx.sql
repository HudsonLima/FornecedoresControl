
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/14/2017 18:40:30
-- Generated from EDMX file: D:\GitRepos\Fornecedores\Fornecedores\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Teste];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EstadoRegiao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegiaoSet] DROP CONSTRAINT [FK_EstadoRegiao];
GO
IF OBJECT_ID(N'[dbo].[FK_FornecedorFornecedorRegiao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FornecedorRegiaoSet] DROP CONSTRAINT [FK_FornecedorFornecedorRegiao];
GO
IF OBJECT_ID(N'[dbo].[FK_RegiaoFornecedorRegiao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FornecedorRegiaoSet] DROP CONSTRAINT [FK_RegiaoFornecedorRegiao];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EstadoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoSet];
GO
IF OBJECT_ID(N'[dbo].[FornecedorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FornecedorSet];
GO
IF OBJECT_ID(N'[dbo].[RegiaoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegiaoSet];
GO
IF OBJECT_ID(N'[dbo].[FornecedorRegiaoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FornecedorRegiaoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EstadoSet'
CREATE TABLE [dbo].[EstadoSet] (
    [IdEstado] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'FornecedorSet'
CREATE TABLE [dbo].[FornecedorSet] (
    [IdFornecedor] bigint IDENTITY(1,1) NOT NULL,
    [CNPJ] nvarchar(20)  NOT NULL,
    [Nome] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'RegiaoSet'
CREATE TABLE [dbo].[RegiaoSet] (
    [IdRegiao] bigint IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(50)  NOT NULL,
    [Ativo] tinyint  NOT NULL,
    [IdEstado] int  NOT NULL
);
GO

-- Creating table 'FornecedorRegiaoSet'
CREATE TABLE [dbo].[FornecedorRegiaoSet] (
    [IdFornecedorRegiao] bigint IDENTITY(1,1) NOT NULL,
    [IdFornecedor] bigint  NOT NULL,
    [IdRegiao] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdEstado] in table 'EstadoSet'
ALTER TABLE [dbo].[EstadoSet]
ADD CONSTRAINT [PK_EstadoSet]
    PRIMARY KEY CLUSTERED ([IdEstado] ASC);
GO

-- Creating primary key on [IdFornecedor] in table 'FornecedorSet'
ALTER TABLE [dbo].[FornecedorSet]
ADD CONSTRAINT [PK_FornecedorSet]
    PRIMARY KEY CLUSTERED ([IdFornecedor] ASC);
GO

-- Creating primary key on [IdRegiao] in table 'RegiaoSet'
ALTER TABLE [dbo].[RegiaoSet]
ADD CONSTRAINT [PK_RegiaoSet]
    PRIMARY KEY CLUSTERED ([IdRegiao] ASC);
GO

-- Creating primary key on [IdFornecedorRegiao] in table 'FornecedorRegiaoSet'
ALTER TABLE [dbo].[FornecedorRegiaoSet]
ADD CONSTRAINT [PK_FornecedorRegiaoSet]
    PRIMARY KEY CLUSTERED ([IdFornecedorRegiao] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdEstado] in table 'RegiaoSet'
ALTER TABLE [dbo].[RegiaoSet]
ADD CONSTRAINT [FK_EstadoRegiao]
    FOREIGN KEY ([IdEstado])
    REFERENCES [dbo].[EstadoSet]
        ([IdEstado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoRegiao'
CREATE INDEX [IX_FK_EstadoRegiao]
ON [dbo].[RegiaoSet]
    ([IdEstado]);
GO

-- Creating foreign key on [IdFornecedor] in table 'FornecedorRegiaoSet'
ALTER TABLE [dbo].[FornecedorRegiaoSet]
ADD CONSTRAINT [FK_FornecedorFornecedorRegiao]
    FOREIGN KEY ([IdFornecedor])
    REFERENCES [dbo].[FornecedorSet]
        ([IdFornecedor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FornecedorFornecedorRegiao'
CREATE INDEX [IX_FK_FornecedorFornecedorRegiao]
ON [dbo].[FornecedorRegiaoSet]
    ([IdFornecedor]);
GO

-- Creating foreign key on [IdRegiao] in table 'FornecedorRegiaoSet'
ALTER TABLE [dbo].[FornecedorRegiaoSet]
ADD CONSTRAINT [FK_RegiaoFornecedorRegiao]
    FOREIGN KEY ([IdRegiao])
    REFERENCES [dbo].[RegiaoSet]
        ([IdRegiao])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegiaoFornecedorRegiao'
CREATE INDEX [IX_FK_RegiaoFornecedorRegiao]
ON [dbo].[FornecedorRegiaoSet]
    ([IdRegiao]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------