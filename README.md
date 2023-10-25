# EmployeesRecord
CREATE TABLE [dbo].[Employees] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    [Surname]       NVARCHAR (MAX) NOT NULL,
    [BirthDate]     DATE           NOT NULL,
    [IpAddress]     NVARCHAR (MAX) NOT NULL,
    [IpCountryCode] NVARCHAR (MAX) NOT NULL,
    [PositionId]    INT            NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employees_Positions_PositionId] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Positions] ([Id]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_Employees_PositionId]
    ON [dbo].[Employees]([PositionId] ASC);

CREATE TABLE [dbo].[Positions] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED ([Id] ASC)
);
