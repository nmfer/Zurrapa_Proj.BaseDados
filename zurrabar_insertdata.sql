USE ZurrapaSede;

-- BAR
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) 
	VALUES (000, 01, 275275275, 'Sede', 00);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) 
	VALUES (001, 01, 271838432, 'n_1 Avenida da Universidade', 000004);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) 
	VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 02, 239878174, 'n_56 Rua de Sao Cristovao, Coimbra', 000006);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) 
	VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 03, 271545666, 'n_5 Avenida Rainha Dona Amelia, Guarda', 000008);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) 
	VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 01, 271562945, 'n_45 Rua Nova Ribeiro da Relva, Covilha', 000009);



