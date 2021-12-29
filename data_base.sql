CREATE TABLE Branch
(
  id_responsible INT NOT NULL,
  id_branch INT NOT NULL,
  designation VARCHAR(40) NOT NULL,
  email VARCHAR(40) NOT NULL,
  phone_num INT NOT NULL,
  address VARCHAR(40) NOT NULL,
  PRIMARY KEY (id_branch)
);

CREATE TABLE Employee
(
  id_num INT NOT NULL,
  type VARCHAR(30) NOT NULL,
  PRIMARY KEY (id_num)
);

CREATE TABLE Products
(
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  category VARCHAR(40) NOT NULL,
  PRIMARY KEY (id_product, name)
);

CREATE TABLE Bar
(
  id_responsible INT NOT NULL,
  address VARCHAR(40) NOT NULL,
  phone_num INT NOT NULL,
  id_bar INT NOT NULL,
  PRIMARY KEY (id_bar)
);

CREATE TABLE Products_in_bar
(
  quatity/unit INT NOT NULL,
  sale_price FLOAT NOT NULL,
  minimum_quatity/unit INT NOT NULL,
  id_bar INT NOT NULL,
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  PRIMARY KEY (id_product, name),
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
  FOREIGN KEY (id_product, name) REFERENCES Products(id_product, name)
);

CREATE TABLE Order
(
  total_price FLOAT NOT NULL,
  id_order INT NOT NULL,
  id_bar INT NOT NULL,
  PRIMARY KEY (id_order),
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar)
);

CREATE TABLE Day_Branch
(
  date INT NOT NULL,
  total_received FLOAT NOT NULL,
  total_spend FLOAT NOT NULL,
  id_branch INT NOT NULL,
  PRIMARY KEY (date),
  FOREIGN KEY (id_branch) REFERENCES Branch(id_branch)
);

CREATE TABLE Day_Bar_Branch
(
  total_received FLOAT NOT NULL,
  total_spend FLOAT NOT NULL,
  id_bar INT NOT NULL,
  date INT NOT NULL,
  PRIMARY KEY (date),
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
  FOREIGN KEY (date) REFERENCES Day_Branch(date)
);

CREATE TABLE Products_order
(
  id_order INT NOT NULL,
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  FOREIGN KEY (id_order) REFERENCES Order(id_order),
  FOREIGN KEY (id_product, name) REFERENCES Products(id_product, name)
);

CREATE TABLE Schedule
(
  entry_time INT NOT NULL,
  exit_time INT NOT NULL,
  cod INT NOT NULL,
  PRIMARY KEY (cod)
);

CREATE TABLE Warehouse
(
  quantity/set INT NOT NULL,
  purchase_price FLOAT NOT NULL,
  set_to_unit INT NOT NULL,
  minimum_quantity/set INT NOT NULL,
  total_quantity INT NOT NULL,
  id_warehouse INT NOT NULL,
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  PRIMARY KEY (id_warehouse),
  FOREIGN KEY (id_product, name) REFERENCES Products(id_product, name)
);

CREATE TABLE List_Employees
(
  date DATE NOT NULL,
  id_branch INT NOT NULL,
  id_bar INT NOT NULL,
  id_num INT NOT NULL,
  id_warehouse INT NOT NULL,
  cod INT NOT NULL,
  FOREIGN KEY (id_branch) REFERENCES Branch(id_branch),
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
  FOREIGN KEY (id_num) REFERENCES Employee(id_num),
  FOREIGN KEY (id_warehouse) REFERENCES Warehouse(id_warehouse),
  FOREIGN KEY (cod) REFERENCES Schedule(cod)
);

CREATE TABLE Products_to_restock
(
  quatity INT NOT NULL,
  id_bar INT NOT NULL,
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  id_warehouse INT NOT NULL,
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
  FOREIGN KEY (id_product, name) REFERENCES Products_in_bar(id_product, name),
  FOREIGN KEY (id_warehouse) REFERENCES Warehouse(id_warehouse)
);