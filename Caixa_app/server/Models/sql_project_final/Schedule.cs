using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
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
