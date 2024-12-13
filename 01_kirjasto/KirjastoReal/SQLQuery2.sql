use KirjastoRealDB;

CREATE TABLE Book
(
    BookId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    ISBN NVARCHAR(13) NOT NULL,
    PublicationYear INT,
    AvailableCopies INT NOT NULL
);

-- Create Member table
CREATE TABLE Member
(
    MemberId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(255),
    RegistrationDate DATE NOT NULL
);

-- Create Loan table
CREATE TABLE Loan
(
    LoanId INT PRIMARY KEY IDENTITY(1,1),
    BookId INT FOREIGN KEY REFERENCES Book(BookId),
    MemberId INT FOREIGN KEY REFERENCES Member(MemberId),
    LoanDate DATE NOT NULL,
    DueDate DATE NOT NULL,
    ReturnDate DATE
);