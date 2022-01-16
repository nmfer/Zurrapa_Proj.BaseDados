using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
{
  [Table("Branch", Schema = "dbo")]
  public partial class Branch
  {
    [Key]
    public int id_branch
    {
      get;
      set;
    }

    public IEnumerable<DayBranch> DayBranches { get; set; }
    public string designation
    {
      get;
      set;
    }
    public string email
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
    public int id_manager
    {
      get;
      set;
    }
  }
}
