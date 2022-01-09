USE ZurrapaSede;

-- BAR
INSERT INTO Bar(id_responsible, address, phone_num, id_branch, id_bar) VALUES (000002, 'Avenida da Universidade n1', 922333123, 01, 001);
INSERT INTO Bar(id_responsible, address, phone_num, id_branch, id_bar) VALUES (000010, 'Rua Jose Ramalho n78', 933344554, 01, ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1));
INSERT INTO Bar(id_responsible, address, phone_num, id_branch, id_bar) VALUES (000012, 'Rua Ramiro n5', 922233412, 01, ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1));
INSERT INTO Bar(id_responsible, address, phone_num, id_branch, id_bar) VALUES (000013, 'Rua da Fonte n7', 934444855, 02, ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1));