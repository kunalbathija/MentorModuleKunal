using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IProductManager
    {
        List<ProductModel> GetAllProducts();
        ProductModel GetProductById(int id);
    }
}
