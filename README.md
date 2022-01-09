# Zurrapa_Proj.BaseDados

## Explicação das tabelas e atributos de cada

**NEGRITO** -> PRIMARY KEY \\
*ITÁLICO* -> FOREIGN KEY

### Branch
- id_responsible -> empregado responsavél pela filial
- **id_branch** -> número de identificação da filial
- designation -> nome da filial
- email
- phone_num
- address -> morada

### Employe
- **id_num** -> número identificação do empregado
- type:
    - Empregado de Mesa
    - Empregado de Balcão
    - Empregado de Armazém
    - Empregado Escritório/Filial
- pwd

### Products
- **id_product** -> número identificação produto
- **name** -> nome do produto
- category:
    - Ingredientes;
    - Bebidas;
    - ...

### Bar
- id_responsible -> número identificação do responsável do bar, sendo que tem que desempenhar alguma função no bar
- **id_bar** -> número de identificação do bar
- phone_num
- address
- id_branch

### Products_in_bar
- ***id_product*** -> número de identificação do produto, obtido da tabela Products
- ***name*** -> nome do produto obtido da tabela Products
- *id_bar* -> número de identificação do bar a que pertence os produtos
- quantity -> qunatidade de produto existente no bar naquele instante
- sale_price -> preço de venda do produto
- minimum_quantity -> quantidade mínima que tem que ser atingida para ser automaticamente reposto o stock do produto

### Orders
- total_price -> preço total do pedido
- **id_order** -> número de identificação do pedido
- *id_bar* -> número de identificação do bar em que foi feito o pedido

### Day_Branch
- **date** -> data com dia/mês/ano de forma a ser possível consultar o progresso com o passar do tempo
- total_spend -> preço da quantidade de produtos gastos
- total_received -> acumular dos pagamentos dos pedidos 
- *id_branch* -> número de identificação da filial

### Day_Bar_Branch
- ***date*** -> data com dia/mês/ano de forma a ser possível consultar o progresso com o passar do tempo, obtido através da tabela Day_Branch
- total_spend -> preço da quantidade de produtos gastos
- total_received -> acumular dos pagamentos dos pedidos
- *id_bar* -> número de identificação do bar

### Products_order
- *id_order* -> número de identificação do pedido
- *id_product* -> número de identificação do produto
- *name* -> nome produto

### Schedule
- entry_time
- exit_time
- **cod**
    ex: **cod** = 1 | entry = 9:00 | exit = 15:00

### Warehouse
- **id_warehouse** -> número de identificação do armazém
- quantity -> quantidade de produto no armazém, sendo esta em conjunto, não individual
- purchase_price -> preço compra do produto a um fornecedor
- set_to_unit -> 1 conjunto de X = x individuais de X
- minimum_quantity -> quantidade mínima que tem que ser atingida para ser automaticamente reposto o stock do produto. É apresentada em conjunto
- total_quantity -> x conjuntos * y individuais que constituem o conjunto
- *id_product* -> número de identificação do produto
- *name* -> nome produto

### List_Employees
- date -> seleciona/apresenta dia
- id_num -> número de identificação do empregado
- id_branch -> número de identificação da filial a qual o empregrado pertence
- id_bar :
    - Se for empregado de Bar -> número de identificação do bar
    - Se não for empregado de Bar -> 0
- id_warehouse :
    - Se for empregado de Armazém -> número de identificação do armazém
    - Se não for empregado de Armazém -> 0
- cod -> horário que irá trabalhar de acordo com o dia

### Products_to_restock
- quantity -> quantidade de produto que deve ser restocked, sendo esta quantidade em individual
- *id_product* -> identificação do produto a ser feito o restock
- *name* 
- *id_bar* -> identificação do bar a que irá ser feito restock
- *id_warehouse* -> identificação do armazém que irá fazer reposição
