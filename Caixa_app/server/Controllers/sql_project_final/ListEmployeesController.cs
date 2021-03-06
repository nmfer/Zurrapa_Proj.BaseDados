using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;




namespace Caixa.Controllers.SqlProjectFinal
{
  using Models;
  using Data;
  using Models.SqlProjectFinal;

  [Route("odata/SqlProjectFinal/ListEmployees")]
  public partial class ListEmployeesController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public ListEmployeesController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/ListEmployees
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.ListEmployee> GetListEmployees()
    {
      var items = this.context.ListEmployees.AsNoTracking().AsQueryable<Models.SqlProjectFinal.ListEmployee>();
      this.OnListEmployeesRead(ref items);

      return items;
    }

    partial void OnListEmployeesRead(ref IQueryable<Models.SqlProjectFinal.ListEmployee> items);

    partial void OnListEmployeeGet(ref SingleResult<Models.SqlProjectFinal.ListEmployee> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_num}")]
    public SingleResult<ListEmployee> GetListEmployee(int key)
    {
        var items = this.context.ListEmployees.AsNoTracking().Where(i=>i.id_num == key);
        var result = SingleResult.Create(items);

        OnListEmployeeGet(ref result);

        return result;
    }
  }
}
