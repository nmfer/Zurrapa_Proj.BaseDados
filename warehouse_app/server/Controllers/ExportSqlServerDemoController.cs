using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Armazem.Data;

namespace Armazem
{
    public partial class ExportSqlServerDemoController : ExportController
    {
        private readonly SqlServerDemoContext context;
        public ExportSqlServerDemoController(SqlServerDemoContext context)
        {
            this.context = context;
        }

        [HttpGet("/export/SqlServerDemo/bars/csv")]
        [HttpGet("/export/SqlServerDemo/bars/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Bars, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/bars/excel")]
        [HttpGet("/export/SqlServerDemo/bars/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Bars, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/branches/csv")]
        [HttpGet("/export/SqlServerDemo/branches/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Branches, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/branches/excel")]
        [HttpGet("/export/SqlServerDemo/branches/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Branches, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/daybarbranches/csv")]
        [HttpGet("/export/SqlServerDemo/daybarbranches/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDayBarBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.DayBarBranches, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/daybarbranches/excel")]
        [HttpGet("/export/SqlServerDemo/daybarbranches/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDayBarBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.DayBarBranches, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/daybranches/csv")]
        [HttpGet("/export/SqlServerDemo/daybranches/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDayBranchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.DayBranches, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/daybranches/excel")]
        [HttpGet("/export/SqlServerDemo/daybranches/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDayBranchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.DayBranches, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/empwarehouses/csv")]
        [HttpGet("/export/SqlServerDemo/empwarehouses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEmpWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EmpWarehouses, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/empwarehouses/excel")]
        [HttpGet("/export/SqlServerDemo/empwarehouses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEmpWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EmpWarehouses, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/employees/csv")]
        [HttpGet("/export/SqlServerDemo/employees/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEmployeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Employees, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/employees/excel")]
        [HttpGet("/export/SqlServerDemo/employees/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEmployeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Employees, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/listemployees/csv")]
        [HttpGet("/export/SqlServerDemo/listemployees/csv(fileName='{fileName}')")]
        public FileStreamResult ExportListEmployeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ListEmployees, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/listemployees/excel")]
        [HttpGet("/export/SqlServerDemo/listemployees/excel(fileName='{fileName}')")]
        public FileStreamResult ExportListEmployeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ListEmployees, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/orders/csv")]
        [HttpGet("/export/SqlServerDemo/orders/csv(fileName='{fileName}')")]
        public FileStreamResult ExportOrdersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Orders, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/orders/excel")]
        [HttpGet("/export/SqlServerDemo/orders/excel(fileName='{fileName}')")]
        public FileStreamResult ExportOrdersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Orders, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/products/csv")]
        [HttpGet("/export/SqlServerDemo/products/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Products, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/products/excel")]
        [HttpGet("/export/SqlServerDemo/products/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Products, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/productsinbars/csv")]
        [HttpGet("/export/SqlServerDemo/productsinbars/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProductsInBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ProductsInBars, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/productsinbars/excel")]
        [HttpGet("/export/SqlServerDemo/productsinbars/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProductsInBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ProductsInBars, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/productsinwarehouses/csv")]
        [HttpGet("/export/SqlServerDemo/productsinwarehouses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProductsInWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ProductsInWarehouses, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/productsinwarehouses/excel")]
        [HttpGet("/export/SqlServerDemo/productsinwarehouses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProductsInWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ProductsInWarehouses, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/productsorders/csv")]
        [HttpGet("/export/SqlServerDemo/productsorders/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProductsOrdersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ProductsOrders, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/productsorders/excel")]
        [HttpGet("/export/SqlServerDemo/productsorders/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProductsOrdersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ProductsOrders, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/restockbars/csv")]
        [HttpGet("/export/SqlServerDemo/restockbars/csv(fileName='{fileName}')")]
        public FileStreamResult ExportRestockBarsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.RestockBars, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/restockbars/excel")]
        [HttpGet("/export/SqlServerDemo/restockbars/excel(fileName='{fileName}')")]
        public FileStreamResult ExportRestockBarsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.RestockBars, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/restockwarehouses/csv")]
        [HttpGet("/export/SqlServerDemo/restockwarehouses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportRestockWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.RestockWarehouses, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/restockwarehouses/excel")]
        [HttpGet("/export/SqlServerDemo/restockwarehouses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportRestockWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.RestockWarehouses, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/schedules/csv")]
        [HttpGet("/export/SqlServerDemo/schedules/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSchedulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Schedules, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/schedules/excel")]
        [HttpGet("/export/SqlServerDemo/schedules/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSchedulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Schedules, Request.Query), fileName);
        }
        [HttpGet("/export/SqlServerDemo/warehouses/csv")]
        [HttpGet("/export/SqlServerDemo/warehouses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportWarehousesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Warehouses, Request.Query), fileName);
        }

        [HttpGet("/export/SqlServerDemo/warehouses/excel")]
        [HttpGet("/export/SqlServerDemo/warehouses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportWarehousesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Warehouses, Request.Query), fileName);
        }
    }
}
