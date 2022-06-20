﻿// <auto-generated />
using BlazorMiamiPizza.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorMiamiPizza.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220617114247_ProductVariants")]
    partial class ProductVariants
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorMiamiPizza.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Пицца",
                            Url = "pizzas"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Напитки",
                            Url = "drinks"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Закуски",
                            Url = "snacks"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Салаты",
                            Url = "salads"
                        });
                });

            modelBuilder.Entity("BlazorMiamiPizza.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Description = "Бекон, сыры чеддер и пармезан, моцарелла, томаты, соус альфредо, красный лук, чеснок, итальянские травы",
                            ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/b195d75f2371491bb519629500d03f24_292x292.jpeg",
                            Title = "Карбонара"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "Горячая закуска с цыпленком, перцем халапеньо, маринованные огурчики, томатами, моцареллой и соусом барбекю в тонкой пшеничной лепешке",
                            ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/0c55068d9fa9432389b848f9b3eb5085_1875x1875.jpeg",
                            Title = "Острый До-достер"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Description = "Pepsi 1Л",
                            ImageUrl = "https://dodopizza-a.akamaihd.net/static/Img/Products/8109d13f041147bdacb115c6b07cccc0_1875x1875.jpeg",
                            Title = "Pepsi-Co"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 4,
                            Description = "1 ШТ. Цыпленок, свежие листья салата айсберг, томаты черри, сыры чеддер и пармезан, соус цезарь, пшеничные гренки, итальянские травы",
                            ImageUrl = "",
                            Title = "Салат Цезарь"
                        });
                });

            modelBuilder.Entity("BlazorMiamiPizza.Shared.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Маленькая"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Средняя"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Большая"
                        });
                });

            modelBuilder.Entity("BlazorMiamiPizza.Shared.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId", "ProductTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 1,
                            OriginalPrice = 0m,
                            Price = 13.90m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 2,
                            OriginalPrice = 0m,
                            Price = 21.90m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 3,
                            OriginalPrice = 0m,
                            Price = 24.30m
                        });
                });

            modelBuilder.Entity("BlazorMiamiPizza.Shared.Product", b =>
                {
                    b.HasOne("BlazorMiamiPizza.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BlazorMiamiPizza.Shared.ProductVariant", b =>
                {
                    b.HasOne("BlazorMiamiPizza.Shared.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorMiamiPizza.Shared.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("BlazorMiamiPizza.Shared.Product", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}