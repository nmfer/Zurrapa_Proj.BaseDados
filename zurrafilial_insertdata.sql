USE ZurrapaSede;

-- FILIAIS
INSERT INTO Branch(id_responsible, id_branch, designation, email, phone_num, address) VALUES (000001, 01, 'ZurrapaSede', 'sede@gmail.com', 911567566, 'n1 da Avenida Montes Hermínios, Covilhã');
INSERT INTO Branch(id_responsible, ((SELECT TOP 1(id_branch) FROM Branch ORDER BY id_branch DESC) + 1), 'ZurrapaFilial 2', 'filial_2@gmail.com', 912345678, 'Rua Secundaria n21');