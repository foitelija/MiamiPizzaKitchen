using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorMiamiPizza.Server.Migrations
{
    public partial class FlagsVisible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ProductVariants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isVisible",
                table: "ProductVariants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isVisible",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 1 },
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 2 },
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 3 },
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 1 },
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 2 },
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 3 },
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 8, 4 },
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 10, 4 },
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 11, 4 },
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "isVisible",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "isVisible",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "isVisible",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isVisible",
                table: "Products");
        }
    }
}
