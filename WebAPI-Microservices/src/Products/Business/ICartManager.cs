using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface ICartManager
    {
        void AddProduct(CartProductModel newProduct);
        void EmptyCart();
        List<CartProductModel> GetCartProducts();
        int GetSize();
    }
}
