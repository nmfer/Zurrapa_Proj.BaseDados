import { Component, Injector } from '@angular/core';
import { EmployeeLoginLayoutGenerated } from './employee-login-layout-generated.component';

@Component({
  selector: 'page-employee-login-layout',
  templateUrl: './employee-login-layout.component.html'
})
export class EmployeeLoginLayoutComponent extends EmployeeLoginLayoutGenerated {
  constructor(injector: Injector) {
    super(injector);
  }
}
