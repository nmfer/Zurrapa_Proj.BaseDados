import { Component, Injector } from '@angular/core';
import { ProdutosParaRestockGenerated } from './produtos-para-restock-generated.component';

@Component({
  selector: 'page-produtos-para-restock',
  templateUrl: './produtos-para-restock.component.html'
})
export class ProdutosParaRestockComponent extends ProdutosParaRestockGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
