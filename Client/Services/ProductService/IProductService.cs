namespace BlazorMiamiPizza.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        List<Product> Products { get; set; } //для заглузки
        List<Product> AdminProducts { get; set; } //для загрузки всей шелухи
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; } 
        string LastSearchText { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int productId);
        Task SearchProducts(string searchText, int page);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
        Task GetAllProducts();
        Task GetAdminProducts();
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(Product product);

    }
}
