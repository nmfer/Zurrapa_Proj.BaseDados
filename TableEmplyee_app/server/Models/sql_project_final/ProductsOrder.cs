using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableEmployee.Models.SqlProjectFinal
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
    public string name
    {
      get;
      set;
    }
  }
}