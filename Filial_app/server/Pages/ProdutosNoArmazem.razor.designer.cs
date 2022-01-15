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
    public partial class ProdutosNoArmazemComponent : ComponentBase
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
        protected RadzenDataGrid<Filial.Models.SqlServerDemo.ProductsInWarehouse> grid0;

        IEnumerable<Filial.Models.SqlServerDemo.ProductsInWarehouse> _getProductsInWarehousesResult;
        protected IEnumerable<Filial.Models.SqlServerDemo.ProductsInWarehouse> getProductsInWarehousesResult
        {
            get
            {
                return _getProductsInWarehousesResult;
            }
            set
            {
                if (!object.Equals(_getProductsInWarehousesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProductsInWarehousesResult", NewValue = value, OldValue = _getProductsInWarehousesResult };
                    _getProductsInWarehousesResult = value;
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
            var sqlServerDemoGetProductsInWarehousesResult = await SqlServerDemo.GetProductsInWarehouses(new Query() { Expand = "Product" });
            getProductsInWarehousesResult = sqlServerDemoGetProductsInWarehousesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddProdutosNoArmazem>("Add Produtos No Armazem", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Filial.Models.SqlServerDemo.ProductsInWarehouse args)
        {
            var dialogResult = await DialogService.OpenAsync<EditProdutosNoArmazem>("Edit Produtos No Armazem", new Dictionary<string, object>() { {"id_warehouse", args.id_warehouse} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var sqlServerDemoDeleteProductsInWarehouseResult = await SqlServerDemo.DeleteProductsInWarehouse(data.id_warehouse);
                    if (sqlServerDemoDeleteProductsInWarehouseResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception sqlServerDemoDeleteProductsInWarehouseException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete ProductsInWarehouse" });
            }
        }
    }
}
