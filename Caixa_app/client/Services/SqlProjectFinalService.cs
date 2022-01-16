
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using Caixa.Models.SqlProjectFinal;

namespace Caixa
{
    public partial class SqlProjectFinalService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public SqlProjectFinalService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/SqlProjectFinal/");
        }

        public async System.Threading.Tasks.Task ExportBarsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/bars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/bars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportBarsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/bars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/bars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetBars(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Bar>> GetBars(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Bars");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBars(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Bar>>(response);
        }
        partial void OnCreateBar(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Bar> CreateBar(Caixa.Models.SqlProjectFinal.Bar bar = default(Caixa.Models.SqlProjectFinal.Bar))
        {
            var uri = new Uri(baseUri, $"Bars");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(bar), Encoding.UTF8, "application/json");

            OnCreateBar(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Bar>(response);
        }

        public async System.Threading.Tasks.Task ExportBranchesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/branches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/branches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportBranchesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/branches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/branches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetBranches(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Branch>> GetBranches(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Branches");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBranches(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Branch>>(response);
        }
        partial void OnCreateBranch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Branch> CreateBranch(Caixa.Models.SqlProjectFinal.Branch branch = default(Caixa.Models.SqlProjectFinal.Branch))
        {
            var uri = new Uri(baseUri, $"Branches");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(branch), Encoding.UTF8, "application/json");

            OnCreateBranch(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Branch>(response);
        }

        public async System.Threading.Tasks.Task ExportDayBarBranchesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/daybarbranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/daybarbranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDayBarBranchesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/daybarbranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/daybarbranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDayBarBranches(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.DayBarBranch>> GetDayBarBranches(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"DayBarBranches");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDayBarBranches(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.DayBarBranch>>(response);
        }
        partial void OnCreateDayBarBranch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.DayBarBranch> CreateDayBarBranch(Caixa.Models.SqlProjectFinal.DayBarBranch dayBarBranch = default(Caixa.Models.SqlProjectFinal.DayBarBranch))
        {
            var uri = new Uri(baseUri, $"DayBarBranches");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(dayBarBranch), Encoding.UTF8, "application/json");

            OnCreateDayBarBranch(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.DayBarBranch>(response);
        }

        public async System.Threading.Tasks.Task ExportDayBranchesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/daybranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/daybranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDayBranchesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/daybranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/daybranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDayBranches(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.DayBranch>> GetDayBranches(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"DayBranches");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDayBranches(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.DayBranch>>(response);
        }
        partial void OnCreateDayBranch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.DayBranch> CreateDayBranch(Caixa.Models.SqlProjectFinal.DayBranch dayBranch = default(Caixa.Models.SqlProjectFinal.DayBranch))
        {
            var uri = new Uri(baseUri, $"DayBranches");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(dayBranch), Encoding.UTF8, "application/json");

            OnCreateDayBranch(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.DayBranch>(response);
        }

        public async System.Threading.Tasks.Task ExportEmpWarehousesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/empwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/empwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEmpWarehousesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/empwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/empwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEmpWarehouses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.EmpWarehouse>> GetEmpWarehouses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"EmpWarehouses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmpWarehouses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.EmpWarehouse>>(response);
        }

        public async System.Threading.Tasks.Task ExportEmployeesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEmployeesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEmployees(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Employee>> GetEmployees(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Employees");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmployees(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Employee>>(response);
        }
        partial void OnCreateEmployee(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Employee> CreateEmployee(Caixa.Models.SqlProjectFinal.Employee employee = default(Caixa.Models.SqlProjectFinal.Employee))
        {
            var uri = new Uri(baseUri, $"Employees");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            OnCreateEmployee(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Employee>(response);
        }

        public async System.Threading.Tasks.Task ExportListEmployeesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/listemployees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/listemployees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportListEmployeesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/listemployees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/listemployees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetListEmployees(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.ListEmployee>> GetListEmployees(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ListEmployees");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetListEmployees(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.ListEmployee>>(response);
        }

        public async System.Threading.Tasks.Task ExportOrdersToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/orders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/orders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportOrdersToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/orders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/orders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetOrders(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Order>> GetOrders(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Orders");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetOrders(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Order>>(response);
        }
        partial void OnCreateOrder(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Order> CreateOrder(Caixa.Models.SqlProjectFinal.Order order = default(Caixa.Models.SqlProjectFinal.Order))
        {
            var uri = new Uri(baseUri, $"Orders");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

            OnCreateOrder(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Order>(response);
        }

        public async System.Threading.Tasks.Task ExportProductsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProductsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetProducts(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Product>> GetProducts(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Products");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProducts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Product>>(response);
        }
        partial void OnCreateProduct(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Product> CreateProduct(Caixa.Models.SqlProjectFinal.Product product = default(Caixa.Models.SqlProjectFinal.Product))
        {
            var uri = new Uri(baseUri, $"Products");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            OnCreateProduct(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Product>(response);
        }

        public async System.Threading.Tasks.Task ExportProductsInBarsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productsinbars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productsinbars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProductsInBarsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productsinbars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productsinbars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetProductsInBars(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.ProductsInBar>> GetProductsInBars(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProductsInBars");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProductsInBars(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.ProductsInBar>>(response);
        }
        partial void OnCreateProductsInBar(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.ProductsInBar> CreateProductsInBar(Caixa.Models.SqlProjectFinal.ProductsInBar productsInBar = default(Caixa.Models.SqlProjectFinal.ProductsInBar))
        {
            var uri = new Uri(baseUri, $"ProductsInBars");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(productsInBar), Encoding.UTF8, "application/json");

            OnCreateProductsInBar(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.ProductsInBar>(response);
        }

        public async System.Threading.Tasks.Task ExportProductsInWarehousesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productsinwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productsinwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProductsInWarehousesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productsinwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productsinwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetProductsInWarehouses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>> GetProductsInWarehouses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProductsInWarehouses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProductsInWarehouses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>>(response);
        }
        partial void OnCreateProductsInWarehouse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.ProductsInWarehouse> CreateProductsInWarehouse(Caixa.Models.SqlProjectFinal.ProductsInWarehouse productsInWarehouse = default(Caixa.Models.SqlProjectFinal.ProductsInWarehouse))
        {
            var uri = new Uri(baseUri, $"ProductsInWarehouses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(productsInWarehouse), Encoding.UTF8, "application/json");

            OnCreateProductsInWarehouse(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>(response);
        }

        public async System.Threading.Tasks.Task ExportProductsOrdersToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productsorders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productsorders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportProductsOrdersToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productsorders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productsorders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetProductsOrders(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.ProductsOrder>> GetProductsOrders(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ProductsOrders");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProductsOrders(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.ProductsOrder>>(response);
        }

        public async System.Threading.Tasks.Task ExportRestockBarsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/restockbars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/restockbars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportRestockBarsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/restockbars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/restockbars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetRestockBars(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.RestockBar>> GetRestockBars(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"RestockBars");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetRestockBars(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.RestockBar>>(response);
        }

        public async System.Threading.Tasks.Task ExportRestockWarehousesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/restockwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/restockwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportRestockWarehousesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/restockwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/restockwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetRestockWarehouses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.RestockWarehouse>> GetRestockWarehouses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"RestockWarehouses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetRestockWarehouses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.RestockWarehouse>>(response);
        }

        public async System.Threading.Tasks.Task ExportSchedulesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/schedules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/schedules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSchedulesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/schedules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/schedules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSchedules(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Schedule>> GetSchedules(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Schedules");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSchedules(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Schedule>>(response);
        }
        partial void OnCreateSchedule(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Schedule> CreateSchedule(Caixa.Models.SqlProjectFinal.Schedule schedule = default(Caixa.Models.SqlProjectFinal.Schedule))
        {
            var uri = new Uri(baseUri, $"Schedules");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(schedule), Encoding.UTF8, "application/json");

            OnCreateSchedule(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Schedule>(response);
        }

        public async System.Threading.Tasks.Task ExportWarehousesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/warehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/warehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportWarehousesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/warehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/warehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetWarehouses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Warehouse>> GetWarehouses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Warehouses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetWarehouses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Caixa.Models.SqlProjectFinal.Warehouse>>(response);
        }
        partial void OnCreateWarehouse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Warehouse> CreateWarehouse(Caixa.Models.SqlProjectFinal.Warehouse warehouse = default(Caixa.Models.SqlProjectFinal.Warehouse))
        {
            var uri = new Uri(baseUri, $"Warehouses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(warehouse), Encoding.UTF8, "application/json");

            OnCreateWarehouse(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Warehouse>(response);
        }
        partial void OnDeleteBar(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBar(int? idBar = default(int?))
        {
            var uri = new Uri(baseUri, $"Bars({idBar})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteBar(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetBarByidBar(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Bar> GetBarByidBar(string expand = default(string), int? idBar = default(int?))
        {
            var uri = new Uri(baseUri, $"Bars({idBar})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBarByidBar(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Bar>(response);
        }
        partial void OnUpdateBar(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateBar(int? idBar = default(int?), Caixa.Models.SqlProjectFinal.Bar bar = default(Caixa.Models.SqlProjectFinal.Bar))
        {
            var uri = new Uri(baseUri, $"Bars({idBar})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(bar), Encoding.UTF8, "application/json");

            OnUpdateBar(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
        partial void OnDeleteBranch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBranch(int? idBranch = default(int?))
        {
            var uri = new Uri(baseUri, $"Branches({idBranch})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteBranch(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetBranchByidBranch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Branch> GetBranchByidBranch(string expand = default(string), int? idBranch = default(int?))
        {
            var uri = new Uri(baseUri, $"Branches({idBranch})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetBranchByidBranch(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Branch>(response);
        }
        partial void OnUpdateBranch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateBranch(int? idBranch = default(int?), Caixa.Models.SqlProjectFinal.Branch branch = default(Caixa.Models.SqlProjectFinal.Branch))
        {
            var uri = new Uri(baseUri, $"Branches({idBranch})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(branch), Encoding.UTF8, "application/json");

            OnUpdateBranch(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
        partial void OnDeleteDayBarBranch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDayBarBranch(int? date = default(int?))
        {
            var uri = new Uri(baseUri, $"DayBarBranches({date})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDayBarBranch(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDayBarBranchBydate(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.DayBarBranch> GetDayBarBranchBydate(string expand = default(string), int? date = default(int?))
        {
            var uri = new Uri(baseUri, $"DayBarBranches({date})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDayBarBranchBydate(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.DayBarBranch>(response);
        }
        partial void OnUpdateDayBarBranch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDayBarBranch(int? date = default(int?), Caixa.Models.SqlProjectFinal.DayBarBranch dayBarBranch = default(Caixa.Models.SqlProjectFinal.DayBarBranch))
        {
            var uri = new Uri(baseUri, $"DayBarBranches({date})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(dayBarBranch), Encoding.UTF8, "application/json");

            OnUpdateDayBarBranch(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
        partial void OnDeleteDayBranch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDayBranch(int? date = default(int?))
        {
            var uri = new Uri(baseUri, $"DayBranches({date})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDayBranch(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDayBranchBydate(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.DayBranch> GetDayBranchBydate(string expand = default(string), int? date = default(int?))
        {
            var uri = new Uri(baseUri, $"DayBranches({date})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDayBranchBydate(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.DayBranch>(response);
        }
        partial void OnUpdateDayBranch(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDayBranch(int? date = default(int?), Caixa.Models.SqlProjectFinal.DayBranch dayBranch = default(Caixa.Models.SqlProjectFinal.DayBranch))
        {
            var uri = new Uri(baseUri, $"DayBranches({date})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(dayBranch), Encoding.UTF8, "application/json");

            OnUpdateDayBranch(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
        partial void OnDeleteEmployee(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteEmployee(int? idNum = default(int?))
        {
            var uri = new Uri(baseUri, $"Employees({idNum})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEmployee(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetEmployeeByidNum(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Employee> GetEmployeeByidNum(string expand = default(string), int? idNum = default(int?))
        {
            var uri = new Uri(baseUri, $"Employees({idNum})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmployeeByidNum(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Employee>(response);
        }
        partial void OnUpdateEmployee(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateEmployee(int? idNum = default(int?), Caixa.Models.SqlProjectFinal.Employee employee = default(Caixa.Models.SqlProjectFinal.Employee))
        {
            var uri = new Uri(baseUri, $"Employees({idNum})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            OnUpdateEmployee(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
        partial void OnDeleteOrder(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteOrder(int? idOrder = default(int?))
        {
            var uri = new Uri(baseUri, $"Orders({idOrder})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteOrder(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetOrderByidOrder(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Order> GetOrderByidOrder(string expand = default(string), int? idOrder = default(int?))
        {
            var uri = new Uri(baseUri, $"Orders({idOrder})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetOrderByidOrder(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Order>(response);
        }
        partial void OnUpdateOrder(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateOrder(int? idOrder = default(int?), Caixa.Models.SqlProjectFinal.Order order = default(Caixa.Models.SqlProjectFinal.Order))
        {
            var uri = new Uri(baseUri, $"Orders({idOrder})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

            OnUpdateOrder(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
        partial void OnDeleteProduct(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteProduct(int? idProduct = default(int?))
        {
            var uri = new Uri(baseUri, $"Products({idProduct})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProduct(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetProductByidProduct(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Product> GetProductByidProduct(string expand = default(string), int? idProduct = default(int?))
        {
            var uri = new Uri(baseUri, $"Products({idProduct})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProductByidProduct(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Product>(response);
        }
        partial void OnUpdateProduct(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateProduct(int? idProduct = default(int?), Caixa.Models.SqlProjectFinal.Product product = default(Caixa.Models.SqlProjectFinal.Product))
        {
            var uri = new Uri(baseUri, $"Products({idProduct})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            OnUpdateProduct(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
        partial void OnDeleteProductsInBar(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteProductsInBar(int? idProduct = default(int?))
        {
            var uri = new Uri(baseUri, $"ProductsInBars({idProduct})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProductsInBar(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetProductsInBarByidProduct(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.ProductsInBar> GetProductsInBarByidProduct(string expand = default(string), int? idProduct = default(int?))
        {
            var uri = new Uri(baseUri, $"ProductsInBars({idProduct})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProductsInBarByidProduct(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.ProductsInBar>(response);
        }
        partial void OnUpdateProductsInBar(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateProductsInBar(int? idProduct = default(int?), Caixa.Models.SqlProjectFinal.ProductsInBar productsInBar = default(Caixa.Models.SqlProjectFinal.ProductsInBar))
        {
            var uri = new Uri(baseUri, $"ProductsInBars({idProduct})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(productsInBar), Encoding.UTF8, "application/json");

            OnUpdateProductsInBar(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
        partial void OnDeleteProductsInWarehouse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteProductsInWarehouse(int? idWarehouse = default(int?))
        {
            var uri = new Uri(baseUri, $"ProductsInWarehouses({idWarehouse})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProductsInWarehouse(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetProductsInWarehouseByidWarehouse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.ProductsInWarehouse> GetProductsInWarehouseByidWarehouse(string expand = default(string), int? idWarehouse = default(int?))
        {
            var uri = new Uri(baseUri, $"ProductsInWarehouses({idWarehouse})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProductsInWarehouseByidWarehouse(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>(response);
        }
        partial void OnUpdateProductsInWarehouse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateProductsInWarehouse(int? idWarehouse = default(int?), Caixa.Models.SqlProjectFinal.ProductsInWarehouse productsInWarehouse = default(Caixa.Models.SqlProjectFinal.ProductsInWarehouse))
        {
            var uri = new Uri(baseUri, $"ProductsInWarehouses({idWarehouse})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(productsInWarehouse), Encoding.UTF8, "application/json");

            OnUpdateProductsInWarehouse(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
        partial void OnDeleteSchedule(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSchedule(int? cod = default(int?))
        {
            var uri = new Uri(baseUri, $"Schedules({cod})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSchedule(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetScheduleBycod(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Schedule> GetScheduleBycod(string expand = default(string), int? cod = default(int?))
        {
            var uri = new Uri(baseUri, $"Schedules({cod})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetScheduleBycod(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Schedule>(response);
        }
        partial void OnUpdateSchedule(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateSchedule(int? cod = default(int?), Caixa.Models.SqlProjectFinal.Schedule schedule = default(Caixa.Models.SqlProjectFinal.Schedule))
        {
            var uri = new Uri(baseUri, $"Schedules({cod})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(schedule), Encoding.UTF8, "application/json");

            OnUpdateSchedule(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
        partial void OnDeleteWarehouse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteWarehouse(int? idWarehouse = default(int?))
        {
            var uri = new Uri(baseUri, $"Warehouses({idWarehouse})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteWarehouse(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetWarehouseByidWarehouse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Caixa.Models.SqlProjectFinal.Warehouse> GetWarehouseByidWarehouse(string expand = default(string), int? idWarehouse = default(int?))
        {
            var uri = new Uri(baseUri, $"Warehouses({idWarehouse})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetWarehouseByidWarehouse(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Caixa.Models.SqlProjectFinal.Warehouse>(response);
        }
        partial void OnUpdateWarehouse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateWarehouse(int? idWarehouse = default(int?), Caixa.Models.SqlProjectFinal.Warehouse warehouse = default(Caixa.Models.SqlProjectFinal.Warehouse))
        {
            var uri = new Uri(baseUri, $"Warehouses({idWarehouse})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(warehouse), Encoding.UTF8, "application/json");

            OnUpdateWarehouse(httpRequestMessage);
            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<HttpResponseMessage>(response);
        }
    }
}
