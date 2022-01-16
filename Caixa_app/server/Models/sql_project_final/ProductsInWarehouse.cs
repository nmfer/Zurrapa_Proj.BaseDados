using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
{
  [Table("Products_in_Warehouse", Schema = "dbo")]
  public partial class ProductsInWarehouse
  {
    [Key]
    public int id_warehouse
    {
      get;
      set;
    }
    public Warehouse Warehouse { get; set; }
    public int id_product
    {
      get;
      set;
    }
    public Product Product { get; set; }
    public int set_to_unit
    {
      get;
      set;
    }
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double total_quantity
    {
      get;
      set;
    }
  }
}
