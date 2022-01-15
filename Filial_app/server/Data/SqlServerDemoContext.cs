using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using Filial.Models.SqlServerDemo;

namespace Filial.Data
{
  public partial class SqlServerDemoContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public SqlServerDemoContext(DbContextOptions<SqlServerDemoContext> options):base(options)
    {
    }

    public SqlServerDemoContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Filial.Models.SqlServerDemo.EmpWarehouse>().HasNoKey();
        builder.Entity<Filial.Models.SqlServerDemo.ListEmployee>().HasNoKey();
        builder.Entity<Filial.Models.SqlServerDemo.ProductsOrder>().HasNoKey();
        builder.Entity<Filial.Models.SqlServerDemo.RestockBar>().HasNoKey();
        builder.Entity<Filial.Models.SqlServerDemo.RestockWarehouse>().HasNoKey();
        builder.Entity<Filial.Models.SqlServerDemo.DayBarBranch>()
              .HasOne(i => i.Bar)
              .WithMany(i => i.DayBarBranches)
              .HasForeignKey(i => i.id_bar)
              .HasPrincipalKey(i => i.id_bar);
        builder.Entity<Filial.Models.SqlServerDemo.DayBranch>()
              .HasOne(i => i.DayBarBranch)
              .WithMany(i => i.DayBranches)
              .HasForeignKey(i => i.date)
              .HasPrincipalKey(i => i.date);
        builder.Entity<Filial.Models.SqlServerDemo.DayBranch>()
              .HasOne(i => i.Branch)
              .WithMany(i => i.DayBranches)
              .HasForeignKey(i => i.id_branch)
              .HasPrincipalKey(i => i.id_branch);
        builder.Entity<Filial.Models.SqlServerDemo.Order>()
              .HasOne(i => i.Bar)
              .WithMany(i => i.Orders)
              .HasForeignKey(i => i.id_bar)
              .HasPrincipalKey(i => i.id_bar);
        builder.Entity<Filial.Models.SqlServerDemo.Order>()
              .HasOne(i => i.Employee)
              .WithMany(i => i.Orders)
              .HasForeignKey(i => i.id_num)
              .HasPrincipalKey(i => i.id_num);
        builder.Entity<Filial.Models.SqlServerDemo.ProductsInBar>()
              .HasOne(i => i.Bar)
              .WithMany(i => i.ProductsInBars)
              .HasForeignKey(i => i.id_bar)
              .HasPrincipalKey(i => i.id_bar);
        builder.Entity<Filial.Models.SqlServerDemo.ProductsInBar>()
              .HasOne(i => i.Product)
              .WithMany(i => i.ProductsInBars)
              .HasForeignKey(i => i.id_product)
              .HasPrincipalKey(i => i.id_product);
        builder.Entity<Filial.Models.SqlServerDemo.ProductsInWarehouse>()
              .HasOne(i => i.Warehouse)
              .WithMany(i => i.ProductsInWarehouses)
              .HasForeignKey(i => i.id_warehouse)
              .HasPrincipalKey(i => i.id_warehouse);
        builder.Entity<Filial.Models.SqlServerDemo.ProductsInWarehouse>()
              .HasOne(i => i.Product)
              .WithMany(i => i.ProductsInWarehouses)
              .HasForeignKey(i => i.id_product)
              .HasPrincipalKey(i => i.id_product);


        builder.Entity<Filial.Models.SqlServerDemo.ListEmployee>()
              .Property(p => p.date)
              .HasColumnType("date");

        builder.Entity<Filial.Models.SqlServerDemo.Bar>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Bar>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Bar>()
              .Property(p => p.phone_num)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Bar>()
              .Property(p => p.id_responsible)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Branch>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Branch>()
              .Property(p => p.phone_num)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Branch>()
              .Property(p => p.id_manager)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.DayBarBranch>()
              .Property(p => p.date)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.DayBarBranch>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.DayBarBranch>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.DayBarBranch>()
              .Property(p => p.total_received)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.DayBarBranch>()
              .Property(p => p.total_spent)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.DayBranch>()
              .Property(p => p.date)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.DayBranch>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.DayBranch>()
              .Property(p => p.total_received)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.DayBranch>()
              .Property(p => p.total_spent)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.EmpWarehouse>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.EmpWarehouse>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.EmpWarehouse>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Employee>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ListEmployee>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ListEmployee>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ListEmployee>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ListEmployee>()
              .Property(p => p.id_local)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ListEmployee>()
              .Property(p => p.cod)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Order>()
              .Property(p => p.id_order)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Order>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Order>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Order>()
              .Property(p => p.table_number)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Order>()
              .Property(p => p.total_price)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Product>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Product>()
              .Property(p => p.set_to_unit)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Product>()
              .Property(p => p.sale_price)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Product>()
              .Property(p => p.purchase_price)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsInBar>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsInBar>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsInBar>()
              .Property(p => p.minimum_quantity)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsInBar>()
              .Property(p => p.quantity)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsInWarehouse>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsInWarehouse>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsInWarehouse>()
              .Property(p => p.set_to_unit)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsInWarehouse>()
              .Property(p => p.minimum_quantity)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsInWarehouse>()
              .Property(p => p.quantity)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsInWarehouse>()
              .Property(p => p.total_quantity)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsOrder>()
              .Property(p => p.id_order)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsOrder>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.ProductsOrder>()
              .Property(p => p.sale_price)
              .HasPrecision(53, 0);

        builder.Entity<Filial.Models.SqlServerDemo.RestockBar>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.RestockBar>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.RestockBar>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.RestockBar>()
              .Property(p => p.quantity_restock)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.RestockWarehouse>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.RestockWarehouse>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.RestockWarehouse>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.RestockWarehouse>()
              .Property(p => p.quantity_restock)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Schedule>()
              .Property(p => p.cod)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Schedule>()
              .Property(p => p.entry_time)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Schedule>()
              .Property(p => p.exit_time)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Warehouse>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<Filial.Models.SqlServerDemo.Warehouse>()
              .Property(p => p.phone_num)
              .HasPrecision(10, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<Filial.Models.SqlServerDemo.Bar> Bars
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.Branch> Branches
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.DayBarBranch> DayBarBranches
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.DayBranch> DayBranches
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.EmpWarehouse> EmpWarehouses
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.Employee> Employees
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.ListEmployee> ListEmployees
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.Order> Orders
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.Product> Products
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.ProductsInBar> ProductsInBars
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.ProductsInWarehouse> ProductsInWarehouses
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.ProductsOrder> ProductsOrders
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.RestockBar> RestockBars
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.RestockWarehouse> RestockWarehouses
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.Schedule> Schedules
    {
      get;
      set;
    }

    public DbSet<Filial.Models.SqlServerDemo.Warehouse> Warehouses
    {
      get;
      set;
    }
  }
}
