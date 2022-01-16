USE ZurrapaSede;

/*
Armazem tem que ter stock suficiente por semana
ex:
	cafe -> esperado para cada filial vender por volta de 600 por semana logo no armazem ficam 600*4 = 2400 + extra caso seja necessario

Os ingredientes e caf� s�o apresentados por kg
As bebidas e pastelaria s�o por unidade
*/
-- FALTA COLOCAR AINDA AS QUANTIDADES


-- ARMAZÉM (só existe 1 armazém)
INSERT INTO Warehouse(id_warehouse, phone_num, address) VALUES (00, 272228636, 'Rua G Zona Industrial, Castelo Branco');

-- PRODUTOS NO ARMAZÉM
-- minimum_quantity e quantity são dados por caixa

INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity) 
	VALUES (0, 1, 4, 10, 20);
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity) 
	VALUES (0, 2, 24, 10, 20);
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity) 
	VALUES (0, 3, 24, 10, 20);
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity) 
	VALUES (0, 4, 24, 10, 20);
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity) 
	VALUES (0, 5, 30, 10, 12);
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity) 
	VALUES (0, 6, 12, 10, 12);
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity) 
	VALUES (0, 7, 18, 10, 12);


-- Emp_Warehouse
-- ALTERAR PARA SER 1 EMP POR BAR
INSERT INTO Emp_Warehouse(id_warehouse, id_num, id_bar) 
	VALUES (0, 4, 1);
INSERT INTO Emp_Warehouse(id_warehouse, id_num, id_bar) 
	VALUES (0, 11, 1);

-- RESTOCK WAREHOUSE

-- RESTOCK BAR
