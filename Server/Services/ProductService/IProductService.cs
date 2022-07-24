namespace BlazorMiamiPizza.Server.Services.ProductService
{
    public interface IProductService
    {
        //Определяем наши будущие методы.
        Task<ServiceResponse<List<Product>>> GetProductsAsync(); // получить все продукты
        Task<ServiceResponse<Product>> GetProductAsync(int productId); // получить один продукт
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl); // получить продукты по категориям
        Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
        Task<ServiceResponse<List<Product>>> GetAdminProducts();
        Task<ServiceResponse<Product>> CreateProducts(Product product);
        Task<ServiceResponse<Product>> UpdateProduct(Product product);
        Task<ServiceResponse<bool>> DeleteProduct(int productId);
    }
}
