USE ZurrapaSede;

-- EMPREGADOS                       -- o único que tem ID definido manual é o 1º de todos -> 000001
INSERT INTO Employee(id_num, type, pwd) VALUES (000001, 'Empregado_Filial', 'final_boss_battle');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', 'mini_boss_fight_1')
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', 'i_likepotatoes');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'pwd123');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'pwd123');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'workin_class4')
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'meh')
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'weow_owen_wilson')
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'minimal_waige')
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', 'pwd123');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'pwd123');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', 'pwd123');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', 'pwd123');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', 'test44');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', '123pass');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', '22qwerty');
-- tipos de empregados - mesa e balcão
-- automatizar a introdução do ID
-- (SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1