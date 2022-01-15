USE ZurrapaSede;

-- BAR
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES (001, 01, 'n_1 Avenida da Universidade', 271838432, 01);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 02, 'n_56 Rua de São Cristovão, Coimbra', 933344554, 01);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 03, 'n_5 Praça Doutor Francisco Salgado Zenha, Guarda', 271545666, );
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 01, , , );

--PRODUTOS NO BAR
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();
INSERT INTO Products_in_bar(id_bar, id_product, minimum_quantity) VALUES ();