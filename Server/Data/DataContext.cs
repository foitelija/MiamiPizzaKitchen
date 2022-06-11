namespace BlazorMiamiPizza.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)  
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "Карбонара",
                        Description = "Бекон, сыры чеддер и пармезан, моцарелла, томаты, соус альфредо, красный лук, чеснок, итальянские травы",
                        ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/b195d75f2371491bb519629500d03f24_292x292.jpeg",
                        Price = 1.99m
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "Острый Додстер",
                        Description = "Горячая закуска с цыпленком, перцем халапеньо, маринованные огурчики, томатами, моцареллой и соусом барбекю в тонкой пшеничной лепешке",
                        ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/0c55068d9fa9432389b848f9b3eb5085_1875x1875.jpeg",
                        Price = 2.99m
                    },
                    new Product
                    {
                        Id = 3,
                        Title = "Pepsi",
                        Description = "Pepsi 1Л",
                        ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/8109d13f041147bdacb115c6b07cccc0_1875x1875.jpeg",
                        Price = 3.99m
                    }
                );
        }



        public DbSet <Product> Products { get; set; }
    }
}
