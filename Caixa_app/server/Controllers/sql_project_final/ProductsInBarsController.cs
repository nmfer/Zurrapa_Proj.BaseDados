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

  [Route("odata/SqlProjectFinal/ProductsInBars")]
  public partial class ProductsInBarsController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public ProductsInBarsController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/ProductsInBars
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.ProductsInBar> GetProductsInBars()
    {
      var items = this.context.ProductsInBars.AsQueryable<Models.SqlProjectFinal.ProductsInBar>();
      this.OnProductsInBarsRead(ref items);

      return items;
    }

    partial void OnProductsInBarsRead(ref IQueryable<Models.SqlProjectFinal.ProductsInBar> items);

    partial void OnProductsInBarGet(ref SingleResult<Models.SqlProjectFinal.ProductsInBar> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_product}")]
    public SingleResult<ProductsInBar> GetProductsInBar(int key)
    {
        var items = this.context.ProductsInBars.Where(i=>i.id_product == key);
        var result = SingleResult.Create(items);

        OnProductsInBarGet(ref result);

        return result;
    }
    partial void OnProductsInBarDeleted(Models.SqlProjectFinal.ProductsInBar item);
    partial void OnAfterProductsInBarDeleted(Models.SqlProjectFinal.ProductsInBar item);

    [HttpDelete("{id_product}")]
    public IActionResult DeleteProductsInBar(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.ProductsInBars
                .Where(i => i.id_product == key)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnProductsInBarDeleted(item);
            this.context.ProductsInBars.Remove(item);
            this.context.SaveChanges();
            this.OnAfterProductsInBarDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProductsInBarUpdated(Models.SqlProjectFinal.ProductsInBar item);
    partial void OnAfterProductsInBarUpdated(Models.SqlProjectFinal.ProductsInBar item);

    [HttpPut("{id_product}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutProductsInBar(int key, [FromBody]Models.SqlProjectFinal.ProductsInBar newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.id_product != key))
            {
                return BadRequest();
            }

            this.OnProductsInBarUpdated(newItem);
            this.context.ProductsInBars.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.ProductsInBars.Where(i => i.id_product == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Bar,Product");
            this.OnAfterProductsInBarUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{id_product}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchProductsInBar(int key, [FromBody]Delta<Models.SqlProjectFinal.ProductsInBar> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.ProductsInBars.Where(i => i.id_product == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnProductsInBarUpdated(item);
            this.context.ProductsInBars.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.ProductsInBars.Where(i => i.id_product == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Bar,Product");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProductsInBarCreated(Models.SqlProjectFinal.ProductsInBar item);
    partial void OnAfterProductsInBarCreated(Models.SqlProjectFinal.ProductsInBar item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.ProductsInBar item)
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

            this.OnProductsInBarCreated(item);
            this.context.ProductsInBars.Add(item);
            this.context.SaveChanges();

            var key = item.id_product;

            var itemToReturn = this.context.ProductsInBars.Where(i => i.id_product == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Bar,Product");

            this.OnAfterProductsInBarCreated(item);

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
