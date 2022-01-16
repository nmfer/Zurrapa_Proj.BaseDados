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

  [Route("odata/SqlProjectFinal/EmpWarehouses")]
  public partial class EmpWarehousesController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public EmpWarehousesController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/EmpWarehouses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.EmpWarehouse> GetEmpWarehouses()
    {
      var items = this.context.EmpWarehouses.AsNoTracking().AsQueryable<Models.SqlProjectFinal.EmpWarehouse>();
      this.OnEmpWarehousesRead(ref items);

      return items;
    }

    partial void OnEmpWarehousesRead(ref IQueryable<Models.SqlProjectFinal.EmpWarehouse> items);

    partial void OnEmpWarehouseGet(ref SingleResult<Models.SqlProjectFinal.EmpWarehouse> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_warehouse}")]
    public SingleResult<EmpWarehouse> GetEmpWarehouse(int key)
    {
        var items = this.context.EmpWarehouses.AsNoTracking().Where(i=>i.id_warehouse == key);
        var result = SingleResult.Create(items);

        OnEmpWarehouseGet(ref result);

        return result;
    }
  }
}
