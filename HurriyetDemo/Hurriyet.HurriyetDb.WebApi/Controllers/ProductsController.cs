using System.Linq;
using Hurriyet.HurriyetDb.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using NLog;

namespace Hurriyet.HurriyetDb.WebApi.Controllers
{
    using System;
    using HurriyetDemo.HurriyetDb.Entities.Concrete;
    using Microsoft.AspNetCore.Mvc;

    namespace Hurriyet.HurriyetDb.WebApi.Controllers
    {
        [Authorize]
        [Route("api/products")]
        public class ProductsController : Controller
        {
            private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
            private IProductService _productService;

            public ProductsController(IProductService productService)
            {
                _productService = productService;
            }

            [HttpGet]
            public IActionResult Get()
            {
                try
                {
                    var products = _productService.GetAll();
                    if (products == null || !products.Any())
                    {
                        return NotFound();
                    }
                    return Ok(products);
                }
                catch (Exception exception)
                {
                    Logger.Error(exception);
                    return new StatusCodeResult(500);
                }
            }

            [HttpGet("{productId}")]
            public IActionResult Get(int productId)
            {
                try
                {
                    var product = _productService.GetById(p => p.Id == productId);

                    if (product == null)
                    {
                        return NotFound($"Product not found. Product Id : {productId}");
                    }
                    return Ok(product);
                }
                catch (Exception exception)
                {
                    Logger.Error(exception);
                    return new StatusCodeResult(500);
                }
            }

            [HttpPost]
            public IActionResult Post([FromBody]Product product)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest("Not a valid model");
                    }
                    _productService.Add(product);

                    return new StatusCodeResult(201);
                }
                catch (Exception exception)
                {
                    Logger.Error(exception);
                    return new StatusCodeResult(500);
                }
            }

            [HttpPut]
            public IActionResult Put([FromBody]Product product)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest("Not a valid model");
                    }
                    _productService.Update(product);

                    return Ok(product);
                }
                catch (Exception exception)
                {
                    Logger.Error(exception);
                    return new StatusCodeResult(500);
                }
            }

            [HttpDelete("{productId}")]
            public IActionResult Delete(int productId)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _productService.Delete(productId);
                        return Ok();
                    }
                    return BadRequest();
                }
                catch (Exception exception)
                {
                    Logger.Error(exception);
                    return new StatusCodeResult(500);
                }
            }
        }
    }

}
