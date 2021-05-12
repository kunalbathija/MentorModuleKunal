using Common;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ProductManager: IProductManager
    {
        private readonly ProductDBContext productDBContext;

        public ProductManager(ProductDBContext productDBContext)
        {
            this.productDBContext = productDBContext;
        }


        public List<ProductModel> GetAllProducts()
        {
            return productDBContext.Products.ToList();
        }

        public ProductModel GetProductById(int id)
        {
            return productDBContext.Products.First(x => x.id == id);
        }
    }
}
 