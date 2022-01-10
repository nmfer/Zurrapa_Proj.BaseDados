import { Component, Injector } from '@angular/core';
import { EditProductsInWarehouseGenerated } from './edit-products-in-warehouse-generated.component';

@Component({
  selector: 'page-edit-products-in-warehouse',
  templateUrl: './edit-products-in-warehouse.component.html'
})
export class EditProductsInWarehouseComponent extends EditProductsInWarehouseGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
