USE [master]
GO
/****** Object:  Database [InfoSales]    Script Date: 5/18/2024 4:32:20 PM ******/
CREATE DATABASE [InfoSales]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InfoSales', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InfoSales.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InfoSales_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InfoSales_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InfoSales].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InfoSales] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InfoSales] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InfoSales] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InfoSales] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InfoSales] SET ARITHABORT OFF 
GO
ALTER DATABASE [InfoSales] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InfoSales] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InfoSales] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InfoSales] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InfoSales] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InfoSales] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InfoSales] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InfoSales] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InfoSales] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InfoSales] SET  ENABLE_BROKER 
GO
ALTER DATABASE [InfoSales] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InfoSales] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InfoSales] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InfoSales] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InfoSales] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InfoSales] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [InfoSales] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InfoSales] SET RECOVERY FULL 
GO
ALTER DATABASE [InfoSales] SET  MULTI_USER 
GO
ALTER DATABASE [InfoSales] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InfoSales] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InfoSales] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InfoSales] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InfoSales] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'InfoSales', N'ON'
GO
USE [InfoSales]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/18/2024 4:32:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 5/18/2024 4:32:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](10) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/18/2024 4:32:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 5/18/2024 4:32:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/18/2024 4:32:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[JoinDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240516064239_Initials', N'6.0.30')
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (4, N'Na', N'Chafunarayan', N'123', 0)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (6, N'new cust2', N'new add2', N'new phone2', 0)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (7, N'abc', N'a', N'a', 0)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (8, N'', N'', N'', 0)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (9, N'a', N'b', N'cv', 0)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (10, N'aadas', N'sd', N'asdas', 0)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (11, N'Nabin Ghimire', N'Changunarayan', N'9860678770', 0)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (12, N'Nabin Ghimire', N'Changunarayan', N'9860678770', 0)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (13, N'Nabin', N'Changunarayan', N'9860678770', 1)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (14, N'Nabin Ghimire', N'Changunarayan', N'9860678', 1)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (15, N'sf sdf', N'sfsd ', N'123213', 0)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Phone], [Status]) VALUES (16, N'dffd ghhfgh', N'terte tert te', N'43242424', 1)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Title], [Rate], [Status]) VALUES (1, N'Prod1', CAST(20.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Products] ([Id], [Title], [Rate], [Status]) VALUES (2, N'Prod2', CAST(20.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Products] ([Id], [Title], [Rate], [Status]) VALUES (3, N'dasdasd', CAST(34.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Products] ([Id], [Title], [Rate], [Status]) VALUES (4, N'fsdfds sfsdf', CAST(520.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Products] ([Id], [Title], [Rate], [Status]) VALUES (5, N'dsf fsdfsdf sfsf', CAST(234.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Products] ([Id], [Title], [Rate], [Status]) VALUES (6, N'ewrrerwr rw', CAST(2222.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Products] ([Id], [Title], [Rate], [Status]) VALUES (7, N'vvvvv', CAST(362.25 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (1, 13, 1, 3, CAST(60.00 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (2, 6, 2, 3, CAST(30.00 AS Decimal(18, 2)), CAST(N'2024-05-10T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (3, 13, 1, 2, CAST(3.00 AS Decimal(18, 2)), CAST(N'2024-04-30T22:24:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (4, 13, 2, 3, CAST(6.00 AS Decimal(18, 2)), CAST(N'2024-05-15T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (5, 14, 3, 2, CAST(5.00 AS Decimal(18, 2)), CAST(N'2024-10-02T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (6, 14, 2, 5, CAST(100.00 AS Decimal(18, 2)), CAST(N'2024-05-17T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (7, 13, 2, 5, CAST(100.00 AS Decimal(18, 2)), CAST(N'2024-05-17T10:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (8, 13, 1, 1, CAST(20.00 AS Decimal(18, 2)), CAST(N'2024-05-17T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (9, 14, 3, 4, CAST(80.00 AS Decimal(18, 2)), CAST(N'2024-05-17T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (10, 13, 3, 3, CAST(69.00 AS Decimal(18, 2)), CAST(N'2024-05-17T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (11, 13, 3, 3, CAST(69.00 AS Decimal(18, 2)), CAST(N'2024-05-17T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (12, 13, 1, 1, CAST(20.00 AS Decimal(18, 2)), CAST(N'2024-05-18T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Transactions] ([TransactionId], [CustomerId], [ProductId], [Quantity], [TotalAmount], [TransactionDate], [Status]) VALUES (13, 16, 4, 6, CAST(3120.00 AS Decimal(18, 2)), CAST(N'2024-05-18T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [Phone], [Status], [JoinDate]) VALUES (1, N'asasds', N'MTIzNDU2Nzg', N'neevanaveen1998@gmail.com', N'', 1, CAST(N'1900-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [Phone], [Status], [JoinDate]) VALUES (2, N'aaaaa', N'MTExMTExMTE', N'neevanavn1998@gmail.com', N'', 1, CAST(N'1900-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([Id], [Username], [Password], [Email], [Phone], [Status], [JoinDate]) VALUES (3, N'aaaaaa', N'MTExMTExMTE', N'As3dd@c.cc', N'', 1, CAST(N'1900-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Transactions_CustomerId]    Script Date: 5/18/2024 4:32:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_CustomerId] ON [dbo].[Transactions]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_ProductId]    Script Date: 5/18/2024 4:32:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_ProductId] ON [dbo].[Transactions]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Products_ProductId]
GO
/****** Object:  StoredProcedure [dbo].[SpCustomers]    Script Date: 5/18/2024 4:32:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpCustomers]
	@flag		VARCHAR(5),
	@Id			INT				= 0,
	@name		NVARCHAR(100)	= '',
	@address	NVARCHAR(100)	= '',
	@phone		NVARCHAR(10)	= '',
	@status		BIT				= 0
AS
BEGIN
	IF(@flag = 'l')
	BEGIN
		SELECT Id, Name, Address, Phone, Status
		FROM Customers
		WHERE Status = 1 AND (Id = @id OR @id = 0)
	END
	ELSE IF(@flag = 'u')
	BEGIN
		UPDATE Customers
		SET Name = @name, Address = @address, Phone = @phone, Status = @status
		WHERE Id = @Id
	END
	ELSE IF(@flag = 'd')
	BEGIN
		UPDATE Customers
		SET Status = 0
		WHERE Id = @Id
	END
	ELSE IF(@flag = 'i')
	BEGIN
		INSERT INTO Customers( Name, Address, Phone, Status)
		VALUES (@name, @address, @phone, @status)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SpDashboard]    Script Date: 5/18/2024 4:32:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpDashboard]
	@flag	VARCHAR(10)
AS
BEGIN
	IF(@flag = 'count')
	BEGIN
		WITH Counts AS (
			SELECT (SELECT SUM(TotalAmount) FROM transactions WHERE Status = 1) AS TotalSales, 
				(SELECT COUNT(1) FROM products WHERE Status = 1) AS TotalProducts,
				(SELECT COUNT(1) FROM Customers WHERE Status = 1) AS TotalCustomer
		)
		SELECT * FROM Counts;		
	END

	ELSE IF(@flag = 'sales')
	BEGIN
		SELECT Top 10 CAST(TransactionDate AS date) TransactionDate, SUM(TotalAmount) TotalAmount
		FROM Transactions
		WHERE Status = 1
		GROUP BY CAST(TransactionDate AS date)
		ORDER BY TransactionDate
	END

	ELSE IF(@flag = 'recent')
	BEGIN
		SELECT TOP 7 T.TransactionDate, P.Title AS ProductTitle, T.TotalAmount
		FROM Transactions T JOIN Products P ON T.ProductId = P.Id
		ORDER BY TransactionDate DESC
	END

	ELSE IF(@flag = 'byProduct')
	BEGIN
		SELECT P.Title AS ProductTitle, SUM(T.TotalAmount) TotalAmount
		FROM Transactions T JOIN Products P ON T.ProductId = P.Id
		WHERE T.Status = 1
		GROUP BY p.Title
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SpProducts]    Script Date: 5/18/2024 4:32:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SpProducts]
	@flag		VARCHAR(5),
	@Id			INT				= 0,
	@title		NVARCHAR(100)	= '',
	@rate		DECIMAL(18, 2)	= 0,
	@status		BIT				= 0
AS
BEGIN
	IF(@flag = 'l')
	BEGIN
		SELECT Id, Title, Rate, Status
		FROM Products
		WHERE Status = 1 AND (Id = @id OR @id = 0)
	END
	ELSE IF(@flag = 'u')
	BEGIN
		UPDATE Products
		SET Title = @title, Rate = @rate, Status = @status
		WHERE Id = @Id
	END
	ELSE IF(@flag = 'd')
	BEGIN
		UPDATE Products
		SET Status = 0
		WHERE Id = @Id
	END
	ELSE IF(@flag = 'i')
	BEGIN
		INSERT INTO Products( Title, Rate, Status)
		VALUES (@title, @rate, @status)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SpUser]    Script Date: 5/18/2024 4:32:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpUser]
	@flag		VARCHAR(5),
	@uname		NVARCHAR(50)	= '',
	@pw			NVARCHAR(50)	= '',
	@email		NVARCHAR(100)	= '',
	@phone		NVARCHAR(10)	= '',
	@date		DATETIME		= '',
	@status		BIT				= 0
AS
BEGIN
	IF(@flag = 'i')
	BEGIN
		IF EXISTS(SELECT 1 FROM Users WHERE Username = @uname)
		BEGIN
			SELECT 'Username  already exists' Result
			RETURN
		END
		IF EXISTS(SELECT 1 FROM Users WHERE Email = @email)
		BEGIN
			SELECT 'Email already exists' Result
			RETURN
		END
		INSERT INTO Users(Username, Password, Email, Phone, Status, JoinDate)
		VALUES(@uname, @pw, @email, @phone, @status ,@date)

		SELECT 'SUCCESS' AS Result
	END

	ELSE IF(@flag = 'login')
	BEGIN
		SELECT Id, Username, Password FROM Users
		WHERE Username = @uname 
	END
END
GO
USE [master]
GO
ALTER DATABASE [InfoSales] SET  READ_WRITE 
GO
