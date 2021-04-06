using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class CartManager: ICartManager
    {
        private List<ProductModel> _cartProducts;

        public CartManager()
        {
            _cartProducts = new List<ProductModel>() { };
        }

        public int GetSize()
        {
            return _cartProducts.Count();
        }

        public void AddProduct(ProductModel product)
        {
            if(_cartProducts.FirstOrDefault(x => x.id == product.id) != null)
            {
                return;
            }
            this._cartProducts.Add(product);
        }

        public List<ProductModel> GetCartProducts()
        {
            return this._cartProducts;
        }

        public void EmptyCart()
        {
            this._cartProducts = new List<ProductModel>() { };
        }
    }
}
