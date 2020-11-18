using Microsoft.EntityFrameworkCore;
using pShopSolution.Data.Entities;
using pShopSolution.Data.Enum;
using System;
using System.Collections.Generic;

namespace pShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Data seeding
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTiltle", Value = "This is home page of pShopSolution" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of pShopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description of pShopSolution" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = true }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                new Category
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active,
                }
            );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation() {Id=1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm thời trang áo nam", SeoTitle = "Sản phẩm thời trang áo nam" },
                new CategoryTranslation() {Id=2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt product for men", SeoTitle = "The shirt product for men" },
                new CategoryTranslation() {Id=3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm thời trang áo nam", SeoTitle = "Sản phẩm thời trang áo nu" },
                new CategoryTranslation() {Id=4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt product for women", SeoTitle = "The shirt product for women" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    DateCreate = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0
                }
            );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() {CategoryId=1, ProductId =1}
                );
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation() {Id=1, ProductId = 1, Name = "Áo sơ mi nam Việt Tiến", LanguageId = "vi-VN", SeoAlias = "ao-so-mi-nam-Viet-Tien", SeoDescription = "Sản phẩm thời trang áo sơ mi nam Việt Tiến", SeoTitle = "Sản phẩm thời trang áo sơ mi nam Việt Tiến", Details = "Sản phẩm thời trang áo sơ mi nam Việt Tiến", Description = "Sản phẩm thời trang áo sơ mi nam Việt Tiến" },
                new ProductTranslation() {Id=2, ProductId = 1, Name = "Viet Tien Men T-Shirt", LanguageId = "en-US", SeoAlias = "viet-tien-men-t-shirt", SeoDescription = "The Viet Tien shirt product for men", SeoTitle = "The Viet Tien shirt product for men", Details = "The Viet Tien t-shirt product for men", Description = "The Viet Tien t-shirt product for men" }
            );
        }
    }
}