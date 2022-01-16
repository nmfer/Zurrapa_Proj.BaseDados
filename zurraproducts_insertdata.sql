USE ZurrapaSede;

-- PRODUTOS
-- BEBIDAS
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES (1, 'cafe', 'bebida', 6, 0.50, 30); -- 1
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'agua 1.5L', 'bebida', 6, 1, 3.5); -- 2
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'agua 0.33cl', 'bebida', 24, 0.40, 5); -- 3
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'cerveja media', 'bebida', 6, 1.5, 4); -- 4
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'cerveja mini', 'bebida', 24, 0.70, 13); -- 5
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'moscatel', 'bebida', 6, 1, 5); -- 6
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'coca-cola 0.33cl', 'bebida', 20, 1, 15); -- 7
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'coca-cola zero 0.33cl', 'bebida', 20, 1, 15); -- 8
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'ice-tea pessego', 'bebida', 20, 1, 15); -- 9
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'bebida energetica', 'bebida', 6, 1.5, 18); --10
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'cha', 'bebida', 12, 0.5, 5); --11

-- COMIDA
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'natas', 'pastelaria', 35, 0.8, 20); -- 12
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'croissant com creme', 'pastelaria', 35, 0.8, 20); --13
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'mil folhas', 'pastelaria', 35, 0.8, 20); -- 14
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'bola berlim', 'pastelaria', 35, 0.8, 20); -- 15
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'croissant com chocolate', 'pastelaria', 35, 0.8, 20); --16
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'pao com fiambre', 'salgados', 5, 0.9, 3.5); -- 17
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'pao com queijo', 'salgados', 5, 0.9, 3.5); -- 18
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'pao misto', 'salgados', 5, 1.2, 4); -- 19
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'torradas', 'salgados', 5, 0.7, 3.5); --20
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'pao com chouriço', 'salgados', 10, 1, 7.5); -- 21
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'tosta mista', 'salgados', 5, 1.2, 4); -- 22
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'batata frita', 'salgados', 10, 1.2, 10); -- 23
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'batata frita camponesa', 'salgados', 10, 1.2, 10); -- 24
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'batata frita ketchup', 'salgados', 10, 1.2, 10); -- 25
INSERT INTO Products(id_product, name, category, set_to_unit, sale_price, purchase_price) VALUES ((SELECT TOP 1(id_product) FROM Products ORDER BY id_product DESC) + 1, 'amendoins', 'salgados', 15, 0.8, 10); -- 26
-- total 26

--PRODUTOS NO BAR
-- Bar 001
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 1, 1, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 2, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 3, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 4, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 5, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 6, 2, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 7, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 8, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 9, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 10, 2, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 11, 3, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 12, 12, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 13, 12, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 14, 12, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 15, 12, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 16, 12, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 17, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 18, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 19, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 20, 2, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 21, 4, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 22, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 23, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 24, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 25, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 26, 4, );

-- Bar 002 - encontra-se mais longe, por isso o stock nos bares tem que ser maior, visto que o armazém se encontra mais longe e demora mais para fazer restock
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 1);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 2);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 3);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 4);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 5);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 6);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 7);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 8);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 9);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 10);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 11);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 12);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 13);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 14);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 15);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 16);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 17);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 18);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 19);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 20);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 21);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 22);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 23);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 24);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 25);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (002, 26);

-- Bar 003
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003, 1);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003, 2);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003, 3);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003,);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (003);

-- Bar 004
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 1, 1, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 2, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 3, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 4, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 5, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 6, 2, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 7, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 8, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 9, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 10, 2, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 11, 3, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 12, 12, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 13, 12, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 14, 12, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 15, 12, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 16, 12, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 17, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 18, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 19, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 20, 2, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 21, 4, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 22, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 23, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 24, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 25, 6, );
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity, quantity) VALUES (001, 26, 4, );

