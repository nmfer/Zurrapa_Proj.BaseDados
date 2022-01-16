using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using Caixa.Models.SqlProjectFinal;

namespace Caixa.Data
{
  public partial class SqlProjectFinalContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public SqlProjectFinalContext(DbContextOptions<SqlProjectFinalContext> options):base(options)
    {
    }

    public SqlProjectFinalContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Caixa.Models.SqlProjectFinal.EmpWarehouse>().HasNoKey();
        builder.Entity<Caixa.Models.SqlProjectFinal.ListEmployee>().HasNoKey();
        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsOrder>().HasNoKey();
        builder.Entity<Caixa.Models.SqlProjectFinal.RestockBar>().HasNoKey();
        builder.Entity<Caixa.Models.SqlProjectFinal.RestockWarehouse>().HasNoKey();
        builder.Entity<Caixa.Models.SqlProjectFinal.DayBarBranch>()
              .HasOne(i => i.Bar)
              .WithMany(i => i.DayBarBranches)
              .HasForeignKey(i => i.id_bar)
              .HasPrincipalKey(i => i.id_bar);
        builder.Entity<Caixa.Models.SqlProjectFinal.DayBranch>()
              .HasOne(i => i.DayBarBranch)
              .WithMany(i => i.DayBranches)
              .HasForeignKey(i => i.date)
              .HasPrincipalKey(i => i.date);
        builder.Entity<Caixa.Models.SqlProjectFinal.DayBranch>()
              .HasOne(i => i.Branch)
              .WithMany(i => i.DayBranches)
              .HasForeignKey(i => i.id_branch)
              .HasPrincipalKey(i => i.id_branch);
        builder.Entity<Caixa.Models.SqlProjectFinal.Order>()
              .HasOne(i => i.Bar)
              .WithMany(i => i.Orders)
              .HasForeignKey(i => i.id_bar)
              .HasPrincipalKey(i => i.id_bar);
        builder.Entity<Caixa.Models.SqlProjectFinal.Order>()
              .HasOne(i => i.Employee)
              .WithMany(i => i.Orders)
              .HasForeignKey(i => i.id_num)
              .HasPrincipalKey(i => i.id_num);
        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInBar>()
              .HasOne(i => i.Bar)
              .WithMany(i => i.ProductsInBars)
              .HasForeignKey(i => i.id_bar)
              .HasPrincipalKey(i => i.id_bar);
        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInBar>()
              .HasOne(i => i.Product)
              .WithMany(i => i.ProductsInBars)
              .HasForeignKey(i => i.id_product)
              .HasPrincipalKey(i => i.id_product);
        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>()
              .HasOne(i => i.Warehouse)
              .WithMany(i => i.ProductsInWarehouses)
              .HasForeignKey(i => i.id_warehouse)
              .HasPrincipalKey(i => i.id_warehouse);
        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>()
              .HasOne(i => i.Product)
              .WithMany(i => i.ProductsInWarehouses)
              .HasForeignKey(i => i.id_product)
              .HasPrincipalKey(i => i.id_product);


        builder.Entity<Caixa.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.date)
              .HasColumnType("date");

        builder.Entity<Caixa.Models.SqlProjectFinal.Bar>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Bar>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Bar>()
              .Property(p => p.phone_num)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Bar>()
              .Property(p => p.id_responsible)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Branch>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Branch>()
              .Property(p => p.phone_num)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Branch>()
              .Property(p => p.id_manager)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.DayBarBranch>()
              .Property(p => p.date)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.DayBarBranch>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.DayBarBranch>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.DayBarBranch>()
              .Property(p => p.total_received)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.DayBarBranch>()
              .Property(p => p.total_spent)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.DayBranch>()
              .Property(p => p.date)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.DayBranch>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.DayBranch>()
              .Property(p => p.total_received)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.DayBranch>()
              .Property(p => p.total_spent)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.EmpWarehouse>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.EmpWarehouse>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.EmpWarehouse>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Employee>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.id_local)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.cod)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Order>()
              .Property(p => p.id_order)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Order>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Order>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Order>()
              .Property(p => p.table_number)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Order>()
              .Property(p => p.total_price)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Product>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Product>()
              .Property(p => p.set_to_unit)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Product>()
              .Property(p => p.sale_price)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Product>()
              .Property(p => p.purchase_price)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInBar>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInBar>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInBar>()
              .Property(p => p.minimum_quantity)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInBar>()
              .Property(p => p.quantity)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>()
              .Property(p => p.set_to_unit)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>()
              .Property(p => p.minimum_quantity)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>()
              .Property(p => p.quantity)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsInWarehouse>()
              .Property(p => p.total_quantity)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsOrder>()
              .Property(p => p.id_order)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsOrder>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.ProductsOrder>()
              .Property(p => p.sale_price)
              .HasPrecision(53, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.RestockBar>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.RestockBar>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.RestockBar>()
              .Property(p => p.quantity_restock)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.RestockWarehouse>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.RestockWarehouse>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.RestockWarehouse>()
              .Property(p => p.quantity_restock)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Schedule>()
              .Property(p => p.cod)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Schedule>()
              .Property(p => p.entry_time)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Schedule>()
              .Property(p => p.exit_time)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Warehouse>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<Caixa.Models.SqlProjectFinal.Warehouse>()
              .Property(p => p.phone_num)
              .HasPrecision(10, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<Caixa.Models.SqlProjectFinal.Bar> Bars
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.Branch> Branches
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.DayBarBranch> DayBarBranches
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.DayBranch> DayBranches
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.EmpWarehouse> EmpWarehouses
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.Employee> Employees
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.ListEmployee> ListEmployees
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.Order> Orders
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.Product> Products
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.ProductsInBar> ProductsInBars
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.ProductsInWarehouse> ProductsInWarehouses
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.ProductsOrder> ProductsOrders
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.RestockBar> RestockBars
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.RestockWarehouse> RestockWarehouses
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.Schedule> Schedules
    {
      get;
      set;
    }

    public DbSet<Caixa.Models.SqlProjectFinal.Warehouse> Warehouses
    {
      get;
      set;
    }
  }
}
