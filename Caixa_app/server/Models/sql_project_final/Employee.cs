using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixa.Models.SqlProjectFinal
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

    public IEnumerable<Order> Orders { get; set; }
    public string name
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
    public string emp_warehouse
    {
      get;
      set;
    }
  }
}
