using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filial.Models.SqlServerDemo
{
  [Table("Day_Bar_Branch", Schema = "dbo")]
  public partial class DayBarBranch
  {
    [Key]
    public int date
    {
      get;
      set;
    }

    public ICollection<DayBranch> DayBranches { get; set; }
    public int id_branch
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
    public double total_received
    {
      get;
      set;
    }
    public double total_spent
    {
      get;
      set;
    }
  }
}
