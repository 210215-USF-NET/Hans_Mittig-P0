--Drop sequence for tables
DROP TABLE orderitems;
DROP TABLE orders;
DROP TABLE inventory;
DROP TABLE location;
DROP TABLE customers;
DROP TABLE product;

--creating tables
CREATE TABLE Customers
(
	id INT IDENTITY PRIMARY KEY,
	NAME VARCHAR(50) not null,
);

CREATE TABLE Location
(
	id INT IDENTITY PRIMARY KEY,
	ADDRESS VARCHAR(40) not null,
);

CREATE TABLE Product
(
	id INT IDENTITY PRIMARY KEY,
	NAME VARCHAR(50) not null,
	DESCRIPTION VARCHAR(50) not null,
	price DECIMAL(9,2) not null
);

CREATE TABLE Inventory
(
	id INT IDENTITY PRIMARY KEY,
	nameOfInventory VARCHAR(50) not null,
	quantity INT not null,
	productid INT REFERENCES Product(id),
	locationid INT REFERENCES LOCATION(id)
);

CREATE TABLE Orders
(
	id INT IDENTITY PRIMARY KEY,
	total DECIMAL(9,2) not null,
	orderdate DATETIME2 not null,
	customerid INT REFERENCES Customers(id),
	locationid INT REFERENCES Location(id)
);

CREATE TABLE OrderItems
(	id INT IDENTITY PRIMARY KEY,
	orderid INT REFERENCES Orders(id),
	quantity INT not null,
	productid INT REFERENCES Product(id)
);


--Adding seed data
INSERT INTO customers (name) VALUES
('Hans Mittig'), ('Zach French');

INSERT INTO location (address) VALUES
('Ossining, NY'), ('Arlington, TX'), ('Los Angeles, CA');

INSERT INTO product (name, description, price) VALUES 
('Laptop','HP', 499.99), ('PC','DELL', 1000.99), ('Tablet', 'SAMSUNG', 299.99);

INSERT INTO inventory (nameOfInventory, quantity, productid, locationid) VALUES
('Tablet Stock', 20, 3, 1), ('Laptop Stock', 15, 1, 1), ('PC Stock', 10, 2, 1),
('Tablet Stock', 20, 3, 2), ('Laptop Stock', 15, 1, 2), ('PC Stock', 10, 2, 2),
('Tablet Stock', 20, 3, 3), ('Laptop Stock', 15, 1, 3), ('PC Stock', 10, 2, 3);

INSERT INTO orders (total, orderdate, customerid, locationid) VALUES
(299.99, cast('2-27-2021'as DATETIME2), 1, 1);


INSERT INTO orderitems(orderid, quantity, productid) VALUES
(1,1,3);

SELECT * FROM customers;

SELECT * FROM location;

SELECT * FROM product;

SELECT * FROM orders;

SELECT * FROM inventory;

SELECT * FROM orderitems;

SELECT * FROM product LEFT JOIN inventory ON product.id = inventory.productid JOIN location on locationid = location.id;