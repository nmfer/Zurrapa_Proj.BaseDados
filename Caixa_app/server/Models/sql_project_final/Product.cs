using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
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

    public IEnumerable<ProductsInWarehouse> ProductsInWarehouses { get; set; }
    public IEnumerable<ProductsInBar> ProductsInBars { get; set; }
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
