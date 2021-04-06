using Business;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly ICartManager cartManager;

        public ProductController(IProductManager productManager, ICartManager cartManager)
        {
            this.productManager = productManager;
            this.cartManager = cartManager;
        }

        [HttpGet]
        public ActionResult<List<ProductModel>> Get()
        {
            return productManager.GetAllProducts();
        }

        [HttpPost("cart/add")]
        public IActionResult AddProductToCart([FromBody] int id)
        {
            try
            {
                var tempProduct = new ProductModel();
                tempProduct = productManager.GetProductById(id);
                cartManager.AddProduct(tempProduct);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

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

        [HttpGet("cart/products")]
        public ActionResult<List<ProductModel>> GetCartProducts()
        {
            return cartManager.GetCartProducts();
        }

        [HttpGet("cart/size")]
        public ActionResult<int> GetCartSize()
        {
            return cartManager.GetSize();
        }
    }
}
