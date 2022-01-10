using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseEmployee.Models.SqlProjectFinal
{
  [Table("Employee", Schema = "dbo")]
  public partial class Employee
  {
    [Key]
    public int id_num
    {
      get;
      set;
    }
    public string type
    {
      get;
      set;
    }
    public string pwd
    {
      get;
      set;
    }
  }
}
