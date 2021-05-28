using Business;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransactionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyNowController : ControllerBase
    {
        private readonly IProductsClient productsClient;
        private readonly IPaymentManager paymentManager;
        private readonly ILogger<BuyNowController> _logger;

        public BuyNowController(IProductsClient productsClient, IPaymentManager paymentManager, ILogger<BuyNowController> logger)
        {
            this.productsClient = productsClient;
            this.paymentManager = paymentManager;
            _logger = logger;
        }

        //get all products in cart
        [HttpGet("cart/products")]
        public async Task<ActionResult<List<CartProductModel>>> GetCartProducts()
        {
            return await productsClient.GetCartProducts();
        }

        [HttpPost]
        public async Task<ActionResult<string>> BuyNow([FromBody] List<CartProductModel> cartProducts)
        {
            try
            {
                //Checking availibity
                foreach (CartProductModel cartProduct in cartProducts)
                {
                    var tempAvailibilty = await productsClient.GetAvailability(cartProduct.id);
                    if (tempAvailibilty < cartProduct.quantity)
                    {
                        return BadRequest("The product " + cartProduct.name + " is out of stock" );
                    }

                }

                //Checking payment
                if (paymentManager.checkPayment())
                {
                    if (await productsClient.UpdateProducts(cartProducts))
                    {
                        return Ok("Success");
                    }
                    else
                    {
                        return BadRequest("Something went wrong");
                    }
                }
                else
                {
                    return BadRequest("Failure in payment");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Occured: ", ex.Message);
                return BadRequest(ex.Message);
            }
            
        }
    }
}
