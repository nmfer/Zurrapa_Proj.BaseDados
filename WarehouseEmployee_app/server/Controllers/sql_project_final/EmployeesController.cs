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

  [Route("odata/SqlProjectFinal/Employees")]
  public partial class EmployeesController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public EmployeesController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/Employees
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.Employee> GetEmployees()
    {
      var items = this.context.Employees.AsQueryable<Models.SqlProjectFinal.Employee>();
      this.OnEmployeesRead(ref items);

      return items;
    }

    partial void OnEmployeesRead(ref IQueryable<Models.SqlProjectFinal.Employee> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_num}")]
    public SingleResult<Employee> GetEmployee(int key)
    {
        var items = this.context.Employees.Where(i=>i.id_num == key);
        this.OnEmployeesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnEmployeesGet(ref IQueryable<Models.SqlProjectFinal.Employee> items);

    partial void OnEmployeeDeleted(Models.SqlProjectFinal.Employee item);

    [HttpDelete("{id_num}")]
    public IActionResult DeleteEmployee(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Employees
                .Where(i => i.id_num == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnEmployeeDeleted(itemToDelete);
            this.context.Employees.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmployeeUpdated(Models.SqlProjectFinal.Employee item);

    [HttpPut("{id_num}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEmployee(int key, [FromBody]Models.SqlProjectFinal.Employee newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.id_num != key))
            {
                return BadRequest();
            }

            this.OnEmployeeUpdated(newItem);
            this.context.Employees.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Employees.Where(i => i.id_num == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{id_num}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEmployee(int key, [FromBody]Delta<Models.SqlProjectFinal.Employee> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Employees.Where(i => i.id_num == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnEmployeeUpdated(itemToUpdate);
            this.context.Employees.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Employees.Where(i => i.id_num == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmployeeCreated(Models.SqlProjectFinal.Employee item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.Employee item)
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

            this.OnEmployeeCreated(item);
            this.context.Employees.Add(item);
            this.context.SaveChanges();

            return Created($"odata/SqlProjectFinal/Employees/{item.id_num}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
