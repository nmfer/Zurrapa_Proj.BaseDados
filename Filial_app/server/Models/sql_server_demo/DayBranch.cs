using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filial.Models.SqlServerDemo
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
    public DayBarBranch DayBarBranch { get; set; }
    public int id_branch
    {
      get;
      set;
    }
    public Branch Branch { get; set; }
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
