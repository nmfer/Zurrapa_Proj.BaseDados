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

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_warehouse}")]
    public SingleResult<Warehouse> GetWarehouse(int key)
    {
        var items = this.context.Warehouses.Where(i=>i.id_warehouse == key);
        this.OnWarehousesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnWarehousesGet(ref IQueryable<Models.SqlProjectFinal.Warehouse> items);

    partial void OnWarehouseDeleted(Models.SqlProjectFinal.Warehouse item);

    [HttpDelete("{id_warehouse}")]
    public IActionResult DeleteWarehouse(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Warehouses
                .Where(i => i.id_warehouse == key)
                .Include(i => i.ProductsInWarehouses)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnWarehouseDeleted(itemToDelete);
            this.context.Warehouses.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnWarehouseUpdated(Models.SqlProjectFinal.Warehouse item);

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

            var itemToUpdate = this.context.Warehouses.Where(i => i.id_warehouse == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnWarehouseUpdated(itemToUpdate);
            this.context.Warehouses.Update(itemToUpdate);
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
