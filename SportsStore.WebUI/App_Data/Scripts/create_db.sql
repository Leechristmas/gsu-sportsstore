DROP TABLE StoreUser;
DROP TABLE Purchase;
DROP TABLE Product;
DROP TABLE Category;

GO

DROP PROCEDURE RegisterStoreUser;
--DROP PROCEDURE RegisterPurchase;

GO

CREATE TABLE Category(
  Id INT IDENTITY(1,1) PRIMARY KEY,
  CategoryName NVARCHAR(64) NOT NULL
  );

GO

CREATE TABLE Product(
  Id INT IDENTITY(1,1) PRIMARY KEY,
  ProductName NVARCHAR (128) NOT NULL,
  ProductCategoryId INT REFERENCES Category,
  Price MONEY NOT NULL,
  ProductDetails NVARCHAR(500),
  ProductImageData VARBINARY(MAX) NULL,
  ImageMimeType VARCHAR(50) NULL
  );

GO

CREATE TABLE StoreUser(
  Id INT IDENTITY(1,1) PRIMARY KEY,
  UserFirstName NVARCHAR(128) NOT NULL,
  UserLastName NVARCHAR(128) NOT NULL,
  UserEmailAddress NVARCHAR(70) NOT NULL,
  UserMobileNumber NVARCHAR(13) NOT NULL,
  UserRegisterDate DATETIME NOT NULL
  );

GO

CREATE TABLE Purchase(
  Id INT IDENTITY(1,1) PRIMARY KEY,
  PurchaseGroupId INT,
  CustomerFirstName NVARCHAR(128) NOT NULL,
  CustomerLastName NVARCHAR(128) NOT NULL,
  CustomerEmail NVARCHAR(128) NOT NULL,
  CustomerPhone NVARCHAR(13) NOT NULL,
  PurchaseDate DATETIME NOT NULL,
  PurchaseProductId INT REFERENCES Product,
  PurchaseProductCount INT NOT NULL
  );

GO

CREATE PROCEDURE RegisterStoreUser 
  @UserFirstName NVARCHAR(128),
  @UserLastName NVARCHAR(128),
  @UserEmailAddress NVARCHAR(70),
  @UserMobileNumber NVARCHAR(13)
AS
  BEGIN
  	INSERT INTO StoreUser(UserFirstName, UserLastName, UserEmailAddress, UserMobileNumber, UserRegisterDate)
      VALUES(@UserFirstName, @UserLastName, @UserEmailAddress, @UserMobileNumber, GETDATE());
  END

GO
/*
CREATE PROCEDURE RegisterPurchase
  @PurchaseGroupId INT,
  @CustomerContact NVARCHAR(200),
  @CustomerId INT,
  @PurchaseDate DATETIME,
  @PurchaseProductId INT,
  @PurchaseProductCount INT
AS
  BEGIN
    IF @CustomerId IS NULL
  	  INSERT INTO Purchase (PurchaseGroupId, CustomerContact, CustomerId, PurchaseDate, PurchaseProductId, PurchaseProductCount)
        VALUES (@PurchaseGroupId, @CustomerContact, NULL, @PurchaseDate, @PurchaseProductId, @PurchaseProductCount);
    ELSE
      INSERT INTO Purchase (PurchaseGroupId, CustomerContact, CustomerId, PurchaseDate, PurchaseProductId, PurchaseProductCount)
        VALUES (@PurchaseGroupId, NULL, @CustomerId, @PurchaseDate, @PurchaseProductId, @PurchaseProductCount);
  END

CREATE PROCEDURE GetNewPurchaseGroupId
AS
  BEGIN
  	
  END
*/