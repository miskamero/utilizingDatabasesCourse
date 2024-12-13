DECLARE @i INT = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO Member (FirstName, LastName, Address, PhoneNumber, Email, RegistrationDate)
    VALUES ('John' + CAST(@i AS NVARCHAR), 'Doe' + CAST(@i AS NVARCHAR), '123 Main St', '555-1234', '
    john.doe' + CAST(@i AS NVARCHAR) + '@example.com', '2020-01-01');
    SET @i = @i + 1;
END

-- Sample data for Book
DECLARE @j INT = 1;
WHILE @j <= 10
BEGIN
    INSERT INTO Book (Title, ISBN, PublicationYear, AvailableCopies)
    VALUES ('To Kill a Mockingbird' + CAST(@j AS NVARCHAR), '9780060935467', 1960, 3),
        ('1984' + CAST(@j AS NVARCHAR), '9780451524935', 1949, 2),
        ('The Catcher in the Rye' + CAST(@j AS NVARCHAR), '9780316769174', 1951, 4);
    SET @j = @j + 1;
END
GO