using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Filial.Data;

namespace Filial
{
    public partial class ExportSqlServerDemoController : ExportController
    {
        private readonly SqlServerDemoContext context;
        private readonly SqlServerDemoService service;
        public ExportSqlServerDemoController(SqlServerDemoContext context, SqlServerDemoService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/SqlServerDemo/bars/csv")]
        [HttpGet("/export/SqlServerDemo/bars/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBars(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/bars/excel")]
        [HttpGet("/export/SqlServerDemo/bars/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBars(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/branches/csv")]
        [HttpGet("/export/SqlServerDemo/branches/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBranches(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/branches/excel")]
        [HttpGet("/export/SqlServerDemo/branches/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBranches(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/daybarbranches/csv")]
        [HttpGet("/export/SqlServerDemo/daybarbranches/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDayBarBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDayBarBranches(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/daybarbranches/excel")]
        [HttpGet("/export/SqlServerDemo/daybarbranches/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDayBarBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDayBarBranches(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/daybranches/csv")]
        [HttpGet("/export/SqlServerDemo/daybranches/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDayBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDayBranches(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/daybranches/excel")]
        [HttpGet("/export/SqlServerDemo/daybranches/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDayBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDayBranches(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/empwarehouses/csv")]
        [HttpGet("/export/SqlServerDemo/empwarehouses/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmpWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEmpWarehouses(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/empwarehouses/excel")]
        [HttpGet("/export/SqlServerDemo/empwarehouses/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmpWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEmpWarehouses(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/employees/csv")]
        [HttpGet("/export/SqlServerDemo/employees/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmployeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEmployees(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/employees/excel")]
        [HttpGet("/export/SqlServerDemo/employees/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmployeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEmployees(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/listemployees/csv")]
        [HttpGet("/export/SqlServerDemo/listemployees/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportListEmployeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetListEmployees(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/listemployees/excel")]
        [HttpGet("/export/SqlServerDemo/listemployees/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportListEmployeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetListEmployees(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/orders/csv")]
        [HttpGet("/export/SqlServerDemo/orders/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOrdersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOrders(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/orders/excel")]
        [HttpGet("/export/SqlServerDemo/orders/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOrdersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOrders(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/products/csv")]
        [HttpGet("/export/SqlServerDemo/products/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProducts(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/products/excel")]
        [HttpGet("/export/SqlServerDemo/products/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProducts(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/productsinbars/csv")]
        [HttpGet("/export/SqlServerDemo/productsinbars/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsInBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProductsInBars(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/productsinbars/excel")]
        [HttpGet("/export/SqlServerDemo/productsinbars/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsInBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProductsInBars(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/productsinwarehouses/csv")]
        [HttpGet("/export/SqlServerDemo/productsinwarehouses/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsInWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProductsInWarehouses(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/productsinwarehouses/excel")]
        [HttpGet("/export/SqlServerDemo/productsinwarehouses/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsInWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProductsInWarehouses(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/productsorders/csv")]
        [HttpGet("/export/SqlServerDemo/productsorders/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsOrdersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProductsOrders(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/productsorders/excel")]
        [HttpGet("/export/SqlServerDemo/productsorders/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsOrdersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProductsOrders(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/restockbars/csv")]
        [HttpGet("/export/SqlServerDemo/restockbars/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRestockBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRestockBars(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/restockbars/excel")]
        [HttpGet("/export/SqlServerDemo/restockbars/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRestockBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRestockBars(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/restockwarehouses/csv")]
        [HttpGet("/export/SqlServerDemo/restockwarehouses/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRestockWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRestockWarehouses(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/restockwarehouses/excel")]
        [HttpGet("/export/SqlServerDemo/restockwarehouses/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRestockWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRestockWarehouses(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/schedules/csv")]
        [HttpGet("/export/SqlServerDemo/schedules/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSchedulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSchedules(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/schedules/excel")]
        [HttpGet("/export/SqlServerDemo/schedules/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSchedulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSchedules(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/warehouses/csv")]
        [HttpGet("/export/SqlServerDemo/warehouses/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetWarehouses(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/warehouses/excel")]
        [HttpGet("/export/SqlServerDemo/warehouses/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetWarehouses(), Request.Query), fileName);
        }
    }
}
