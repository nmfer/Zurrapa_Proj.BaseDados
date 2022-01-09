USE ZurrapaSede;

CREATE TABLE Branch
(
  id_branch INT NOT NULL,
  id_responsible INT NOT NULL,
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
  pwd VARCHAR(30) NOT NULL,
  
  PRIMARY KEY (id_num)
);

CREATE TABLE Products
(
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  category VARCHAR(40) NOT NULL,
  set_to_unit INT NOT NULL,
  sale_price FLOAT NOT NULL,
  purchase_price FLOAT NOT NULL,
  
  PRIMARY KEY (id_product, name)
);

CREATE TABLE Bar
(
  id_bar INT NOT NULL,
  id_responsible INT NOT NULL,
  address VARCHAR(40) NOT NULL,
  phone_num INT NOT NULL,
  id_branch INT NOT NULL,
  
  PRIMARY KEY (id_bar)
);

CREATE TABLE Products_in_bar
(
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  quantity INT NOT NULL,
  sale_price FLOAT NOT NULL,
  minimum_quantity INT NOT NULL,
  id_bar INT NOT NULL,
  
  PRIMARY KEY (id_product, name),
  
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
  FOREIGN KEY (id_product, name) REFERENCES Products(id_product, name)
);

CREATE TABLE Orders
(
  id_order INT NOT NULL,
  total_price FLOAT NOT NULL,
  id_bar INT NOT NULL,
  table_number INT NOT NULL,
  order_status VARCHAR(30) NOT NULL,
  
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
  date INT NOT NULL,
  total_received FLOAT NOT NULL,
  total_spend FLOAT NOT NULL,
  id_bar INT NOT NULL,
  
  PRIMARY KEY (date),
  
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
  FOREIGN KEY (date) REFERENCES Day_Branch(date)
);

CREATE TABLE Products_order
(
  id_order INT NOT NULL,
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  
  FOREIGN KEY (id_order) REFERENCES Orders(id_order),
  FOREIGN KEY (id_product, name) REFERENCES Products(id_product, name)
);

CREATE TABLE Schedule
(
  cod INT NOT NULL,
  entry_time INT NOT NULL,
  exit_time INT NOT NULL,
  
  PRIMARY KEY (cod)
);

CREATE TABLE Warehouse
(
  id_warehouse INT NOT NULL,
  
  PRIMARY KEY (id_warehouse)
)

CREATE TABLE Products_in_Warehouse
(
  id_warehouse INT NOT NULL,
  quantity INT NOT NULL,
  purchase_price FLOAT NOT NULL,
  minimum_quantity INT NOT NULL,
  total_quantity INT NOT NULL,
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  
  FOREIGN KEY (id_warehouse) REFERENCES Warehouse(id_warehouse),
  FOREIGN KEY (id_product, name) REFERENCES Products(id_product, name),
  
  PRIMARY KEY (id_warehouse)
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
  restock_status VARCHAR(30) NOT NULL,
  quatity INT NOT NULL,
  id_bar INT NOT NULL,
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  id_warehouse INT NOT NULL,
  
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
  FOREIGN KEY (id_product, name) REFERENCES Products_in_bar(id_product, name),
  FOREIGN KEY (id_warehouse) REFERENCES Warehouse(id_warehouse)

);