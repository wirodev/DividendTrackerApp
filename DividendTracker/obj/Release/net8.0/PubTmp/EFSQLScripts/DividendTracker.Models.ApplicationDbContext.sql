IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240331192601_InitialCreate'
)
BEGIN
    CREATE TABLE [Stocks] (
        [Ticker] nvarchar(450) NOT NULL,
        [CompanyName] nvarchar(max) NOT NULL,
        [Sector] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Stocks] PRIMARY KEY ([Ticker])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240331192601_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240331192601_InitialCreate', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240331194333_SeedStockData'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Ticker', N'CompanyName', N'Sector') AND [object_id] = OBJECT_ID(N'[Stocks]'))
        SET IDENTITY_INSERT [Stocks] ON;
    EXEC(N'INSERT INTO [Stocks] ([Ticker], [CompanyName], [Sector])
    VALUES (N''ABB'', N''ABB'', N''Industrial''),
    (N''ALFA'', N''Alfa Laval'', N''Industrial''),
    (N''ALIV-SDB'', N''Autoliv'', N''Industrial''),
    (N''ASSA-B'', N''Assa Abloy'', N''Real Estate''),
    (N''ATCO-A'', N''Atlas Copco A'', N''Industrial''),
    (N''ATCO-B'', N''Atlas Copco B'', N''Industrial''),
    (N''AZN'', N''AstraZeneca'', N''Pharma''),
    (N''BOL'', N''Boliden'', N''Raw Material''),
    (N''ERIC-B'', N''Ericsson B'', N''Communication''),
    (N''ESSITY-B'', N''Essity B'', N''Consumer goods''),
    (N''EVO'', N''Evolution'', N''Consumer goods''),
    (N''GETI-B'', N''Getinge'', N''Pharma''),
    (N''HEXA-B'', N''Hexagon'', N''Utilities''),
    (N''HM-B'', N''Hennes & Mauritz'', N''Consumer goods''),
    (N''INVE-B'', N''Investor B'', N''Investment company''),
    (N''NDA-SE'', N''Nordea Bank'', N''Finance''),
    (N''NIBE-B'', N''NIBE Industrier'', N''Utilities''),
    (N''SAND'', N''Sandvik'', N''Industrial''),
    (N''SCA-B'', N''SCA B'', N''Raw Material''),
    (N''SEB-A'', N''SEB A'', N''Finance''),
    (N''SHB-A'', N''Handelsbanken A'', N''Finance''),
    (N''SKF-B'', N''SKF B'', N''Industrial''),
    (N''SWED-A'', N''Swedbank'', N''Finance''),
    (N''TEL2-B'', N''Tele2 B'', N''Communication''),
    (N''TELIA'', N''Telia Company'', N''Communication''),
    (N''VOLV-B'', N''Volvo B'', N''Industrial'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Ticker', N'CompanyName', N'Sector') AND [object_id] = OBJECT_ID(N'[Stocks]'))
        SET IDENTITY_INSERT [Stocks] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240331194333_SeedStockData'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240331194333_SeedStockData', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240331200652_AddDividendTable'
)
BEGIN
    CREATE TABLE [Dividends] (
        [DividendId] int NOT NULL IDENTITY,
        [Ticker] nvarchar(450) NOT NULL,
        [CurrentStockPrice] decimal(18,2) NOT NULL,
        [DividendAmount] decimal(18,2) NOT NULL,
        [PayoutFrequency] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Dividends] PRIMARY KEY ([DividendId]),
        CONSTRAINT [FK_Dividends_Stocks_Ticker] FOREIGN KEY ([Ticker]) REFERENCES [Stocks] ([Ticker]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240331200652_AddDividendTable'
)
BEGIN
    CREATE INDEX [IX_Dividends_Ticker] ON [Dividends] ([Ticker]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240331200652_AddDividendTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240331200652_AddDividendTable', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240331203011_SeedDividendsWithIds'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DividendId', N'CurrentStockPrice', N'DividendAmount', N'PayoutFrequency', N'Ticker') AND [object_id] = OBJECT_ID(N'[Dividends]'))
        SET IDENTITY_INSERT [Dividends] ON;
    EXEC(N'INSERT INTO [Dividends] ([DividendId], [CurrentStockPrice], [DividendAmount], [PayoutFrequency], [Ticker])
    VALUES (-26, 239.6, 7.75, N''Annually'', N''ESSITY-B''),
    (-25, 285.3, 7.5, N''Annually'', N''BOL''),
    (-24, 228.1, 7.5, N''Annually'', N''SKF-B''),
    (-23, 428.0, 7.5, N''Annually'', N''ALFA''),
    (-22, 86.44, 6.9, N''Annually'', N''TEL2-B''),
    (-21, 149.68, 6.5, N''Annually'', N''HM-B''),
    (-20, 241.0, 5.5, N''Annually'', N''SAND''),
    (-19, 309.4, 5.4, N''Annually'', N''ASSA-B''),
    (-18, 263.8, 4.8, N''Annually'', N''INVE-B''),
    (-17, 206.4, 4.4, N''Annually'', N''GETI-B''),
    (-16, 1369.0, 2.9, N''Annually'', N''AZN''),
    (-15, 160.75, 2.8, N''Annually'', N''ATCO-B''),
    (-14, 181.7, 2.8, N''Annually'', N''ATCO-A''),
    (-13, 156.55, 2.75, N''Annually'', N''SCA-B''),
    (-12, 57.02, 2.7, N''Annually'', N''ERIC-B''),
    (-11, 1258.5, 2.66, N''Annually'', N''ALIV-SDB''),
    (-10, 1358.6, 2.65, N''Annually'', N''EVO''),
    (-9, 25.69, 2.0, N''Annually'', N''TELIA''),
    (-8, 306.9, 18.0, N''Annually'', N''VOLV-B''),
    (-7, 226.5, 15.15, N''Annually'', N''SWED-A''),
    (-6, 122.3, 13.0, N''Annually'', N''SHB-A''),
    (-5, 144.85, 11.5, N''Annually'', N''SEB-A''),
    (-4, 497.4, 1.01, N''Annually'', N''ABB''),
    (-3, 125.76, 0.92, N''Annually'', N''NDA-SE''),
    (-2, 55.06, 0.65, N''Annually'', N''NIBE-B''),
    (-1, 124.95, 0.13, N''Annually'', N''HEXA-B'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DividendId', N'CurrentStockPrice', N'DividendAmount', N'PayoutFrequency', N'Ticker') AND [object_id] = OBJECT_ID(N'[Dividends]'))
        SET IDENTITY_INSERT [Dividends] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240331203011_SeedDividendsWithIds'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240331203011_SeedDividendsWithIds', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240401212003_CreateUserPortfolio'
)
BEGIN
    CREATE TABLE [UserPortfolios] (
        [UserPortfolioId] int NOT NULL IDENTITY,
        [Ticker] nvarchar(450) NOT NULL,
        [AverageCostPerShare] decimal(18,2) NOT NULL,
        [AmountOfSharesOwned] int NOT NULL,
        CONSTRAINT [PK_UserPortfolios] PRIMARY KEY ([UserPortfolioId]),
        CONSTRAINT [FK_UserPortfolios_Stocks_Ticker] FOREIGN KEY ([Ticker]) REFERENCES [Stocks] ([Ticker]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240401212003_CreateUserPortfolio'
)
BEGIN
    CREATE INDEX [IX_UserPortfolios_Ticker] ON [UserPortfolios] ([Ticker]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240401212003_CreateUserPortfolio'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240401212003_CreateUserPortfolio', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240403135421_RemoveStockNavigationProperty'
)
BEGIN
    ALTER TABLE [UserPortfolios] DROP CONSTRAINT [FK_UserPortfolios_Stocks_Ticker];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240403135421_RemoveStockNavigationProperty'
)
BEGIN
    DROP INDEX [IX_UserPortfolios_Ticker] ON [UserPortfolios];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240403135421_RemoveStockNavigationProperty'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserPortfolios]') AND [c].[name] = N'Ticker');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [UserPortfolios] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [UserPortfolios] ALTER COLUMN [Ticker] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240403135421_RemoveStockNavigationProperty'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240403135421_RemoveStockNavigationProperty', N'8.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240408202644_UpdateDatabaseSchemaForUserPortfolio'
)
BEGIN
    DROP INDEX [IX_Dividends_Ticker] ON [Dividends];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240408202644_UpdateDatabaseSchemaForUserPortfolio'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserPortfolios]') AND [c].[name] = N'Ticker');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [UserPortfolios] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [UserPortfolios] ALTER COLUMN [Ticker] nvarchar(450) NOT NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240408202644_UpdateDatabaseSchemaForUserPortfolio'
)
BEGIN
    CREATE INDEX [IX_UserPortfolios_Ticker] ON [UserPortfolios] ([Ticker]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240408202644_UpdateDatabaseSchemaForUserPortfolio'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Dividends_Ticker] ON [Dividends] ([Ticker]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240408202644_UpdateDatabaseSchemaForUserPortfolio'
)
BEGIN
    ALTER TABLE [UserPortfolios] ADD CONSTRAINT [FK_UserPortfolios_Stocks_Ticker] FOREIGN KEY ([Ticker]) REFERENCES [Stocks] ([Ticker]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240408202644_UpdateDatabaseSchemaForUserPortfolio'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240408202644_UpdateDatabaseSchemaForUserPortfolio', N'8.0.3');
END;
GO

COMMIT;
GO

