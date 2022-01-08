using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminBranch.Models.SqlProjectFinal
{
  [Table("Branch", Schema = "dbo")]
  public partial class Branch
  {
    public int id_responsible
    {
      get;
      set;
    }
    [Key]
    public int id_branch
    {
      get;
      set;
    }

    public ICollection<DayBranch> DayBranches { get; set; }
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
  }
}
