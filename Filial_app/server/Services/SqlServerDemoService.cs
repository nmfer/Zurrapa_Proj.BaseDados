using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Filial.Data;

namespace Filial
{
    public partial class SqlServerDemoService
    {
        SqlServerDemoContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly SqlServerDemoContext context;
        private readonly NavigationManager navigationManager;

        public SqlServerDemoService(SqlServerDemoContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public async Task ExportBarsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/bars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/bars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBarsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/bars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/bars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBarsRead(ref IQueryable<Models.SqlServerDemo.Bar> items);

        public async Task<IQueryable<Models.SqlServerDemo.Bar>> GetBars(Query query = null)
        {
            var items = Context.Bars.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnBarsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBarCreated(Models.SqlServerDemo.Bar item);
        partial void OnAfterBarCreated(Models.SqlServerDemo.Bar item);

        public async Task<Models.SqlServerDemo.Bar> CreateBar(Models.SqlServerDemo.Bar bar)
        {
            OnBarCreated(bar);

            var existingItem = Context.Bars
                              .Where(i => i.id_bar == bar.id_bar)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Bars.Add(bar);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(bar).State = EntityState.Detached;
                throw;
            }

            OnAfterBarCreated(bar);

            return bar;
        }
        public async Task ExportBranchesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/branches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/branches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBranchesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/branches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/branches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBranchesRead(ref IQueryable<Models.SqlServerDemo.Branch> items);

        public async Task<IQueryable<Models.SqlServerDemo.Branch>> GetBranches(Query query = null)
        {
            var items = Context.Branches.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnBranchesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBranchCreated(Models.SqlServerDemo.Branch item);
        partial void OnAfterBranchCreated(Models.SqlServerDemo.Branch item);

        public async Task<Models.SqlServerDemo.Branch> CreateBranch(Models.SqlServerDemo.Branch branch)
        {
            OnBranchCreated(branch);

            var existingItem = Context.Branches
                              .Where(i => i.id_branch == branch.id_branch)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Branches.Add(branch);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(branch).State = EntityState.Detached;
                throw;
            }

            OnAfterBranchCreated(branch);

            return branch;
        }
        public async Task ExportDayBarBranchesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/daybarbranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/daybarbranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDayBarBranchesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/daybarbranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/daybarbranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDayBarBranchesRead(ref IQueryable<Models.SqlServerDemo.DayBarBranch> items);

        public async Task<IQueryable<Models.SqlServerDemo.DayBarBranch>> GetDayBarBranches(Query query = null)
        {
            var items = Context.DayBarBranches.AsQueryable();

            items = items.Include(i => i.Bar);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnDayBarBranchesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDayBarBranchCreated(Models.SqlServerDemo.DayBarBranch item);
        partial void OnAfterDayBarBranchCreated(Models.SqlServerDemo.DayBarBranch item);

        public async Task<Models.SqlServerDemo.DayBarBranch> CreateDayBarBranch(Models.SqlServerDemo.DayBarBranch dayBarBranch)
        {
            OnDayBarBranchCreated(dayBarBranch);

            var existingItem = Context.DayBarBranches
                              .Where(i => i.date == dayBarBranch.date)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DayBarBranches.Add(dayBarBranch);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(dayBarBranch).State = EntityState.Detached;
                dayBarBranch.Bar = null;
                throw;
            }

            OnAfterDayBarBranchCreated(dayBarBranch);

            return dayBarBranch;
        }
        public async Task ExportDayBranchesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/daybranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/daybranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDayBranchesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/daybranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/daybranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDayBranchesRead(ref IQueryable<Models.SqlServerDemo.DayBranch> items);

        public async Task<IQueryable<Models.SqlServerDemo.DayBranch>> GetDayBranches(Query query = null)
        {
            var items = Context.DayBranches.AsQueryable();

            items = items.Include(i => i.DayBarBranch);

            items = items.Include(i => i.Branch);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnDayBranchesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDayBranchCreated(Models.SqlServerDemo.DayBranch item);
        partial void OnAfterDayBranchCreated(Models.SqlServerDemo.DayBranch item);

        public async Task<Models.SqlServerDemo.DayBranch> CreateDayBranch(Models.SqlServerDemo.DayBranch dayBranch)
        {
            OnDayBranchCreated(dayBranch);

            var existingItem = Context.DayBranches
                              .Where(i => i.date == dayBranch.date)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DayBranches.Add(dayBranch);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(dayBranch).State = EntityState.Detached;
                dayBranch.DayBarBranch = null;
                dayBranch.Branch = null;
                throw;
            }

            OnAfterDayBranchCreated(dayBranch);

            return dayBranch;
        }
        public async Task ExportEmpWarehousesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/empwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/empwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEmpWarehousesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/empwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/empwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEmpWarehousesRead(ref IQueryable<Models.SqlServerDemo.EmpWarehouse> items);

        public async Task<IQueryable<Models.SqlServerDemo.EmpWarehouse>> GetEmpWarehouses(Query query = null)
        {
            var items = Context.EmpWarehouses.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEmpWarehousesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportEmployeesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEmployeesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEmployeesRead(ref IQueryable<Models.SqlServerDemo.Employee> items);

        public async Task<IQueryable<Models.SqlServerDemo.Employee>> GetEmployees(Query query = null)
        {
            var items = Context.Employees.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEmployeesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEmployeeCreated(Models.SqlServerDemo.Employee item);
        partial void OnAfterEmployeeCreated(Models.SqlServerDemo.Employee item);

        public async Task<Models.SqlServerDemo.Employee> CreateEmployee(Models.SqlServerDemo.Employee employee)
        {
            OnEmployeeCreated(employee);

            var existingItem = Context.Employees
                              .Where(i => i.id_num == employee.id_num)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Employees.Add(employee);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(employee).State = EntityState.Detached;
                throw;
            }

            OnAfterEmployeeCreated(employee);

            return employee;
        }
        public async Task ExportListEmployeesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/listemployees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/listemployees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportListEmployeesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/listemployees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/listemployees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnListEmployeesRead(ref IQueryable<Models.SqlServerDemo.ListEmployee> items);

        public async Task<IQueryable<Models.SqlServerDemo.ListEmployee>> GetListEmployees(Query query = null)
        {
            var items = Context.ListEmployees.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnListEmployeesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportOrdersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/orders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/orders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOrdersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/orders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/orders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOrdersRead(ref IQueryable<Models.SqlServerDemo.Order> items);

        public async Task<IQueryable<Models.SqlServerDemo.Order>> GetOrders(Query query = null)
        {
            var items = Context.Orders.AsQueryable();

            items = items.Include(i => i.Bar);

            items = items.Include(i => i.Employee);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOrdersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOrderCreated(Models.SqlServerDemo.Order item);
        partial void OnAfterOrderCreated(Models.SqlServerDemo.Order item);

        public async Task<Models.SqlServerDemo.Order> CreateOrder(Models.SqlServerDemo.Order order)
        {
            OnOrderCreated(order);

            var existingItem = Context.Orders
                              .Where(i => i.id_order == order.id_order)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Orders.Add(order);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(order).State = EntityState.Detached;
                order.Bar = null;
                order.Employee = null;
                throw;
            }

            OnAfterOrderCreated(order);

            return order;
        }
        public async Task ExportProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductsRead(ref IQueryable<Models.SqlServerDemo.Product> items);

        public async Task<IQueryable<Models.SqlServerDemo.Product>> GetProducts(Query query = null)
        {
            var items = Context.Products.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProductsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProductCreated(Models.SqlServerDemo.Product item);
        partial void OnAfterProductCreated(Models.SqlServerDemo.Product item);

        public async Task<Models.SqlServerDemo.Product> CreateProduct(Models.SqlServerDemo.Product product)
        {
            OnProductCreated(product);

            var existingItem = Context.Products
                              .Where(i => i.id_product == product.id_product)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Products.Add(product);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(product).State = EntityState.Detached;
                throw;
            }

            OnAfterProductCreated(product);

            return product;
        }
        public async Task ExportProductsInBarsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/productsinbars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/productsinbars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductsInBarsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/productsinbars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/productsinbars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductsInBarsRead(ref IQueryable<Models.SqlServerDemo.ProductsInBar> items);

        public async Task<IQueryable<Models.SqlServerDemo.ProductsInBar>> GetProductsInBars(Query query = null)
        {
            var items = Context.ProductsInBars.AsQueryable();

            items = items.Include(i => i.Bar);

            items = items.Include(i => i.Product);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProductsInBarsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProductsInBarCreated(Models.SqlServerDemo.ProductsInBar item);
        partial void OnAfterProductsInBarCreated(Models.SqlServerDemo.ProductsInBar item);

        public async Task<Models.SqlServerDemo.ProductsInBar> CreateProductsInBar(Models.SqlServerDemo.ProductsInBar productsInBar)
        {
            OnProductsInBarCreated(productsInBar);

            var existingItem = Context.ProductsInBars
                              .Where(i => i.id_product == productsInBar.id_product)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProductsInBars.Add(productsInBar);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(productsInBar).State = EntityState.Detached;
                productsInBar.Bar = null;
                productsInBar.Product = null;
                throw;
            }

            OnAfterProductsInBarCreated(productsInBar);

            return productsInBar;
        }
        public async Task ExportProductsInWarehousesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/productsinwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/productsinwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductsInWarehousesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/productsinwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/productsinwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductsInWarehousesRead(ref IQueryable<Models.SqlServerDemo.ProductsInWarehouse> items);

        public async Task<IQueryable<Models.SqlServerDemo.ProductsInWarehouse>> GetProductsInWarehouses(Query query = null)
        {
            var items = Context.ProductsInWarehouses.AsQueryable();

            items = items.Include(i => i.Warehouse);

            items = items.Include(i => i.Product);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProductsInWarehousesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProductsInWarehouseCreated(Models.SqlServerDemo.ProductsInWarehouse item);
        partial void OnAfterProductsInWarehouseCreated(Models.SqlServerDemo.ProductsInWarehouse item);

        public async Task<Models.SqlServerDemo.ProductsInWarehouse> CreateProductsInWarehouse(Models.SqlServerDemo.ProductsInWarehouse productsInWarehouse)
        {
            OnProductsInWarehouseCreated(productsInWarehouse);

            var existingItem = Context.ProductsInWarehouses
                              .Where(i => i.id_warehouse == productsInWarehouse.id_warehouse)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProductsInWarehouses.Add(productsInWarehouse);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(productsInWarehouse).State = EntityState.Detached;
                productsInWarehouse.Warehouse = null;
                productsInWarehouse.Product = null;
                throw;
            }

            OnAfterProductsInWarehouseCreated(productsInWarehouse);

            return productsInWarehouse;
        }
        public async Task ExportProductsOrdersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/productsorders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/productsorders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductsOrdersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/productsorders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/productsorders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductsOrdersRead(ref IQueryable<Models.SqlServerDemo.ProductsOrder> items);

        public async Task<IQueryable<Models.SqlServerDemo.ProductsOrder>> GetProductsOrders(Query query = null)
        {
            var items = Context.ProductsOrders.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProductsOrdersRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportRestockBarsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/restockbars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/restockbars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRestockBarsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/restockbars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/restockbars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRestockBarsRead(ref IQueryable<Models.SqlServerDemo.RestockBar> items);

        public async Task<IQueryable<Models.SqlServerDemo.RestockBar>> GetRestockBars(Query query = null)
        {
            var items = Context.RestockBars.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnRestockBarsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportRestockWarehousesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/restockwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/restockwarehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRestockWarehousesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/restockwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/restockwarehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRestockWarehousesRead(ref IQueryable<Models.SqlServerDemo.RestockWarehouse> items);

        public async Task<IQueryable<Models.SqlServerDemo.RestockWarehouse>> GetRestockWarehouses(Query query = null)
        {
            var items = Context.RestockWarehouses.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnRestockWarehousesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportSchedulesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/schedules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/schedules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSchedulesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/schedules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/schedules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSchedulesRead(ref IQueryable<Models.SqlServerDemo.Schedule> items);

        public async Task<IQueryable<Models.SqlServerDemo.Schedule>> GetSchedules(Query query = null)
        {
            var items = Context.Schedules.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSchedulesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnScheduleCreated(Models.SqlServerDemo.Schedule item);
        partial void OnAfterScheduleCreated(Models.SqlServerDemo.Schedule item);

        public async Task<Models.SqlServerDemo.Schedule> CreateSchedule(Models.SqlServerDemo.Schedule schedule)
        {
            OnScheduleCreated(schedule);

            var existingItem = Context.Schedules
                              .Where(i => i.cod == schedule.cod)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Schedules.Add(schedule);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(schedule).State = EntityState.Detached;
                throw;
            }

            OnAfterScheduleCreated(schedule);

            return schedule;
        }
        public async Task ExportWarehousesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/warehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/warehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportWarehousesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlserverdemo/warehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlserverdemo/warehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnWarehousesRead(ref IQueryable<Models.SqlServerDemo.Warehouse> items);

        public async Task<IQueryable<Models.SqlServerDemo.Warehouse>> GetWarehouses(Query query = null)
        {
            var items = Context.Warehouses.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnWarehousesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnWarehouseCreated(Models.SqlServerDemo.Warehouse item);
        partial void OnAfterWarehouseCreated(Models.SqlServerDemo.Warehouse item);

        public async Task<Models.SqlServerDemo.Warehouse> CreateWarehouse(Models.SqlServerDemo.Warehouse warehouse)
        {
            OnWarehouseCreated(warehouse);

            var existingItem = Context.Warehouses
                              .Where(i => i.id_warehouse == warehouse.id_warehouse)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Warehouses.Add(warehouse);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(warehouse).State = EntityState.Detached;
                throw;
            }

            OnAfterWarehouseCreated(warehouse);

            return warehouse;
        }

        partial void OnBarDeleted(Models.SqlServerDemo.Bar item);
        partial void OnAfterBarDeleted(Models.SqlServerDemo.Bar item);

        public async Task<Models.SqlServerDemo.Bar> DeleteBar(int? idBar)
        {
            var itemToDelete = Context.Bars
                              .Where(i => i.id_bar == idBar)
                              .Include(i => i.ProductsInBars)
                              .Include(i => i.Orders)
                              .Include(i => i.DayBarBranches)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBarDeleted(itemToDelete);

            Context.Bars.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBarDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnBarGet(Models.SqlServerDemo.Bar item);

        public async Task<Models.SqlServerDemo.Bar> GetBarByidBar(int? idBar)
        {
            var items = Context.Bars
                              .AsNoTracking()
                              .Where(i => i.id_bar == idBar);

            var itemToReturn = items.FirstOrDefault();

            OnBarGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.Bar> CancelBarChanges(Models.SqlServerDemo.Bar item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBarUpdated(Models.SqlServerDemo.Bar item);
        partial void OnAfterBarUpdated(Models.SqlServerDemo.Bar item);

        public async Task<Models.SqlServerDemo.Bar> UpdateBar(int? idBar, Models.SqlServerDemo.Bar bar)
        {
            OnBarUpdated(bar);

            var itemToUpdate = Context.Bars
                              .Where(i => i.id_bar == idBar)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(bar);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterBarUpdated(bar);

            return bar;
        }

        partial void OnBranchDeleted(Models.SqlServerDemo.Branch item);
        partial void OnAfterBranchDeleted(Models.SqlServerDemo.Branch item);

        public async Task<Models.SqlServerDemo.Branch> DeleteBranch(int? idBranch)
        {
            var itemToDelete = Context.Branches
                              .Where(i => i.id_branch == idBranch)
                              .Include(i => i.DayBranches)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBranchDeleted(itemToDelete);

            Context.Branches.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBranchDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnBranchGet(Models.SqlServerDemo.Branch item);

        public async Task<Models.SqlServerDemo.Branch> GetBranchByidBranch(int? idBranch)
        {
            var items = Context.Branches
                              .AsNoTracking()
                              .Where(i => i.id_branch == idBranch);

            var itemToReturn = items.FirstOrDefault();

            OnBranchGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.Branch> CancelBranchChanges(Models.SqlServerDemo.Branch item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBranchUpdated(Models.SqlServerDemo.Branch item);
        partial void OnAfterBranchUpdated(Models.SqlServerDemo.Branch item);

        public async Task<Models.SqlServerDemo.Branch> UpdateBranch(int? idBranch, Models.SqlServerDemo.Branch branch)
        {
            OnBranchUpdated(branch);

            var itemToUpdate = Context.Branches
                              .Where(i => i.id_branch == idBranch)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(branch);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterBranchUpdated(branch);

            return branch;
        }

        partial void OnDayBarBranchDeleted(Models.SqlServerDemo.DayBarBranch item);
        partial void OnAfterDayBarBranchDeleted(Models.SqlServerDemo.DayBarBranch item);

        public async Task<Models.SqlServerDemo.DayBarBranch> DeleteDayBarBranch(int? date)
        {
            var itemToDelete = Context.DayBarBranches
                              .Where(i => i.date == date)
                              .Include(i => i.DayBranches)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDayBarBranchDeleted(itemToDelete);

            Context.DayBarBranches.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDayBarBranchDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnDayBarBranchGet(Models.SqlServerDemo.DayBarBranch item);

        public async Task<Models.SqlServerDemo.DayBarBranch> GetDayBarBranchBydate(int? date)
        {
            var items = Context.DayBarBranches
                              .AsNoTracking()
                              .Where(i => i.date == date);

            items = items.Include(i => i.Bar);

            var itemToReturn = items.FirstOrDefault();

            OnDayBarBranchGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.DayBarBranch> CancelDayBarBranchChanges(Models.SqlServerDemo.DayBarBranch item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDayBarBranchUpdated(Models.SqlServerDemo.DayBarBranch item);
        partial void OnAfterDayBarBranchUpdated(Models.SqlServerDemo.DayBarBranch item);

        public async Task<Models.SqlServerDemo.DayBarBranch> UpdateDayBarBranch(int? date, Models.SqlServerDemo.DayBarBranch dayBarBranch)
        {
            OnDayBarBranchUpdated(dayBarBranch);

            var itemToUpdate = Context.DayBarBranches
                              .Where(i => i.date == date)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(dayBarBranch);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterDayBarBranchUpdated(dayBarBranch);

            return dayBarBranch;
        }

        partial void OnDayBranchDeleted(Models.SqlServerDemo.DayBranch item);
        partial void OnAfterDayBranchDeleted(Models.SqlServerDemo.DayBranch item);

        public async Task<Models.SqlServerDemo.DayBranch> DeleteDayBranch(int? date)
        {
            var itemToDelete = Context.DayBranches
                              .Where(i => i.date == date)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDayBranchDeleted(itemToDelete);

            Context.DayBranches.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDayBranchDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnDayBranchGet(Models.SqlServerDemo.DayBranch item);

        public async Task<Models.SqlServerDemo.DayBranch> GetDayBranchBydate(int? date)
        {
            var items = Context.DayBranches
                              .AsNoTracking()
                              .Where(i => i.date == date);

            items = items.Include(i => i.DayBarBranch);

            items = items.Include(i => i.Branch);

            var itemToReturn = items.FirstOrDefault();

            OnDayBranchGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.DayBranch> CancelDayBranchChanges(Models.SqlServerDemo.DayBranch item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDayBranchUpdated(Models.SqlServerDemo.DayBranch item);
        partial void OnAfterDayBranchUpdated(Models.SqlServerDemo.DayBranch item);

        public async Task<Models.SqlServerDemo.DayBranch> UpdateDayBranch(int? date, Models.SqlServerDemo.DayBranch dayBranch)
        {
            OnDayBranchUpdated(dayBranch);

            var itemToUpdate = Context.DayBranches
                              .Where(i => i.date == date)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(dayBranch);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterDayBranchUpdated(dayBranch);

            return dayBranch;
        }

        partial void OnEmployeeDeleted(Models.SqlServerDemo.Employee item);
        partial void OnAfterEmployeeDeleted(Models.SqlServerDemo.Employee item);

        public async Task<Models.SqlServerDemo.Employee> DeleteEmployee(int? idNum)
        {
            var itemToDelete = Context.Employees
                              .Where(i => i.id_num == idNum)
                              .Include(i => i.Orders)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEmployeeDeleted(itemToDelete);

            Context.Employees.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEmployeeDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEmployeeGet(Models.SqlServerDemo.Employee item);

        public async Task<Models.SqlServerDemo.Employee> GetEmployeeByidNum(int? idNum)
        {
            var items = Context.Employees
                              .AsNoTracking()
                              .Where(i => i.id_num == idNum);

            var itemToReturn = items.FirstOrDefault();

            OnEmployeeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.Employee> CancelEmployeeChanges(Models.SqlServerDemo.Employee item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEmployeeUpdated(Models.SqlServerDemo.Employee item);
        partial void OnAfterEmployeeUpdated(Models.SqlServerDemo.Employee item);

        public async Task<Models.SqlServerDemo.Employee> UpdateEmployee(int? idNum, Models.SqlServerDemo.Employee employee)
        {
            OnEmployeeUpdated(employee);

            var itemToUpdate = Context.Employees
                              .Where(i => i.id_num == idNum)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(employee);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterEmployeeUpdated(employee);

            return employee;
        }

        partial void OnOrderDeleted(Models.SqlServerDemo.Order item);
        partial void OnAfterOrderDeleted(Models.SqlServerDemo.Order item);

        public async Task<Models.SqlServerDemo.Order> DeleteOrder(int? idOrder)
        {
            var itemToDelete = Context.Orders
                              .Where(i => i.id_order == idOrder)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOrderDeleted(itemToDelete);

            Context.Orders.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOrderDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnOrderGet(Models.SqlServerDemo.Order item);

        public async Task<Models.SqlServerDemo.Order> GetOrderByidOrder(int? idOrder)
        {
            var items = Context.Orders
                              .AsNoTracking()
                              .Where(i => i.id_order == idOrder);

            items = items.Include(i => i.Bar);

            items = items.Include(i => i.Employee);

            var itemToReturn = items.FirstOrDefault();

            OnOrderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.Order> CancelOrderChanges(Models.SqlServerDemo.Order item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOrderUpdated(Models.SqlServerDemo.Order item);
        partial void OnAfterOrderUpdated(Models.SqlServerDemo.Order item);

        public async Task<Models.SqlServerDemo.Order> UpdateOrder(int? idOrder, Models.SqlServerDemo.Order order)
        {
            OnOrderUpdated(order);

            var itemToUpdate = Context.Orders
                              .Where(i => i.id_order == idOrder)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(order);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterOrderUpdated(order);

            return order;
        }

        partial void OnProductDeleted(Models.SqlServerDemo.Product item);
        partial void OnAfterProductDeleted(Models.SqlServerDemo.Product item);

        public async Task<Models.SqlServerDemo.Product> DeleteProduct(int? idProduct)
        {
            var itemToDelete = Context.Products
                              .Where(i => i.id_product == idProduct)
                              .Include(i => i.ProductsInWarehouses)
                              .Include(i => i.ProductsInBars)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProductDeleted(itemToDelete);

            Context.Products.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProductDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnProductGet(Models.SqlServerDemo.Product item);

        public async Task<Models.SqlServerDemo.Product> GetProductByidProduct(int? idProduct)
        {
            var items = Context.Products
                              .AsNoTracking()
                              .Where(i => i.id_product == idProduct);

            var itemToReturn = items.FirstOrDefault();

            OnProductGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.Product> CancelProductChanges(Models.SqlServerDemo.Product item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProductUpdated(Models.SqlServerDemo.Product item);
        partial void OnAfterProductUpdated(Models.SqlServerDemo.Product item);

        public async Task<Models.SqlServerDemo.Product> UpdateProduct(int? idProduct, Models.SqlServerDemo.Product product)
        {
            OnProductUpdated(product);

            var itemToUpdate = Context.Products
                              .Where(i => i.id_product == idProduct)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(product);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterProductUpdated(product);

            return product;
        }

        partial void OnProductsInBarDeleted(Models.SqlServerDemo.ProductsInBar item);
        partial void OnAfterProductsInBarDeleted(Models.SqlServerDemo.ProductsInBar item);

        public async Task<Models.SqlServerDemo.ProductsInBar> DeleteProductsInBar(int? idProduct)
        {
            var itemToDelete = Context.ProductsInBars
                              .Where(i => i.id_product == idProduct)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProductsInBarDeleted(itemToDelete);

            Context.ProductsInBars.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProductsInBarDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnProductsInBarGet(Models.SqlServerDemo.ProductsInBar item);

        public async Task<Models.SqlServerDemo.ProductsInBar> GetProductsInBarByidProduct(int? idProduct)
        {
            var items = Context.ProductsInBars
                              .AsNoTracking()
                              .Where(i => i.id_product == idProduct);

            items = items.Include(i => i.Bar);

            items = items.Include(i => i.Product);

            var itemToReturn = items.FirstOrDefault();

            OnProductsInBarGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.ProductsInBar> CancelProductsInBarChanges(Models.SqlServerDemo.ProductsInBar item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProductsInBarUpdated(Models.SqlServerDemo.ProductsInBar item);
        partial void OnAfterProductsInBarUpdated(Models.SqlServerDemo.ProductsInBar item);

        public async Task<Models.SqlServerDemo.ProductsInBar> UpdateProductsInBar(int? idProduct, Models.SqlServerDemo.ProductsInBar productsInBar)
        {
            OnProductsInBarUpdated(productsInBar);

            var itemToUpdate = Context.ProductsInBars
                              .Where(i => i.id_product == idProduct)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(productsInBar);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterProductsInBarUpdated(productsInBar);

            return productsInBar;
        }

        partial void OnProductsInWarehouseDeleted(Models.SqlServerDemo.ProductsInWarehouse item);
        partial void OnAfterProductsInWarehouseDeleted(Models.SqlServerDemo.ProductsInWarehouse item);

        public async Task<Models.SqlServerDemo.ProductsInWarehouse> DeleteProductsInWarehouse(int? idWarehouse)
        {
            var itemToDelete = Context.ProductsInWarehouses
                              .Where(i => i.id_warehouse == idWarehouse)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProductsInWarehouseDeleted(itemToDelete);

            Context.ProductsInWarehouses.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProductsInWarehouseDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnProductsInWarehouseGet(Models.SqlServerDemo.ProductsInWarehouse item);

        public async Task<Models.SqlServerDemo.ProductsInWarehouse> GetProductsInWarehouseByidWarehouse(int? idWarehouse)
        {
            var items = Context.ProductsInWarehouses
                              .AsNoTracking()
                              .Where(i => i.id_warehouse == idWarehouse);

            items = items.Include(i => i.Warehouse);

            items = items.Include(i => i.Product);

            var itemToReturn = items.FirstOrDefault();

            OnProductsInWarehouseGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.ProductsInWarehouse> CancelProductsInWarehouseChanges(Models.SqlServerDemo.ProductsInWarehouse item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProductsInWarehouseUpdated(Models.SqlServerDemo.ProductsInWarehouse item);
        partial void OnAfterProductsInWarehouseUpdated(Models.SqlServerDemo.ProductsInWarehouse item);

        public async Task<Models.SqlServerDemo.ProductsInWarehouse> UpdateProductsInWarehouse(int? idWarehouse, Models.SqlServerDemo.ProductsInWarehouse productsInWarehouse)
        {
            OnProductsInWarehouseUpdated(productsInWarehouse);

            var itemToUpdate = Context.ProductsInWarehouses
                              .Where(i => i.id_warehouse == idWarehouse)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(productsInWarehouse);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterProductsInWarehouseUpdated(productsInWarehouse);

            return productsInWarehouse;
        }

        partial void OnScheduleDeleted(Models.SqlServerDemo.Schedule item);
        partial void OnAfterScheduleDeleted(Models.SqlServerDemo.Schedule item);

        public async Task<Models.SqlServerDemo.Schedule> DeleteSchedule(int? cod)
        {
            var itemToDelete = Context.Schedules
                              .Where(i => i.cod == cod)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnScheduleDeleted(itemToDelete);

            Context.Schedules.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterScheduleDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnScheduleGet(Models.SqlServerDemo.Schedule item);

        public async Task<Models.SqlServerDemo.Schedule> GetScheduleBycod(int? cod)
        {
            var items = Context.Schedules
                              .AsNoTracking()
                              .Where(i => i.cod == cod);

            var itemToReturn = items.FirstOrDefault();

            OnScheduleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.Schedule> CancelScheduleChanges(Models.SqlServerDemo.Schedule item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnScheduleUpdated(Models.SqlServerDemo.Schedule item);
        partial void OnAfterScheduleUpdated(Models.SqlServerDemo.Schedule item);

        public async Task<Models.SqlServerDemo.Schedule> UpdateSchedule(int? cod, Models.SqlServerDemo.Schedule schedule)
        {
            OnScheduleUpdated(schedule);

            var itemToUpdate = Context.Schedules
                              .Where(i => i.cod == cod)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(schedule);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterScheduleUpdated(schedule);

            return schedule;
        }

        partial void OnWarehouseDeleted(Models.SqlServerDemo.Warehouse item);
        partial void OnAfterWarehouseDeleted(Models.SqlServerDemo.Warehouse item);

        public async Task<Models.SqlServerDemo.Warehouse> DeleteWarehouse(int? idWarehouse)
        {
            var itemToDelete = Context.Warehouses
                              .Where(i => i.id_warehouse == idWarehouse)
                              .Include(i => i.ProductsInWarehouses)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnWarehouseDeleted(itemToDelete);

            Context.Warehouses.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterWarehouseDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnWarehouseGet(Models.SqlServerDemo.Warehouse item);

        public async Task<Models.SqlServerDemo.Warehouse> GetWarehouseByidWarehouse(int? idWarehouse)
        {
            var items = Context.Warehouses
                              .AsNoTracking()
                              .Where(i => i.id_warehouse == idWarehouse);

            var itemToReturn = items.FirstOrDefault();

            OnWarehouseGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlServerDemo.Warehouse> CancelWarehouseChanges(Models.SqlServerDemo.Warehouse item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnWarehouseUpdated(Models.SqlServerDemo.Warehouse item);
        partial void OnAfterWarehouseUpdated(Models.SqlServerDemo.Warehouse item);

        public async Task<Models.SqlServerDemo.Warehouse> UpdateWarehouse(int? idWarehouse, Models.SqlServerDemo.Warehouse warehouse)
        {
            OnWarehouseUpdated(warehouse);

            var itemToUpdate = Context.Warehouses
                              .Where(i => i.id_warehouse == idWarehouse)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(warehouse);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterWarehouseUpdated(warehouse);

            return warehouse;
        }
    }
}
