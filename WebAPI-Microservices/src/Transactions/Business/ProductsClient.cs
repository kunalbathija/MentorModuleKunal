﻿using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductsClient: IProductsClient
    {
        private readonly HttpClient httpClient;

        public ProductsClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<ProductModel>> GetCartProducts()
        {

            var response = await httpClient.GetAsync("/api/product/cart/products");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var ObjResponse = response.Content.ReadAsStringAsync().Result;
            var Products = JsonConvert.DeserializeObject<List<ProductModel>>(ObjResponse);

            return Products;

        }

        public async Task<int> GetAvailability(int id)
        {

            var myContent = JsonConvert.SerializeObject(id);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/product/availability", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            var availibility = int.Parse(response.Content.ReadAsStringAsync().Result);
            return availibility;
        }
    }
}