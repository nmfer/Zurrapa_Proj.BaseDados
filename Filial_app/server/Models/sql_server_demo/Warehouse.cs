using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filial.Models.SqlServerDemo
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
