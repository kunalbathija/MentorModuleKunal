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
            Console.WriteLine("Zero");
            Console.WriteLine(newProduct);
            Console.WriteLine(newProduct.id);
            Console.WriteLine(newProduct.name);
            Console.WriteLine(newProduct.quantity);
            /*if (!_cartProducts.Any(x => x.id == newProduct.id))
            {
                
                
            }*/
            this._cartProducts.Add(newProduct);
            Console.WriteLine("First");
            Console.WriteLine(_cartProducts);
            return;

        }

        public List<CartProductModel> GetCartProducts()
        {
            Console.WriteLine("Second");
            foreach (var i in _cartProducts)
            {
                Console.WriteLine(i);
            }
            return this._cartProducts;
        }

        public void EmptyCart()
        {
            this._cartProducts = new List<CartProductModel>() { };
        }
    }
}
