using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ProductManager: IProductManager
    {
        private readonly ProductDBContext _productDBContext;

        public ProductManager(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
        }


        public List<ProductModel> GetAllProducts()
        {
            return _productDBContext.Products.ToList();
        }

        public ProductModel GetProductById(int id)
        {
            return _productDBContext.Products.FirstOrDefault(x => x.id == id);
        }

        public void Add(ProductModel newProduct)
        {
            _productDBContext.Products.Add(newProduct);
            _productDBContext.SaveChanges();
        } 

        public void Update(int id, CartProductModel productBaught)
        {
            ProductModel oldProduct = GetProductById(id);

            if (oldProduct == null)
            {
                throw new InvalidOperationException("Product record couldn't be found.");
            }

            var difference = oldProduct.availability - productBaught.quantity;
            if (difference <= 0)
            {
                Delete(oldProduct);
            }
            else
            {
                oldProduct.availability = difference;
                _productDBContext.SaveChanges();
            }            
        }

        public void Delete(ProductModel product)
        {
            _productDBContext.Products.Remove(product);
            _productDBContext.SaveChanges();
        }
    }
}
 