using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filial.Models.SqlServerDemo
{
  [Table("Emp_Warehouse", Schema = "dbo")]
  public partial class EmpWarehouse
  {
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
