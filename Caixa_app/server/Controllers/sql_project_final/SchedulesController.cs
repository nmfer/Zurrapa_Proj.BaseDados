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

  [Route("odata/SqlProjectFinal/Schedules")]
  public partial class SchedulesController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public SchedulesController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/Schedules
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.Schedule> GetSchedules()
    {
      var items = this.context.Schedules.AsQueryable<Models.SqlProjectFinal.Schedule>();
      this.OnSchedulesRead(ref items);

      return items;
    }

    partial void OnSchedulesRead(ref IQueryable<Models.SqlProjectFinal.Schedule> items);

    partial void OnScheduleGet(ref SingleResult<Models.SqlProjectFinal.Schedule> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{cod}")]
    public SingleResult<Schedule> GetSchedule(int key)
    {
        var items = this.context.Schedules.Where(i=>i.cod == key);
        var result = SingleResult.Create(items);

        OnScheduleGet(ref result);

        return result;
    }
    partial void OnScheduleDeleted(Models.SqlProjectFinal.Schedule item);
    partial void OnAfterScheduleDeleted(Models.SqlProjectFinal.Schedule item);

    [HttpDelete("{cod}")]
    public IActionResult DeleteSchedule(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Schedules
                .Where(i => i.cod == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnScheduleDeleted(item);
            this.context.Schedules.Remove(item);
            this.context.SaveChanges();
            this.OnAfterScheduleDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnScheduleUpdated(Models.SqlProjectFinal.Schedule item);
    partial void OnAfterScheduleUpdated(Models.SqlProjectFinal.Schedule item);

    [HttpPut("{cod}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutSchedule(int key, [FromBody]Models.SqlProjectFinal.Schedule newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.cod != key))
            {
                return BadRequest();
            }

            this.OnScheduleUpdated(newItem);
            this.context.Schedules.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Schedules.Where(i => i.cod == key);
            this.OnAfterScheduleUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{cod}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchSchedule(int key, [FromBody]Delta<Models.SqlProjectFinal.Schedule> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Schedules.Where(i => i.cod == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnScheduleUpdated(item);
            this.context.Schedules.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Schedules.Where(i => i.cod == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnScheduleCreated(Models.SqlProjectFinal.Schedule item);
    partial void OnAfterScheduleCreated(Models.SqlProjectFinal.Schedule item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.Schedule item)
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

            this.OnScheduleCreated(item);
            this.context.Schedules.Add(item);
            this.context.SaveChanges();

            return Created($"odata/SqlProjectFinal/Schedules/{item.cod}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
