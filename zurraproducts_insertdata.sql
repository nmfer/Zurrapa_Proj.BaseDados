USE ZurrapaSede;

-- PRODUTOS

-- BEBIDAS
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) 
	-- os precos de venda e compra neste caso é por kg; cafe 1kg -> 120 cafes
	VALUES (1, 'cafe', 'bebida', 4, 58.8, 24); -- 1
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) 
	VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'agua 0.33cl', 'bebida', 24, 0.45, 0.08); -- 2
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) 
	VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'refrigerante', 'bebida', 24, 0.89, 0.35); -- 3
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) 
	VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'sumo', 'bebida', 24, 0.79, 0.20); -- 4

-- COMIDA
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) 
	VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'bolos diversos', 'comida', 30, 0.65, 0.42); -- 5
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) 
	VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'sandes', 'comida', 12, 1.63, 0.89); -- 6
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) 
	VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'croissant misto', 'comida', 18, 0.89, 0.35); -- 7
--PRODUTOS NO BAR
-- minimum_quantity e quantity são dados em produtos individuais, no caso do café é por kg

-- Bar 001

INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 1, 1, 8);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 2, 8, 48);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 3, 8, 48);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 4, 8, 48);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 5, 8, 60);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 6, 8, 24);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 7, 8, 36);

-- Bar 002 - encontra-se mais longe, por isso o stock nos bares tem que ser maior, visto que o armazém se encontra mais longe e demora mais para fazer restock
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 1, 2, 12);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 2, 12, 72);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 3, 12, 72);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 4, 12, 72);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 5, 12, 90);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 6, 12, 36);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 7, 12, 54);

-- Bar 003
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003, 1, 1, 8);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003, 2, 8, 48);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003, 3, 8, 48);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003, 4, 8, 48);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003, 5, 8, 60);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003, 6, 8, 24);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003, 7, 8, 36);

-- Bar 004
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (004, 1, 1, 8);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (004, 2, 8, 48);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (004, 3, 8, 48);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (004, 4, 8, 48);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (004, 5, 8, 60);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (004, 6, 8, 24);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (004, 7, 8, 36);

