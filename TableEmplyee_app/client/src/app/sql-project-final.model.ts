export interface Bar {
  id_bar: number;
  id_responsible: number;
  address: string;
  phone_num: number;
  id_branch: number;
}

export interface Branch {
  id_branch: number;
  id_responsible: number;
  designation: string;
  email: string;
  phone_num: number;
  address: string;
}

export interface DayBarBranch {
  date: number;
  total_received: number;
  total_spend: number;
  id_bar: number;
}

export interface DayBranch {
  date: number;
  total_received: number;
  total_spend: number;
  id_branch: number;
}

export interface Employee {
  id_num: number;
  type: string;
  pwd: string;
}

export interface ListEmployee {
  date: string;
  id_branch: number;
  id_bar: number;
  id_num: number;
  id_warehouse: number;
  cod: number;
}

export interface Order {
  id_order: number;
  total_price: number;
  id_bar: number;
  table_number: number;
  order_status: string;
}

export interface Product {
  id_product: number;
  name: string;
  category: string;
  set_to_unit: number;
  sale_price: number;
  purchase_price: number;
}

export interface ProductsInBar {
  id_product: number;
  name: string;
  quantity: number;
  sale_price: number;
  minimum_quantity: number;
  id_bar: number;
}

export interface ProductsInWarehouse {
  id_warehouse: number;
  quantity: number;
  purchase_price: number;
  minimum_quantity: number;
  total_quantity: number;
  id_product: number;
  name: string;
}

export interface ProductsOrder {
  id_order: number;
  id_product: number;
  name: string;
}

export interface ProductsToRestock {
  restock_status: string;
  quatity: number;
  id_bar: number;
  id_product: number;
  name: string;
  id_warehouse: number;
}

export interface Schedule {
  cod: number;
  entry_time: number;
  exit_time: number;
}

export interface Warehouse {
  id_warehouse: number;
}
