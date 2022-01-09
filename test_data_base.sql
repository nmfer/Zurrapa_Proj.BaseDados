USE ZurrapaSede;

/*SELECT * FROM Bar;
SELECT * FROM Branch;
SELECT * FROM Day_Bar_Branch;
SELECT * FROM Day_Branch;

SELECT * FROM List_Employees;
SELECT * FROM Orders;
SELECT * FROM Products;
SELECT * FROM Products_in_bar;
SELECT * FROM Products_order;
SELECT * FROM Products_to_restock;
SELECT * FROM Schedule;
SELECT * FROM Warehouse;


ALTER TABLE Employee 
ALTER COLUMN pwd VARCHAR(30) NOT NULL 

ALTER TABLE Bar 
ADD id_branch INT NOT NULL

SELECT * FROM Bar;*/

DROP TABLE Warehouse;

ALTER TABLE Schedule
ALTER COLUMN entry_time FLOAT NOT NULL

ALTER TABLE Schedule
ALTER COLUMN exit_time FLOAT NOT NULL


CREATE TABLE Warehouse
(
  id_warehouse INT NOT NULL,
  PRIMARY KEY (id_warehouse)
)

CREATE TABLE Products_in_Warehouse
(
  quantity INT NOT NULL,
  purchase_price FLOAT NOT NULL,
  set_to_unit INT NOT NULL,
  minimum_quantity INT NOT NULL,
  total_quantity INT NOT NULL,
  id_warehouse INT NOT NULL,
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  FOREIGN KEY (id_warehouse) REFERENCES Warehouse(id_warehouse),
  FOREIGN KEY (id_product, name) REFERENCES Products(id_product, name),
  PRIMARY KEY (id_warehouse)
);