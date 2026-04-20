IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='__EFMigrationsHistory')
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES ('20260420195712_InitialCreate', '8.0.24');