using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminBranch.Data;

namespace AdminBranch
{
    public partial class ExportSqlProjectFinalController : ExportController
    {
        private readonly SqlProjectFinalContext context;
        private readonly SqlProjectFinalService service;
        public ExportSqlProjectFinalController(SqlProjectFinalContext context, SqlProjectFinalService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/SqlProjectFinal/bars/csv")]
        [HttpGet("/export/SqlProjectFinal/bars/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBars(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/bars/excel")]
        [HttpGet("/export/SqlProjectFinal/bars/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBars(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/branches/csv")]
        [HttpGet("/export/SqlProjectFinal/branches/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBranches(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/branches/excel")]
        [HttpGet("/export/SqlProjectFinal/branches/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBranches(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/daybarbranches/csv")]
        [HttpGet("/export/SqlProjectFinal/daybarbranches/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDayBarBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDayBarBranches(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/daybarbranches/excel")]
        [HttpGet("/export/SqlProjectFinal/daybarbranches/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDayBarBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDayBarBranches(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/daybranches/csv")]
        [HttpGet("/export/SqlProjectFinal/daybranches/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDayBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDayBranches(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/daybranches/excel")]
        [HttpGet("/export/SqlProjectFinal/daybranches/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDayBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDayBranches(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/employees/csv")]
        [HttpGet("/export/SqlProjectFinal/employees/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmployeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEmployees(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/employees/excel")]
        [HttpGet("/export/SqlProjectFinal/employees/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmployeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEmployees(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/listemployees/csv")]
        [HttpGet("/export/SqlProjectFinal/listemployees/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportListEmployeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetListEmployees(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/listemployees/excel")]
        [HttpGet("/export/SqlProjectFinal/listemployees/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportListEmployeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetListEmployees(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/orders/csv")]
        [HttpGet("/export/SqlProjectFinal/orders/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOrdersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOrders(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/orders/excel")]
        [HttpGet("/export/SqlProjectFinal/orders/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOrdersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOrders(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/products/csv")]
        [HttpGet("/export/SqlProjectFinal/products/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProducts(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/products/excel")]
        [HttpGet("/export/SqlProjectFinal/products/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProducts(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/productsinbars/csv")]
        [HttpGet("/export/SqlProjectFinal/productsinbars/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsInBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProductsInBars(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/productsinbars/excel")]
        [HttpGet("/export/SqlProjectFinal/productsinbars/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsInBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProductsInBars(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/productsorders/csv")]
        [HttpGet("/export/SqlProjectFinal/productsorders/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsOrdersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProductsOrders(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/productsorders/excel")]
        [HttpGet("/export/SqlProjectFinal/productsorders/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsOrdersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProductsOrders(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/productstorestocks/csv")]
        [HttpGet("/export/SqlProjectFinal/productstorestocks/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsToRestocksToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProductsToRestocks(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/productstorestocks/excel")]
        [HttpGet("/export/SqlProjectFinal/productstorestocks/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProductsToRestocksToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProductsToRestocks(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/schedules/csv")]
        [HttpGet("/export/SqlProjectFinal/schedules/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSchedulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSchedules(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/schedules/excel")]
        [HttpGet("/export/SqlProjectFinal/schedules/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSchedulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSchedules(), Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/warehouses/csv")]
        [HttpGet("/export/SqlProjectFinal/warehouses/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetWarehouses(), Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/warehouses/excel")]
        [HttpGet("/export/SqlProjectFinal/warehouses/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetWarehouses(), Request.Query), fileName);
        }
    }
}
