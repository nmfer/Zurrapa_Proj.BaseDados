using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Filial.Models.SqlServerDemo;
using Microsoft.EntityFrameworkCore;

namespace Filial.Pages
{
    public partial class AddProdutosNoArmazemComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SqlServerDemoService SqlServerDemo { get; set; }

        IEnumerable<Filial.Models.SqlServerDemo.Warehouse> _getWarehousesResult;
        protected IEnumerable<Filial.Models.SqlServerDemo.Warehouse> getWarehousesResult
        {
            get
            {
                return _getWarehousesResult;
            }
            set
            {
                if (!object.Equals(_getWarehousesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getWarehousesResult", NewValue = value, OldValue = _getWarehousesResult };
                    _getWarehousesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Filial.Models.SqlServerDemo.Product> _getProductsResult;
        protected IEnumerable<Filial.Models.SqlServerDemo.Product> getProductsResult
        {
            get
            {
                return _getProductsResult;
            }
            set
            {
                if (!object.Equals(_getProductsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProductsResult", NewValue = value, OldValue = _getProductsResult };
                    _getProductsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        Filial.Models.SqlServerDemo.ProductsInWarehouse _productsinwarehouse;
        protected Filial.Models.SqlServerDemo.ProductsInWarehouse productsinwarehouse
        {
            get
            {
                return _productsinwarehouse;
            }
            set
            {
                if (!object.Equals(_productsinwarehouse, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "productsinwarehouse", NewValue = value, OldValue = _productsinwarehouse };
                    _productsinwarehouse = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var sqlServerDemoGetWarehousesResult = await SqlServerDemo.GetWarehouses();
            getWarehousesResult = sqlServerDemoGetWarehousesResult;

            var sqlServerDemoGetProductsResult = await SqlServerDemo.GetProducts();
            getProductsResult = sqlServerDemoGetProductsResult;

            productsinwarehouse = new Filial.Models.SqlServerDemo.ProductsInWarehouse(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Filial.Models.SqlServerDemo.ProductsInWarehouse args)
        {
            try
            {
                var sqlServerDemoCreateProductsInWarehouseResult = await SqlServerDemo.CreateProductsInWarehouse(productsinwarehouse);
                DialogService.Close(productsinwarehouse);
            }
            catch (System.Exception sqlServerDemoCreateProductsInWarehouseException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new ProductsInWarehouse!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
