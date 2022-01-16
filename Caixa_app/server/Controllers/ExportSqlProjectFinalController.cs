using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Caixa.Data;

namespace Caixa
{
    public partial class ExportSqlProjectFinalController : ExportController
    {
        private readonly SqlProjectFinalContext context;
        public ExportSqlProjectFinalController(SqlProjectFinalContext context)
        {
            this.context = context;
        }

        [HttpGet("/export/SqlProjectFinal/bars/csv")]
        [HttpGet("/export/SqlProjectFinal/bars/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Bars, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/bars/excel")]
        [HttpGet("/export/SqlProjectFinal/bars/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Bars, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/branches/csv")]
        [HttpGet("/export/SqlProjectFinal/branches/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Branches, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/branches/excel")]
        [HttpGet("/export/SqlProjectFinal/branches/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Branches, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/daybarbranches/csv")]
        [HttpGet("/export/SqlProjectFinal/daybarbranches/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDayBarBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.DayBarBranches, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/daybarbranches/excel")]
        [HttpGet("/export/SqlProjectFinal/daybarbranches/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDayBarBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.DayBarBranches, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/daybranches/csv")]
        [HttpGet("/export/SqlProjectFinal/daybranches/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDayBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.DayBranches, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/daybranches/excel")]
        [HttpGet("/export/SqlProjectFinal/daybranches/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDayBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.DayBranches, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/empwarehouses/csv")]
        [HttpGet("/export/SqlProjectFinal/empwarehouses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEmpWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EmpWarehouses, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/empwarehouses/excel")]
        [HttpGet("/export/SqlProjectFinal/empwarehouses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEmpWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EmpWarehouses, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/employees/csv")]
        [HttpGet("/export/SqlProjectFinal/employees/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEmployeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Employees, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/employees/excel")]
        [HttpGet("/export/SqlProjectFinal/employees/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEmployeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Employees, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/listemployees/csv")]
        [HttpGet("/export/SqlProjectFinal/listemployees/csv(fileName='{fileName}')")]
        public FileStreamResult ExportListEmployeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ListEmployees, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/listemployees/excel")]
        [HttpGet("/export/SqlProjectFinal/listemployees/excel(fileName='{fileName}')")]
        public FileStreamResult ExportListEmployeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ListEmployees, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/orders/csv")]
        [HttpGet("/export/SqlProjectFinal/orders/csv(fileName='{fileName}')")]
        public FileStreamResult ExportOrdersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Orders, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/orders/excel")]
        [HttpGet("/export/SqlProjectFinal/orders/excel(fileName='{fileName}')")]
        public FileStreamResult ExportOrdersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Orders, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/products/csv")]
        [HttpGet("/export/SqlProjectFinal/products/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Products, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/products/excel")]
        [HttpGet("/export/SqlProjectFinal/products/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Products, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/productsinbars/csv")]
        [HttpGet("/export/SqlProjectFinal/productsinbars/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProductsInBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ProductsInBars, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/productsinbars/excel")]
        [HttpGet("/export/SqlProjectFinal/productsinbars/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProductsInBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ProductsInBars, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/productsinwarehouses/csv")]
        [HttpGet("/export/SqlProjectFinal/productsinwarehouses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProductsInWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ProductsInWarehouses, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/productsinwarehouses/excel")]
        [HttpGet("/export/SqlProjectFinal/productsinwarehouses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProductsInWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ProductsInWarehouses, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/productsorders/csv")]
        [HttpGet("/export/SqlProjectFinal/productsorders/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProductsOrdersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ProductsOrders, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/productsorders/excel")]
        [HttpGet("/export/SqlProjectFinal/productsorders/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProductsOrdersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ProductsOrders, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/restockbars/csv")]
        [HttpGet("/export/SqlProjectFinal/restockbars/csv(fileName='{fileName}')")]
        public FileStreamResult ExportRestockBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.RestockBars, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/restockbars/excel")]
        [HttpGet("/export/SqlProjectFinal/restockbars/excel(fileName='{fileName}')")]
        public FileStreamResult ExportRestockBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.RestockBars, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/restockwarehouses/csv")]
        [HttpGet("/export/SqlProjectFinal/restockwarehouses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportRestockWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.RestockWarehouses, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/restockwarehouses/excel")]
        [HttpGet("/export/SqlProjectFinal/restockwarehouses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportRestockWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.RestockWarehouses, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/schedules/csv")]
        [HttpGet("/export/SqlProjectFinal/schedules/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSchedulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Schedules, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/schedules/excel")]
        [HttpGet("/export/SqlProjectFinal/schedules/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSchedulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Schedules, Request.Query), fileName);
        }
        [HttpGet("/export/SqlProjectFinal/warehouses/csv")]
        [HttpGet("/export/SqlProjectFinal/warehouses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Warehouses, Request.Query), fileName);
        }

        [HttpGet("/export/SqlProjectFinal/warehouses/excel")]
        [HttpGet("/export/SqlProjectFinal/warehouses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Warehouses, Request.Query), fileName);
        }
    }
}
