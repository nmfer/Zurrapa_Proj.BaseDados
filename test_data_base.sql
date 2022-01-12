USE ZurrapaSede;

UPDATE Bar
SET id_responsible = E.id_num
FROM Branch B, List_Employees E
WHERE E.responsible = 'sim';

UPDATE Products_in_Warehouse
SET set_to_unit = P.set_to_unit
FROM Products P, Products_in_Warehouse W
WHERE W.id_product = P.id_product;

UPDATE Emp_Warehouse
SET id_num = E.id_num
FROM Emp_Warehouse W, List_Employees E
WHERE E.emp_warehouse = 'sim';
