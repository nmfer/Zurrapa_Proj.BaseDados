using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using AdminBranch.Models.SqlProjectFinal;

namespace AdminBranch.Data
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

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ListEmployee>().HasNoKey();
        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsOrder>().HasNoKey();
        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsToRestock>().HasNoKey();
        builder.Entity<AdminBranch.Models.SqlProjectFinal.Product>().HasKey(table => new {
          table.id_product, table.name
        });
        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsInBar>().HasKey(table => new {
          table.id_product, table.name
        });
        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBarBranch>()
              .HasOne(i => i.Bar)
              .WithMany(i => i.DayBarBranches)
              .HasForeignKey(i => i.id_bar)
              .HasPrincipalKey(i => i.id_bar);
        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBarBranch>()
              .HasOne(i => i.DayBranch)
              .WithMany(i => i.DayBarBranches)
              .HasForeignKey(i => i.date)
              .HasPrincipalKey(i => i.date);
        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBranch>()
              .HasOne(i => i.Branch)
              .WithMany(i => i.DayBranches)
              .HasForeignKey(i => i.id_branch)
              .HasPrincipalKey(i => i.id_branch);
        builder.Entity<AdminBranch.Models.SqlProjectFinal.Order>()
              .HasOne(i => i.Bar)
              .WithMany(i => i.Orders)
              .HasForeignKey(i => i.id_bar)
              .HasPrincipalKey(i => i.id_bar);
        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsInBar>()
              .HasOne(i => i.Bar)
              .WithMany(i => i.ProductsInBars)
              .HasForeignKey(i => i.id_bar)
              .HasPrincipalKey(i => i.id_bar);
        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsInBar>()
              .HasOne(i => i.Product)
              .WithMany(i => i.ProductsInBars)
              .HasForeignKey(i => new { i.id_product, i.name })
              .HasPrincipalKey(i => new { i.id_product, i.name });
        builder.Entity<AdminBranch.Models.SqlProjectFinal.Warehouse>()
              .HasOne(i => i.Product)
              .WithMany(i => i.Warehouses)
              .HasForeignKey(i => new { i.id_product, i.name })
              .HasPrincipalKey(i => new { i.id_product, i.name });


        builder.Entity<AdminBranch.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.date)
              .HasColumnType("date");

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Bar>()
              .Property(p => p.id_responsible)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Bar>()
              .Property(p => p.phone_num)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Bar>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Branch>()
              .Property(p => p.id_responsible)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Branch>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Branch>()
              .Property(p => p.phone_num)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBarBranch>()
              .Property(p => p.total_received)
              .HasPrecision(53, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBarBranch>()
              .Property(p => p.total_spend)
              .HasPrecision(53, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBarBranch>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBarBranch>()
              .Property(p => p.date)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBranch>()
              .Property(p => p.date)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBranch>()
              .Property(p => p.total_received)
              .HasPrecision(53, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBranch>()
              .Property(p => p.total_spend)
              .HasPrecision(53, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.DayBranch>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Employee>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.id_branch)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.id_num)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ListEmployee>()
              .Property(p => p.cod)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Order>()
              .Property(p => p.total_price)
              .HasPrecision(53, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Order>()
              .Property(p => p.id_order)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Order>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Product>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsInBar>()
              .Property(p => p.quantity)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsInBar>()
              .Property(p => p.sale_price)
              .HasPrecision(53, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsInBar>()
              .Property(p => p.minimum_quantity)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsInBar>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsInBar>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsOrder>()
              .Property(p => p.id_order)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsOrder>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsToRestock>()
              .Property(p => p.quatity)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsToRestock>()
              .Property(p => p.id_bar)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsToRestock>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.ProductsToRestock>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Schedule>()
              .Property(p => p.entry_time)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Schedule>()
              .Property(p => p.exit_time)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Schedule>()
              .Property(p => p.cod)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Warehouse>()
              .Property(p => p.quantity)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Warehouse>()
              .Property(p => p.purchase_price)
              .HasPrecision(53, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Warehouse>()
              .Property(p => p.set_to_unit)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Warehouse>()
              .Property(p => p.minimum_quantity)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Warehouse>()
              .Property(p => p.total_quantity)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Warehouse>()
              .Property(p => p.id_warehouse)
              .HasPrecision(10, 0);

        builder.Entity<AdminBranch.Models.SqlProjectFinal.Warehouse>()
              .Property(p => p.id_product)
              .HasPrecision(10, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<AdminBranch.Models.SqlProjectFinal.Bar> Bars
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.Branch> Branches
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.DayBarBranch> DayBarBranches
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.DayBranch> DayBranches
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.Employee> Employees
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.ListEmployee> ListEmployees
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.Order> Orders
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.Product> Products
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.ProductsInBar> ProductsInBars
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.ProductsOrder> ProductsOrders
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.ProductsToRestock> ProductsToRestocks
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.Schedule> Schedules
    {
      get;
      set;
    }

    public DbSet<AdminBranch.Models.SqlProjectFinal.Warehouse> Warehouses
    {
      get;
      set;
    }
  }
}
