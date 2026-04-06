-- =============================================
-- Student Management System - Database Script
-- Author: Venkata Ganesh Nanipalli
-- =============================================

-- Step 1: Create Database
CREATE DATABASE StudentDb;
GO

USE StudentDb;
GO

-- Step 2: Create Students Table
CREATE TABLE Students (
    Id          INT           PRIMARY KEY IDENTITY(1,1),
    Name        NVARCHAR(100) NOT NULL,
    Email       NVARCHAR(100) NOT NULL,
    Course      NVARCHAR(100) NOT NULL,
    Age         INT           NOT NULL DEFAULT 0,
    CreatedDate DATETIME      NOT NULL DEFAULT GETUTCDATE()
);
GO

-- Step 3: Create Users Table
CREATE TABLE Users (
    Id       INT           PRIMARY KEY IDENTITY(1,1),
    Email    NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL
);
GO

-- Step 4: Insert Admin User
INSERT INTO Users (Email, Password)
VALUES ('admin@gmail.com', '1234');
GO

-- Step 5: Verify Tables
SELECT * FROM Students;
SELECT * FROM Users;
GO