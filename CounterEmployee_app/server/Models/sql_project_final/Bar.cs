using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CounterEmployee.Models.SqlProjectFinal
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


    public ICollection<ProductsInBar> ProductsInBars { get; set; }

    public ICollection<Order> Orders { get; set; }

    public ICollection<DayBarBranch> DayBarBranches { get; set; }
    public int id_responsible
    {
      get;
      set;
    }
    public string address
    {
      get;
      set;
    }
    public int phone_num
    {
      get;
      set;
    }
    public int id_branch
    {
      get;
      set;
    }
  }
}
