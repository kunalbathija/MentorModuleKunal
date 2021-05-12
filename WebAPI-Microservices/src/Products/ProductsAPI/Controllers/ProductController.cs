﻿using Business;
using Common;
using Microsoft.AspNetCore.Mvc;
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

        //not in use
        [HttpPost("cart/add")]
        public ActionResult<int> AddProductToCart([FromBody] CartProductModel cartProduct)
        {
            Console.WriteLine(cartProduct);
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
