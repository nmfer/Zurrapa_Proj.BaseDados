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

  [Route("odata/SqlProjectFinal/RestockWarehouses")]
  public partial class RestockWarehousesController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public RestockWarehousesController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/RestockWarehouses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.RestockWarehouse> GetRestockWarehouses()
    {
      var items = this.context.RestockWarehouses.AsNoTracking().AsQueryable<Models.SqlProjectFinal.RestockWarehouse>();
      this.OnRestockWarehousesRead(ref items);

      return items;
    }

    partial void OnRestockWarehousesRead(ref IQueryable<Models.SqlProjectFinal.RestockWarehouse> items);

    partial void OnRestockWarehouseGet(ref SingleResult<Models.SqlProjectFinal.RestockWarehouse> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_warehouse}")]
    public SingleResult<RestockWarehouse> GetRestockWarehouse(int key)
    {
        var items = this.context.RestockWarehouses.AsNoTracking().Where(i=>i.id_warehouse == key);
        var result = SingleResult.Create(items);

        OnRestockWarehouseGet(ref result);

        return result;
    }
  }
}
