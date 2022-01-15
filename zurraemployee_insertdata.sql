USE ZurrapaSede;

-- HORÁRIO
INSERT INTO Schedule(cod, entry_time, exit_time) VALUES (0, 0, 0);
INSERT INTO Schedule(cod, entry_time, exit_time) VALUES (1, 8.00, 17.00);
INSERT INTO Schedule(cod, entry_time, exit_time) VALUES (2, 8.30, 17.30);
INSERT INTO Schedule(cod, entry_time, exit_time) VALUES (3, 9.00, 18.00);
INSERT INTO Schedule(cod, entry_time, exit_time) VALUES (4, 10.00, 19.00);
INSERT INTO Schedule(cod, entry_time, exit_time) VALUES (5, 12.00, 16.00);
INSERT INTO Schedule(cod, entry_time, exit_time) VALUES (6, 13.00, 17.00);

-- EMPREGADOS                       -- o único que tem ID definido manual é o 1º de todos -> 000001
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES (000001, 'Michael from The Office', 'empregado de escritorio', 'final_boss_battle', 'nao');
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de balcao', 'João no Balcão', 'mini_boss_fight_1', 'nao'); -- 2
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de caixa', 'Tiago da Caixa', 'i_likepotatoes', 'nao'); -- 3
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de balcao', 'Alberto da Uni', 'pwd123', 'sim'); -- 4
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de escritorio', 'Mateus A Brás', 'pwd123', 'nao'); -- 5
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de escritorio', 'Sergei Volasky', 'workin_class4', 'nao'); --6
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de escritorio', 'Natasha Romanov', 'meh', 'nao'); -- 7
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de escritorio', 'Simao the Manjericão','weow_owen_wilson', 'nao'); -- 8
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de balcao', 'Steve Rogers', 'minimal_waige', 'nao'); -- 9
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de caixa', 'Beatriz Calada', 'pwd123', 'nao'); -- 10
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de balcao', 'Helena Bolonha', 'pwd123', 'sim'); -- 11
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de balcao', 'Carla Carlota', 'pwd123', 'nao'); -- 12
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de balcao', 'Humberto Fernandes', 'pwd123', 'nao'); -- 13
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de caixa', 'Wanda Maximof', 'test44', 'nao'); -- 14
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de balcao', 'Benjamim Matias', '123pass', 'nao'); -- 15
INSERT INTO Employee(id_num, name, type, pwd, emp_warehouse) VALUES ((SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1, 'empregado de caixa', 'Fernando Ferreira', '22qwerty', 'nao'); -- 16
-- tipos de empregados - mesa e  name,balcão
-- automatizar a introdução do ID
-- (SELECT TOP 1(id_num) FROM Employees ORDER BY id_num DESC) + 1

-- LISTA DE EMPREGADOS
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
INSERT INTO List_of_Employees(id_num, id_bar, id_branch, id_local, responsible, date, cod) VALUES ();
