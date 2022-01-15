USE ZurrapaSede;

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

-- INGREDIENTES -- MUDAR PARA SAGADOS
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
