using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filial.Models.SqlServerDemo
{
  [Table("Orders", Schema = "dbo")]
  public partial class Order
  {
    [Key]
    public int id_order
    {
      get;
      set;
    }
    public int id_bar
    {
      get;
      set;
    }
    public Bar Bar { get; set; }
    public int id_num
    {
      get;
      set;
    }
    public Employee Employee { get; set; }
    public int table_number
    {
      get;
      set;
    }
    public double total_price
    {
      get;
      set;
    }
    public string order_status
    {
      get;
      set;
    }
  }
}
