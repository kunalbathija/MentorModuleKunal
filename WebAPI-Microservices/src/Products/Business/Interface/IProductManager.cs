using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IProductManager
    {
        void Add(ProductModel newProduct);
        List<ProductModel> GetAllProducts();
        ProductModel GetProductById(int id);
        void Update(int id, CartProductModel newProduct);
    }
}
