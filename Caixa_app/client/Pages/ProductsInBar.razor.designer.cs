using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Caixa.Models.SqlProjectFinal;
using Caixa.Client.Pages;

namespace Caixa.Pages
{
    public partial class ProductsInBarComponent : ComponentBase
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
        protected SqlProjectFinalService SqlProjectFinal { get; set; }
        protected RadzenDataGrid<Caixa.Models.SqlProjectFinal.ProductsInBar> grid0;

        IEnumerable<Caixa.Models.SqlProjectFinal.ProductsInBar> _getProductsInBarsResult;
        protected IEnumerable<Caixa.Models.SqlProjectFinal.ProductsInBar> getProductsInBarsResult
        {
            get
            {
                return _getProductsInBarsResult;
            }
            set
            {
                if (!object.Equals(_getProductsInBarsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProductsInBarsResult", NewValue = value, OldValue = _getProductsInBarsResult };
                    _getProductsInBarsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getProductsInBarsCount;
        protected int getProductsInBarsCount
        {
            get
            {
                return _getProductsInBarsCount;
            }
            set
            {
                if (!object.Equals(_getProductsInBarsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProductsInBarsCount", NewValue = value, OldValue = _getProductsInBarsCount };
                    _getProductsInBarsCount = value;
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

        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var sqlProjectFinalGetProductsInBarsResult = await SqlProjectFinal.GetProductsInBars(filter:$"{args.Filter}", orderby:$"{args.OrderBy}", expand:$"Product,Bar", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getProductsInBarsResult = sqlProjectFinalGetProductsInBarsResult.Value.AsODataEnumerable();

                getProductsInBarsCount = sqlProjectFinalGetProductsInBarsResult.Count;
            }
            catch (System.Exception sqlProjectFinalGetProductsInBarsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load ProductsInBars" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Caixa.Models.SqlProjectFinal.ProductsInBar args)
        {
            var dialogResult = await DialogService.OpenAsync<EditProductsInBar>("Edit Products In Bar", new Dictionary<string, object>() { {"id_product", args.id_product} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
