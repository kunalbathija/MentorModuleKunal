using Common;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ProductManager: IProductManager
    {
        private readonly ICartManager cartManager;
        private readonly ProductDBContext productDBContext;
        private List<ProductModel> _products;

        public ProductManager(ICartManager cartManager, ProductDBContext productDBContext)
        {
            _products = new List<ProductModel>();
            this.cartManager = cartManager;
            this.productDBContext = productDBContext;
            _products = productDBContext.Products.ToList();
        }


        public List<ProductModel> GetAllProducts()
        {
            return productDBContext.Products.ToList();
        }

        public ProductModel GetProductById(int id)
        {
            //cartManager.AddProduct(_products.FirstOrDefault(x => x.id == id));
            return productDBContext.Products.FirstOrDefault(x => x.id == id);
        }
    }
}
 