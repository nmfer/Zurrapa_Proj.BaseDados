using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
{
  [Table("Products_order", Schema = "dbo")]
  public partial class ProductsOrder
  {
    [Key]
    public int id_order
    {
      get;
      set;
    }
    public int id_product
    {
      get;
      set;
    }
    public double sale_price
    {
      get;
      set;
    }
  }
}
