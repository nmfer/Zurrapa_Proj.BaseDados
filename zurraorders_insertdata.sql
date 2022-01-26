USE ZurrapaSede;

-- PEDIDOS
INSERT INTO Orders(id_order, id_bar, id_num, table_number, total_price, order_status) VALUES (1, 001, 000004, 1, 5.40, 'em aberto');
INSERT INTO Orders(id_order, id_bar, id_num, table_number, total_price, order_status) VALUES (2, 001, 000004, 3, 2, 'satisfeito');


/*
-- PRODUTOS NO PEDIDO
INSERT INTO Products_order(id_order, id_product, sale_price) VALUES ();
INSERT INTO Products_order(id_order, id_product, sale_price) VALUES ();
INSERT INTO Products_order(id_order, id_product, sale_price) VALUES ();
INSERT INTO Products_order(id_order, id_product, sale_price) VALUES ();
INSERT INTO Products_order(id_order, id_product, sale_price) VALUES ();
INSERT INTO Products_order(id_order, id_product, sale_price) VALUES ();
INSERT INTO Products_order(id_order, id_product, sale_price) VALUES ();
INSERT INTO Products_order(id_order, id_product, sale_price) VALUES ();
*/