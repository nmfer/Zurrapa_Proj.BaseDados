/*
  This file is automatically generated. Any changes will be overwritten.
  Modify add-products-in-bar.component.ts instead.
*/
import { LOCALE_ID, ChangeDetectorRef, ViewChild, AfterViewInit, Injector, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Subscription } from 'rxjs';

import { DialogService, DIALOG_PARAMETERS, DialogRef } from '@radzen/angular/dist/dialog';
import { NotificationService } from '@radzen/angular/dist/notification';
import { ContentComponent } from '@radzen/angular/dist/content';
import { HeadingComponent } from '@radzen/angular/dist/heading';
import { TemplateFormComponent } from '@radzen/angular/dist/template-form';
import { LabelComponent } from '@radzen/angular/dist/label';
import { DropDownComponent } from '@radzen/angular/dist/dropdown';
import { RequiredValidatorComponent } from '@radzen/angular/dist/required-validator';
import { TextBoxComponent } from '@radzen/angular/dist/textbox';
import { NumericComponent } from '@radzen/angular/dist/numeric';
import { ButtonComponent } from '@radzen/angular/dist/button';

import { ConfigService } from '../config.service';

import { SqlProjectFinalService } from '../sql-project-final.service';

export class AddProductsInBarGenerated implements AfterViewInit, OnInit, OnDestroy {
  // Components
  @ViewChild('content1') content1: ContentComponent;
  @ViewChild('pageTitle') pageTitle: HeadingComponent;
  @ViewChild('form0') form0: TemplateFormComponent;
  @ViewChild('idProductLabel') idProductLabel: LabelComponent;
  @ViewChild('idProduct') idProduct: DropDownComponent;
  @ViewChild('idProductRequiredValidator') idProductRequiredValidator: RequiredValidatorComponent;
  @ViewChild('nameLabel') nameLabel: LabelComponent;
  @ViewChild('name') name: TextBoxComponent;
  @ViewChild('nameRequiredValidator') nameRequiredValidator: RequiredValidatorComponent;
  @ViewChild('quantityLabel') quantityLabel: LabelComponent;
  @ViewChild('quantity') quantity: NumericComponent;
  @ViewChild('quantityRequiredValidator') quantityRequiredValidator: RequiredValidatorComponent;
  @ViewChild('salePriceLabel') salePriceLabel: LabelComponent;
  @ViewChild('salePrice') salePrice: NumericComponent;
  @ViewChild('salePriceRequiredValidator') salePriceRequiredValidator: RequiredValidatorComponent;
  @ViewChild('minimumQuantityLabel') minimumQuantityLabel: LabelComponent;
  @ViewChild('minimumQuantity') minimumQuantity: NumericComponent;
  @ViewChild('minimumQuantityRequiredValidator') minimumQuantityRequiredValidator: RequiredValidatorComponent;
  @ViewChild('idBarLabel') idBarLabel: LabelComponent;
  @ViewChild('idBar') idBar: DropDownComponent;
  @ViewChild('idBarRequiredValidator') idBarRequiredValidator: RequiredValidatorComponent;
  @ViewChild('button1') button1: ButtonComponent;
  @ViewChild('button2') button2: ButtonComponent;

  router: Router;

  cd: ChangeDetectorRef;

  route: ActivatedRoute;

  notificationService: NotificationService;

  configService: ConfigService;

  dialogService: DialogService;

  dialogRef: DialogRef;

  httpClient: HttpClient;

  locale: string;

  _location: Location;

  _subscription: Subscription;

  sqlProjectFinal: SqlProjectFinalService;
  getProductsResult: any;
  getBarsResult: any;
  parameters: any;

  constructor(private injector: Injector) {
  }

  ngOnInit() {
    this.notificationService = this.injector.get(NotificationService);

    this.configService = this.injector.get(ConfigService);

    this.dialogService = this.injector.get(DialogService);

    this.dialogRef = this.injector.get(DialogRef, null);

    this.locale = this.injector.get(LOCALE_ID);

    this.router = this.injector.get(Router);

    this.cd = this.injector.get(ChangeDetectorRef);

    this._location = this.injector.get(Location);

    this.route = this.injector.get(ActivatedRoute);

    this.httpClient = this.injector.get(HttpClient);

    this.sqlProjectFinal = this.injector.get(SqlProjectFinalService);
  }

  ngAfterViewInit() {
    this._subscription = this.route.params.subscribe(parameters => {
      if (this.dialogRef) {
        this.parameters = this.injector.get(DIALOG_PARAMETERS);
      } else {
        this.parameters = parameters;
      }
      this.load();
      this.cd.detectChanges();
    });
  }

  ngOnDestroy() {
    if (this._subscription) {
      this._subscription.unsubscribe();
    }
  }


  load() {
    this.sqlProjectFinal.getProducts(null, null, null, null, null, null, null, null)
    .subscribe((result: any) => {
      this.getProductsResult = result.value;
    }, (result: any) => {

    });

    this.sqlProjectFinal.getBars(null, null, null, null, null, null, null, null)
    .subscribe((result: any) => {
      this.getBarsResult = result.value;
    }, (result: any) => {

    });
  }

  form0Submit(event: any) {
    this.sqlProjectFinal.createProductsInBar(null, event)
    .subscribe((result: any) => {
      if (this.dialogRef) {
        this.dialogRef.close();
      } else {
        this._location.back();
      }
    }, (result: any) => {
      this.notificationService.notify({ severity: "error", summary: `Error`, detail: `Unable to create new ProductsInBar!` });
    });
  }

  button2Click(event: any) {
    if (this.dialogRef) {
      this.dialogRef.close();
    } else {
      this._location.back();
    }
  }
}
