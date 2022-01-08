using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminBranch.Models.SqlProjectFinal
{
  [Table("Orders", Schema = "dbo")]
  public partial class Order
  {
    public double total_price
    {
      get;
      set;
    }
    [Key]
    public int id_order
    {
      get;
      set;
    }
    public int id_bar
    {
      get;
      set;
    }
    public Bar Bar { get; set; }
  }
}
