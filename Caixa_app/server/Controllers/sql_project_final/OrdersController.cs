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

    partial void OnOrderGet(ref SingleResult<Models.SqlProjectFinal.Order> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_order}")]
    public SingleResult<Order> GetOrder(int key)
    {
        var items = this.context.Orders.Where(i=>i.id_order == key);
        var result = SingleResult.Create(items);

        OnOrderGet(ref result);

        return result;
    }
    partial void OnOrderDeleted(Models.SqlProjectFinal.Order item);
    partial void OnAfterOrderDeleted(Models.SqlProjectFinal.Order item);

    [HttpDelete("{id_order}")]
    public IActionResult DeleteOrder(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Orders
                .Where(i => i.id_order == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnOrderDeleted(item);
            this.context.Orders.Remove(item);
            this.context.SaveChanges();
            this.OnAfterOrderDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnOrderUpdated(Models.SqlProjectFinal.Order item);
    partial void OnAfterOrderUpdated(Models.SqlProjectFinal.Order item);

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
            Request.QueryString = Request.QueryString.Add("$expand", "Bar,Employee");
            this.OnAfterOrderUpdated(newItem);
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

            var item = this.context.Orders.Where(i => i.id_order == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnOrderUpdated(item);
            this.context.Orders.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Orders.Where(i => i.id_order == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Bar,Employee");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnOrderCreated(Models.SqlProjectFinal.Order item);
    partial void OnAfterOrderCreated(Models.SqlProjectFinal.Order item);

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

            Request.QueryString = Request.QueryString.Add("$expand", "Bar,Employee");

            this.OnAfterOrderCreated(item);

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
