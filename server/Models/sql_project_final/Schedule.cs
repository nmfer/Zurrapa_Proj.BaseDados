using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminBranch.Models.SqlProjectFinal
{
  [Table("Schedule", Schema = "dbo")]
  public partial class Schedule
  {
    public int entry_time
    {
      get;
      set;
    }
    public int exit_time
    {
      get;
      set;
    }
    [Key]
    public int cod
    {
      get;
      set;
    }
  }
}
