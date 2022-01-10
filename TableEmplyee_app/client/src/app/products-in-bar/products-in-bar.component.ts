import { Component, Injector } from '@angular/core';
import { ProductsInBarGenerated } from './products-in-bar-generated.component';

@Component({
  selector: 'page-products-in-bar',
  templateUrl: './products-in-bar.component.html'
})
export class ProductsInBarComponent extends ProductsInBarGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
