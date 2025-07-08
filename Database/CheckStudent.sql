create database CheckStudent;
use CheckStudent;

CREATE TABLE Student (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Code NVARCHAR(50) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Status NVARCHAR(50) NOT NULL
);

CREATE TABLE StudentFace (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    FaceData IMAGE,
    CaptureDate DATETIME,
    StudentID INT NOT NULL,
    FOREIGN KEY (StudentID) REFERENCES Student(ID)
);

CREATE TABLE Subject (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Code NVARCHAR(50) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    Prerequisite NVARCHAR(500)
);

CREATE TABLE Course (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Instructor NVARCHAR(100) NOT NULL,
    InstructorName NVARCHAR(100) NOT NULL,
    Room NVARCHAR(50) NOT NULL,
    Schedule NVARCHAR(100) NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    SubjectID INT NOT NULL,
    FOREIGN KEY (SubjectID) REFERENCES Subject(ID)
);

CREATE TABLE StudentInCourse (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    EnrollmentDate DATETIME NOT NULL,
    Grade INT,
    Note NVARCHAR(255),
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    FOREIGN KEY (StudentID) REFERENCES Student(ID),
    FOREIGN KEY (CourseID) REFERENCES Course(ID)
);

CREATE TABLE Semester (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Description NVARCHAR(500),
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    CourseID INT NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Course(ID)
);

-- Insert data into the Student table
INSERT INTO Student (Code, Name, Email, Phone, Address, DateOfBirth, Gender, Status)
VALUES 
('SE151044', 'Tống Mạnh Tân', 'tantmse151044@fpt.edu.vn', '0902142663', '123 Main St', '2000-01-01', 'Male', 'Active'),
('SE170110', 'Trần Minh An', 'antmse170110@fpt.edu.vn', '09872421581', '456 Elm St', '2001-02-02', 'Male', 'Reserve'),
('SE171065', 'Dương Tôn Bảo', 'baodtse171065@fpt.edu.vn', '0636211345', '789 Pine St', '1999-03-03', 'Male', 'Graduated'),
('SE171092', 'Đặng Phan Gia Đức', 'ducpgse171092@fpt.edu.vn', '0156783145', '101 Maple St', '2002-04-04', 'Male', 'Active'),
('QE180092', 'Võ Thị Thanh Tâm', 'tamvttqe180092@fpt.edu.vn', '0326733837', '202 Oak St', '2003-05-05', 'Female', 'Inactive');

-- Insert data into the StudentFace table
INSERT INTO StudentFace (FaceData, CaptureDate, StudentID)
VALUES 
(NULL, NULL, 1),
(NULL, NULL, 2),
(NULL, NULL, 3),
(NULL, NULL, 4),
(NULL, NULL, 5);

-- Insert data into the Subject table
INSERT INTO Subject (Code, Name, Description, Prerequisite)
VALUES 
('SWD392', 'Software Architecture and Design', 'Comprehensive overview of software architecture and design principles, patterns, and best practices.', 'SWE201c'),
('SWD392', 'Software Architecture and Design', 'Comprehensive overview of software architecture and design principles, patterns, and best practices.', 'SWE201c'),
('SWD392', 'Software Architecture and Design', 'Comprehensive overview of software architecture and design principles, patterns, and best practices.', 'SWE201c'),
('SWP391', 'Software development project', 'Introduction to English Literature', 'SWE201c'),
('SWP391', 'Software development project', 'Overview of World History', 'SWE201c');

-- Insert data into the Course table
INSERT INTO Course (Instructor, InstructorName, Room, Schedule, StartTime, EndTime, SubjectID)
VALUES 
('PhuongLHK', 'Lâm Hữu Khánh Phương', 'Room 101', 'Mon-Thu', '2023-01-02 08:00:00', '2023-01-04 09:30:00', 1),
('PhuongLHK', 'Lâm Hữu Khánh Phương', 'Room 102', 'Tue-Fri', '2023-05-02 10:00:00', '2023-08-04 11:30:00', 2),
('PhuongLHK', 'Lâm Hữu Khánh Phương', 'Room 103', 'Mon-Thu', '2023-09-02 13:00:00', '2023-012-04 14:30:00', 3),
('PhuongLHK', 'Lâm Hữu Khánh Phương', 'Room 104', 'Wed-Sat', '2024-01-02 15:00:00', '2024-01-04 16:30:00', 4),
('PhuongLHK', 'Lâm Hữu Khánh Phương', 'Room 105', 'Tue-Fri', '2023-05-06 17:00:00', '2024-07-28 18:30:00', 5);

-- Insert data into the StudentInCourse table
INSERT INTO StudentInCourse (EnrollmentDate, Grade, Note, StudentID, CourseID)
VALUES 
('2023-01-10', 9.0, 'Excellent performance', 1, 1),
('2023-02-15', 7.7, 'Good understanding', 2, 2),
('2023-03-20', 8.2, 'Very good', 3, 3),
('2023-04-25', 7.3, 'Satisfactory', 4, 4),
('2023-05-30', Null, Null, 5, 5);

-- Insert data into the Semester table
INSERT INTO Semester (Name, Description, StartTime, EndTime, CourseID)
VALUES 
('Spring 2023', 'Spring semester of the academic year 2023', '2023-01-01', '2023-04-30', 1),
('Summer 2023', 'Summer semester of the academic year 2023', '2023-05-01', '2023-08-31', 2),
('Fall 2023', 'Fall semester of the academic year 2023', '2023-09-01', '2023-12-31', 3),
('Spring 2024', 'Spring semester of the academic year 2024', '2024-01-01', '2024-04-30', 4),
('Summer 2024', 'Summer semester of the academic year 2024', '2024-05-01', '2024-08-31', 5);

-- Tạo bảng User để lưu thông tin người dùng
CREATE TABLE [User] (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

-- Ví dụ thêm một số người dùng vào bảng User
INSERT INTO [User] (Username, Password, Role)
VALUES 
('admin', 'admin123', 'Admin'),
('instructor1', 'password1', 'Instructor'),
('instructor2', 'password2', 'Instructor');

DROP TABLE [User];