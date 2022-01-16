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

  [Route("odata/SqlProjectFinal/RestockBars")]
  public partial class RestockBarsController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public RestockBarsController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/RestockBars
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.RestockBar> GetRestockBars()
    {
      var items = this.context.RestockBars.AsNoTracking().AsQueryable<Models.SqlProjectFinal.RestockBar>();
      this.OnRestockBarsRead(ref items);

      return items;
    }

    partial void OnRestockBarsRead(ref IQueryable<Models.SqlProjectFinal.RestockBar> items);

    partial void OnRestockBarGet(ref SingleResult<Models.SqlProjectFinal.RestockBar> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_bar}")]
    public SingleResult<RestockBar> GetRestockBar(int key)
    {
        var items = this.context.RestockBars.AsNoTracking().Where(i=>i.id_bar == key);
        var result = SingleResult.Create(items);

        OnRestockBarGet(ref result);

        return result;
    }
  }
}
