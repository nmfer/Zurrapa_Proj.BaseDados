using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filial.Models.SqlServerDemo
{
  [Table("Schedule", Schema = "dbo")]
  public partial class Schedule
  {
    [Key]
    public int cod
    {
      get;
      set;
    }
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
  }
}
