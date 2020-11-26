using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using pShopSolution.AdminApp.Services;
using PShopSolution.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace pShopSolution.AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;

        public UserController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 2)
        {
            var request = new GetUserPagingRequest()
            {
                Keywork = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _userApiClient.GetUserPagings(request);
            if (keyword != "")
            {
                ViewBag.Keyword = keyword;
            }
            if (TempData["Success"] != null)
            {
                ViewBag.SuccessMsg = TempData["Success"];
            }
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _userApiClient.RegisterUser(request);
            if (rs.IsSuccessed)
            {
                TempData["Success"] = "Create User Success";
                return RedirectToAction("Index", "User");
            }

            ModelState.AddModelError("", rs.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _userApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new UserUpdateRequest()
                {
                    Dob = user.Dob,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.Phone,
                    Id = id
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _userApiClient.UpdateUser(request.Id, request);
            if (rs.IsSuccessed)
            {
                TempData["Success"] = "Update User Success";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", rs.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _userApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                return View(user);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rs = await _userApiClient.GetById(id);
            if (!rs.IsSuccessed)
                return RedirectToAction("Error", "Home");
            var model = new DeleteUserRequest()
            {
                Id = rs.ResultObj.Id,
                Username = rs.ResultObj.UserName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            var rs = await _userApiClient.DeleteUser(request.Id);
            if (rs.IsSuccessed)
            {
                TempData["Success"] = "Update User Success";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", rs.Message);
            return View(rs.Message);
        }
    }
}