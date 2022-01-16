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

  [Route("odata/SqlProjectFinal/Warehouses")]
  public partial class WarehousesController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public WarehousesController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/Warehouses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.Warehouse> GetWarehouses()
    {
      var items = this.context.Warehouses.AsQueryable<Models.SqlProjectFinal.Warehouse>();
      this.OnWarehousesRead(ref items);

      return items;
    }

    partial void OnWarehousesRead(ref IQueryable<Models.SqlProjectFinal.Warehouse> items);

    partial void OnWarehouseGet(ref SingleResult<Models.SqlProjectFinal.Warehouse> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_warehouse}")]
    public SingleResult<Warehouse> GetWarehouse(int key)
    {
        var items = this.context.Warehouses.Where(i=>i.id_warehouse == key);
        var result = SingleResult.Create(items);

        OnWarehouseGet(ref result);

        return result;
    }
    partial void OnWarehouseDeleted(Models.SqlProjectFinal.Warehouse item);
    partial void OnAfterWarehouseDeleted(Models.SqlProjectFinal.Warehouse item);

    [HttpDelete("{id_warehouse}")]
    public IActionResult DeleteWarehouse(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Warehouses
                .Where(i => i.id_warehouse == key)
                .Include(i => i.ProductsInWarehouses)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnWarehouseDeleted(item);
            this.context.Warehouses.Remove(item);
            this.context.SaveChanges();
            this.OnAfterWarehouseDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnWarehouseUpdated(Models.SqlProjectFinal.Warehouse item);
    partial void OnAfterWarehouseUpdated(Models.SqlProjectFinal.Warehouse item);

    [HttpPut("{id_warehouse}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutWarehouse(int key, [FromBody]Models.SqlProjectFinal.Warehouse newItem)
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

            this.OnWarehouseUpdated(newItem);
            this.context.Warehouses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Warehouses.Where(i => i.id_warehouse == key);
            this.OnAfterWarehouseUpdated(newItem);
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
    public IActionResult PatchWarehouse(int key, [FromBody]Delta<Models.SqlProjectFinal.Warehouse> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Warehouses.Where(i => i.id_warehouse == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnWarehouseUpdated(item);
            this.context.Warehouses.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Warehouses.Where(i => i.id_warehouse == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnWarehouseCreated(Models.SqlProjectFinal.Warehouse item);
    partial void OnAfterWarehouseCreated(Models.SqlProjectFinal.Warehouse item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.Warehouse item)
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

            this.OnWarehouseCreated(item);
            this.context.Warehouses.Add(item);
            this.context.SaveChanges();

            return Created($"odata/SqlProjectFinal/Warehouses/{item.id_warehouse}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
