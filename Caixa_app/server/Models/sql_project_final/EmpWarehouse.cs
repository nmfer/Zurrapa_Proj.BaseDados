using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
{
  [Table("Emp_Warehouse", Schema = "dbo")]
  public partial class EmpWarehouse
  {
    [Key]
    public int id_warehouse
    {
      get;
      set;
    }
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
  }
}
