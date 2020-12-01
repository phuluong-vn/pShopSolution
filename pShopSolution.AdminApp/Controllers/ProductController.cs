using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using pShopSolution.AdminApp.Services;
using pShopSolution.Application.Catalog.Products;
using pShopSolution.Utilities.Constants;
using PShopSolution.ViewModels.Catalog.Products;

namespace pShopSolution.AdminApp.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;

        public ProductController(IProductApiClient productApiClient, IConfiguration configuration)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 2)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var request = new GetManageProductPagingRequest()
            {
                Keywork = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId
            };
            var data = await _productApiClient.GetProductPagings(request);
            if (keyword != "")
            {
                ViewBag.Keyword = keyword;
            }
            if (TempData["Success"] != null)
            {
                ViewBag.SuccessMsg = TempData["Success"];
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _productApiClient.CreateProduct(request);
            if (rs)
            {
                TempData["Success"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index", "product");
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    var result = await _productApiClient.GetById(id);
        //    if (result.IsSuccessed)
        //    {
        //        var product = result.ResultObj;
        //        var updateRequest = new productUpdateRequest()
        //        {
        //            Dob = product.Dob,
        //            Email = product.Email,
        //            FirstName = product.FirstName,
        //            LastName = product.LastName,
        //            PhoneNumber = product.Phone,
        //            Id = id
        //        };
        //        return View(updateRequest);
        //    }
        //    return RedirectToAction("Error", "Home");
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(productUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View();
        //    var rs = await _productApiClient.Updateproduct(request.Id, request);
        //    if (rs.IsSuccessed)
        //    {
        //        TempData["Success"] = "Cập nhật người dùng thành công";
        //        return RedirectToAction("Index");
        //    }
        //    ModelState.AddModelError("", rs.Message);
        //    return View(request);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Details(Guid id)
        //{
        //    var result = await _productApiClient.GetById(id);
        //    if (result.IsSuccessed)
        //    {
        //        var product = result.ResultObj;
        //        return View(product);
        //    }
        //    return RedirectToAction("Error", "Home");
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var rs = await _productApiClient.GetById(id);
        //    if (!rs.IsSuccessed)
        //        return RedirectToAction("Error", "Home");
        //    var model = new DeleteproductRequest()
        //    {
        //        Id = rs.ResultObj.Id,
        //        productname = rs.ResultObj.productName
        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(DeleteproductRequest request)
        //{
        //    var rs = await _productApiClient.Deleteproduct(request.Id);
        //    if (rs.IsSuccessed)
        //    {
        //        TempData["Success"] = "Xóa người dùng thành công";
        //        return RedirectToAction("Index");
        //    }
        //    ModelState.AddModelError("", rs.Message);
        //    return View(rs.Message);
        //}

        //[HttpGet]
        //public async Task<IActionResult> RoleAssign(Guid Id)
        //{
        //    var roleAssignRequest = await GetRoleAssignRequest(Id);
        //    return View(roleAssignRequest);
        //}

        //[HttpPost]
        //public async Task<IActionResult> RoleAssign(RoleAssignRequest request)
        //{
        //    var rs = await _productApiClient.RoleAssign(request.Id, request);

        //    if (rs.IsSuccessed)
        //    {
        //        TempData["Success"] = "Cập nhật quyền thành công";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", rs.Message);
        //    var roleAssignRequest = await GetRoleAssignRequest(request.Id);
        //    return View(roleAssignRequest);
        //}

        //private async Task<RoleAssignRequest> GetRoleAssignRequest(Guid uId)
        //{
        //    var rsproduct = await _productApiClient.GetById(uId);
        //    var rsRole = await _roleApiClient.GetAll();
        //    var roleAssignRequest = new RoleAssignRequest();
        //    foreach (var role in rsRole.ResultObj)
        //    {
        //        roleAssignRequest.Roles.Add(new SelectedItem()
        //        {
        //            Id = role.Id.ToString(),
        //            Name = role.Name,
        //            Selected = rsproduct.ResultObj.Roles.Contains(role.Name)
        //        });
        //    }

        //    return roleAssignRequest;
        //}
    }
}