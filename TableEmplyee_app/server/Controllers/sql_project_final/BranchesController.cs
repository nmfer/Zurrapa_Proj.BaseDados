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



namespace TableEmployee.Controllers.SqlProjectFinal
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

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_branch}")]
    public SingleResult<Branch> GetBranch(int key)
    {
        var items = this.context.Branches.Where(i=>i.id_branch == key);
        this.OnBranchesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnBranchesGet(ref IQueryable<Models.SqlProjectFinal.Branch> items);

    partial void OnBranchDeleted(Models.SqlProjectFinal.Branch item);

    [HttpDelete("{id_branch}")]
    public IActionResult DeleteBranch(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Branches
                .Where(i => i.id_branch == key)
                .Include(i => i.DayBranches)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnBranchDeleted(itemToDelete);
            this.context.Branches.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBranchUpdated(Models.SqlProjectFinal.Branch item);

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

            var itemToUpdate = this.context.Branches.Where(i => i.id_branch == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnBranchUpdated(itemToUpdate);
            this.context.Branches.Update(itemToUpdate);
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
