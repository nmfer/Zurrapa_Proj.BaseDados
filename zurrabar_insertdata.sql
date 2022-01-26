USE ZurrapaSede;

-- BAR

INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES (001, 01, 271838432, 'n_1 Avenida da Universidade', 000004);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 933344554, 02, 'Rua de São Cristovão, Coimbra',  000006);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 271545666, 03, 'Praça Doutor Francisco, Guarda', 000008);
INSERT INTO Bar(id_bar, id_branch, phone_num, address, id_responsible) VALUES ((SELECT TOP 1(id_bar) FROM Bar ORDER BY id_bar DESC) + 1, 271443589, 01, 'Avenida Frei Heitor, Covilhã', 000009);

