namespace BlazorMiamiPizza.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)  
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVariant>().HasKey(p => new { p.ProductId, p.ProductTypeId});

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Маленькая" },
                new ProductType { Id = 2, Name = "Средняя"},
                new ProductType { Id = 3, Name = "Большая"},
                new ProductType { Id = 4, Name = "ШТ"}
                );

            modelBuilder.Entity<Category>().HasData(
                new Category {
                    Id = 1,
                    Name = "Пицца",
                    Url = "pizzas",
                    },
                new Category { 
                    Id =2,
                    Name = "Напитки",
                    Url = "drinks",
                    },
                new Category { 
                    Id=3,
                    Name = "Закуски",
                    Url = "snacks",
                    },
                new Category
                    {
                    Id =4,
                    Name = "Салаты",
                    Url = "salads",
                    }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 7,
                        Title = "Карбонара",
                        Description = "Бекон, сыры чеддер и пармезан, моцарелла, томаты, соус альфредо, красный лук, чеснок, итальянские травы",
                        ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/b195d75f2371491bb519629500d03f24_292x292.jpeg",
                        CategoryId = 1,
                    },
                    new Product
                    {
                        Id = 8,
                        Title = "Острый До-достер",
                        Description = "Горячая закуска с цыпленком, перцем халапеньо, маринованные огурчики, томатами, моцареллой и соусом барбекю в тонкой пшеничной лепешке",
                        ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/0c55068d9fa9432389b848f9b3eb5085_1875x1875.jpeg",
                        CategoryId = 3,
                    },
                    new Product
                    {
                        Id = 10,
                        Title = "Pepsi-Co",
                        Description = "Pepsi 1Л",
                        ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/8109d13f041147bdacb115c6b07cccc0_1875x1875.jpeg",
                        CategoryId = 2,
                    },
                    new Product
                    {
                        Id = 11,
                        Title = "Салат Цезарь",
                        Description = "1 ШТ. Цыпленок, свежие листья салата айсберг, томаты черри, сыры чеддер и пармезан, соус цезарь, пшеничные гренки, итальянские травы",
                        ImageUrl= "https://dodopizza-a.akamaihd.net/static/Img/Products/32d83655ee2c4434859a670ce3677d42_1875x1875.jpeg",
                        CategoryId = 4,
                    }
                );

            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 1,
                    Price = 13.90m,
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 2,
                    Price = 21.90m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 3,
                    Price = 24.30m
                },
                new ProductVariant
                {
                    ProductId =8,
                    ProductTypeId = 4,
                    Price = 6.90m
                },
                new ProductVariant
                {
                    ProductId = 10,
                    ProductTypeId = 4,
                    Price = 3.30m
                },
                new ProductVariant
                {
                    ProductId = 11,
                    ProductTypeId = 4,
                    Price = 8.90m
                }
                );
        }



        public DbSet <Product> Products { get; set; }
        public DbSet <Category> Categories{ get; set; }
        public DbSet <ProductType> ProductTypes { get; set; }
        public DbSet <ProductVariant> ProductVariants { get; set; }
    }
}
