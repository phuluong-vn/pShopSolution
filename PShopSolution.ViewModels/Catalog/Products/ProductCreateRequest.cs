using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace pShopSolution.Application.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Vui lòng nhập giá bán sản phẩm")]
        public decimal Price { get; set; }

        [Display(Name = "Giá nhập")]
        public decimal OriginalPrice { get; set; }

        [Display(Name = "Số lượng tồn")]
        public int Stock { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Name { set; get; }

        [Display(Name = "Mô tả")]
        public string Description { set; get; }

        [Display(Name = "Chi tiết")]
        public string Details { set; get; }

        public bool? IsFeature { get; set; }

        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }

        [Display(Name = "Hình ảnh")]
        public IFormFile ThumbnailImage { get; set; }
    }
}