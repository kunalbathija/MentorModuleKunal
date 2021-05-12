using Business;
using Common;
using Microsoft.AspNetCore.Mvc;
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

        public BuyNowController(IProductsClient productsClient, IPaymentManager paymentManager)
        {
            this.productsClient = productsClient;
            this.paymentManager = paymentManager;
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
                return Ok(new string[] { "Success" });
            }
            else
            {
                return BadRequest(new string[] { "Failure in payment" });
            }


        }
    }
}
