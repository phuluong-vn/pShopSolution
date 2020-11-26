using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pShopSolution.Data.Entities;
using PShopSolution.ViewModels.Common;
using PShopSolution.ViewModels.System.Users;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace pShopSolution.Application.System
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                return new ApiErrorResult<string>("Không đúng tài khoản!");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
                return new ApiErrorResult<string>("Không đúng tài khoản hoặc mật khẩu!");

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return new ApiErrorResult<bool>($"Cannot find user by id: {id}");
            var rs = await _userManager.DeleteAsync(user);
            if (!rs.Succeeded)
            {
                return new ApiErrorResult<bool>("Cannot delete this user!");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<UserVm>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return new ApiErrorResult<UserVm>($"Cannot find user by id: {id}");
            UserVm uv = new UserVm()
            {
                Email = user.Email,
                Phone = user.PhoneNumber,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                UserName = user.UserName,
                Dob = user.Dob
            };
            return new ApiSuccessResult<UserVm>(uv);
        }

        public async Task<ApiResult<PageResult<UserVm>>> GetUserPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keywork))
            {
                query = query.Where(x => x.UserName.Contains(request.Keywork) || x.PhoneNumber.Contains(request.Keywork));
            }
            //3. Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserVm()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    Phone = x.PhoneNumber
                }).ToListAsync();

            //4. Select and projection
            var pageResult = new PageResult<UserVm>()
            {
                TotalRecord = totalRow,
                PageIndex = request.PageIndex,
                PageSise = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PageResult<UserVm>>(pageResult);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var checkUser = await _userManager.FindByNameAsync(request.Username);
            var checkEmail = await _userManager.FindByEmailAsync(request.Email);
            if (checkUser != null)
            {
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại!");
            }
            if (checkEmail != null)
            {
                return new ApiErrorResult<bool>("Email đã tồn tại!");
            }
            var user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Username
            };
            var rs = await _userManager.CreateAsync(user, request.Password);
            if (rs.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng ký không thành công");
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            var checkEmail = await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id);
            if (checkEmail)
            {
                return new ApiErrorResult<bool>("Email đã tồn tại!");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Dob = request.Dob;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            var rs = await _userManager.UpdateAsync(user);
            if (rs.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật người dùng không thành công!");
        }
    }
}