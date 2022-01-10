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

  [Route("odata/SqlProjectFinal/DayBranches")]
  public partial class DayBranchesController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public DayBranchesController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/DayBranches
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.DayBranch> GetDayBranches()
    {
      var items = this.context.DayBranches.AsQueryable<Models.SqlProjectFinal.DayBranch>();
      this.OnDayBranchesRead(ref items);

      return items;
    }

    partial void OnDayBranchesRead(ref IQueryable<Models.SqlProjectFinal.DayBranch> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{date}")]
    public SingleResult<DayBranch> GetDayBranch(int key)
    {
        var items = this.context.DayBranches.Where(i=>i.date == key);
        this.OnDayBranchesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnDayBranchesGet(ref IQueryable<Models.SqlProjectFinal.DayBranch> items);

    partial void OnDayBranchDeleted(Models.SqlProjectFinal.DayBranch item);

    [HttpDelete("{date}")]
    public IActionResult DeleteDayBranch(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.DayBranches
                .Where(i => i.date == key)
                .Include(i => i.DayBarBranches)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnDayBranchDeleted(itemToDelete);
            this.context.DayBranches.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDayBranchUpdated(Models.SqlProjectFinal.DayBranch item);

    [HttpPut("{date}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDayBranch(int key, [FromBody]Models.SqlProjectFinal.DayBranch newItem)
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

            this.OnDayBranchUpdated(newItem);
            this.context.DayBranches.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.DayBranches.Where(i => i.date == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Branch");
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
    public IActionResult PatchDayBranch(int key, [FromBody]Delta<Models.SqlProjectFinal.DayBranch> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.DayBranches.Where(i => i.date == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnDayBranchUpdated(itemToUpdate);
            this.context.DayBranches.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.DayBranches.Where(i => i.date == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Branch");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDayBranchCreated(Models.SqlProjectFinal.DayBranch item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.DayBranch item)
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

            this.OnDayBranchCreated(item);
            this.context.DayBranches.Add(item);
            this.context.SaveChanges();

            var key = item.date;

            var itemToReturn = this.context.DayBranches.Where(i => i.date == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Branch");

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
