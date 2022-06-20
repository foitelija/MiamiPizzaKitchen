﻿namespace BlazorMiamiPizza.Server.Services.ProductService
{
    public interface IProductService
    {
        //Определяем наши будущие методы.
        Task<ServiceResponse<List<Product>>> GetProductsAsync(); // получить все продукты
        Task<ServiceResponse<Product>> GetProductAsync(int productId); // получить один продукт
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl); // получить продукты по категориям
        Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
    }
}
