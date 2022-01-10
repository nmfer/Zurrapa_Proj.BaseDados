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



namespace TableEmployee.Controllers.SqlProjectFinal
{
  using Models;
  using Data;
  using Models.SqlProjectFinal;

  [Route("odata/SqlProjectFinal/ProductsOrders")]
  public partial class ProductsOrdersController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public ProductsOrdersController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/ProductsOrders
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.ProductsOrder> GetProductsOrders()
    {
      var items = this.context.ProductsOrders.AsNoTracking().AsQueryable<Models.SqlProjectFinal.ProductsOrder>();
      this.OnProductsOrdersRead(ref items);

      return items;
    }

    partial void OnProductsOrdersRead(ref IQueryable<Models.SqlProjectFinal.ProductsOrder> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_order}")]
    public SingleResult<ProductsOrder> GetProductsOrder(int key)
    {
        var items = this.context.ProductsOrders.AsNoTracking().Where(i=>i.id_order == key);
        this.OnProductsOrdersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnProductsOrdersGet(ref IQueryable<Models.SqlProjectFinal.ProductsOrder> items);

  }
}
