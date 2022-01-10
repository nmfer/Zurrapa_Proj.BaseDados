using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using WarehouseEmployee.Models.SqlProjectFinal;

namespace WarehouseEmployee.Data
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

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Product>().HasKey(table => new {
              table.id_product, table.name
            });
            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInBar>().HasKey(table => new {
              table.id_product, table.name
            });
            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .HasOne(i => i.DayBranch)
                  .WithMany(i => i.DayBarBranches)
                  .HasForeignKey(i => i.date)
                  .HasPrincipalKey(i => i.date);
            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .HasOne(i => i.Bar)
                  .WithMany(i => i.DayBarBranches)
                  .HasForeignKey(i => i.id_bar)
                  .HasPrincipalKey(i => i.id_bar);
            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBranch>()
                  .HasOne(i => i.Branch)
                  .WithMany(i => i.DayBranches)
                  .HasForeignKey(i => i.id_branch)
                  .HasPrincipalKey(i => i.id_branch);
            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Order>()
                  .HasOne(i => i.Bar)
                  .WithMany(i => i.Orders)
                  .HasForeignKey(i => i.id_bar)
                  .HasPrincipalKey(i => i.id_bar);
            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .HasOne(i => i.Product)
                  .WithMany(i => i.ProductsInBars)
                  .HasForeignKey(i => new { i.id_product, i.name })
                  .HasPrincipalKey(i => new { i.id_product, i.name });
            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .HasOne(i => i.Bar)
                  .WithMany(i => i.ProductsInBars)
                  .HasForeignKey(i => i.id_bar)
                  .HasPrincipalKey(i => i.id_bar);
            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .HasOne(i => i.Warehouse)
                  .WithMany(i => i.ProductsInWarehouses)
                  .HasForeignKey(i => i.id_warehouse)
                  .HasPrincipalKey(i => i.id_warehouse);
            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .HasOne(i => i.Product)
                  .WithMany(i => i.ProductsInWarehouses)
                  .HasForeignKey(i => new { i.id_product, i.name })
                  .HasPrincipalKey(i => new { i.id_product, i.name });


            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.date)
                  .HasColumnType("date");

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Bar>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Bar>()
                  .Property(p => p.id_responsible)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Bar>()
                  .Property(p => p.phone_num)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Bar>()
                  .Property(p => p.id_branch)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Branch>()
                  .Property(p => p.id_branch)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Branch>()
                  .Property(p => p.id_responsible)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Branch>()
                  .Property(p => p.phone_num)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .Property(p => p.date)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .Property(p => p.total_received)
                  .HasPrecision(53, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .Property(p => p.total_spend)
                  .HasPrecision(53, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBarBranch>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBranch>()
                  .Property(p => p.date)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBranch>()
                  .Property(p => p.total_received)
                  .HasPrecision(53, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBranch>()
                  .Property(p => p.total_spend)
                  .HasPrecision(53, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.DayBranch>()
                  .Property(p => p.id_branch)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Employee>()
                  .Property(p => p.id_num)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.id_branch)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.id_num)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.id_warehouse)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ListEmployee>()
                  .Property(p => p.cod)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Order>()
                  .Property(p => p.id_order)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Order>()
                  .Property(p => p.total_price)
                  .HasPrecision(53, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Order>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Order>()
                  .Property(p => p.table_number)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Product>()
                  .Property(p => p.id_product)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Product>()
                  .Property(p => p.set_to_unit)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Product>()
                  .Property(p => p.sale_price)
                  .HasPrecision(53, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Product>()
                  .Property(p => p.purchase_price)
                  .HasPrecision(53, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .Property(p => p.id_product)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .Property(p => p.quantity)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .Property(p => p.sale_price)
                  .HasPrecision(53, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .Property(p => p.minimum_quantity)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInBar>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.id_warehouse)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.quantity)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.purchase_price)
                  .HasPrecision(53, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.minimum_quantity)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.total_quantity)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsInWarehouse>()
                  .Property(p => p.id_product)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsOrder>()
                  .Property(p => p.id_order)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsOrder>()
                  .Property(p => p.id_product)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsToRestock>()
                  .Property(p => p.quatity)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsToRestock>()
                  .Property(p => p.id_bar)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsToRestock>()
                  .Property(p => p.id_product)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.ProductsToRestock>()
                  .Property(p => p.id_warehouse)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Schedule>()
                  .Property(p => p.cod)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Schedule>()
                  .Property(p => p.entry_time)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Schedule>()
                  .Property(p => p.exit_time)
                  .HasPrecision(10, 0);

            builder.Entity<WarehouseEmployee.Models.SqlProjectFinal.Warehouse>()
                  .Property(p => p.id_warehouse)
                  .HasPrecision(10, 0);
            this.OnModelBuilding(builder);
        }


        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.Bar> Bars
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.Branch> Branches
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.DayBarBranch> DayBarBranches
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.DayBranch> DayBranches
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.Employee> Employees
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.ListEmployee> ListEmployees
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.Order> Orders
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.Product> Products
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.ProductsInBar> ProductsInBars
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.ProductsInWarehouse> ProductsInWarehouses
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.ProductsOrder> ProductsOrders
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.ProductsToRestock> ProductsToRestocks
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.Schedule> Schedules
        {
          get;
          set;
        }

        public DbSet<WarehouseEmployee.Models.SqlProjectFinal.Warehouse> Warehouses
        {
          get;
          set;
        }
    }
}