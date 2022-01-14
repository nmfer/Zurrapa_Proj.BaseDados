USE ZurrapaSede;


-- adicionar views!!

CREATE TABLE Branch
(
  id_branch INT NOT NULL,
  designation VARCHAR(40) NOT NULL,
  email VARCHAR(40) NOT NULL,
  phone_num INT NOT NULL,
  address VARCHAR(40) NOT NULL,
  -- not done yet
  id_manager INT NOT NULL,
  
  PRIMARY KEY (id_branch)
);
 
CREATE TABLE Bar
(
  id_bar INT NOT NULL,
  id_branch INT NOT NULL,
  phone_num INT NOT NULL,
  address VARCHAR(40) NOT NULL,
  -- not done yet
  id_responsible INT NOT NULL,

  PRIMARY KEY (id_bar)
);

CREATE TABLE Employee
(
  id_num INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  type VARCHAR(30) NOT NULL,
  pwd VARCHAR(30) NOT NULL,
  emp_warehouse VARCHAR(40) NOT NULL,

  CONSTRAINT CHK_OPType CHECK (type = 'empregado de caixa' OR type = 'empregado de balcao' OR type = 'empregado de escritorio'),
  CONSTRAINT CHK_OPEmpWare CHECK (emp_warehouse = 'sim' OR emp_warehouse = 'nao'),
  CONSTRAINT CHK_OPEmpCounter CHECK (type != 'empregado de balcao' AND emp_warehouse = 'nao'),
  
  PRIMARY KEY (id_num)
);

CREATE TABLE Schedule
(
  cod INT NOT NULL,
  entry_time INT NOT NULL,
  exit_time INT NOT NULL,
  
  PRIMARY KEY (cod)
);

CREATE TABLE List_Employees
(
  id_num INT NOT NULL,
  id_bar INT NOT NULL,
  id_branch INT NOT NULL,
  id_local INT NOT NULL,
  responsible VARCHAR(4) NOT NULL,
  date DATE NOT NULL,
  cod INT NOT NULL,

  CONSTRAINT CHK_OPResponsible CHECK (responsible = 'sim' OR responsible = 'nao'),

  FOREIGN KEY (id_branch) REFERENCES Branch(id_branch),
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
  FOREIGN KEY (id_num) REFERENCES Employee(id_num),
  FOREIGN KEY (cod) REFERENCES Schedule(cod)
);

CREATE TABLE Products
(
  id_product INT NOT NULL,
  name VARCHAR(40) NOT NULL,
  category VARCHAR(40) NOT NULL,
  set_to_unit INT NOT NULL,
  sale_price FLOAT NOT NULL,
  purchase_price FLOAT NOT NULL,

  CONSTRAINT CHK_OPCategory CHECK (category = 'bebida' OR category = 'pastelaria' OR category = 'ingrediente'),
  
  PRIMARY KEY (id_product)
);

CREATE TABLE Warehouse
(
  -- id_warehouse = 00
  id_warehouse INT NOT NULL,
  phone_num INT NOT NULL,
  address VARCHAR(40) NOT NULL,

  PRIMARY KEY (id_warehouse)
);

CREATE TABLE Emp_Warehouse
(
  id_warehouse INT NOT NULL,
  id_num INT NOT NULL,
  id_bar INT NOT NULL,

  FOREIGN KEY (id_warehouse) REFERENCES Warehouse(id_warehouse),
  FOREIGN KEY (id_num) REFERENCES Employee(id_num),
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
);

CREATE TABLE Products_in_Warehouse
(
  id_warehouse INT NOT NULL,
  id_product INT NOT NULL,
  set_to_unit INT NOT NULL,
  minimum_quantity FLOAT NOT NULL,
  quantity FLOAT NOT NULL,
  total_quantity AS quantity * set_to_unit,
  
  FOREIGN KEY (id_warehouse) REFERENCES Warehouse(id_warehouse),
  FOREIGN KEY (id_product) REFERENCES Products(id_product),
  
  PRIMARY KEY (id_warehouse)
);

CREATE TABLE Products_in_bar
(
  id_bar INT NOT NULL,
  id_product INT NOT NULL,
  minimum_quantity FLOAT NOT NULL,
  quantity FLOAT NOT NULL,
  
  PRIMARY KEY (id_product),
  
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
  FOREIGN KEY (id_product) REFERENCES Products(id_product)
);

CREATE TABLE Restock_Warehouse
(
  id_warehouse INT NOT NULL,
  id_product INT NOT NULL,
  id_num INT NOT NULL,
  quantity_restock INT NOT NULL,
  restock_status VARCHAR(30) NOT NULL,

  -- adicionar mais opcoes de restock_status, nao sei o que colocar
  CONSTRAINT CHK_OPWareRestockStatus CHECK (restock_status = 'em entrega' OR restock_status = 'concluido'),
  
  -- FOREIGN KEY (id_num) REFERENCES Emp_Warehouse(id_num),
  FOREIGN KEY (id_product) REFERENCES Products_in_bar(id_product),
  FOREIGN KEY (id_warehouse) REFERENCES Warehouse(id_warehouse)

);

CREATE TABLE Restock_Bar
(
  id_bar INT NOT NULL,
  id_product INT NOT NULL,
  id_num INT NOT NULL,
  quantity_restock INT NOT NULL,
  restock_status VARCHAR(30) NOT NULL,
  
  -- adicionar mais opcoes de restock_status, nao sei o que colocar
  CONSTRAINT CHK_OPBarRestockStatus CHECK (restock_status = 'em entrega' OR restock_status = 'concluido'),

  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar),
  FOREIGN KEY (id_product) REFERENCES Products_in_bar(id_product),

);

CREATE TABLE Orders
(
  id_order INT NOT NULL,
  id_bar INT NOT NULL,
  id_num INT NOT NULL,
  table_number INT NOT NULL,
  -- acabar
  total_price FLOAT NOT NULL,
  order_status VARCHAR(30) NOT NULL,

  -- talvez adicionar mais opcoes de order_status, nao sei o que colocar
  CONSTRAINT CHK_OPOrderStatus CHECK (order_status = 'em aberto' OR order_status = 'satisfeito' OR order_status = 'em entrega'),
  
  PRIMARY KEY (id_order),
  
  FOREIGN KEY (id_num) REFERENCES Employee(id_num),
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar)
);

CREATE TABLE Products_order
(
  id_order INT NOT NULL,
  id_product INT NOT NULL,
  sale_price FLOAT NOT NULL,
  
  FOREIGN KEY (id_order) REFERENCES Orders(id_order),
  FOREIGN KEY (id_product) REFERENCES Products(id_product)
);

CREATE TABLE Day_Bar_Branch
(
  date INT NOT NULL,
  id_branch INT NOT NULL,
  id_bar INT NOT NULL,
  total_received FLOAT NOT NULL,
  total_spent FLOAT NOT NULL,
  
  PRIMARY KEY (date),
  
  FOREIGN KEY (id_bar) REFERENCES Bar(id_bar)
);

CREATE TABLE Day_Branch
(
  date INT NOT NULL,
  id_branch INT NOT NULL,
  total_received FLOAT NOT NULL,
  total_spent FLOAT NOT NULL,
  
  PRIMARY KEY (date),
  
  FOREIGN KEY (id_branch) REFERENCES Branch(id_branch),
  FOREIGN KEY (date) REFERENCES Day_Bar_Branch(date)
);
