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

  [Route("odata/SqlProjectFinal/Orders")]
  public partial class OrdersController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public OrdersController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/Orders
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.Order> GetOrders()
    {
      var items = this.context.Orders.AsQueryable<Models.SqlProjectFinal.Order>();
      this.OnOrdersRead(ref items);

      return items;
    }

    partial void OnOrdersRead(ref IQueryable<Models.SqlProjectFinal.Order> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_order}")]
    public SingleResult<Order> GetOrder(int key)
    {
        var items = this.context.Orders.Where(i=>i.id_order == key);
        this.OnOrdersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnOrdersGet(ref IQueryable<Models.SqlProjectFinal.Order> items);

    partial void OnOrderDeleted(Models.SqlProjectFinal.Order item);

    [HttpDelete("{id_order}")]
    public IActionResult DeleteOrder(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Orders
                .Where(i => i.id_order == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnOrderDeleted(itemToDelete);
            this.context.Orders.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnOrderUpdated(Models.SqlProjectFinal.Order item);

    [HttpPut("{id_order}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutOrder(int key, [FromBody]Models.SqlProjectFinal.Order newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.id_order != key))
            {
                return BadRequest();
            }

            this.OnOrderUpdated(newItem);
            this.context.Orders.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Orders.Where(i => i.id_order == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Bar");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{id_order}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchOrder(int key, [FromBody]Delta<Models.SqlProjectFinal.Order> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Orders.Where(i => i.id_order == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnOrderUpdated(itemToUpdate);
            this.context.Orders.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Orders.Where(i => i.id_order == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Bar");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnOrderCreated(Models.SqlProjectFinal.Order item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.Order item)
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

            this.OnOrderCreated(item);
            this.context.Orders.Add(item);
            this.context.SaveChanges();

            var key = item.id_order;

            var itemToReturn = this.context.Orders.Where(i => i.id_order == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Bar");

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
