using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableEmployee.Models.SqlProjectFinal
{
  [Table("Products_in_Warehouse", Schema = "dbo")]
  public partial class ProductsInWarehouse
  {
    [Key]
    public int id_warehouse
    {
      get;
      set;
    }

    public Warehouse Warehouse { get; set; }
    public int quantity
    {
      get;
      set;
    }
    public double purchase_price
    {
      get;
      set;
    }
    public int minimum_quantity
    {
      get;
      set;
    }
    public int total_quantity
    {
      get;
      set;
    }
    public int id_product
    {
      get;
      set;
    }

    public Product Product { get; set; }
    public string name
    {
      get;
      set;
    }
  }
}
