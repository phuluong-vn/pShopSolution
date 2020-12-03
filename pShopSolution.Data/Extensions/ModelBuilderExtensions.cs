using Microsoft.AspNetCore.Identity;
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
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = true }
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
                new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm thời trang áo nam", SeoTitle = "Sản phẩm thời trang áo nam" },
                new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en", SeoAlias = "men-shirt", SeoDescription = "The shirt product for men", SeoTitle = "The shirt product for men" },
                new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm thời trang áo nam", SeoTitle = "Sản phẩm thời trang áo nu" },
                new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en", SeoAlias = "women-shirt", SeoDescription = "The shirt product for women", SeoTitle = "The shirt product for women" }
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
                new ProductInCategory() { CategoryId = 1, ProductId = 1 }
                );
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation() { Id = 1, ProductId = 1, Name = "Áo sơ mi nam Việt Tiến", LanguageId = "vi", SeoAlias = "ao-so-mi-nam-Viet-Tien", SeoDescription = "Sản phẩm thời trang áo sơ mi nam Việt Tiến", SeoTitle = "Sản phẩm thời trang áo sơ mi nam Việt Tiến", Details = "Sản phẩm thời trang áo sơ mi nam Việt Tiến", Description = "Sản phẩm thời trang áo sơ mi nam Việt Tiến" },
                new ProductTranslation() { Id = 2, ProductId = 1, Name = "Viet Tien Men T-Shirt", LanguageId = "en", SeoAlias = "viet-tien-men-t-shirt", SeoDescription = "The Viet Tien shirt product for men", SeoTitle = "The Viet Tien shirt product for men", Details = "The Viet Tien t-shirt product for men", Description = "The Viet Tien t-shirt product for men" }
            );

            var RoleID = new Guid("B0EEED3D-5092-4789-A760-E252AA217E3C");
            var AdminID = new Guid("30DCD73B-C849-44AC-BCA3-E48E2843691B");
            // any guid, but nothing is against to use the same one

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = RoleID,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = AdminID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "phuluong2019@gmail.com",
                NormalizedEmail = "phuluong2019@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Phú",
                LastName = "Lương",
                Dob = new DateTime(2020, 02, 10)
            }); ;

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = RoleID,
                UserId = AdminID
            });

            modelBuilder.Entity<Slide>().HasData(
                new Slide()
                {
                    Id = 1,
                    Name = "Second Thumbnail label",
                    Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                    Image = "/themes/images/carousel/1.png",
                    SortOrder = 1,
                    Url = "#",
                    Status = Status.Active
                },
                new Slide()
                {
                    Id = 2,
                    Name = "Second Thumbnail label",
                    Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                    Image = "/themes/images/carousel/2.png",
                    SortOrder = 2,
                    Url = "#",
                    Status = Status.Active
                },
                new Slide()
                {
                    Id = 3,
                    Name = "Second Thumbnail label",
                    Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                    Image = "/themes/images/carousel/3.png",
                    SortOrder = 3,
                    Url = "#",
                    Status = Status.Active
                },
                new Slide()
                {
                    Id = 4,
                    Name = "Second Thumbnail label",
                    Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                    Image = "/themes/images/carousel/4.png",
                    SortOrder = 4,
                    Url = "#",
                    Status = Status.Active
                },
                new Slide()
                {
                    Id = 5,
                    Name = "Second Thumbnail label",
                    Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                    Image = "/themes/images/carousel/5.png",
                    SortOrder = 5,
                    Url = "#",
                    Status = Status.Active
                },
                new Slide()
                {
                    Id = 6,
                    Name = "Second Thumbnail label",
                    Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                    Image = "/themes/images/carousel/6.png",
                    SortOrder = 6,
                    Url = "#",
                    Status = Status.Active
                }
                );
        }
    }
}