namespace BlazorMiamiPizza.Server.Services.ProductService
{
    public interface IProductService
    {
        //Определяем наши будущие методы.
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
    }
}
