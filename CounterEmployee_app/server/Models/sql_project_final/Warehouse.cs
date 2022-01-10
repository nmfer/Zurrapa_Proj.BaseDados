using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CounterEmployee.Models.SqlProjectFinal
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


    public ICollection<ProductsInWarehouse> ProductsInWarehouses { get; set; }
  }
}
