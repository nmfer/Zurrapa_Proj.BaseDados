using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CounterEmployee.Models.SqlProjectFinal
{
  [Table("Day_Branch", Schema = "dbo")]
  public partial class DayBranch
  {
    [Key]
    public int date
    {
      get;
      set;
    }


    public ICollection<DayBarBranch> DayBarBranches { get; set; }
    public double total_received
    {
      get;
      set;
    }
    public double total_spend
    {
      get;
      set;
    }
    public int id_branch
    {
      get;
      set;
    }

    public Branch Branch { get; set; }
  }
}
