using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ProductManager: IProductManager
    {
        private readonly ICartManager cartManager;
        private List<ProductModel> _products;

        public ProductManager(ICartManager cartManager)
        {
            _products = new List<ProductModel>()
            {
                new ProductModel(){id=0,name="Product 1", availability= 1, description="Product 1 description"},
                new ProductModel(){id=1,name="Product 2", availability= 6, description="Product 2 description"},
                new ProductModel(){id=2,name="Product 3", availability= 4, description="Product 3 description"},
                new ProductModel(){id=3,name="Product 4", availability= 32, description="Product 4 description"},
            };
            this.cartManager = cartManager;
        }

        public List<ProductModel> GetAllProducts()
        {
            return _products;
        }

        public ProductModel GetProductById(int id)
        {
            //cartManager.AddProduct(_products.FirstOrDefault(x => x.id == id));
            return _products.FirstOrDefault(x => x.id == id);
        }
    }
}
 