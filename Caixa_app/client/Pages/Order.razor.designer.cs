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
    public partial class OrderComponent : ComponentBase
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
        protected RadzenDataGrid<Caixa.Models.SqlProjectFinal.Order> grid0;

        IEnumerable<Caixa.Models.SqlProjectFinal.Order> _getOrdersResult;
        protected IEnumerable<Caixa.Models.SqlProjectFinal.Order> getOrdersResult
        {
            get
            {
                return _getOrdersResult;
            }
            set
            {
                if (!object.Equals(_getOrdersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOrdersResult", NewValue = value, OldValue = _getOrdersResult };
                    _getOrdersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getOrdersCount;
        protected int getOrdersCount
        {
            get
            {
                return _getOrdersCount;
            }
            set
            {
                if (!object.Equals(_getOrdersCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOrdersCount", NewValue = value, OldValue = _getOrdersCount };
                    _getOrdersCount = value;
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
                var sqlProjectFinalGetOrdersResult = await SqlProjectFinal.GetOrders(filter:$"{args.Filter}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getOrdersResult = sqlProjectFinalGetOrdersResult.Value.AsODataEnumerable();

                getOrdersCount = sqlProjectFinalGetOrdersResult.Count;
            }
            catch (System.Exception sqlProjectFinalGetOrdersException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load Orders" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Caixa.Models.SqlProjectFinal.Order args)
        {
            var dialogResult = await DialogService.OpenAsync<EditOrder>("Edit Order", new Dictionary<string, object>() { {"id_order", args.id_order} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var sqlProjectFinalDeleteOrderResult = await SqlProjectFinal.DeleteOrder(idOrder:data.id_order);
                    if (sqlProjectFinalDeleteOrderResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception sqlProjectFinalDeleteOrderException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Order" });
            }
        }
    }
}
