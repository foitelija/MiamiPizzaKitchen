namespace BlazorMiamiPizza.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Product>> CreateProducts(Product product)
        {
            foreach(var variant in product.Variants)
            {
                variant.ProductType = null;
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Product>
            {
                Data = product
            };
        }

        public async Task<ServiceResponse<bool>> DeleteProduct(int productId)
        {
            var dbProduct = await _context.Products.FindAsync(productId);
            if(dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Продукт не найден"
                };
            }
            //мягкое удаление, просто скрываем короче, в БД остаётся
            dbProduct.isDeleted = true;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> 
            { 
                Data = true 
            };
        }

        public async Task<ServiceResponse<List<Product>>> GetAdminProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(p => !p.isDeleted)
                .Include(p => p.Variants.Where(v => !v.isDeleted))
                .ThenInclude(v => v.ProductType)
                .Include(p => p.Images)
                .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(p => p.Featured && p.isVisible && !p.isDeleted)
                .Include(p => p.Variants.Where(v => v.isVisible && !v.isDeleted))
                .Include(p => p.Images)
                .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            Product product = null;

            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Products
                .Include(p => p.Variants.Where(v => !v.isDeleted))
                .ThenInclude(v => v.ProductType)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == productId && !p.isDeleted);
            }
            else
            {
                product = await _context.Products
                .Include(p => p.Variants.Where(v => v.isVisible && !v.isDeleted))
                .ThenInclude(v => v.ProductType)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == productId && p.isVisible && !p.isDeleted);
            }
            if (product == null)
            {
                response.Success = false;
                response.Message = "Данный продукт не существует ;(";
            }
            else
            {
                response.Data = product;
            }

            return response;
        }

        //реализуем метод получения всех продуктов.
        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(p => p.isVisible && !p.isDeleted)
                .Include(p => p.Variants.Where(v => v.isVisible && !v.isDeleted))
                .Include(p => p.Images)
                .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower())
                && p.isVisible && !p.isDeleted)
                .Include(p => p.Variants.Where(v => v.isVisible && !v.isDeleted))
                .Include(p => p.Images)
                .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchtext(searchText);

            List<string> result = new List<string>();

            foreach(var product in products)
            {
                if(product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if(product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach(var word in words)
                    {
                        if(word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result};

        }

        public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindProductsBySearchtext(searchText)).Count / pageResults);
            var products = await _context.Products
                            .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            ||
                            p.Description.ToLower().Contains(searchText.ToLower())
                            && p.isVisible && !p.isDeleted)
                            .Include(p => p.Variants)
                            .Include(p => p.Images)
                            .Skip((page - 1) * (int)pageResults)
                            .Take((int)pageResults)
                            .ToListAsync();


            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                }
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == product.Id);
            if(dbProduct == null)
            {
                return new ServiceResponse<Product>
                {
                    Success = false,
                    Message = "Продукт не найден"
                };
            }

            dbProduct.Title = product.Title;
            dbProduct.Description = product.Description;
            dbProduct.ImageUrl = product.ImageUrl;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.isVisible = product.isVisible;
            dbProduct.Featured = product.Featured;

            var productImages = dbProduct.Images;
            _context.Images.RemoveRange(productImages);
            dbProduct.Images = product.Images;


            foreach(var variant in product.Variants)
            {
                var dbVariant = await _context.ProductVariants
                    .SingleOrDefaultAsync(v => v.ProductId == variant.ProductId &&
                    v.ProductTypeId == variant.ProductTypeId);

                if(dbVariant == null)
                {
                    variant.ProductType = null;
                    _context.ProductVariants.Add(variant);
                }
                else
                {
                    dbVariant.ProductTypeId = variant.ProductTypeId;
                    dbVariant.Price = variant.Price;
                    dbVariant.OriginalPrice = variant.OriginalPrice;
                    dbVariant.isVisible = variant.isVisible;
                    dbVariant.isDeleted = variant.isDeleted;
                }
            }
            await _context.SaveChangesAsync();
            return new ServiceResponse<Product>
            {
                Data = product
            };
        }

        private async Task<List<Product>> FindProductsBySearchtext(string searchText)
        {
            //Выдать мне продукты где название и описание содержит искомый текст.

            return await _context.Products
                            .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            ||
                            p.Description.ToLower().Contains(searchText.ToLower())
                            && p.isVisible && !p.isDeleted)
                            .Include(p => p.Variants)
                            .ToListAsync();
        }
    }
}
