namespace BlazorMiamiPizza.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            var responce = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if(responce != null && responce.Data != null)
            Categories = responce.Data;
        }
    }
}
