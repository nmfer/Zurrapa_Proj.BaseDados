using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminBranch.Models.SqlProjectFinal
{
  [Table("Warehouse", Schema = "dbo")]
  public partial class Warehouse
  {
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
    public int set_to_unit
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
    [Key]
    public int id_warehouse
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
