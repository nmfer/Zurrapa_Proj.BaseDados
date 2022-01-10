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

  [Route("odata/SqlProjectFinal/DayBarBranches")]
  public partial class DayBarBranchesController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public DayBarBranchesController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/DayBarBranches
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.DayBarBranch> GetDayBarBranches()
    {
      var items = this.context.DayBarBranches.AsQueryable<Models.SqlProjectFinal.DayBarBranch>();
      this.OnDayBarBranchesRead(ref items);

      return items;
    }

    partial void OnDayBarBranchesRead(ref IQueryable<Models.SqlProjectFinal.DayBarBranch> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{date}")]
    public SingleResult<DayBarBranch> GetDayBarBranch(int key)
    {
        var items = this.context.DayBarBranches.Where(i=>i.date == key);
        this.OnDayBarBranchesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnDayBarBranchesGet(ref IQueryable<Models.SqlProjectFinal.DayBarBranch> items);

    partial void OnDayBarBranchDeleted(Models.SqlProjectFinal.DayBarBranch item);

    [HttpDelete("{date}")]
    public IActionResult DeleteDayBarBranch(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.DayBarBranches
                .Where(i => i.date == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnDayBarBranchDeleted(itemToDelete);
            this.context.DayBarBranches.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDayBarBranchUpdated(Models.SqlProjectFinal.DayBarBranch item);

    [HttpPut("{date}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDayBarBranch(int key, [FromBody]Models.SqlProjectFinal.DayBarBranch newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.date != key))
            {
                return BadRequest();
            }

            this.OnDayBarBranchUpdated(newItem);
            this.context.DayBarBranches.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.DayBarBranches.Where(i => i.date == key);
            Request.QueryString = Request.QueryString.Add("$expand", "DayBranch,Bar");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{date}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDayBarBranch(int key, [FromBody]Delta<Models.SqlProjectFinal.DayBarBranch> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.DayBarBranches.Where(i => i.date == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnDayBarBranchUpdated(itemToUpdate);
            this.context.DayBarBranches.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.DayBarBranches.Where(i => i.date == key);
            Request.QueryString = Request.QueryString.Add("$expand", "DayBranch,Bar");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDayBarBranchCreated(Models.SqlProjectFinal.DayBarBranch item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.DayBarBranch item)
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

            this.OnDayBarBranchCreated(item);
            this.context.DayBarBranches.Add(item);
            this.context.SaveChanges();

            var key = item.date;

            var itemToReturn = this.context.DayBarBranches.Where(i => i.date == key);

            Request.QueryString = Request.QueryString.Add("$expand", "DayBranch,Bar");

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
