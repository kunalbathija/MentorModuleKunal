using Business;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TransactionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyNowController : ControllerBase
    {
        private readonly IProductsClient productsClient;
        private readonly IPaymentManager paymentManager;

        public BuyNowController(IProductsClient productsClient, IPaymentManager paymentManager)
        {
            this.productsClient = productsClient;
            this.paymentManager = paymentManager;
        }


        [HttpGet("cart/products")]
        public async Task<ActionResult<List<ProductModel>>> GetCartProducts()
        {

            return await productsClient.GetCartProducts();


        }

        [HttpPost]
        public async Task<ActionResult<string>> GetAvaibility([FromBody] List<CartProductModel> cartProducts)
        {
            int size = cartProducts.Count();
            for(int i = 0; i < size; i++)
            {
                var tempAvailibilty = await productsClient.GetAvailability(cartProducts[i].id);
                Console.WriteLine("Output");
                Console.WriteLine(tempAvailibilty);
                Console.WriteLine(cartProducts[i].quantity);
                Console.WriteLine("OP - End");
                if (tempAvailibilty < cartProducts[i].quantity)
                {
                    return BadRequest("The product " + cartProducts[i].name + " is out of stock");
                }

            }

            if (paymentManager.checkPayment())
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest("Failure in payment");
            }

            
        }
    }
}
