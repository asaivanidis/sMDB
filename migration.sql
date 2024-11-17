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
CREATE TABLE [Movies] (
    [MovieId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [ReleaseDate] datetime2 NOT NULL,
    [ImageUrl] nvarchar(max) NULL,
    [TrailerUrl] nvarchar(max) NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([MovieId])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241117165859_InitialCreate', N'9.0.0');

COMMIT;
GO

