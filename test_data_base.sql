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
*/

ALTER TABLE Employee 
ALTER pwd VARCHAR(30) NOT NULL 

ALTER TABLE Bar 
ADD COLUMN id_branch INT NOT NULL

SELECT * FROM Employee;