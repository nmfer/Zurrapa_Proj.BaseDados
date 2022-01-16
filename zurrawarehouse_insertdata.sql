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
INSERT INTO Warehouse(id_warehouse, phone_num, address) VALUES (00, 272228636, 'Rua G Zona Industrial 1ª Fase, Castelo Branco');

-- PRODUTOS NO ARMAZÉM
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, set_to_unit, minimum_quantity, quantity, total_quantity) VALUES ();

-- RESTOCK BAR
INSERT INTO Restock_Bar(id_bar, id_product, id_num, quantity_restock, restock_status) VALUES ();
INSERT INTO Restock_Bar(id_bar, id_product, id_num, quantity_restock, restock_status) VALUES ();
INSERT INTO Restock_Bar(id_bar, id_product, id_num, quantity_restock, restock_status) VALUES ();
INSERT INTO Restock_Bar(id_bar, id_product, id_num, quantity_restock, restock_status) VALUES ();
INSERT INTO Restock_Bar(id_bar, id_product, id_num, quantity_restock, restock_status) VALUES ();
INSERT INTO Restock_Bar(id_bar, id_product, id_num, quantity_restock, restock_status) VALUES ();
INSERT INTO Restock_Bar(id_bar, id_product, id_num, quantity_restock, restock_status) VALUES ();

-- RESTOCK WAREHOUSE
INSERT INTO Restock_Warehouse(id_warehouse, id_product, id_num, quantity_restock, restock_status) VALUES ()
INSERT INTO Restock_Warehouse(id_warehouse, id_product, id_num, quantity_restock, restock_status) VALUES ()
INSERT INTO Restock_Warehouse(id_warehouse, id_product, id_num, quantity_restock, restock_status) VALUES ()