using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
{
  [Table("Bar", Schema = "dbo")]
  public partial class Bar
  {
    [Key]
    public int id_bar
    {
      get;
      set;
    }

    public IEnumerable<ProductsInBar> ProductsInBars { get; set; }
    public IEnumerable<Order> Orders { get; set; }
    public IEnumerable<DayBarBranch> DayBarBranches { get; set; }
    public int id_branch
    {
      get;
      set;
    }
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
    public int id_responsible
    {
      get;
      set;
    }
  }
}
