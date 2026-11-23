-- 2 USERS
IF NOT EXISTS (SELECT 1 FROM [dbo].[Users])
BEGIN
    INSERT INTO [dbo].[Users] ([Username], [Password], [Role]) VALUES
    (N'admin', N'admin123', N'Admin'),
    (N'frontdesk', N'front123', N'FrontDesk');
END
GO

-- 4 ROOM TYPES (may bed size at max guests)
IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomTypes])
BEGIN
    INSERT INTO [dbo].[RoomTypes] ([Name], [Rate], [BedSize], [MaxGuests]) VALUES
    (N'Standard', 1500.00, N'Single', 1), (N'Deluxe', 2000.00, N'Double', 2),
    (N'Family Room', 3000.00, N'Queen', 3), (N'Suite', 5000.00, N'King', 4);
END
GO

-- 50 ROOMS (Floor 1 = Standard, 2 = Deluxe, 3 = Family Room, 4 at 5 = Suite)
IF NOT EXISTS (SELECT 1 FROM [dbo].[Rooms])
BEGIN
    INSERT INTO [dbo].[Rooms] ([RoomNumber], [RoomTypeId], [Status], [IsActive]) VALUES
    (N'101', 1, N'Available', 1), (N'102', 1, N'Available', 1), (N'103', 1, N'Available', 1), (N'104', 1, N'Available', 1), (N'105', 1, N'Available', 1), (N'106', 1, N'Available', 1), (N'107', 1, N'Available', 1), (N'108', 1, N'Available', 1), (N'109', 1, N'Available', 1), (N'110', 1, N'Available', 1),
    (N'201', 2, N'Available', 1), (N'202', 2, N'Available', 1), (N'203', 2, N'Available', 1), (N'204', 2, N'Available', 1), (N'205', 2, N'Available', 1), (N'206', 2, N'Available', 1), (N'207', 2, N'Available', 1), (N'208', 2, N'Available', 1), (N'209', 2, N'Available', 1), (N'210', 2, N'Available', 1),
    (N'301', 3, N'Available', 1), (N'302', 3, N'Available', 1), (N'303', 3, N'Available', 1), (N'304', 3, N'Available', 1), (N'305', 3, N'Available', 1), (N'306', 3, N'Available', 1), (N'307', 3, N'Available', 1), (N'308', 3, N'Available', 1), (N'309', 3, N'Available', 1), (N'310', 3, N'Available', 1),
    (N'401', 4, N'Available', 1), (N'402', 4, N'Available', 1), (N'403', 4, N'Available', 1), (N'404', 4, N'Available', 1), (N'405', 4, N'Available', 1), (N'406', 4, N'Available', 1), (N'407', 4, N'Available', 1), (N'408', 4, N'Available', 1), (N'409', 4, N'Available', 1), (N'410', 4, N'Available', 1),
    (N'501', 4, N'Available', 1), (N'502', 4, N'Available', 1), (N'503', 4, N'Available', 1), (N'504', 4, N'Available', 1), (N'505', 4, N'Available', 1), (N'506', 4, N'Available', 1), (N'507', 4, N'Available', 1), (N'508', 4, N'Available', 1), (N'509', 4, N'Available', 1), (N'510', 4, N'Available', 1);
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