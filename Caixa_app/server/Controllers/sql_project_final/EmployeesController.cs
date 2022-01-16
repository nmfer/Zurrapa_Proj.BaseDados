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

    partial void OnEmployeeGet(ref SingleResult<Models.SqlProjectFinal.Employee> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_num}")]
    public SingleResult<Employee> GetEmployee(int key)
    {
        var items = this.context.Employees.Where(i=>i.id_num == key);
        var result = SingleResult.Create(items);

        OnEmployeeGet(ref result);

        return result;
    }
    partial void OnEmployeeDeleted(Models.SqlProjectFinal.Employee item);
    partial void OnAfterEmployeeDeleted(Models.SqlProjectFinal.Employee item);

    [HttpDelete("{id_num}")]
    public IActionResult DeleteEmployee(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Employees
                .Where(i => i.id_num == key)
                .Include(i => i.Orders)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnEmployeeDeleted(item);
            this.context.Employees.Remove(item);
            this.context.SaveChanges();
            this.OnAfterEmployeeDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEmployeeUpdated(Models.SqlProjectFinal.Employee item);
    partial void OnAfterEmployeeUpdated(Models.SqlProjectFinal.Employee item);

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
            this.OnAfterEmployeeUpdated(newItem);
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

            var item = this.context.Employees.Where(i => i.id_num == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnEmployeeUpdated(item);
            this.context.Employees.Update(item);
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
    partial void OnAfterEmployeeCreated(Models.SqlProjectFinal.Employee item);

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
