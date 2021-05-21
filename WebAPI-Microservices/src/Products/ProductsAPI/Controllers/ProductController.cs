using Business;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly ICartManager cartManager;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductManager productManager, ICartManager cartManager, ILogger<ProductController> logger)
        {
            this.productManager = productManager;
            this.cartManager = cartManager;
            _logger = logger;
        }

        [HttpGet] 
        public ActionResult<List<ProductModel>> Get()
        {
            try
            {
                return productManager.GetAllProducts();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured: ", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public ActionResult<int> AddNewProduct([FromBody] ProductModel newProduct)
        {
            try
            {
                productManager.Add(newProduct);
                _logger.LogInformation("A product {productname} added", newProduct.name);
                return Ok(1);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured: ", ex.Message);
                return BadRequest(ex.Message);
            }
                        
        }

        [HttpPut("update/{id}")]
        public ActionResult<Boolean> UpdateProduct(int id, [FromBody] CartProductModel productBaught)
        {
            if (productBaught == null)
            {
                return BadRequest("New Product is null");
            }

            ProductModel productToUpdate = productManager.GetProductById(id);
            
            if(productToUpdate == null)
            {
                return NotFound("Product record couldn't be found.");
            }

            try
            {
                productManager.Update(productToUpdate, productBaught);
                _logger.LogInformation("{productname} updated", productToUpdate.name);
                return Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured: ", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //not in use
        [HttpPost("cart/add")]
        public ActionResult<int> AddProductToCart([FromBody] CartProductModel cartProduct)
        {
            try
            {
                cartManager.AddProduct(cartProduct);
                var cartSize = cartManager.GetSize();
                return Ok(cartSize);
            }
            catch
            {
                return NotFound(0);
            }
        }

        //not in use
        [HttpDelete("cart/delete")]
        public IActionResult EmptyCart()
        {
            try
            {
                cartManager.EmptyCart();
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        //not in use
        [HttpGet("cart/products")]
        public ActionResult<List<CartProductModel>> GetCartProducts()
        {
            return cartManager.GetCartProducts();
        }

        //not in use
        [HttpGet("cart/size")]
        public ActionResult<int> GetCartSize()
        {
            return cartManager.GetSize();
        }

        //not in use
        [HttpPost("availability")]
        public ActionResult<int> GetAvailabilty([FromBody] int id)
        {
            try
            {
                var tempProduct = new ProductModel();
                tempProduct = productManager.GetProductById(id);
                return Ok(tempProduct.availability);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
