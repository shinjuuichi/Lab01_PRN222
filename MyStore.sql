-- Create the MyStore database
CREATE DATABASE MyStore;
GO

-- Use the MyStore database
USE MyStore;
GO

-- Create Table AccountMember
CREATE TABLE AccountMember (
    MemberID nvarchar(20) PRIMARY KEY,
    MemberPassword nvarchar(20) NOT NULL,
    FullName nvarchar(100) NOT NULL,
    EmailAddress nvarchar(100) NOT NULL,
    MemberRole int NOT NULL
);
GO

-- Create Table Categories
CREATE TABLE Categories (
    CategoryID int PRIMARY KEY,
    CategoryName nvarchar(15) NOT NULL
);
GO

-- Create Table Products
CREATE TABLE Products (
    ProductID int IDENTITY(1,1) PRIMARY KEY,
    ProductName nvarchar(40) NOT NULL,
    CategoryID int NOT NULL,
    UnitsInStock smallint NULL,
    UnitPrice money NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
GO