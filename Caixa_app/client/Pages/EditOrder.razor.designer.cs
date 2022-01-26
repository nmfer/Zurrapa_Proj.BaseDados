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
    public partial class EditOrderComponent : ComponentBase
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
        public dynamic id_order { get; set; }

        Caixa.Models.SqlProjectFinal.Order _order;
        protected Caixa.Models.SqlProjectFinal.Order order
        {
            get
            {
                return _order;
            }
            set
            {
                if (!object.Equals(_order, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "order", NewValue = value, OldValue = _order };
                    _order = value;
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

        IEnumerable<Caixa.Models.SqlProjectFinal.Employee> _getEmployeesResult;
        protected IEnumerable<Caixa.Models.SqlProjectFinal.Employee> getEmployeesResult
        {
            get
            {
                return _getEmployeesResult;
            }
            set
            {
                if (!object.Equals(_getEmployeesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEmployeesResult", NewValue = value, OldValue = _getEmployeesResult };
                    _getEmployeesResult = value;
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
            var sqlProjectFinalGetOrderByidOrderResult = await SqlProjectFinal.GetOrderByidOrder(idOrder:id_order);
            order = sqlProjectFinalGetOrderByidOrderResult;

            var sqlProjectFinalGetBarsResult = await SqlProjectFinal.GetBars();
            getBarsResult = sqlProjectFinalGetBarsResult.Value.AsODataEnumerable();

            var sqlProjectFinalGetEmployeesResult = await SqlProjectFinal.GetEmployees();
            getEmployeesResult = sqlProjectFinalGetEmployeesResult.Value.AsODataEnumerable();
        }

        protected async System.Threading.Tasks.Task Form0Submit(Caixa.Models.SqlProjectFinal.Order args)
        {
            try
            {
                var sqlProjectFinalUpdateOrderResult = await SqlProjectFinal.UpdateOrder(idOrder:id_order, order:order);
                DialogService.Close(order);
            }
            catch (System.Exception sqlProjectFinalUpdateOrderException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Order" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
