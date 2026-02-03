================================ */
CREATE DATABASE OrderManagementDB;
GO

USE OrderManagementDB;
GO

/* ===============================
   TABLE CREATION
================================ */

-- Customers Table
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
    CustomerName VARCHAR(50),
    Email VARCHAR(50)
);

-- Products Table
CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    ProductName VARCHAR(50),
    Price DECIMAL(10,2)
);

-- Orders Table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY,
    CustomerId INT,
    ProductId INT,
    OrderDate DATE,
    Quantity INT,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

/* ===============================
   INSERT SAMPLE DATA
================================ */

INSERT INTO Customers VALUES
(1, 'Jyothi', 'jyothi@gmail.com'),
(2, 'Ravi', 'ravi@gmail.com');

INSERT INTO Products VALUES
(101, 'Laptop', 60000),
(102, 'Mobile', 20000);

INSERT INTO Orders VALUES
(1001, 1, 101, '2024-01-10', 1),
(1002, 2, 102, '2024-01-12', 2);

/* ===============================
   SELECT QUERIES (OUTPUT)
================================ */

-- 1. View all customers
SELECT * FROM Customers;

-- 2. View all products
SELECT * FROM Products;

-- 3. View all orders
SELECT * FROM Orders;

-- 4. Order details with customer & product
SELECT 
    o.OrderId,
    c.CustomerName,
    p.ProductName,
    o.Quantity,
    p.Price,
    (o.Quantity * p.Price) AS TotalAmount,
    o.OrderDate
FROM Orders o
JOIN Customers c ON o.CustomerId = c.CustomerId
JOIN Products p ON o.ProductId = p.ProductId;

-- 5. Total orders count
SELECT COUNT(*) AS TotalOrders FROM Orders;

-- 6. Orders by specific customer
SELECT * FROM Orders
WHERE CustomerId = 1;