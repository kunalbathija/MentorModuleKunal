using Business;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public async Task<ActionResult<IEnumerable<string>>> BuyNow([FromBody] List<CartProductModel> cartProducts)
        {
            _logger.LogInformation("Buy Now Call requested");
            //Checking availibity
            foreach(CartProductModel cartProduct in cartProducts)
            {
                var tempAvailibilty = await productsClient.GetAvailability(cartProduct.id);
                if (tempAvailibilty < cartProduct.quantity)
                {
                    return BadRequest(new string[] { "The product " + cartProduct.name + " is out of stock" });
                }

            }
            
            //Checking payment
            if (paymentManager.checkPayment())
            {
                if (productsClient.UpdateProducts(cartProducts).Result)
                {
                    _logger.LogInformation("{size} products bought", cartProducts.Count);
                    return Ok(new string[] { "Success" });
                }
                else
                {
                    return BadRequest(new string[] { "Something went wrong" });
                }
            }
            else
            {
                _logger.LogInformation("Failure in payment");
                return BadRequest(new string[] { "Failure in payment" });
            }


        }
    }
}
