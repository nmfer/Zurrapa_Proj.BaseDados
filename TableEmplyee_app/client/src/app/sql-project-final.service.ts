import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject, throwError } from 'rxjs';

import { ConfigService } from './config.service';
import { ODataClient } from './odata-client';
import * as models from './sql-project-final.model';

@Injectable()
export class SqlProjectFinalService {
  odata: ODataClient;
  basePath: string;

  constructor(private http: HttpClient, private config: ConfigService) {
    this.basePath = config.get('sqlProjectFinal');
    this.odata = new ODataClient(this.http, this.basePath, { legacy: false, withCredentials: true });
  }

  getBars(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Bars`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createBar(expand: string | null, bar: models.Bar | null) : Observable<any> {
    return this.odata.post(`/Bars`, bar, { expand }, []);
  }

  deleteBar(idBar: number | null) : Observable<any> {
    return this.odata.delete(`/Bars(${idBar})`, item => !(item.id_bar == idBar));
  }

  getBarByidBar(expand: string | null, idBar: number | null) : Observable<any> {
    return this.odata.getById(`/Bars(${idBar})`, { expand });
  }

  updateBar(expand: string | null, idBar: number | null, bar: models.Bar | null) : Observable<any> {
    return this.odata.patch(`/Bars(${idBar})`, bar, item => item.id_bar == idBar, { expand }, []);
  }

  getBranches(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Branches`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createBranch(expand: string | null, branch: models.Branch | null) : Observable<any> {
    return this.odata.post(`/Branches`, branch, { expand }, []);
  }

  deleteBranch(idBranch: number | null) : Observable<any> {
    return this.odata.delete(`/Branches(${idBranch})`, item => !(item.id_branch == idBranch));
  }

  getBranchByidBranch(expand: string | null, idBranch: number | null) : Observable<any> {
    return this.odata.getById(`/Branches(${idBranch})`, { expand });
  }

  updateBranch(expand: string | null, idBranch: number | null, branch: models.Branch | null) : Observable<any> {
    return this.odata.patch(`/Branches(${idBranch})`, branch, item => item.id_branch == idBranch, { expand }, []);
  }

  getDayBarBranches(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/DayBarBranches`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createDayBarBranch(expand: string | null, dayBarBranch: models.DayBarBranch | null) : Observable<any> {
    return this.odata.post(`/DayBarBranches`, dayBarBranch, { expand }, ['DayBranch', 'Bar']);
  }

  deleteDayBarBranch(date: number | null) : Observable<any> {
    return this.odata.delete(`/DayBarBranches(${date})`, item => !(item.date == date));
  }

  getDayBarBranchBydate(expand: string | null, date: number | null) : Observable<any> {
    return this.odata.getById(`/DayBarBranches(${date})`, { expand });
  }

  updateDayBarBranch(expand: string | null, date: number | null, dayBarBranch: models.DayBarBranch | null) : Observable<any> {
    return this.odata.patch(`/DayBarBranches(${date})`, dayBarBranch, item => item.date == date, { expand }, ['DayBranch','Bar']);
  }

  getDayBranches(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/DayBranches`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createDayBranch(expand: string | null, dayBranch: models.DayBranch | null) : Observable<any> {
    return this.odata.post(`/DayBranches`, dayBranch, { expand }, ['Branch']);
  }

  deleteDayBranch(date: number | null) : Observable<any> {
    return this.odata.delete(`/DayBranches(${date})`, item => !(item.date == date));
  }

  getDayBranchBydate(expand: string | null, date: number | null) : Observable<any> {
    return this.odata.getById(`/DayBranches(${date})`, { expand });
  }

  updateDayBranch(expand: string | null, date: number | null, dayBranch: models.DayBranch | null) : Observable<any> {
    return this.odata.patch(`/DayBranches(${date})`, dayBranch, item => item.date == date, { expand }, ['Branch']);
  }

  getEmployees(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Employees`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createEmployee(expand: string | null, employee: models.Employee | null) : Observable<any> {
    return this.odata.post(`/Employees`, employee, { expand }, []);
  }

  deleteEmployee(idNum: number | null) : Observable<any> {
    return this.odata.delete(`/Employees(${idNum})`, item => !(item.id_num == idNum));
  }

  getEmployeeByidNum(expand: string | null, idNum: number | null) : Observable<any> {
    return this.odata.getById(`/Employees(${idNum})`, { expand });
  }

  updateEmployee(expand: string | null, idNum: number | null, employee: models.Employee | null) : Observable<any> {
    return this.odata.patch(`/Employees(${idNum})`, employee, item => item.id_num == idNum, { expand }, []);
  }

  getListEmployees(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/ListEmployees`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getOrders(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Orders`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createOrder(expand: string | null, order: models.Order | null) : Observable<any> {
    return this.odata.post(`/Orders`, order, { expand }, ['Bar']);
  }

  deleteOrder(idOrder: number | null) : Observable<any> {
    return this.odata.delete(`/Orders(${idOrder})`, item => !(item.id_order == idOrder));
  }

  getOrderByidOrder(expand: string | null, idOrder: number | null) : Observable<any> {
    return this.odata.getById(`/Orders(${idOrder})`, { expand });
  }

  updateOrder(expand: string | null, idOrder: number | null, order: models.Order | null) : Observable<any> {
    return this.odata.patch(`/Orders(${idOrder})`, order, item => item.id_order == idOrder, { expand }, ['Bar']);
  }

  getProducts(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Products`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createProduct(expand: string | null, product: models.Product | null) : Observable<any> {
    return this.odata.post(`/Products`, product, { expand }, []);
  }

  getProductsInBars(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/ProductsInBars`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createProductsInBar(expand: string | null, productsInBar: models.ProductsInBar | null) : Observable<any> {
    return this.odata.post(`/ProductsInBars`, productsInBar, { expand }, ['Product', 'Bar']);
  }

  getProductsInWarehouses(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/ProductsInWarehouses`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createProductsInWarehouse(expand: string | null, productsInWarehouse: models.ProductsInWarehouse | null) : Observable<any> {
    return this.odata.post(`/ProductsInWarehouses`, productsInWarehouse, { expand }, ['Warehouse', 'Product']);
  }

  deleteProductsInWarehouse(idWarehouse: number | null) : Observable<any> {
    return this.odata.delete(`/ProductsInWarehouses(${idWarehouse})`, item => !(item.id_warehouse == idWarehouse));
  }

  getProductsInWarehouseByidWarehouse(expand: string | null, idWarehouse: number | null) : Observable<any> {
    return this.odata.getById(`/ProductsInWarehouses(${idWarehouse})`, { expand });
  }

  updateProductsInWarehouse(expand: string | null, idWarehouse: number | null, productsInWarehouse: models.ProductsInWarehouse | null) : Observable<any> {
    return this.odata.patch(`/ProductsInWarehouses(${idWarehouse})`, productsInWarehouse, item => item.id_warehouse == idWarehouse, { expand }, ['Warehouse','Product']);
  }

  getProductsOrders(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/ProductsOrders`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getProductsToRestocks(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/ProductsToRestocks`, { filter, top, skip, orderby, count, expand, format, select });
  }

  getSchedules(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Schedules`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createSchedule(expand: string | null, schedule: models.Schedule | null) : Observable<any> {
    return this.odata.post(`/Schedules`, schedule, { expand }, []);
  }

  deleteSchedule(cod: number | null) : Observable<any> {
    return this.odata.delete(`/Schedules(${cod})`, item => !(item.cod == cod));
  }

  getScheduleBycod(expand: string | null, cod: number | null) : Observable<any> {
    return this.odata.getById(`/Schedules(${cod})`, { expand });
  }

  updateSchedule(expand: string | null, cod: number | null, schedule: models.Schedule | null) : Observable<any> {
    return this.odata.patch(`/Schedules(${cod})`, schedule, item => item.cod == cod, { expand }, []);
  }

  getWarehouses(filter: string | null, top: number | null, skip: number | null, orderby: string | null, count: boolean | null, expand: string | null, format: string | null, select: string | null) : Observable<any> {
    return this.odata.get(`/Warehouses`, { filter, top, skip, orderby, count, expand, format, select });
  }

  createWarehouse(expand: string | null, warehouse: models.Warehouse | null) : Observable<any> {
    return this.odata.post(`/Warehouses`, warehouse, { expand }, []);
  }

  deleteWarehouse(idWarehouse: number | null) : Observable<any> {
    return this.odata.delete(`/Warehouses(${idWarehouse})`, item => !(item.id_warehouse == idWarehouse));
  }

  getWarehouseByidWarehouse(expand: string | null, idWarehouse: number | null) : Observable<any> {
    return this.odata.getById(`/Warehouses(${idWarehouse})`, { expand });
  }

  updateWarehouse(expand: string | null, idWarehouse: number | null, warehouse: models.Warehouse | null) : Observable<any> {
    return this.odata.patch(`/Warehouses(${idWarehouse})`, warehouse, item => item.id_warehouse == idWarehouse, { expand }, []);
  }

  deleteProduct(idProduct: number | null, name: string | null) : Observable<any> {
    return this.odata.delete(`/Products(id_product=${idProduct},name='${encodeURIComponent(name)}')`, item => !(item.id_product == idProduct && item.name == name));
  }

  getProductByIdProductAndName(idProduct: number | null, name: string | null, expand: string | null) : Observable<any> {
    return this.odata.getById(`/Products(id_product=${idProduct},name='${encodeURIComponent(name)}')`, { expand });
  }

  updateProduct(idProduct: number | null, name: string | null, expand: string | null, product: models.Product | null) : Observable<any> {
    return this.odata.patch(`/Products(id_product=${idProduct},name='${encodeURIComponent(name)}')`, product, item => item.id_product == idProduct && item.name == name, { expand }, []);
  }

  deleteProductsInBar(idProduct: number | null, name: string | null) : Observable<any> {
    return this.odata.delete(`/ProductsInBars(id_product=${idProduct},name='${encodeURIComponent(name)}')`, item => !(item.id_product == idProduct && item.name == name));
  }

  getProductsInBarByIdProductAndName(idProduct: number | null, name: string | null, expand: string | null) : Observable<any> {
    return this.odata.getById(`/ProductsInBars(id_product=${idProduct},name='${encodeURIComponent(name)}')`, { expand });
  }

  updateProductsInBar(idProduct: number | null, name: string | null, expand: string | null, productsInBar: models.ProductsInBar | null) : Observable<any> {
    return this.odata.patch(`/ProductsInBars(id_product=${idProduct},name='${encodeURIComponent(name)}')`, productsInBar, item => item.id_product == idProduct && item.name == name, { expand }, ['Product','Bar']);
  }
}
