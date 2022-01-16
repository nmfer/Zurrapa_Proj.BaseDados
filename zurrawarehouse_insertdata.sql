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
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 1, 'cafe', '', '', '4', '', '24');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 2, 'agua 1.5L', '', '', '6', '', '0.14');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 3, 'agua 0.33L', '', '', '24', '', '0.08');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 4, 'cerveja media', '', '', '20', '', '0.40');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 5, 'cerveja mini', '', '', '24', '', '0.30');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 6, 'refrigerante', '', '', '24', '', '0.35');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 7, 'sumo', '', '', '24', '', '0.20');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 8, 'bebida energetica', '', '', '24', '', '0.61');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 9, 'cha', '', '', '60', '', '0.20');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 10, 'bolos diversos', '', '', '24', '', '0.42');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 11, 'croissant', '', '', '20', '', '0.20');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 12, 'pao', '', '', '20', '', '0.15');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 13, 'pao de forma', '', '', '24', '', '0.10');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 14, 'pao para cachorro', '', '', '12', '', '0.20');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 15, 'fiambre', '', '', '2', '', '7');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 16, 'queijo', '', '', '2', '', '8.49');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 17, 'manteiga', '', '', '2', '', '6.49');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 18, 'salsicha', '', '', '4', '', '9.89');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 19, 'arroz', '', '', '10', '', '0.89');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 20, 'carne', '', '', '4', '', '2.29');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 21, 'batata frita', '', '', '4', '', '0.30');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 22, 'alface', '', '', '2', '', '1.99');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 23, 'tomate', '', '', '2', '', '1.76');
INSERT INTO Products_in_Warehouse(id_warehouse, id_product, name, minimum_quantity, quantity, set_to_unit, total_quantity, purchase_price) VALUES (1, 24, 'molhos', '', '', '2', '', '2.05');

-- PRODUTOS PARA RESTOCK
INSERT INTO Products_to_restock(quantity, id_bar, id_product, name, id_warehouse) VALUES ();
INSERT INTO Products_to_restock(quantity, id_bar, id_product, name, id_warehouse) VALUES ();
INSERT INTO Products_to_restock(quantity, id_bar, id_product, name, id_warehouse) VALUES ();
INSERT INTO Products_to_restock(quantity, id_bar, id_product, name, id_warehouse) VALUES ();
INSERT INTO Products_to_restock(quantity, id_bar, id_product, name, id_warehouse) VALUES ();
INSERT INTO Products_to_restock(quantity, id_bar, id_product, name, id_warehouse) VALUES ();
INSERT INTO Products_to_restock(quantity, id_bar, id_product, name, id_warehouse) VALUES ();
INSERT INTO Products_to_restock(quantity, id_bar, id_product, name, id_warehouse) VALUES ();
INSERT INTO Products_to_restock(quantity, id_bar, id_product, name, id_warehouse) VALUES ();