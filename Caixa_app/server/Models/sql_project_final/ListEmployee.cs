using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
{
  [Table("List_Employees", Schema = "dbo")]
  public partial class ListEmployee
  {
    [Key]
    public int id_num
    {
      get;
      set;
    }
    public int id_bar
    {
      get;
      set;
    }
    public int id_branch
    {
      get;
      set;
    }
    public int id_local
    {
      get;
      set;
    }
    public string responsible
    {
      get;
      set;
    }
    public DateTime date
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
