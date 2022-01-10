import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { LoginComponent } from './login/login.component';
import { ProdutosNoArmazemComponent } from './produtos-no-armazém/produtos-no-armazém.component';
import { ProdutosParaRestockComponent } from './produtos-para-restock/produtos-para-restock.component';
import { EditProductsInWarehouseComponent } from './edit-products-in-warehouse/edit-products-in-warehouse.component';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  {
    path: '',
    component: LoginLayoutComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent
      },
    ]
  },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'produtos-no-armazém',
        component: ProdutosNoArmazemComponent
      },
      {
        path: 'produtos-para-restock',
        component: ProdutosParaRestockComponent
      },
      {
        path: 'edit-products-in-warehouse',
        component: EditProductsInWarehouseComponent
      },
    ]
  },
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
