import { Component, Injector } from '@angular/core';
import { ProdutosNoArmazemGenerated } from './produtos-no-armazém-generated.component';

@Component({
  selector: 'page-produtos-no-armazém',
  templateUrl: './produtos-no-armazém.component.html'
})
export class ProdutosNoArmazemComponent extends ProdutosNoArmazemGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
