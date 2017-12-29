using Hurriyet.HurriyetDb.Business.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace Hurriyet.HurriyetDb.WebApi.Controllers
{
    using System;
    using HurriyetDemo.HurriyetDb.Entities.Concrete;
    using Microsoft.AspNetCore.Mvc;

    namespace Hurriyet.HurriyetDb.WebApi.Controllers
    {
        [Authorize]
        [Route("api/[controller]")]
        public class ProductsController : Controller
        {
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
                    if (products == null)
                    {
                        return NotFound();
                    }
                    return Ok(products);
                }
                catch (Exception e)
                {
                    return new StatusCodeResult(500);
                }
            }

            [HttpGet("{productId}")]
            public IActionResult Get(int productId)
            {
                try
                {
                    var products = _productService.GetById(p => p.Id == productId);

                    if (products == null)
                    {
                        return NotFound($"Product not found. Product Id : {productId}");
                    }
                    return Ok(products);
                }
                catch (Exception e)
                {
                    return new StatusCodeResult(500);
                }
            }

            [HttpPost]
            public IActionResult Post([FromBody]Product product)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _productService.Add(product);
                        return new StatusCodeResult(201);
                    }
                    return BadRequest();
                }
                catch (Exception e)
                {
                    return new StatusCodeResult(500);
                }
            }

            [HttpPut]
            public IActionResult Put(Product product)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        _productService.Update(product);
                        return Ok(product);
                    }
                    return BadRequest();
                }
                catch (Exception e)
                {
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
                catch (Exception e)
                {
                    return new StatusCodeResult(500);
                }
            }
        }
    }

}
