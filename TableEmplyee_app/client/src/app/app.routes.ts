import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { LoginComponent } from './login/login.component';
import { ProductsInBarComponent } from './products-in-bar/products-in-bar.component';
import { AddProductsInBarComponent } from './add-products-in-bar/add-products-in-bar.component';
import { EditProductsInBarComponent } from './edit-products-in-bar/edit-products-in-bar.component';

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
        path: 'products-in-bar',
        component: ProductsInBarComponent
      },
      {
        path: 'add-products-in-bar',
        component: AddProductsInBarComponent
      },
      {
        path: 'edit-products-in-bar/:id_product/:name',
        component: EditProductsInBarComponent
      },
    ]
  },
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
