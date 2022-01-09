USE ZurrapaSede;

-- EMPREGADOS                       -- o único que tem ID definido manual é o 1º de todos -> 000001
INSERT INTO Employees(id_num, type, pwd) VALUES (000001, 'Empregado_Filial', 'final_boss_battle');
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', 'mini_boss_fight_1')
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', 'i_likepotatoes');
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'pwd123');
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'pwd123');
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'workin_class4')
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'meh')
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'weow_owen_wilson')
INSERT INTO Employees(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'minimal_waige')

-- tipos de empregados - mesa e balcão
-- automatizar a introdução do ID
-- (SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1

-- BAR
INSERT INTO Bar(id_responsible, address, phone_num, id_branch, id_bar) VALUES (000002, 'Avenida da Universidade nº1', 922333123, 01, 001);
INSERT INTO Bar(id_responsible, address, phone_num, id_branch, id_bar) VALUES (000002, 'Avenida da Universidade nº1', 922333123, 01, 001);

-- FILIAIS
INSERT INTO Branch(id_responsible, id_branch, designation, email, phone_num, address) VALUES (000001, 01, 'Filial 1', 'filial_1@gmail.com', 911567566, 'Rua Lisboa nº4')

-- BEBIDAS
INSERT INTO Products(id_product, name, category) VALUES (1, 'cafe', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES (2, 'agua 1.5L', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES (3, 'agua 0.33cl', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES (4, 'cerveja media', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES (5, 'cerveja mini', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES (6, 'moscatel', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES (7, 'refrigerante', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES (8, 'sumo', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES (9, 'bebida energetica', 'bebida');
INSERT INTO Products(id_product, name, category) VALUES (10, 'cha', 'bebida');

-- PASTELARIA
INSERT INTO Products(id_product, name, category) VALUES (11, 'bolos diversos', 'pastelaria');
INSERT INTO Products(id_product, name, category) VALUES (12, 'croissant', 'pastelaria');
INSERT INTO Products(id_product, name, category) VALUES (13, 'pao', 'pastelaria');
INSERT INTO Products(id_product, name, category) VALUES (14, 'pao de forma', 'pastelaria');
INSERT INTO Products(id_product, name, category) VALUES (15, 'pao para cachorro', 'pastelaria');

-- INGREDIENTES
INSERT INTO Products(id_product, name, category) VALUES (16, 'fiambre', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES (17, 'queijo', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES (18, 'manteiga', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES (19, 'salsicha', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES (20, 'arroz', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES (21, 'carne', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES (22, 'batata frita', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES (23, 'alface', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES (24, 'tomate', 'ingrediente');
INSERT INTO Products(id_product, name, category) VALUES (25, 'molhos', 'ingrediente');
