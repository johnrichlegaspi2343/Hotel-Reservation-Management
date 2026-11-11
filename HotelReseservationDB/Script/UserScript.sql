-- 2 USERS
IF NOT EXISTS (SELECT 1 FROM [dbo].[Users])
BEGIN
    INSERT INTO [dbo].[Users] ([Username], [Password], [Role]) VALUES
    (N'admin', N'admin123', N'Admin'),
    (N'frontdesk', N'front123', N'FrontDesk');
END
GO

-- 4 ROOM TYPES
IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomTypes])
BEGIN
    INSERT INTO [dbo].[RoomTypes] ([Name], [Rate]) VALUES
    (N'Standard', 1500.00), (N'Deluxe', 2000.00), (N'Family Room', 3000.00), (N'Suite', 5000.00);
END
GO

-- 16 ROOMS (Floor 1 = Standard, 2 = Deluxe, 3 = Family Room, 4 = Suite)
IF NOT EXISTS (SELECT 1 FROM [dbo].[Rooms])
BEGIN
    INSERT INTO [dbo].[Rooms] ([RoomNumber], [RoomTypeId], [Status], [IsActive]) VALUES
    (N'101', 1, N'Available', 1), (N'102', 1, N'Available', 1), (N'103', 1, N'Available', 1), (N'104', 1, N'Available', 1),
    (N'201', 2, N'Available', 1), (N'202', 2, N'Available', 1), (N'203', 2, N'Available', 1), (N'204', 2, N'Available', 1),
    (N'301', 3, N'Available', 1), (N'302', 3, N'Available', 1), (N'303', 3, N'Available', 1), (N'304', 3, N'Available', 1),
    (N'401', 4, N'Available', 1), (N'402', 4, N'Available', 1), (N'403', 4, N'Available', 1), (N'404', 4, N'Available', 1);
END
GO

-- 50 GUESTS (GST-001 hanggang GST-050), parehong formula sa SeedData.cs
IF NOT EXISTS (SELECT 1 FROM [dbo].[Guests])
BEGIN
    DECLARE @count INT = 0;
    DECLARE @l INT = 0;
    DECLARE @f INT;
    DECLARE @first NVARCHAR(50);
    DECLARE @last NVARCHAR(50);

    WHILE @l < 5
    BEGIN
        SET @last = CHOOSE(@l + 1, N'Santos', N'Reyes', N'Cruz', N'Bautista', N'Garcia');
        SET @f = 0;
        WHILE @f < 10
        BEGIN
            SET @count = @count + 1;
            SET @first = CHOOSE(@f + 1, N'Juan', N'Jose', N'Mark', N'Carlo', N'Miguel',
                                        N'Maria', N'Ana', N'Kristine', N'Angelica', N'Patricia');

            INSERT INTO [dbo].[Guests] ([FirstName], [LastName], [Gender], [DateOfBirth], [ContactNumber], [Email],
                                        [Address], [EmergencyContactName], [EmergencyContactNumber], [IsActive])
            VALUES (@first, @last,
                    CASE WHEN @f < 5 THEN N'Male' ELSE N'Female' END,
                    DATEFROMPARTS(1980 + (@count % 20), (@count % 12) + 1, (@count % 28) + 1),
                    N'0917' + RIGHT('0000000' + CAST(@count AS VARCHAR(7)), 7),
                    LOWER(@first) + N'.' + LOWER(@last) + N'@email.com',
                    CAST(@count AS NVARCHAR(10)) + N' Rizal St., Manila',
                    N'Parent of ' + @first,
                    N'0918' + RIGHT('0000000' + CAST(@count AS VARCHAR(7)), 7),
                    1);

            SET @f = @f + 1;
        END
        SET @l = @l + 1;
    END
END
GO