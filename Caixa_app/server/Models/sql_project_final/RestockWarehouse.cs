using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
{
  [Table("Restock_Warehouse", Schema = "dbo")]
  public partial class RestockWarehouse
  {
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
    public int quantity_restock
    {
      get;
      set;
    }
    public string restock_status
    {
      get;
      set;
    }
  }
}
