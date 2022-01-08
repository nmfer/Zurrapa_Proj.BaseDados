using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminBranch.Models.SqlProjectFinal
{
  [Table("Products_in_bar", Schema = "dbo")]
  public partial class ProductsInBar
  {
    public int quantity
    {
      get;
      set;
    }
    public double sale_price
    {
      get;
      set;
    }
    public int minimum_quantity
    {
      get;
      set;
    }
    public int id_bar
    {
      get;
      set;
    }
    public Bar Bar { get; set; }
    [Key]
    public int id_product
    {
      get;
      set;
    }
    public Product Product { get; set; }
    [Key]
    public string name
    {
      get;
      set;
    }
  }
}
