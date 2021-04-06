using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface ICartManager
    {
        void AddProduct(ProductModel product);
        void EmptyCart();
        List<ProductModel> GetCartProducts();
        int GetSize();
    }
}
