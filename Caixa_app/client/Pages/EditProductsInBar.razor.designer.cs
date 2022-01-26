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
    public partial class EditProductsInBarComponent : ComponentBase
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

        [Parameter]
        public dynamic id_product { get; set; }

        Caixa.Models.SqlProjectFinal.ProductsInBar _productsinbar;
        protected Caixa.Models.SqlProjectFinal.ProductsInBar productsinbar
        {
            get
            {
                return _productsinbar;
            }
            set
            {
                if (!object.Equals(_productsinbar, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "productsinbar", NewValue = value, OldValue = _productsinbar };
                    _productsinbar = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Caixa.Models.SqlProjectFinal.Bar> _getBarsResult;
        protected IEnumerable<Caixa.Models.SqlProjectFinal.Bar> getBarsResult
        {
            get
            {
                return _getBarsResult;
            }
            set
            {
                if (!object.Equals(_getBarsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBarsResult", NewValue = value, OldValue = _getBarsResult };
                    _getBarsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Caixa.Models.SqlProjectFinal.Product> _getProductsResult;
        protected IEnumerable<Caixa.Models.SqlProjectFinal.Product> getProductsResult
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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var sqlProjectFinalGetProductsInBarByidProductResult = await SqlProjectFinal.GetProductsInBarByidProduct(idProduct:id_product);
            productsinbar = sqlProjectFinalGetProductsInBarByidProductResult;

            var sqlProjectFinalGetBarsResult = await SqlProjectFinal.GetBars();
            getBarsResult = sqlProjectFinalGetBarsResult.Value.AsODataEnumerable();

            var sqlProjectFinalGetProductsResult = await SqlProjectFinal.GetProducts();
            getProductsResult = sqlProjectFinalGetProductsResult.Value.AsODataEnumerable();
        }

        protected async System.Threading.Tasks.Task Form0Submit(Caixa.Models.SqlProjectFinal.ProductsInBar args)
        {
            try
            {
                var sqlProjectFinalUpdateProductsInBarResult = await SqlProjectFinal.UpdateProductsInBar(idProduct:id_product, productsInBar:productsinbar);
                DialogService.Close(productsinbar);
            }
            catch (System.Exception sqlProjectFinalUpdateProductsInBarException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update ProductsInBar" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
