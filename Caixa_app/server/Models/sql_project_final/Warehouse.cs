using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
{
  [Table("Warehouse", Schema = "dbo")]
  public partial class Warehouse
  {
    [Key]
    public int id_warehouse
    {
      get;
      set;
    }

    public IEnumerable<ProductsInWarehouse> ProductsInWarehouses { get; set; }
    public int phone_num
    {
      get;
      set;
    }
    public string address
    {
      get;
      set;
    }
  }
}
