USE ZurrapaSede;

-- HORÁRIO
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (0, 0, 0);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (8.00, 17.00, 1);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (8.30, 17.30, 2);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (9.00, 18.00, 3);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (10.00, 19.00, 4);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (12.00, 16.00, 5);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (13.00, 17.00, 6);

-- ARMAZÉM (só existe 1 armazém)
INSERT INTO Warehouse(id_warehouse) VALUES (1);

-- EMPREGADOS                       -- o único que tem ID definido manual é o 1º de todos -> 000001
INSERT INTO Employees(id_num, type, pwd) VALUES (000001, 'Empregado_Filial', 'final_boss_battle');
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', 'mini_boss_fight_1'); -- 2
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', 'i_likepotatoes'); -- 3
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'pwd123'); -- 4
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'pwd123'); -- 5
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'workin_class4'); --6
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'meh'); -- 7
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'weow_owen_wilson'); -- 8
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'minimal_waige'); -- 9
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', 'pwd123'); -- 10
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'pwd123'); -- 11
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', 'pwd123'); -- 12
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', 'pwd123'); -- 13
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', 'test44'); -- 14
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', '123pass'); -- 15
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', '22qwerty'); -- 16
-- tipos de empregados - mesa e balcão
-- automatizar a introdução do ID
-- (SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1

-- FILIAIS
INSERT INTO Branch(id_responsible, id_branch, designation, email, phone_num, address) VALUES (000001, 01, 'Filial 1', 'filial_1@gmail.com', 911567566, 'Rua Principal Lisboa n4');
INSERT INTO Branch(id_responsible, id_branch, designation, email, phone_num, address) VALUES (000007, ((SELECT TOP 1(id_branch) FROM Branch ORDER BY id_branch DESC) + 1), 'Filial 2', 'filial_2@gmail.com', 912345678, 'Rua Secundaria n21');

-- BAR
INSERT INTO Bar(id_responsible, address, phone_num, id_branch, id_bar) VALUES (000002, 'Avenida da Universidade n1', 922333123, 01, 001);
INSERT INTO Bar(id_responsible, address, phone_num, id_branch, id_bar) VALUES (000010, 'Rua Jose Ramalho n78', 933344554, 01, ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1));
INSERT INTO Bar(id_responsible, address, phone_num, id_branch, id_bar) VALUES (000012, 'Rua Ramiro n5', 922233412, 01, ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1));
INSERT INTO Bar(id_responsible, address, phone_num, id_branch, id_bar) VALUES (000013, 'Rua da Fonte n7', 934444855, 02, ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1));

-- LISTA DE EMPREGADOS
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 01, 001, 000002, 0, 1);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 01, 002, 000010, 0, 1);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 01, 003, 000012, 0, 1);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 02, 004, 000013, 0, 1);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 01, 001, 000003, 0, 3);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 01, 0, 000008, 0, 0);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 02, 0, 000006, 0, 3);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 0, 0, 000004, 1, 1);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 0, 0, 000009, 1, 3);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 0, 0, 000011, 1, 0);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 01, 0, 000001, 0, 1);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 02, 0, 000007, 0, 1);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 01, 003, 000014, 0, 2);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 02, 004, 000016, 0, 0);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 01, 002, 000015, 0, 3);
INSERT INTO List_of_Employees(date, id_branch, id_bar, id_num, id_warehouse, cod) VALUES (01-02-2022, 01, 0, 000005, 0, 0);

-- PRODUTOS
-- BEBIDAS
INSERT INTO Products(id_product, name, category) VALUES (1, 'cafe', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'agua 1.5L', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'agua 0.33cl', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'cerveja media', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'cerveja mini', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'moscatel', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'refrigerante', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'sumo', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'bebida energetica', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'cha', 'bebida');

-- PASTELARIA
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'bolos diversos', 'pastelaria');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'croissant', 'pastelaria');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'pao', 'pastelaria');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'pao de forma', 'pastelaria');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'pao para cachorro', 'pastelaria');

-- INGREDIENTES
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'fiambre', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'queijo', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'manteiga', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'salsicha', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'arroz', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'carne', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'batata frita', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'alface', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'tomate', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES ((SELECT TOP 1(id_product) FROM Employees ORDER BY id_product DESC) + 1, 'molhos', 'ingrediente');

-- PRODUTOS NO ARMAZÉM
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();
INSERT INTO Products_in_Warehouse(quantity, purchase_price, set_to_unit, minimum_quantity, total_quantity, id_warehouse, id_product) VALUES ();

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

--PRODUTOS NO BAR
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();
INSERT INTO Products_in_bar(quantity, sale_price, minimum_quantity, id_bar, id_product) VALUES ();

-- PEDIDOS
INSERT INTO Orders(total_price, id_order, id_bar) VALUES ();

-- PRODUTOS NO PEDIDO
INSERT INTO Products_order(id_order, id_product, name) VALUES ();