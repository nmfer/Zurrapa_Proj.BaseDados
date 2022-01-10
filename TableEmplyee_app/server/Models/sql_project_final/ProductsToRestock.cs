using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableEmployee.Models.SqlProjectFinal
{
  [Table("Products_to_restock", Schema = "dbo")]
  public partial class ProductsToRestock
  {
    [Key]
    public string restock_status
    {
      get;
      set;
    }
    public int quatity
    {
      get;
      set;
    }
    public int id_bar
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
    public int id_warehouse
    {
      get;
      set;
    }
  }
}
