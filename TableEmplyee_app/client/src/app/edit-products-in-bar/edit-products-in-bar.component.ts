import { Component, Injector } from '@angular/core';
import { EditProductsInBarGenerated } from './edit-products-in-bar-generated.component';

@Component({
  selector: 'page-edit-products-in-bar',
  templateUrl: './edit-products-in-bar.component.html'
})
export class EditProductsInBarComponent extends EditProductsInBarGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
