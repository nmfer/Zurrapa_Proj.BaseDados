USE ZurrapaSede;

-- BAR
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES (001, 01, 'n_1 Avenida da Universidade', 271838432, 000004);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 02, 'n_56 Rua de São Cristovão, Coimbra', 239878174, 000006);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 03, 'n_5 Praça Doutor Francisco Salgado Zenha, Guarda', 271545666, 000008);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 01, 'n_45 Rua Nova Ribeiro da Relva, Covilhã', 271562945, 000009);

