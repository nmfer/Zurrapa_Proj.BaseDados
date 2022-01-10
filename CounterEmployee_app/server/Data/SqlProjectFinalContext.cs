using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using CounterEmployee.Models.SqlProjectFinal;

namespace CounterEmployee.Data
{
    public partial class SqlProjectFinalContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IHttpContextAccessor httpAccessor;

        public SqlProjectFinalContext(IHttpContextAccessor httpAccessor, DbContextOptions<SqlProjectFinalContext> options):base(options)
        {
            this.httpAccessor = httpAccessor;
        }

        public SqlProjectFinalContext(IHttpContextAccessor httpAccessor)
        {
            this.httpAccessor = httpAccessor;
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Product>().HasKey(table => new {
              table.id_product, table.name
            });
            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInBar>().HasKey(table => new {
              table.id_product, table.name
            });
            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .HasOne(i => i.DayBranch)
                  .WithMany(i => i.DayBarBranches)
                  .HasForeignKey(i => i.date)
                  .HasPrincipalKey(i => i.date);
            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .HasOne(i => i.Bar)
                  .WithMany(i => i.DayBarBranches)
                  .HasForeignKey(i => i.id_bar)
                  .HasPrincipalKey(i => i.id_bar);
            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBranch>()
                  .HasOne(i => i.Branch)
                  .WithMany(i => i.DayBranches)
                  .HasForeignKey(i => i.id_branch)
                  .HasPrincipalKey(i => i.id_branch);
            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Order>()
                  .HasOne(i => i.Bar)
                  .WithMany(i => i.Orders)
                  .HasForeignKey(i => i.id_bar)
                  .HasPrincipalKey(i => i.id_bar);
            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .HasOne(i => i.Product)
                  .WithMany(i => i.ProductsInBars)
                  .HasForeignKey(i => new { i.id_product, i.name })
                  .HasPrincipalKey(i => new { i.id_product, i.name });
            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .HasOne(i => i.Bar)
                  .WithMany(i => i.ProductsInBars)
                  .HasForeignKey(i => i.id_bar)
                  .HasPrincipalKey(i => i.id_bar);
            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .HasOne(i => i.Warehouse)
                  .WithMany(i => i.ProductsInWarehouses)
                  .HasForeignKey(i => i.id_warehouse)
                  .HasPrincipalKey(i => i.id_warehouse);
            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .HasOne(i => i.Product)
                  .WithMany(i => i.ProductsInWarehouses)
                  .HasForeignKey(i => new { i.id_product, i.name })
                  .HasPrincipalKey(i => new { i.id_product, i.name });


            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.date)
                  .HasColumnType("date");

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Bar>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Bar>()
                  .Property(p => p.id_responsible)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Bar>()
                  .Property(p => p.phone_num)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Bar>()
                  .Property(p => p.id_branch)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Branch>()
                  .Property(p => p.id_branch)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Branch>()
                  .Property(p => p.id_responsible)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Branch>()
                  .Property(p => p.phone_num)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .Property(p => p.date)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .Property(p => p.total_received)
                  .HasPrecision(53, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .Property(p => p.total_spend)
                  .HasPrecision(53, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBranch>()
                  .Property(p => p.date)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBranch>()
                  .Property(p => p.total_received)
                  .HasPrecision(53, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBranch>()
                  .Property(p => p.total_spend)
                  .HasPrecision(53, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.DayBranch>()
                  .Property(p => p.id_branch)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Employee>()
                  .Property(p => p.id_num)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.id_branch)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.id_num)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.id_warehouse)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.cod)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Order>()
                  .Property(p => p.id_order)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Order>()
                  .Property(p => p.total_price)
                  .HasPrecision(53, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Order>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Order>()
                  .Property(p => p.table_number)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Product>()
                  .Property(p => p.id_product)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Product>()
                  .Property(p => p.set_to_unit)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Product>()
                  .Property(p => p.sale_price)
                  .HasPrecision(53, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Product>()
                  .Property(p => p.purchase_price)
                  .HasPrecision(53, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .Property(p => p.id_product)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .Property(p => p.quantity)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .Property(p => p.sale_price)
                  .HasPrecision(53, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .Property(p => p.minimum_quantity)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.id_warehouse)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.quantity)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.purchase_price)
                  .HasPrecision(53, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.minimum_quantity)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.total_quantity)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.id_product)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsOrder>()
                  .Property(p => p.id_order)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsOrder>()
                  .Property(p => p.id_product)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsToRestock>()
                  .Property(p => p.quatity)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsToRestock>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsToRestock>()
                  .Property(p => p.id_product)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.ProductsToRestock>()
                  .Property(p => p.id_warehouse)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Schedule>()
                  .Property(p => p.cod)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Schedule>()
                  .Property(p => p.entry_time)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Schedule>()
                  .Property(p => p.exit_time)
                  .HasPrecision(10, 0);

            builder.Entity<CounterEmployee.Models.SqlProjectFinal.Warehouse>()
                  .Property(p => p.id_warehouse)
                  .HasPrecision(10, 0);
            this.OnModelBuilding(builder);
        }


        public DbSet<CounterEmployee.Models.SqlProjectFinal.Bar> Bars
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.Branch> Branches
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.DayBarBranch> DayBarBranches
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.DayBranch> DayBranches
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.Employee> Employees
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.ListEmployee> ListEmployees
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.Order> Orders
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.Product> Products
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.ProductsInBar> ProductsInBars
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.ProductsInWarehouse> ProductsInWarehouses
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.ProductsOrder> ProductsOrders
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.ProductsToRestock> ProductsToRestocks
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.Schedule> Schedules
        {
          get;
          set;
        }

        public DbSet<CounterEmployee.Models.SqlProjectFinal.Warehouse> Warehouses
        {
          get;
          set;
        }
    }
}
