using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filial.Models.SqlServerDemo
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
    public int id_manager
    {
      get;
      set;
    }
  }
}
