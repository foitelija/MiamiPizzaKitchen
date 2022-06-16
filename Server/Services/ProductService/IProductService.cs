namespace BlazorMiamiPizza.Server.Services.ProductService
{
    public interface IProductService
    {
        //Определяем наши будущие методы.
        Task<ServiceResponse<List<Product>>> GetProductsAsync(); // получить все продукты
        Task<ServiceResponse<Product>> GetProductAsync(int productId); // получить один продукт
    }
}
