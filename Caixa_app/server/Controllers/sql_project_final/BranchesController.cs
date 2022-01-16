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

  [Route("odata/SqlProjectFinal/Branches")]
  public partial class BranchesController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public BranchesController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/Branches
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.Branch> GetBranches()
    {
      var items = this.context.Branches.AsQueryable<Models.SqlProjectFinal.Branch>();
      this.OnBranchesRead(ref items);

      return items;
    }

    partial void OnBranchesRead(ref IQueryable<Models.SqlProjectFinal.Branch> items);

    partial void OnBranchGet(ref SingleResult<Models.SqlProjectFinal.Branch> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_branch}")]
    public SingleResult<Branch> GetBranch(int key)
    {
        var items = this.context.Branches.Where(i=>i.id_branch == key);
        var result = SingleResult.Create(items);

        OnBranchGet(ref result);

        return result;
    }
    partial void OnBranchDeleted(Models.SqlProjectFinal.Branch item);
    partial void OnAfterBranchDeleted(Models.SqlProjectFinal.Branch item);

    [HttpDelete("{id_branch}")]
    public IActionResult DeleteBranch(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Branches
                .Where(i => i.id_branch == key)
                .Include(i => i.DayBranches)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnBranchDeleted(item);
            this.context.Branches.Remove(item);
            this.context.SaveChanges();
            this.OnAfterBranchDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBranchUpdated(Models.SqlProjectFinal.Branch item);
    partial void OnAfterBranchUpdated(Models.SqlProjectFinal.Branch item);

    [HttpPut("{id_branch}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBranch(int key, [FromBody]Models.SqlProjectFinal.Branch newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.id_branch != key))
            {
                return BadRequest();
            }

            this.OnBranchUpdated(newItem);
            this.context.Branches.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Branches.Where(i => i.id_branch == key);
            this.OnAfterBranchUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{id_branch}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBranch(int key, [FromBody]Delta<Models.SqlProjectFinal.Branch> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Branches.Where(i => i.id_branch == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnBranchUpdated(item);
            this.context.Branches.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Branches.Where(i => i.id_branch == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBranchCreated(Models.SqlProjectFinal.Branch item);
    partial void OnAfterBranchCreated(Models.SqlProjectFinal.Branch item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.Branch item)
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

            this.OnBranchCreated(item);
            this.context.Branches.Add(item);
            this.context.SaveChanges();

            return Created($"odata/SqlProjectFinal/Branches/{item.id_branch}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
