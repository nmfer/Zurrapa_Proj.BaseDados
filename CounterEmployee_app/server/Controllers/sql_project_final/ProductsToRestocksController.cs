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



namespace CounterEmployee.Controllers.SqlProjectFinal
{
  using Models;
  using Data;
  using Models.SqlProjectFinal;

  [Route("odata/SqlProjectFinal/ProductsToRestocks")]
  public partial class ProductsToRestocksController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public ProductsToRestocksController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/ProductsToRestocks
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.ProductsToRestock> GetProductsToRestocks()
    {
      var items = this.context.ProductsToRestocks.AsNoTracking().AsQueryable<Models.SqlProjectFinal.ProductsToRestock>();
      this.OnProductsToRestocksRead(ref items);

      return items;
    }

    partial void OnProductsToRestocksRead(ref IQueryable<Models.SqlProjectFinal.ProductsToRestock> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{restock_status}")]
    public SingleResult<ProductsToRestock> GetProductsToRestock(string key)
    {
        var items = this.context.ProductsToRestocks.AsNoTracking().Where(i=>i.restock_status == key);
        this.OnProductsToRestocksGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnProductsToRestocksGet(ref IQueryable<Models.SqlProjectFinal.ProductsToRestock> items);

  }
}
