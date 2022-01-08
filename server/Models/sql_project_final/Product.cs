using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminBranch.Models.SqlProjectFinal
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

    public ICollection<ProductsInBar> ProductsInBars { get; set; }
    public ICollection<Warehouse> Warehouses { get; set; }
    [Key]
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
  }
}
