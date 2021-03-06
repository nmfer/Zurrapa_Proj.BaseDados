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

    partial void OnBarGet(ref SingleResult<Models.SqlProjectFinal.Bar> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_bar}")]
    public SingleResult<Bar> GetBar(int key)
    {
        var items = this.context.Bars.Where(i=>i.id_bar == key);
        var result = SingleResult.Create(items);

        OnBarGet(ref result);

        return result;
    }
    partial void OnBarDeleted(Models.SqlProjectFinal.Bar item);
    partial void OnAfterBarDeleted(Models.SqlProjectFinal.Bar item);

    [HttpDelete("{id_bar}")]
    public IActionResult DeleteBar(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Bars
                .Where(i => i.id_bar == key)
                .Include(i => i.ProductsInBars)
                .Include(i => i.Orders)
                .Include(i => i.DayBarBranches)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnBarDeleted(item);
            this.context.Bars.Remove(item);
            this.context.SaveChanges();
            this.OnAfterBarDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBarUpdated(Models.SqlProjectFinal.Bar item);
    partial void OnAfterBarUpdated(Models.SqlProjectFinal.Bar item);

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
            this.OnAfterBarUpdated(newItem);
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

            var item = this.context.Bars.Where(i => i.id_bar == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnBarUpdated(item);
            this.context.Bars.Update(item);
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
    partial void OnAfterBarCreated(Models.SqlProjectFinal.Bar item);

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
