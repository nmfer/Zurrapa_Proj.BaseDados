import { Component, Injector } from '@angular/core';
import { AddProductsInBarGenerated } from './add-products-in-bar-generated.component';

@Component({
  selector: 'page-add-products-in-bar',
  templateUrl: './add-products-in-bar.component.html'
})
export class AddProductsInBarComponent extends AddProductsInBarGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
