using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MH.Application.IService;
using MH.Domain.DBModel;
using MH.Domain.Model;
using MH.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using MH.Application.Enum;
using MH.Domain.IEntity;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Z.EntityFramework.Plus;

namespace MH.Api.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserService _userService;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, IUserService userService, ICurrentUser currentUser = null, IMapper mapper = null)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(RegisterModel registerModel)
        {
            var user = new ApplicationUser()
            {
                //FullName = registerModel.FullName,
                Email = registerModel.Email,
                UserName = registerModel.Email,
                PasswordHash = registerModel.Password,
                Status = 2
            };
            await CreateNewUser(user);
            return Ok();
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Select(x => new UserViewModel {
                    Id = x.Id,
                    //FullName = x.FullName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    UserRoles = x.UserRoles.Select(y => y.Role.Name).ToList()
                })
                .ToListAsync();
            return Ok(users);
        }
        
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
        [HttpPatch]
        [Route("UpdateUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> UpdateUser(UserModel user)
        {
            await _userService.UpdateUser(user);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
        [HttpPatch]
        [Route("ChangePassword")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var user = await _userManager.FindByIdAsync(_currentUser.User.Id.ToString());
            await _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
            return Ok();
        }
        [HttpPatch]
        [Route("ResetPassword")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var user = await _userManager.FindByIdAsync(_currentUser.User.Id.ToString());
            await _userManager.ChangePasswordAsync(user, resetPasswordModel.CurrentPassword, resetPasswordModel.NewPassword);
            return Ok();
        }

        private async Task CreateNewUser(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                throw new Exception(errors.ToString());
            }
            await _userManager.AddToRoleAsync(user, RoleEnum.Doctor.ToString());
        }
    }
}
