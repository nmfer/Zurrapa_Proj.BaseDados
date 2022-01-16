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

    partial void OnProductGet(ref SingleResult<Models.SqlProjectFinal.Product> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{id_product}")]
    public SingleResult<Product> GetProduct(int key)
    {
        var items = this.context.Products.Where(i=>i.id_product == key);
        var result = SingleResult.Create(items);

        OnProductGet(ref result);

        return result;
    }
    partial void OnProductDeleted(Models.SqlProjectFinal.Product item);
    partial void OnAfterProductDeleted(Models.SqlProjectFinal.Product item);

    [HttpDelete("{id_product}")]
    public IActionResult DeleteProduct(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Products
                .Where(i => i.id_product == key)
                .Include(i => i.ProductsInWarehouses)
                .Include(i => i.ProductsInBars)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnProductDeleted(item);
            this.context.Products.Remove(item);
            this.context.SaveChanges();
            this.OnAfterProductDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProductUpdated(Models.SqlProjectFinal.Product item);
    partial void OnAfterProductUpdated(Models.SqlProjectFinal.Product item);

    [HttpPut("{id_product}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutProduct(int key, [FromBody]Models.SqlProjectFinal.Product newItem)
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

            this.OnProductUpdated(newItem);
            this.context.Products.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Products.Where(i => i.id_product == key);
            this.OnAfterProductUpdated(newItem);
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
    public IActionResult PatchProduct(int key, [FromBody]Delta<Models.SqlProjectFinal.Product> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Products.Where(i => i.id_product == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnProductUpdated(item);
            this.context.Products.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Products.Where(i => i.id_product == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnProductCreated(Models.SqlProjectFinal.Product item);
    partial void OnAfterProductCreated(Models.SqlProjectFinal.Product item);

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

            return Created($"odata/SqlProjectFinal/Products/{item.id_product}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
