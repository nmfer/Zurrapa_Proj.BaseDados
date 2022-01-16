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

    partial void OnDayBranchGet(ref SingleResult<Models.SqlProjectFinal.DayBranch> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{date}")]
    public SingleResult<DayBranch> GetDayBranch(int key)
    {
        var items = this.context.DayBranches.Where(i=>i.date == key);
        var result = SingleResult.Create(items);

        OnDayBranchGet(ref result);

        return result;
    }
    partial void OnDayBranchDeleted(Models.SqlProjectFinal.DayBranch item);
    partial void OnAfterDayBranchDeleted(Models.SqlProjectFinal.DayBranch item);

    [HttpDelete("{date}")]
    public IActionResult DeleteDayBranch(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.DayBranches
                .Where(i => i.date == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnDayBranchDeleted(item);
            this.context.DayBranches.Remove(item);
            this.context.SaveChanges();
            this.OnAfterDayBranchDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDayBranchUpdated(Models.SqlProjectFinal.DayBranch item);
    partial void OnAfterDayBranchUpdated(Models.SqlProjectFinal.DayBranch item);

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
            Request.QueryString = Request.QueryString.Add("$expand", "DayBarBranch,Branch");
            this.OnAfterDayBranchUpdated(newItem);
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

            var item = this.context.DayBranches.Where(i => i.date == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnDayBranchUpdated(item);
            this.context.DayBranches.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.DayBranches.Where(i => i.date == key);
            Request.QueryString = Request.QueryString.Add("$expand", "DayBarBranch,Branch");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDayBranchCreated(Models.SqlProjectFinal.DayBranch item);
    partial void OnAfterDayBranchCreated(Models.SqlProjectFinal.DayBranch item);

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

            Request.QueryString = Request.QueryString.Add("$expand", "DayBarBranch,Branch");

            this.OnAfterDayBranchCreated(item);

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
