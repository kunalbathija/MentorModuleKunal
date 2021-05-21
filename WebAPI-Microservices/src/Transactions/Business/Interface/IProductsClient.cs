using Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProductsClient
    {
        Task<int> GetAvailability(int id);
        Task<List<CartProductModel>> GetCartProducts();
        Task<bool> UpdateProducts(List<CartProductModel> productsBought);
    }
}
