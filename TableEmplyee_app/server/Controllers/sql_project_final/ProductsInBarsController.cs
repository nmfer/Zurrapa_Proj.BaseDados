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

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_product},{name}")]
    public SingleResult<ProductsInBar> GetProductsInBar([FromODataUri] int keyid_product,[FromODataUri] string keyname)
    {
        var items = this.context.ProductsInBars.Where(i=>i.id_product == keyid_product && i.name == keyname);
        this.OnProductsInBarsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnProductsInBarsGet(ref IQueryable<Models.SqlProjectFinal.ProductsInBar> items);

    partial void OnProductsInBarDeleted(Models.SqlProjectFinal.ProductsInBar item);

    [HttpDelete("{id_product},{name}")]
    public IActionResult DeleteProductsInBar([FromODataUri] int keyid_product,[FromODataUri] string keyname)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.ProductsInBars
                .Where(i => i.id_product == keyid_product && i.name == keyname)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnProductsInBarDeleted(itemToDelete);
            this.context.ProductsInBars.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProductsInBarUpdated(Models.SqlProjectFinal.ProductsInBar item);

    [HttpPut("{id_product},{name}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutProductsInBar([FromODataUri] int keyid_product,[FromODataUri] string keyname, [FromBody]Models.SqlProjectFinal.ProductsInBar newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.id_product != keyid_product && newItem.name != keyname))
            {
                return BadRequest();
            }

            this.OnProductsInBarUpdated(newItem);
            this.context.ProductsInBars.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.ProductsInBars.Where(i => i.id_product == keyid_product && i.name == keyname);
            Request.QueryString = Request.QueryString.Add("$expand", "Product,Bar");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{id_product},{name}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchProductsInBar([FromODataUri] int keyid_product,[FromODataUri] string keyname, [FromBody]Delta<Models.SqlProjectFinal.ProductsInBar> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.ProductsInBars.Where(i => i.id_product == keyid_product && i.name == keyname).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnProductsInBarUpdated(itemToUpdate);
            this.context.ProductsInBars.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.ProductsInBars.Where(i => i.id_product == keyid_product && i.name == keyname);
            Request.QueryString = Request.QueryString.Add("$expand", "Product,Bar");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProductsInBarCreated(Models.SqlProjectFinal.ProductsInBar item);

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

            var keyid_product = item.id_product;
            var keyname = item.name;

            var itemToReturn = this.context.ProductsInBars.Where(i => i.id_product == keyid_product && i.name == keyname);

            Request.QueryString = Request.QueryString.Add("$expand", "Product,Bar");

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
