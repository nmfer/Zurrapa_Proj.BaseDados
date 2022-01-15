using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filial.Models.SqlServerDemo
{
  [Table("Restock_Bar", Schema = "dbo")]
  public partial class RestockBar
  {
    public int id_bar
    {
      get;
      set;
    }
    public int id_product
    {
      get;
      set;
    }
    public int id_num
    {
      get;
      set;
    }
    public int quantity_restock
    {
      get;
      set;
    }
    public string restock_status
    {
      get;
      set;
    }
  }
}
