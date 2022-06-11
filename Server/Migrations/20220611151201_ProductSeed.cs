using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorMiamiPizza.Server.Migrations
{
    public partial class ProductSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 1, "Бекон, сыры чеддер и пармезан, моцарелла, томаты, соус альфредо, красный лук, чеснок, итальянские травы", "https://dodopizza-a.akamaihd.net/static/Img/Products/b195d75f2371491bb519629500d03f24_292x292.jpeg", 1.99m, "Карбонара" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 2, "Горячая закуска с цыпленком, перцем халапеньо, маринованные огурчики, томатами, моцареллой и соусом барбекю в тонкой пшеничной лепешке", "https://dodopizza-a.akamaihd.net/static/Img/Products/0c55068d9fa9432389b848f9b3eb5085_1875x1875.jpeg", 2.99m, "Острый Додстер" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 3, "Pepsi 1Л", "https://dodopizza-a.akamaihd.net/static/Img/Products/8109d13f041147bdacb115c6b07cccc0_1875x1875.jpeg", 3.99m, "Pepsi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
