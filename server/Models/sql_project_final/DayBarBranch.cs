using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminBranch.Models.SqlProjectFinal
{
  [Table("Day_Bar_Branch", Schema = "dbo")]
  public partial class DayBarBranch
  {
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
    public int id_bar
    {
      get;
      set;
    }
    public Bar Bar { get; set; }
    [Key]
    public int date
    {
      get;
      set;
    }
    public DayBranch DayBranch { get; set; }
  }
}
