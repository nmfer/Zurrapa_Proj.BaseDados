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

  [Route("odata/SqlProjectFinal/Products")]
  public partial class ProductsController : ODataController
  {
    private Data.SqlProjectFinalContext context;

    public ProductsController(Data.SqlProjectFinalContext context)
    {
      this.context = context;
    }
    // GET /odata/SqlProjectFinal/Products
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.SqlProjectFinal.Product> GetProducts()
    {
      var items = this.context.Products.AsQueryable<Models.SqlProjectFinal.Product>();
      this.OnProductsRead(ref items);

      return items;
    }

    partial void OnProductsRead(ref IQueryable<Models.SqlProjectFinal.Product> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_product},{name}")]
    public SingleResult<Product> GetProduct([FromODataUri] int keyid_product,[FromODataUri] string keyname)
    {
        var items = this.context.Products.Where(i=>i.id_product == keyid_product && i.name == keyname);
        this.OnProductsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnProductsGet(ref IQueryable<Models.SqlProjectFinal.Product> items);

    partial void OnProductDeleted(Models.SqlProjectFinal.Product item);

    [HttpDelete("{id_product},{name}")]
    public IActionResult DeleteProduct([FromODataUri] int keyid_product,[FromODataUri] string keyname)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Products
                .Where(i => i.id_product == keyid_product && i.name == keyname)
                .Include(i => i.ProductsInBars)
                .Include(i => i.ProductsInWarehouses)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnProductDeleted(itemToDelete);
            this.context.Products.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProductUpdated(Models.SqlProjectFinal.Product item);

    [HttpPut("{id_product},{name}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutProduct([FromODataUri] int keyid_product,[FromODataUri] string keyname, [FromBody]Models.SqlProjectFinal.Product newItem)
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

            this.OnProductUpdated(newItem);
            this.context.Products.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Products.Where(i => i.id_product == keyid_product && i.name == keyname);
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
    public IActionResult PatchProduct([FromODataUri] int keyid_product,[FromODataUri] string keyname, [FromBody]Delta<Models.SqlProjectFinal.Product> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Products.Where(i => i.id_product == keyid_product && i.name == keyname).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnProductUpdated(itemToUpdate);
            this.context.Products.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Products.Where(i => i.id_product == keyid_product && i.name == keyname);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProductCreated(Models.SqlProjectFinal.Product item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.SqlProjectFinal.Product item)
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

            this.OnProductCreated(item);
            this.context.Products.Add(item);
            this.context.SaveChanges();

            return Created($"odata/SqlProjectFinal/Products/(id_product={item.id_product},name={item.name})", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
