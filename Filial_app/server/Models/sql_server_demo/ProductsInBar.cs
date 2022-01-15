using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filial.Models.SqlServerDemo
{
  [Table("Products_in_bar", Schema = "dbo")]
  public partial class ProductsInBar
  {
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
    public double minimum_quantity
    {
      get;
      set;
    }
    public double quantity
    {
      get;
      set;
    }
  }
}
