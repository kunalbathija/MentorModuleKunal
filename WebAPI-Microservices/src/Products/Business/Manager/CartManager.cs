using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
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
            Console.WriteLine("Zero");
            Console.WriteLine(newProduct);
            if(!_cartProducts.Any(x => x.id == newProduct.id))
            {
                this._cartProducts.Add(newProduct);
                Console.WriteLine("First");
                Console.WriteLine(_cartProducts[0]);
                return;
            }
            
        }

        public List<CartProductModel> GetCartProducts()
        {
            Console.WriteLine("Second");
            Console.WriteLine(_cartProducts);
            return this._cartProducts;
        }

        public void EmptyCart()
        {
            this._cartProducts = new List<CartProductModel>() { };
        }
    }
}
