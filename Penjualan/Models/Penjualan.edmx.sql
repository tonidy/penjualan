
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/28/2015 14:55:19
-- Generated from EDMX file: D:\GITHUB\Penjualan\Models\Penjualan.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Penjualan];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Barangs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Barangs];
GO
IF OBJECT_ID(N'[dbo].[KategoriPembelis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KategoriPembelis];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Pembelis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pembelis];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Barangs'
CREATE TABLE [dbo].[Barangs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nama] nvarchar(10)  NOT NULL,
    [Harga] int  NOT NULL
);
GO

-- Creating table 'Pembelis'
CREATE TABLE [dbo].[Pembelis] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nama] nvarchar(max)  NOT NULL,
    [JenisKelamin] nvarchar(max)  NOT NULL,
    [TTL] datetime  NOT NULL,
    [KategoriPembeli_Id] int  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Total] int  NOT NULL,
    [Barang_Id] int  NOT NULL
);
GO

-- Creating table 'KategoriPembelis'
CREATE TABLE [dbo].[KategoriPembelis] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nama] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrderDetails'
CREATE TABLE [dbo].[OrderDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Order_Id] int  NOT NULL,
    [Barang_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Barangs'
ALTER TABLE [dbo].[Barangs]
ADD CONSTRAINT [PK_Barangs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pembelis'
ALTER TABLE [dbo].[Pembelis]
ADD CONSTRAINT [PK_Pembelis]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KategoriPembelis'
ALTER TABLE [dbo].[KategoriPembelis]
ADD CONSTRAINT [PK_KategoriPembelis]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [PK_OrderDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KategoriPembeli_Id] in table 'Pembelis'
ALTER TABLE [dbo].[Pembelis]
ADD CONSTRAINT [FK_KategoriPembeliPembeli]
    FOREIGN KEY ([KategoriPembeli_Id])
    REFERENCES [dbo].[KategoriPembelis]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KategoriPembeliPembeli'
CREATE INDEX [IX_FK_KategoriPembeliPembeli]
ON [dbo].[Pembelis]
    ([KategoriPembeli_Id]);
GO

-- Creating foreign key on [Order_Id] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK_OrderOrderDetail]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderDetail'
CREATE INDEX [IX_FK_OrderOrderDetail]
ON [dbo].[OrderDetails]
    ([Order_Id]);
GO

-- Creating foreign key on [Barang_Id] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK_BarangOrderDetail]
    FOREIGN KEY ([Barang_Id])
    REFERENCES [dbo].[Barangs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BarangOrderDetail'
CREATE INDEX [IX_FK_BarangOrderDetail]
ON [dbo].[OrderDetails]
    ([Barang_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------