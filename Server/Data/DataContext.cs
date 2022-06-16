namespace BlazorMiamiPizza.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)  
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                        Price = 1.99m,
                        CategoryId = 1,
                    },
                    new Product
                    {
                        Id = 8,
                        Title = "Острый До-достер",
                        Description = "Горячая закуска с цыпленком, перцем халапеньо, маринованные огурчики, томатами, моцареллой и соусом барбекю в тонкой пшеничной лепешке",
                        ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/0c55068d9fa9432389b848f9b3eb5085_1875x1875.jpeg",
                        Price = 2.99m,
                        CategoryId = 3,
                    },
                    new Product
                    {
                        Id = 10,
                        Title = "Pepsi-Co",
                        Description = "Pepsi 1Л",
                        ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/8109d13f041147bdacb115c6b07cccc0_1875x1875.jpeg",
                        Price = 3.99m,
                        CategoryId = 2,
                    },
                    new Product
                    {
                        Id = 11,
                        Title = "Салат Цезарь",
                        Description = "1 ШТ. Цыпленок, свежие листья салата айсберг, томаты черри, сыры чеддер и пармезан, соус цезарь, пшеничные гренки, итальянские травы",
                        ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/32d83655ee2c4434859a670ce3677d42_1875x1875.jpeg",
                        Price = 8.90m,
                        CategoryId = 4,
                    }
                );
        }



        public DbSet <Product> Products { get; set; }
        public DbSet <Category> Categories{ get; set; }
    }
}
