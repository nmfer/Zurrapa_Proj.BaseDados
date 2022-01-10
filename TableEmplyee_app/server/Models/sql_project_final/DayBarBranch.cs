using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableEmployee.Models.SqlProjectFinal
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

    public DayBranch DayBranch { get; set; }
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
  }
}
