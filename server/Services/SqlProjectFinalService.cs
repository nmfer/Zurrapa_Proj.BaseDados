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
using AdminBranch.Data;

namespace AdminBranch
{
    public partial class SqlProjectFinalService
    {
        SqlProjectFinalContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly SqlProjectFinalContext context;
        private readonly NavigationManager navigationManager;

        public SqlProjectFinalService(SqlProjectFinalContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public async Task ExportBarsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/bars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/bars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBarsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/bars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/bars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBarsRead(ref IQueryable<Models.SqlProjectFinal.Bar> items);

        public async Task<IQueryable<Models.SqlProjectFinal.Bar>> GetBars(Query query = null)
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

        partial void OnBarCreated(Models.SqlProjectFinal.Bar item);
        partial void OnAfterBarCreated(Models.SqlProjectFinal.Bar item);

        public async Task<Models.SqlProjectFinal.Bar> CreateBar(Models.SqlProjectFinal.Bar bar)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/branches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/branches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBranchesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/branches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/branches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBranchesRead(ref IQueryable<Models.SqlProjectFinal.Branch> items);

        public async Task<IQueryable<Models.SqlProjectFinal.Branch>> GetBranches(Query query = null)
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

        partial void OnBranchCreated(Models.SqlProjectFinal.Branch item);
        partial void OnAfterBranchCreated(Models.SqlProjectFinal.Branch item);

        public async Task<Models.SqlProjectFinal.Branch> CreateBranch(Models.SqlProjectFinal.Branch branch)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/daybarbranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/daybarbranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDayBarBranchesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/daybarbranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/daybarbranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDayBarBranchesRead(ref IQueryable<Models.SqlProjectFinal.DayBarBranch> items);

        public async Task<IQueryable<Models.SqlProjectFinal.DayBarBranch>> GetDayBarBranches(Query query = null)
        {
            var items = Context.DayBarBranches.AsQueryable();

            items = items.Include(i => i.Bar);

            items = items.Include(i => i.DayBranch);

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

        partial void OnDayBarBranchCreated(Models.SqlProjectFinal.DayBarBranch item);
        partial void OnAfterDayBarBranchCreated(Models.SqlProjectFinal.DayBarBranch item);

        public async Task<Models.SqlProjectFinal.DayBarBranch> CreateDayBarBranch(Models.SqlProjectFinal.DayBarBranch dayBarBranch)
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
                dayBarBranch.DayBranch = null;
                throw;
            }

            OnAfterDayBarBranchCreated(dayBarBranch);

            return dayBarBranch;
        }
        public async Task ExportDayBranchesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/daybranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/daybranches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDayBranchesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/daybranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/daybranches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDayBranchesRead(ref IQueryable<Models.SqlProjectFinal.DayBranch> items);

        public async Task<IQueryable<Models.SqlProjectFinal.DayBranch>> GetDayBranches(Query query = null)
        {
            var items = Context.DayBranches.AsQueryable();

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

        partial void OnDayBranchCreated(Models.SqlProjectFinal.DayBranch item);
        partial void OnAfterDayBranchCreated(Models.SqlProjectFinal.DayBranch item);

        public async Task<Models.SqlProjectFinal.DayBranch> CreateDayBranch(Models.SqlProjectFinal.DayBranch dayBranch)
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
                dayBranch.Branch = null;
                throw;
            }

            OnAfterDayBranchCreated(dayBranch);

            return dayBranch;
        }
        public async Task ExportEmployeesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/employees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEmployeesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/employees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEmployeesRead(ref IQueryable<Models.SqlProjectFinal.Employee> items);

        public async Task<IQueryable<Models.SqlProjectFinal.Employee>> GetEmployees(Query query = null)
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

        partial void OnEmployeeCreated(Models.SqlProjectFinal.Employee item);
        partial void OnAfterEmployeeCreated(Models.SqlProjectFinal.Employee item);

        public async Task<Models.SqlProjectFinal.Employee> CreateEmployee(Models.SqlProjectFinal.Employee employee)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/listemployees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/listemployees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportListEmployeesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/listemployees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/listemployees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnListEmployeesRead(ref IQueryable<Models.SqlProjectFinal.ListEmployee> items);

        public async Task<IQueryable<Models.SqlProjectFinal.ListEmployee>> GetListEmployees(Query query = null)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/orders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/orders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOrdersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/orders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/orders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOrdersRead(ref IQueryable<Models.SqlProjectFinal.Order> items);

        public async Task<IQueryable<Models.SqlProjectFinal.Order>> GetOrders(Query query = null)
        {
            var items = Context.Orders.AsQueryable();

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

            OnOrdersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOrderCreated(Models.SqlProjectFinal.Order item);
        partial void OnAfterOrderCreated(Models.SqlProjectFinal.Order item);

        public async Task<Models.SqlProjectFinal.Order> CreateOrder(Models.SqlProjectFinal.Order order)
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
                throw;
            }

            OnAfterOrderCreated(order);

            return order;
        }
        public async Task ExportProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/products/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/products/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductsRead(ref IQueryable<Models.SqlProjectFinal.Product> items);

        public async Task<IQueryable<Models.SqlProjectFinal.Product>> GetProducts(Query query = null)
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

        partial void OnProductCreated(Models.SqlProjectFinal.Product item);
        partial void OnAfterProductCreated(Models.SqlProjectFinal.Product item);

        public async Task<Models.SqlProjectFinal.Product> CreateProduct(Models.SqlProjectFinal.Product product)
        {
            OnProductCreated(product);

            var existingItem = Context.Products
                              .Where(i => i.id_product == product.id_product && i.name == product.name)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productsinbars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productsinbars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductsInBarsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productsinbars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productsinbars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductsInBarsRead(ref IQueryable<Models.SqlProjectFinal.ProductsInBar> items);

        public async Task<IQueryable<Models.SqlProjectFinal.ProductsInBar>> GetProductsInBars(Query query = null)
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

        partial void OnProductsInBarCreated(Models.SqlProjectFinal.ProductsInBar item);
        partial void OnAfterProductsInBarCreated(Models.SqlProjectFinal.ProductsInBar item);

        public async Task<Models.SqlProjectFinal.ProductsInBar> CreateProductsInBar(Models.SqlProjectFinal.ProductsInBar productsInBar)
        {
            OnProductsInBarCreated(productsInBar);

            var existingItem = Context.ProductsInBars
                              .Where(i => i.id_product == productsInBar.id_product && i.name == productsInBar.name)
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
        public async Task ExportProductsOrdersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productsorders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productsorders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductsOrdersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productsorders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productsorders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductsOrdersRead(ref IQueryable<Models.SqlProjectFinal.ProductsOrder> items);

        public async Task<IQueryable<Models.SqlProjectFinal.ProductsOrder>> GetProductsOrders(Query query = null)
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
        public async Task ExportProductsToRestocksToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productstorestocks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productstorestocks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductsToRestocksToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/productstorestocks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/productstorestocks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductsToRestocksRead(ref IQueryable<Models.SqlProjectFinal.ProductsToRestock> items);

        public async Task<IQueryable<Models.SqlProjectFinal.ProductsToRestock>> GetProductsToRestocks(Query query = null)
        {
            var items = Context.ProductsToRestocks.AsQueryable();
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

            OnProductsToRestocksRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportSchedulesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/schedules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/schedules/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSchedulesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/schedules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/schedules/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSchedulesRead(ref IQueryable<Models.SqlProjectFinal.Schedule> items);

        public async Task<IQueryable<Models.SqlProjectFinal.Schedule>> GetSchedules(Query query = null)
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

        partial void OnScheduleCreated(Models.SqlProjectFinal.Schedule item);
        partial void OnAfterScheduleCreated(Models.SqlProjectFinal.Schedule item);

        public async Task<Models.SqlProjectFinal.Schedule> CreateSchedule(Models.SqlProjectFinal.Schedule schedule)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/warehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/warehouses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportWarehousesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/sqlprojectfinal/warehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/sqlprojectfinal/warehouses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnWarehousesRead(ref IQueryable<Models.SqlProjectFinal.Warehouse> items);

        public async Task<IQueryable<Models.SqlProjectFinal.Warehouse>> GetWarehouses(Query query = null)
        {
            var items = Context.Warehouses.AsQueryable();

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

            OnWarehousesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnWarehouseCreated(Models.SqlProjectFinal.Warehouse item);
        partial void OnAfterWarehouseCreated(Models.SqlProjectFinal.Warehouse item);

        public async Task<Models.SqlProjectFinal.Warehouse> CreateWarehouse(Models.SqlProjectFinal.Warehouse warehouse)
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
                warehouse.Product = null;
                throw;
            }

            OnAfterWarehouseCreated(warehouse);

            return warehouse;
        }

        partial void OnBarDeleted(Models.SqlProjectFinal.Bar item);
        partial void OnAfterBarDeleted(Models.SqlProjectFinal.Bar item);

        public async Task<Models.SqlProjectFinal.Bar> DeleteBar(int? idBar)
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

        partial void OnBarGet(Models.SqlProjectFinal.Bar item);

        public async Task<Models.SqlProjectFinal.Bar> GetBarByidBar(int? idBar)
        {
            var items = Context.Bars
                              .AsNoTracking()
                              .Where(i => i.id_bar == idBar);

            var itemToReturn = items.FirstOrDefault();

            OnBarGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlProjectFinal.Bar> CancelBarChanges(Models.SqlProjectFinal.Bar item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBarUpdated(Models.SqlProjectFinal.Bar item);
        partial void OnAfterBarUpdated(Models.SqlProjectFinal.Bar item);

        public async Task<Models.SqlProjectFinal.Bar> UpdateBar(int? idBar, Models.SqlProjectFinal.Bar bar)
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

        partial void OnBranchDeleted(Models.SqlProjectFinal.Branch item);
        partial void OnAfterBranchDeleted(Models.SqlProjectFinal.Branch item);

        public async Task<Models.SqlProjectFinal.Branch> DeleteBranch(int? idBranch)
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

        partial void OnBranchGet(Models.SqlProjectFinal.Branch item);

        public async Task<Models.SqlProjectFinal.Branch> GetBranchByidBranch(int? idBranch)
        {
            var items = Context.Branches
                              .AsNoTracking()
                              .Where(i => i.id_branch == idBranch);

            var itemToReturn = items.FirstOrDefault();

            OnBranchGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlProjectFinal.Branch> CancelBranchChanges(Models.SqlProjectFinal.Branch item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBranchUpdated(Models.SqlProjectFinal.Branch item);
        partial void OnAfterBranchUpdated(Models.SqlProjectFinal.Branch item);

        public async Task<Models.SqlProjectFinal.Branch> UpdateBranch(int? idBranch, Models.SqlProjectFinal.Branch branch)
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

        partial void OnDayBarBranchDeleted(Models.SqlProjectFinal.DayBarBranch item);
        partial void OnAfterDayBarBranchDeleted(Models.SqlProjectFinal.DayBarBranch item);

        public async Task<Models.SqlProjectFinal.DayBarBranch> DeleteDayBarBranch(int? date)
        {
            var itemToDelete = Context.DayBarBranches
                              .Where(i => i.date == date)
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

        partial void OnDayBarBranchGet(Models.SqlProjectFinal.DayBarBranch item);

        public async Task<Models.SqlProjectFinal.DayBarBranch> GetDayBarBranchBydate(int? date)
        {
            var items = Context.DayBarBranches
                              .AsNoTracking()
                              .Where(i => i.date == date);

            items = items.Include(i => i.Bar);

            items = items.Include(i => i.DayBranch);

            var itemToReturn = items.FirstOrDefault();

            OnDayBarBranchGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlProjectFinal.DayBarBranch> CancelDayBarBranchChanges(Models.SqlProjectFinal.DayBarBranch item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDayBarBranchUpdated(Models.SqlProjectFinal.DayBarBranch item);
        partial void OnAfterDayBarBranchUpdated(Models.SqlProjectFinal.DayBarBranch item);

        public async Task<Models.SqlProjectFinal.DayBarBranch> UpdateDayBarBranch(int? date, Models.SqlProjectFinal.DayBarBranch dayBarBranch)
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

        partial void OnDayBranchDeleted(Models.SqlProjectFinal.DayBranch item);
        partial void OnAfterDayBranchDeleted(Models.SqlProjectFinal.DayBranch item);

        public async Task<Models.SqlProjectFinal.DayBranch> DeleteDayBranch(int? date)
        {
            var itemToDelete = Context.DayBranches
                              .Where(i => i.date == date)
                              .Include(i => i.DayBarBranches)
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

        partial void OnDayBranchGet(Models.SqlProjectFinal.DayBranch item);

        public async Task<Models.SqlProjectFinal.DayBranch> GetDayBranchBydate(int? date)
        {
            var items = Context.DayBranches
                              .AsNoTracking()
                              .Where(i => i.date == date);

            items = items.Include(i => i.Branch);

            var itemToReturn = items.FirstOrDefault();

            OnDayBranchGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlProjectFinal.DayBranch> CancelDayBranchChanges(Models.SqlProjectFinal.DayBranch item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDayBranchUpdated(Models.SqlProjectFinal.DayBranch item);
        partial void OnAfterDayBranchUpdated(Models.SqlProjectFinal.DayBranch item);

        public async Task<Models.SqlProjectFinal.DayBranch> UpdateDayBranch(int? date, Models.SqlProjectFinal.DayBranch dayBranch)
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

        partial void OnEmployeeDeleted(Models.SqlProjectFinal.Employee item);
        partial void OnAfterEmployeeDeleted(Models.SqlProjectFinal.Employee item);

        public async Task<Models.SqlProjectFinal.Employee> DeleteEmployee(int? idNum)
        {
            var itemToDelete = Context.Employees
                              .Where(i => i.id_num == idNum)
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

        partial void OnEmployeeGet(Models.SqlProjectFinal.Employee item);

        public async Task<Models.SqlProjectFinal.Employee> GetEmployeeByidNum(int? idNum)
        {
            var items = Context.Employees
                              .AsNoTracking()
                              .Where(i => i.id_num == idNum);

            var itemToReturn = items.FirstOrDefault();

            OnEmployeeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlProjectFinal.Employee> CancelEmployeeChanges(Models.SqlProjectFinal.Employee item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEmployeeUpdated(Models.SqlProjectFinal.Employee item);
        partial void OnAfterEmployeeUpdated(Models.SqlProjectFinal.Employee item);

        public async Task<Models.SqlProjectFinal.Employee> UpdateEmployee(int? idNum, Models.SqlProjectFinal.Employee employee)
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

        partial void OnOrderDeleted(Models.SqlProjectFinal.Order item);
        partial void OnAfterOrderDeleted(Models.SqlProjectFinal.Order item);

        public async Task<Models.SqlProjectFinal.Order> DeleteOrder(int? idOrder)
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

        partial void OnOrderGet(Models.SqlProjectFinal.Order item);

        public async Task<Models.SqlProjectFinal.Order> GetOrderByidOrder(int? idOrder)
        {
            var items = Context.Orders
                              .AsNoTracking()
                              .Where(i => i.id_order == idOrder);

            items = items.Include(i => i.Bar);

            var itemToReturn = items.FirstOrDefault();

            OnOrderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlProjectFinal.Order> CancelOrderChanges(Models.SqlProjectFinal.Order item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOrderUpdated(Models.SqlProjectFinal.Order item);
        partial void OnAfterOrderUpdated(Models.SqlProjectFinal.Order item);

        public async Task<Models.SqlProjectFinal.Order> UpdateOrder(int? idOrder, Models.SqlProjectFinal.Order order)
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

        partial void OnProductDeleted(Models.SqlProjectFinal.Product item);
        partial void OnAfterProductDeleted(Models.SqlProjectFinal.Product item);

        public async Task<Models.SqlProjectFinal.Product> DeleteProduct(int? idProduct, string name)
        {
            var itemToDelete = Context.Products
                              .Where(i => i.id_product == idProduct && i.name == name)
                              .Include(i => i.ProductsInBars)
                              .Include(i => i.Warehouses)
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

        partial void OnProductGet(Models.SqlProjectFinal.Product item);

        public async Task<Models.SqlProjectFinal.Product> GetProductByIdProductAndName(int? idProduct, string name)
        {
            var items = Context.Products
                              .AsNoTracking()
                              .Where(i => i.id_product == idProduct && i.name == name);

            var itemToReturn = items.FirstOrDefault();

            OnProductGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlProjectFinal.Product> CancelProductChanges(Models.SqlProjectFinal.Product item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProductUpdated(Models.SqlProjectFinal.Product item);
        partial void OnAfterProductUpdated(Models.SqlProjectFinal.Product item);

        public async Task<Models.SqlProjectFinal.Product> UpdateProduct(int? idProduct, string name, Models.SqlProjectFinal.Product product)
        {
            OnProductUpdated(product);

            var itemToUpdate = Context.Products
                              .Where(i => i.id_product == idProduct && i.name == name)
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

        partial void OnProductsInBarDeleted(Models.SqlProjectFinal.ProductsInBar item);
        partial void OnAfterProductsInBarDeleted(Models.SqlProjectFinal.ProductsInBar item);

        public async Task<Models.SqlProjectFinal.ProductsInBar> DeleteProductsInBar(int? idProduct, string name)
        {
            var itemToDelete = Context.ProductsInBars
                              .Where(i => i.id_product == idProduct && i.name == name)
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

        partial void OnProductsInBarGet(Models.SqlProjectFinal.ProductsInBar item);

        public async Task<Models.SqlProjectFinal.ProductsInBar> GetProductsInBarByIdProductAndName(int? idProduct, string name)
        {
            var items = Context.ProductsInBars
                              .AsNoTracking()
                              .Where(i => i.id_product == idProduct && i.name == name);

            items = items.Include(i => i.Bar);

            items = items.Include(i => i.Product);

            var itemToReturn = items.FirstOrDefault();

            OnProductsInBarGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlProjectFinal.ProductsInBar> CancelProductsInBarChanges(Models.SqlProjectFinal.ProductsInBar item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProductsInBarUpdated(Models.SqlProjectFinal.ProductsInBar item);
        partial void OnAfterProductsInBarUpdated(Models.SqlProjectFinal.ProductsInBar item);

        public async Task<Models.SqlProjectFinal.ProductsInBar> UpdateProductsInBar(int? idProduct, string name, Models.SqlProjectFinal.ProductsInBar productsInBar)
        {
            OnProductsInBarUpdated(productsInBar);

            var itemToUpdate = Context.ProductsInBars
                              .Where(i => i.id_product == idProduct && i.name == name)
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

        partial void OnScheduleDeleted(Models.SqlProjectFinal.Schedule item);
        partial void OnAfterScheduleDeleted(Models.SqlProjectFinal.Schedule item);

        public async Task<Models.SqlProjectFinal.Schedule> DeleteSchedule(int? cod)
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

        partial void OnScheduleGet(Models.SqlProjectFinal.Schedule item);

        public async Task<Models.SqlProjectFinal.Schedule> GetScheduleBycod(int? cod)
        {
            var items = Context.Schedules
                              .AsNoTracking()
                              .Where(i => i.cod == cod);

            var itemToReturn = items.FirstOrDefault();

            OnScheduleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlProjectFinal.Schedule> CancelScheduleChanges(Models.SqlProjectFinal.Schedule item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnScheduleUpdated(Models.SqlProjectFinal.Schedule item);
        partial void OnAfterScheduleUpdated(Models.SqlProjectFinal.Schedule item);

        public async Task<Models.SqlProjectFinal.Schedule> UpdateSchedule(int? cod, Models.SqlProjectFinal.Schedule schedule)
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

        partial void OnWarehouseDeleted(Models.SqlProjectFinal.Warehouse item);
        partial void OnAfterWarehouseDeleted(Models.SqlProjectFinal.Warehouse item);

        public async Task<Models.SqlProjectFinal.Warehouse> DeleteWarehouse(int? idWarehouse)
        {
            var itemToDelete = Context.Warehouses
                              .Where(i => i.id_warehouse == idWarehouse)
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

        partial void OnWarehouseGet(Models.SqlProjectFinal.Warehouse item);

        public async Task<Models.SqlProjectFinal.Warehouse> GetWarehouseByidWarehouse(int? idWarehouse)
        {
            var items = Context.Warehouses
                              .AsNoTracking()
                              .Where(i => i.id_warehouse == idWarehouse);

            items = items.Include(i => i.Product);

            var itemToReturn = items.FirstOrDefault();

            OnWarehouseGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.SqlProjectFinal.Warehouse> CancelWarehouseChanges(Models.SqlProjectFinal.Warehouse item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnWarehouseUpdated(Models.SqlProjectFinal.Warehouse item);
        partial void OnAfterWarehouseUpdated(Models.SqlProjectFinal.Warehouse item);

        public async Task<Models.SqlProjectFinal.Warehouse> UpdateWarehouse(int? idWarehouse, Models.SqlProjectFinal.Warehouse warehouse)
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
