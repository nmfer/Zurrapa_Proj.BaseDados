USE ZurrapaSede;

-- HORÁRIO
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (0, 0, 0);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (8.00, 17.00, 1);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (8.30, 17.30, 2);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (9.00, 18.00, 3);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (10.00, 19.00, 4);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (12.00, 16.00, 5);
INSERT INTO Schedule(entry_time, exit_time, cod) VALUES (13.00, 17.00, 6);

-- EMPREGADOS                       -- o único que tem ID definido manual é o 1º de todos -> 000001
INSERT INTO Employee(id_num, type, pwd) VALUES (000001, 'Empregado_Filial', 'final_boss_battle');
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', 'mini_boss_fight_1'); -- 2
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', 'i_likepotatoes'); -- 3
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'pwd123'); -- 4
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'pwd123'); -- 5
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'workin_class4'); --6
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'meh'); -- 7
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Filial', 'weow_owen_wilson'); -- 8
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'minimal_waige'); -- 9
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', 'pwd123'); -- 10
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Armazem', 'pwd123'); -- 11
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', 'pwd123'); -- 12
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', 'pwd123'); -- 13
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', 'test44'); -- 14
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Balcao', '123pass'); -- 15
INSERT INTO Employee(id_num, type, pwd) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'Empregado_Mesa', '22qwerty'); -- 16
-- tipos de empregados - mesa e balcão
-- automatizar a introdução do ID
-- (SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1

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
