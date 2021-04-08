# TSS-Mentor-Module
My assignment work done at Mentor Module by TSS for getting ready for Angular and ASP.NET Core (Microservices).

# Documentation -> Guide for Microservices endpoints - 
ProductsAPI
1. HTTPGET - https://localhost:44325/api/product - Get all products
2. HTTPPOST - https://localhost:44325/api/product/cart/add - Add a single product to cart 
3. HTTPGET - https://localhost:44325/api/product/cart/products - Get all products in cart
4. HTTPGET - https://localhost:44325/api/product/cart/size - Get cart size
5. HTTPDELETE - https://localhost:44325/api/product/cart/delete - Empty cart
6. HTTPPOST - https://localhost:44325/api/product/availability - Availibilty of a product (Integer)

TransactionsAPI
1. HTTPPOST - https://localhost:44343/api/buynow - BuyNow Implementation (Checking availibilty from ProductsAPI and payment random function)
