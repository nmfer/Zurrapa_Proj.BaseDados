using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CounterEmployee.Models.SqlProjectFinal
{
  [Table("Products", Schema = "dbo")]
  public partial class Product
  {
    [Key]
    public int id_product
    {
      get;
      set;
    }


    public ICollection<ProductsInBar> ProductsInBars { get; set; }

    public ICollection<ProductsInWarehouse> ProductsInWarehouses { get; set; }
    [Key]
    public string name
    {
      get;
      set;
    }
    public string category
    {
      get;
      set;
    }
    public int set_to_unit
    {
      get;
      set;
    }
    public double sale_price
    {
      get;
      set;
    }
    public double purchase_price
    {
      get;
      set;
    }
  }
}
