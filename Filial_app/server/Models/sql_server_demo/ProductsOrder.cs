using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filial.Models.SqlServerDemo
{
  [Table("Products_order", Schema = "dbo")]
  public partial class ProductsOrder
  {
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
