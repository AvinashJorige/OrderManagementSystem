USE [master]
GO
/****** Object:  Database [OrderManagementDB]    Script Date: 28-07-2020 11:29:52 ******/
CREATE DATABASE [OrderManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER\MSSQL\DATA\OrderManagementDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OrderManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER\MSSQL\DATA\OrderManagementDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OrderManagementDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrderManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrderManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrderManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrderManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrderManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrderManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OrderManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrderManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrderManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrderManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrderManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrderManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrderManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrderManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrderManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OrderManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrderManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrderManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrderManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrderManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrderManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OrderManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrderManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OrderManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [OrderManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrderManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrderManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrderManagementDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [OrderManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [OrderManagementDB]
GO
USE [OrderManagementDB]
GO
/****** Object:  Sequence [dbo].[SQ_OrderId]    Script Date: 28-07-2020 11:29:52 ******/
CREATE SEQUENCE [dbo].[SQ_OrderId] 
 AS [int]
 START WITH 10
 INCREMENT BY 1
 MINVALUE 10
 MAXVALUE 99
 CYCLE 
 CACHE 
GO
/****** Object:  UserDefinedFunction [dbo].[AUTOINCREMENTNUMBER]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTOINCREMENTNUMBER](@I INT, @PREFIX CHAR(4))
RETURNS CHAR(30)
AS
BEGIN
  RETURN @PREFIX + (CHAR(@I / 26000 % 26 + 65) +
    CHAR(@I / 1000 % 26 + 65) +
    CHAR(@I / 100 % 10 + 48) +
    CHAR(@I / 10 % 10 + 48) +
    CHAR(@I % 10 + 48))
  END

GO
/****** Object:  UserDefinedFunction [dbo].[FN_ORDERSEQID]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[FN_ORDERSEQID](@seq int)
RETURNS VARCHAR(30) 
BEGIN
	Declare @NewOrderId varchar(14)
	set @NewOrderId = (cast(YEAR(GETDATE()) as varchar) + cast(MONTH(GETDATE()) as varchar) + dbo.AutoIncrementNumber(@seq,'O'))
    
    RETURN @NewOrderId
END



GO
/****** Object:  UserDefinedFunction [dbo].[RANDAM_ALPHANUMBER]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[RANDAM_ALPHANUMBER](@SIZE INT)
RETURNS VARCHAR(8)
AS
BEGIN

DECLARE @r varchar(8)

SELECT @r = coalesce(@r, '') + n
FROM (SELECT top 8 
CHAR(number) n FROM
master..spt_values
WHERE type = 'P' AND 
(number between ascii(0) and ascii(9)
or number between ascii('A') and ascii('Z')
--or number between ascii('a') and ascii('z')
)
ORDER BY (SELECT NEW_ID FROM getNewID)) a


RETURN (SELECT @r)
END

GO
/****** Object:  Table [dbo].[DB_Errors]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DB_Errors](
	[ErrorID] [int] IDENTITY(1,1) NOT NULL,
	[ErrorNumber] [int] NULL,
	[ErrorState] [int] NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorLine] [int] NULL,
	[ErrorProcedure] [varchar](max) NULL,
	[ErrorMessage] [varchar](max) NULL,
	[ErrorDateTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Customer_T]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Customer_T](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cust_Id] [varchar](20) NULL,
	[Cust_Name] [varchar](50) NULL,
	[Cust_Email] [varchar](60) NULL,
	[Cust_DOJ] [date] NULL,
	[Cust_Address] [varchar](100) NULL,
	[Cust_City] [varchar](30) NULL,
	[Cust_Role] [int] NULL,
	[IsActive] [bit] NULL,
	[Cust_Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Customer_T_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Order_Details]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Order_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [varchar](50) NULL,
	[CustId] [varchar](20) NULL,
	[ProductId] [varchar](30) NULL,
	[Ord_Sale_date] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[UpdatedDate] [datetime] NULL,
	[Delivery_Date] [datetime] NULL,
	[Order_status] [int] NULL,
	[Quantity] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tbl_Order_Details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Order_Shipping_T]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Order_Shipping_T](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_Id] [varchar](30) NOT NULL,
	[Shipping_Id] [varchar](50) NULL,
	[Address_1] [varchar](60) NULL,
	[Address_2] [varchar](60) NULL,
	[Address_3] [varchar](60) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](30) NULL,
	[PostalCode] [varchar](10) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tbl_Order_Shipping_T_1] PRIMARY KEY CLUSTERED 
(
	[Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Order_Status_Code_M]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Order_Status_Code_M](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusCode] [char](2) NULL,
	[StatusName] [varchar](30) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Tbl_Order_Status_Code_M] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Order_Status_M]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Order_Status_M](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_id] [varchar](30) NULL,
	[Order_Status_Code] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Product_T]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Product_T](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Prod_Id] [varchar](20) NULL,
	[Prod_Name] [varchar](30) NULL,
	[Prod_Weight] [decimal](18, 2) NULL,
	[Prod_W_UOM] [int] NULL,
	[Prod_Height] [decimal](18, 2) NULL,
	[Prod_H_UOM] [int] NULL,
	[Prod_Image_Url] [varchar](50) NULL,
	[Prod_SKU] [int] NULL,
	[Prod_Barcode] [varchar](20) NULL,
	[Prod_Unit_Price] [decimal](18, 2) NULL,
	[Prod_Unit_Cost] [decimal](18, 2) NULL,
	[Prod_AvailableQuantity] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Unit_of_measure_M]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Unit_of_measure_M](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UOM_Name] [varchar](30) NULL,
	[UOM_Code] [varchar](5) NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_User_Role_M]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_User_Role_M](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Role] [varchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[IsActive] [bit] NULL,
	[User_Role_Id] [uniqueidentifier] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Users_T]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Users_T](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](30) NULL,
	[UserName] [varchar](30) NULL,
	[Email] [varchar](60) NULL,
	[HireDate] [datetime] NULL,
	[BirthDate] [datetime] NULL,
	[Role] [int] NULL,
	[Address] [varchar](100) NULL,
	[City] [varchar](20) NULL,
	[PostalCode] [varchar](10) NULL,
	[PhotoPath] [varchar](150) NULL,
	[LastDate] [datetime] NULL,
	[Notes] [nchar](10) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[UserPassword] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[getNewID]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[getNewID] as select newid() as new_id
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Tbl_Customer_T]    Script Date: 28-07-2020 11:29:52 ******/
CREATE NONCLUSTERED INDEX [IX_Tbl_Customer_T] ON [dbo].[Tbl_Customer_T]
(
	[Cust_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[USP_CANCEL_ORDER]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<AVINASH JORIGE>
-- Create date: <23-07-2020>
-- Description:	<ARCHIVE THE ORDER>
-- =============================================
CREATE PROCEDURE [dbo].[USP_CANCEL_ORDER] (
@ORDERID	VARCHAR(30),
@UPDATEDBY	UNIQUEIDENTIFIER
)
AS
BEGIN	
	SET NOCOUNT ON;    
		
	BEGIN TRY
		BEGIN TRANSACTION
			-- SET THE ISACTIVE COLUMN TO 0
			UPDATE TBL_ORDER_DETAILS SET ISACTIVE = 0, ORDER_STATUS = 3 WHERE ORDERID = @ORDERID
			UPDATE TBL_ORDER_SHIPPING_T SET ISACTIVE = 0 WHERE ORDER_ID = @ORDERID

			-- UPDATE THE ORDER STATUS COLUMN IN THE ORDER STATUS
			UPDATE TBL_ORDER_STATUS_M SET ORDER_STATUS_CODE = 'CN' WHERE ORDER_ID = @ORDERID

			/* 
				UPDATE THE STOCK BACK AS THE ORDER CANCEL
				GET THE QUANTITY FROM TBL_ORDER_DETAILS PLACED BY CUSTOMER 
			*/			
			UPDATE PDT
			SET 
				PDT.PROD_AVAILABLEQUANTITY = (PDT.PROD_AVAILABLEQUANTITY + OD.QUANTITY)
			FROM
			TBL_PRODUCT_T PDT
			INNER JOIN TBL_ORDER_DETAILS OD ON PDT.PROD_ID = OD.PRODUCTID
			WHERE 
			OD.ORDERID = @ORDERID

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		INSERT INTO DBO.DB_ERRORS
		VALUES
		  (ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE());
	   ROLLBACK TRANSACTION
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[USP_FINDVALUEINTABLE]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<AVINASH JORIGE>
-- Create date: <23-07-2020>
-- Description:	<FETCHING THE STRING VALUE FROM SP BY PASSING SEARCHING VALUE AND TABLE WHERE TO SEARCH>
-- Example :	USP_FINDVALUEINTABLE 'CAA005','TBL_CUSTOMER_T'
-- =============================================
CREATE PROCEDURE [dbo].[USP_FINDVALUEINTABLE] 
@stringToFind VARCHAR(100), @table sysname 
AS
BEGIN TRY
   DECLARE @sqlCommand varchar(max) = 'SELECT * FROM DBO.[' + @table + '] WHERE ' 
	   
   SELECT @sqlCommand = @sqlCommand + '[' + COLUMN_NAME + '] LIKE ''' + @stringToFind + '%'' OR '
   FROM INFORMATION_SCHEMA.COLUMNS 
   WHERE TABLE_SCHEMA = 'DBO'
   AND TABLE_NAME = @table 
   AND DATA_TYPE IN ('char','nchar','ntext','nvarchar','text','varchar')

   SET @sqlCommand = left(@sqlCommand,len(@sqlCommand)-3)
   EXEC (@sqlCommand)
   PRINT @sqlCommand
END TRY

BEGIN CATCH 
	INSERT INTO dbo.DB_Errors
		VALUES
	  (ERROR_NUMBER(),
	   ERROR_STATE(),
	   ERROR_SEVERITY(),
	   ERROR_LINE(),
	   ERROR_PROCEDURE(),
	   ERROR_MESSAGE(),
	   GETDATE());
END CATCH 
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_CUSTOMERORDERS]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GET_CUSTOMERORDERS]
(
	@CUSTID VARCHAR(20)
)
AS
BEGIN
	SET NOCOUNT ON
	BEGIN TRY		
		SELECT Cust_Id,Cust_Name, Cust_Email, Cust_DOJ, Cust_Address, Cust_City 
		FROM Tbl_Customer_T 
		WHERE Cust_Id = @CUSTID AND IsActive = 1

		SELECT ORDERID, ProductId, Ord_Sale_date, Delivery_Date, Order_status, Quantity, Amount 
		FROM Tbl_Order_Details 
		WHERE CustId = @CUSTID AND IsActive = 1 
		ORDER BY CreatedDate DESC

		SELECT PROD_ID, PROD_NAME, Prod_Weight, Prod_W_UOM, Prod_Height, Prod_H_UOM,  Prod_Image_Url, Prod_Barcode, Prod_Unit_Price 
		FROM Tbl_Product_T 
		WHERE PROD_ID IN (SELECT OD.ProductId FROM Tbl_Order_Details OD WHERE OD.CustId = @CUSTID) AND IsActive = 1

		SELECT Order_Id, Address_1, Address_2, Address_3, City, State, Country, PostalCode 
		FROM Tbl_Order_Shipping_T 
		WHERE Order_Id IN (SELECT OD.OrderId FROM Tbl_Order_Details OD WHERE OD.CustId = @CUSTID) AND IsActive = 1
	END TRY
	BEGIN CATCH
		INSERT INTO DBO.DB_ERRORS
			VALUES
			(ERROR_NUMBER(),
			ERROR_STATE(),
			ERROR_SEVERITY(),
			ERROR_LINE(),
			ERROR_PROCEDURE(),
			ERROR_MESSAGE(),
			GETDATE());
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GET_ORDERDETAILS]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GET_ORDERDETAILS]
(
	@ORDERID VARCHAR(40)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	BEGIN TRY
		DECLARE @CUSTID VARCHAR(30)

		SELECT @CUSTID = CustId 
		FROM Tbl_Order_Details 
		WHERE OrderId = @ORDERID AND IsActive = 1 

		SELECT Cust_Id,Cust_Name, Cust_Email, Cust_DOJ, Cust_Address, Cust_City 
		FROM Tbl_Customer_T 
		WHERE Cust_Id = @CUSTID AND IsActive = 1

		SELECT ORDERID, ProductId, Ord_Sale_date, Delivery_Date, Order_status, Quantity, Amount 
		FROM Tbl_Order_Details 
		WHERE OrderId = @ORDERID AND IsActive = 1 
		ORDER BY CreatedDate DESC

		SELECT PROD_ID, PROD_NAME, Prod_Weight, Prod_W_UOM, Prod_Height, Prod_H_UOM,  Prod_Image_Url, Prod_Barcode, Prod_Unit_Price 
		FROM Tbl_Product_T 
		WHERE PROD_ID IN (SELECT OD.ProductId FROM Tbl_Order_Details OD WHERE OD.OrderId = @ORDERID) AND IsActive = 1

		SELECT Order_Id, Address_1, Address_2, Address_3, City, State, Country, PostalCode 
		FROM Tbl_Order_Shipping_T 
		WHERE Order_Id IN (SELECT OD.OrderId FROM Tbl_Order_Details OD WHERE OD.OrderId = @ORDERID) AND IsActive = 1
	END TRY
	BEGIN CATCH
		INSERT INTO DBO.DB_ERRORS
		VALUES
		  (ERROR_NUMBER(),
		   ERROR_STATE(),
		   ERROR_SEVERITY(),
		   ERROR_LINE(),
		   ERROR_PROCEDURE(),
		   ERROR_MESSAGE(),
		   GETDATE());
	   ROLLBACK TRANSACTION
	END CATCH
END




GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_CUSTOMERS]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_INSERT_CUSTOMERS] (
@CUST_NAME		VARCHAR(50),
@CUST_EMAIL		VARCHAR(60),
@CUST_DOJ		DATE,
@CUST_ADDRESS	VARCHAR(100),
@CUST_CITY		VARCHAR(30),
@CUST_ROLE		INT,
@CUST_PWD		NVARCHAR(MAX)
)
AS
BEGIN	
	SET NOCOUNT ON;    
		
	BEGIN TRY
			INSERT INTO Tbl_Customer_T(CUST_NAME, CUST_EMAIL, CUST_DOJ, CUST_ADDRESS, CUST_CITY, CUST_ROLE, CUST_PASSWORD, ISACTIVE)
			SELECT @CUST_NAME, @CUST_EMAIL, @CUST_DOJ, @CUST_ADDRESS, @CUST_CITY, @CUST_ROLE, @CUST_PWD, 1
	END TRY
	BEGIN CATCH
		INSERT INTO dbo.DB_Errors
		VALUES
	  (ERROR_NUMBER(),
	   ERROR_STATE(),
	   ERROR_SEVERITY(),
	   ERROR_LINE(),
	   ERROR_PROCEDURE(),
	   ERROR_MESSAGE(),
	   GETDATE());
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_ORDERDETAILS]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_INSERT_ORDERDETAILS] (
@CUSTID			VARCHAR(20), 
@PRODUCTID		VARCHAR(30), 
@ORD_SALE_DATE	DATETIME, 
@DELIVERY_DATE	DATETIME, 
@ORDER_STATUS	INT, 
@QUANTITY		DECIMAL(18,2), 
@ADDRESS_1		VARCHAR(60), 
@ADDRESS_2		VARCHAR(60), 
@ADDRESS_3		VARCHAR(60), 
@CITY			VARCHAR(50),  
@COUNTRY		VARCHAR(30),  
@POSTALCODE		VARCHAR(10), 
@CREATEDBY		UNIQUEIDENTIFIER
)
AS
BEGIN	
	SET NOCOUNT ON;    
		
	BEGIN TRY

	DECLARE  @NXTID INT,
			 @NXTODID VARCHAR(30),
			 @AMOUNT DECIMAL(18,2)

	SET @NXTID   = (NEXT VALUE FOR SQ_ORDERID)	
	SET @NXTODID = (@CUSTID+ (SELECT [DBO].[FN_ORDERSEQID](@NXTID)))
	SET @AMOUNT  = (SELECT (Prod_Unit_Price*@QUANTITY) FROM Tbl_Product_T WITH(NOLOCK) WHERE Prod_Id = @PRODUCTID)

	 BEGIN TRANSACTION
			-- INSERTING THE ORDER DETAILS TO THE TABLE
			INSERT INTO TBL_ORDER_DETAILS(CUSTID, ORDERID, PRODUCTID, ORD_SALE_DATE, DELIVERY_DATE, ORDER_STATUS, QUANTITY, AMOUNT,CREATEDBY, CREATEDDATE, ISACTIVE)
			SELECT @CUSTID, @NXTODID, @PRODUCTID, @ORD_SALE_DATE, @DELIVERY_DATE, @ORDER_STATUS, @QUANTITY, @AMOUNT,@CREATEDBY, GETDATE(), 1

			-- INSERTING ORDER SHIPPING ADDRESS.
			INSERT INTO TBL_ORDER_SHIPPING_T(ORDER_ID, ADDRESS_1, ADDRESS_2, ADDRESS_3, CITY, COUNTRY, POSTALCODE, CREATEDBY, CREATEDDATE, ISACTIVE)
			SELECT @NXTODID, @ADDRESS_1, @ADDRESS_2, @ADDRESS_3, @CITY, @COUNTRY, @POSTALCODE, @CREATEDBY, GETDATE(), 1

			-- UPDATING THE STOCK DETAILS WHEN NEW ORDER PLACED.
			UPDATE TBL_PRODUCT_T SET PROD_AVAILABLEQUANTITY = (PROD_AVAILABLEQUANTITY - @QUANTITY) WHERE PROD_ID = @PRODUCTID

		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
		INSERT INTO dbo.DB_Errors
		VALUES
	  (ERROR_NUMBER(),
	   ERROR_STATE(),
	   ERROR_SEVERITY(),
	   ERROR_LINE(),
	   ERROR_PROCEDURE(),
	   ERROR_MESSAGE(),
	   GETDATE());

	   ROLLBACK TRANSACTION
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_PRODUCT]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<AVINASH JORIGE>
-- Create date: <23-07-2020>
-- Description:	<INSERTING THE NEW CUSTOMER>
-- =============================================
CREATE PROCEDURE [dbo].[USP_INSERT_PRODUCT] (
@PROD_CUSTID				VARCHAR(20),
@PROD_NAME					VARCHAR(30),
@PROD_WEIGHT				DECIMAL(18,2),
@PROD_W_UOM					INT,
@PROD_HEIGHT				DECIMAL(18,2),
@PROD_H_UOM					INT,
@PROD_IMG_URL				VARCHAR(50),
@PROD_SKU					INT,
@PROD_BARCODE				VARCHAR(20),
@PROD_AVAILABLE_QUANITITY	INT,
@CREATEDBY					UNIQUEIDENTIFIER,
@CREATEDDATE				DATETIME,
@OPER_TYPE					CHAR(1)
)
AS
BEGIN	
	SET NOCOUNT ON;    
		
	BEGIN TRY
		IF @OPER_TYPE = 'I'
		BEGIN
			-- INSERT PRODUCT DETAILS
				INSERT INTO TBL_PRODUCT_T(PROD_NAME,PROD_WEIGHT,PROD_W_UOM,PROD_HEIGHT,PROD_H_UOM,PROD_IMAGE_URL,
				PROD_SKU,PROD_AVAILABLEQUANTITY,CREATEDBY,CREATEDON,ISACTIVE)
				SELECT @PROD_NAME,@PROD_WEIGHT,@PROD_W_UOM,@PROD_HEIGHT,@PROD_H_UOM,@PROD_IMG_URL,@PROD_SKU,@PROD_AVAILABLE_QUANITITY,@CREATEDBY
				,@CREATEDDATE,1
		END
		ELSE 
		BEGIN
			-- UPDATE PRODUCT DETAILS
			UPDATE TBL_PRODUCT_T SET 
			PROD_NAME	= @PROD_NAME,
			PROD_WEIGHT = @PROD_WEIGHT,
			PROD_W_UOM	= @PROD_W_UOM,
			PROD_HEIGHT = @PROD_HEIGHT, 
			PROD_H_UOM	= @PROD_H_UOM,
			PROD_SKU	= @PROD_SKU,
			UpdatedBy	= @CREATEDBY,
			UpdatedOn	= GETDATE(),
			PROD_IMAGE_URL = @PROD_IMG_URL,
			PROD_AVAILABLEQUANTITY = @PROD_AVAILABLE_QUANITITY
		END
	END TRY
	BEGIN CATCH
		INSERT INTO dbo.DB_Errors
		VALUES
	  (ERROR_NUMBER(),
	   ERROR_STATE(),
	   ERROR_SEVERITY(),
	   ERROR_LINE(),
	   ERROR_PROCEDURE(),
	   ERROR_MESSAGE(),
	   GETDATE());
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_ORDERDETAILS]    Script Date: 28-07-2020 11:29:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_UPDATE_ORDERDETAILS] (
@UPDATE_ORDER_D		CHAR(1),
@UPDATE_SHIIPPING	CHAR(1),
@ORDERID			VARCHAR(30), 
@ORD_SALE_DATE		DATETIME		= NULL, 
@DELIVERY_DATE		DATETIME		= NULL, 
@ORDER_STATUS		INT				= NULL, 
@QUANTITY			DECIMAL(18,2)	= NULL, 
@AMOUNT				DECIMAL(18,2)	= NULL, 
@ADDRESS_1			VARCHAR(60)		= NULL, 
@ADDRESS_2			VARCHAR(60)		= NULL, 
@ADDRESS_3			VARCHAR(60)		= NULL, 
@CITY				VARCHAR(50)		= NULL,  
@COUNTRY			VARCHAR(30)		= NULL,  
@POSTALCODE			VARCHAR(10)		= NULL, 
@UPDATEDBY			UNIQUEIDENTIFIER 
)
AS
BEGIN	
	SET NOCOUNT ON;    
		
	BEGIN TRY
	BEGIN TRANSACTION	
		-- IF THERE IS CHANGE IN THE ORDER DETAILS THEN 
		IF @UPDATE_ORDER_D = 'Y'
		BEGIN
			UPDATE TBL_ORDER_DETAILS 
			SET 
					ORD_SALE_DATE	= @ORD_SALE_DATE, 
					DELIVERY_DATE	= @DELIVERY_DATE, 
					ORDER_STATUS	= @ORDER_STATUS, 
					QUANTITY		= @QUANTITY, 
					AMOUNT			= @AMOUNT,
					UPDATEDBY		= @UPDATEDBY, 
					UPDATEDDATE		= GETDATE()
			WHERE 
					ORDERID = @ORDERID

			IF @QUANTITY > (SELECT Quantity FROM TBL_ORDER_DETAILS WHERE OrderId = @ORDERID)
				BEGIN
					/*
						IF THE QUANTITY IS GREATER THE PREVIOUS QUANTITY THEN 
						1. TAKE THE DIFFERNCE OF NEW QUANTITY WITH OLD QUANTITY
						2. REDUCE THE QUANTITY IN THE PRODUCT_M TABLE WITH DIFFERENCE VALUE QUANTITY
					*/
					UPDATE	TBL_PRODUCT_T 
					SET		PROD_AVAILABLEQUANTITY = (PROD_AVAILABLEQUANTITY - (SELECT (@QUANTITY - Quantity) FROM TBL_ORDER_DETAILS WHERE OrderId = @ORDERID)) 
					WHERE	Prod_Id = (SELECT Prod_Id FROM TBL_ORDER_DETAILS WHERE OrderId = @ORDERID)
				END
			ELSE 
				BEGIN
					/*
						IF THE QUANTITY IS LESSER THE PREVIOUS QUANTITY THEN 
						1. TAKE THE DIFFERNCE OF OLD QUANTITY WITH NEW QUANTITY
						2. ADD THE QUANTITY IN THE PRODUCT_M TABLE WITH DIFFERENCE VALUE QUANTITY
					*/	
					UPDATE	TBL_PRODUCT_T 
					SET		PROD_AVAILABLEQUANTITY = (PROD_AVAILABLEQUANTITY + (SELECT (Quantity - @QUANTITY) FROM TBL_ORDER_DETAILS WHERE OrderId = @ORDERID)) 
					WHERE	Prod_Id = (SELECT Prod_Id FROM TBL_ORDER_DETAILS WHERE OrderId = @ORDERID)
				END
		END

		-- IF THERE IS NO CHANGE IN THE ORDER DETAILS BUT CHANGES IN THE SHIPPING ADDRESS.
		IF @UPDATE_SHIIPPING = 'Y'
		BEGIN
			UPDATE TBL_ORDER_SHIPPING_T
			SET 
					ADDRESS_1	= @ADDRESS_1, 
					ADDRESS_2	= @ADDRESS_2, 
					ADDRESS_3	= @ADDRESS_3, 
					CITY		= @CITY, 
					COUNTRY		= @COUNTRY, 
					POSTALCODE	= @POSTALCODE,
					UPDATEDBY	= @UPDATEDBY,
					UPDATEDDATE	= GETDATE()
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		INSERT INTO dbo.DB_Errors
		VALUES
	  (ERROR_NUMBER(),
	   ERROR_STATE(),
	   ERROR_SEVERITY(),
	   ERROR_LINE(),
	   ERROR_PROCEDURE(),
	   ERROR_MESSAGE(),
	   GETDATE());

	   ROLLBACK TRANSACTION
	END CATCH
END

GO
USE [master]
GO
ALTER DATABASE [OrderManagementDB] SET  READ_WRITE 
GO
