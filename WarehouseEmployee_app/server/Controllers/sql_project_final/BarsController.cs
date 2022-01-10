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



namespace WarehouseEmployee.Controllers.SqlProjectFinal
{
  using Models;
  using Data;
  using Models.SqlProjectFinal;

  [Route("odata/SqlProjectFinal/Bars")]
  public partial class BarsController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public BarsController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/Bars
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.Bar> GetBars()
    {
      var items = this.context.Bars.AsQueryable<Models.SqlProjectFinal.Bar>();
      this.OnBarsRead(ref items);

      return items;
    }

    partial void OnBarsRead(ref IQueryable<Models.SqlProjectFinal.Bar> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_bar}")]
    public SingleResult<Bar> GetBar(int key)
    {
        var items = this.context.Bars.Where(i=>i.id_bar == key);
        this.OnBarsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnBarsGet(ref IQueryable<Models.SqlProjectFinal.Bar> items);

    partial void OnBarDeleted(Models.SqlProjectFinal.Bar item);

    [HttpDelete("{id_bar}")]
    public IActionResult DeleteBar(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Bars
                .Where(i => i.id_bar == key)
                .Include(i => i.ProductsInBars)
                .Include(i => i.Orders)
                .Include(i => i.DayBarBranches)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnBarDeleted(itemToDelete);
            this.context.Bars.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBarUpdated(Models.SqlProjectFinal.Bar item);

    [HttpPut("{id_bar}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBar(int key, [FromBody]Models.SqlProjectFinal.Bar newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.id_bar != key))
            {
                return BadRequest();
            }

            this.OnBarUpdated(newItem);
            this.context.Bars.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Bars.Where(i => i.id_bar == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{id_bar}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBar(int key, [FromBody]Delta<Models.SqlProjectFinal.Bar> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Bars.Where(i => i.id_bar == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnBarUpdated(itemToUpdate);
            this.context.Bars.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Bars.Where(i => i.id_bar == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBarCreated(Models.SqlProjectFinal.Bar item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.Bar item)
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

            this.OnBarCreated(item);
            this.context.Bars.Add(item);
            this.context.SaveChanges();

            return Created($"odata/SqlProjectFinal/Bars/{item.id_bar}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
