using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminBranch.Models.SqlProjectFinal
{
  [Table("List_Employees", Schema = "dbo")]
  public partial class ListEmployee
  {
    public DateTime date
    {
      get;
      set;
    }
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
    public int id_num
    {
      get;
      set;
    }
    public int id_warehouse
    {
      get;
      set;
    }
    public int cod
    {
      get;
      set;
    }
  }
}
