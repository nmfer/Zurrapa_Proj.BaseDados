USE ZurrapaSede;

-- FILIAIS
INSERT INTO Branch(id_responsible, id_branch, designation, email, phone_num, address) VALUES (000001, 01, 'Filial 1', 'filial_1@gmail.com', 911567566, 'Rua Principal Lisboa n4');
INSERT INTO Branch(id_responsible, ((SELECT TOP 1(id_branch) FROM Branch ORDER BY id_branch DESC) + 1), 'Filial 2', 'filial_2@gmail.com', 912345678, 'Rua Secundaria n21');