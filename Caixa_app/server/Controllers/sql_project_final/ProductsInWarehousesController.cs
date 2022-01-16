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

  [Route("odata/SqlProjectFinal/ProductsInWarehouses")]
  public partial class ProductsInWarehousesController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public ProductsInWarehousesController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/ProductsInWarehouses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.ProductsInWarehouse> GetProductsInWarehouses()
    {
      var items = this.context.ProductsInWarehouses.AsQueryable<Models.SqlProjectFinal.ProductsInWarehouse>();
      this.OnProductsInWarehousesRead(ref items);

      return items;
    }

    partial void OnProductsInWarehousesRead(ref IQueryable<Models.SqlProjectFinal.ProductsInWarehouse> items);

    partial void OnProductsInWarehouseGet(ref SingleResult<Models.SqlProjectFinal.ProductsInWarehouse> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_warehouse}")]
    public SingleResult<ProductsInWarehouse> GetProductsInWarehouse(int key)
    {
        var items = this.context.ProductsInWarehouses.Where(i=>i.id_warehouse == key);
        var result = SingleResult.Create(items);

        OnProductsInWarehouseGet(ref result);

        return result;
    }
    partial void OnProductsInWarehouseDeleted(Models.SqlProjectFinal.ProductsInWarehouse item);
    partial void OnAfterProductsInWarehouseDeleted(Models.SqlProjectFinal.ProductsInWarehouse item);

    [HttpDelete("{id_warehouse}")]
    public IActionResult DeleteProductsInWarehouse(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.ProductsInWarehouses
                .Where(i => i.id_warehouse == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnProductsInWarehouseDeleted(item);
            this.context.ProductsInWarehouses.Remove(item);
            this.context.SaveChanges();
            this.OnAfterProductsInWarehouseDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProductsInWarehouseUpdated(Models.SqlProjectFinal.ProductsInWarehouse item);
    partial void OnAfterProductsInWarehouseUpdated(Models.SqlProjectFinal.ProductsInWarehouse item);

    [HttpPut("{id_warehouse}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutProductsInWarehouse(int key, [FromBody]Models.SqlProjectFinal.ProductsInWarehouse newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.id_warehouse != key))
            {
                return BadRequest();
            }

            this.OnProductsInWarehouseUpdated(newItem);
            this.context.ProductsInWarehouses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.ProductsInWarehouses.Where(i => i.id_warehouse == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Warehouse,Product");
            this.OnAfterProductsInWarehouseUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{id_warehouse}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchProductsInWarehouse(int key, [FromBody]Delta<Models.SqlProjectFinal.ProductsInWarehouse> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.ProductsInWarehouses.Where(i => i.id_warehouse == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnProductsInWarehouseUpdated(item);
            this.context.ProductsInWarehouses.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.ProductsInWarehouses.Where(i => i.id_warehouse == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Warehouse,Product");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProductsInWarehouseCreated(Models.SqlProjectFinal.ProductsInWarehouse item);
    partial void OnAfterProductsInWarehouseCreated(Models.SqlProjectFinal.ProductsInWarehouse item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.ProductsInWarehouse item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnProductsInWarehouseCreated(item);
            this.context.ProductsInWarehouses.Add(item);
            this.context.SaveChanges();

            var key = item.id_warehouse;

            var itemToReturn = this.context.ProductsInWarehouses.Where(i => i.id_warehouse == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Warehouse,Product");

            this.OnAfterProductsInWarehouseCreated(item);

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
