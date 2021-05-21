using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    //Not in use currently
    public class CartManager: ICartManager
    {
        private List<CartProductModel> _cartProducts;

        public CartManager()
        {
            _cartProducts = new List<CartProductModel>() { };
        }

        public int GetSize()
        {
            return _cartProducts.Count();
        }

        public void AddProduct(CartProductModel newProduct)
        {
            if (!_cartProducts.Any(x => x.id == newProduct.id))
            {
                this._cartProducts.Add(newProduct);
            }
            return;

        }

        public List<CartProductModel> GetCartProducts()
        {
            return this._cartProducts;
        }

        public void EmptyCart()
        {
            this._cartProducts = new List<CartProductModel>() { };
        }
    }
}
