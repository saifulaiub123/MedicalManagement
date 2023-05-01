using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SS.Application.IService;
using SS.Domain.DBModel;
using SS.Domain.Model;
using SS.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using SS.Application.Enum;
using SS.Domain.IEntity;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace SS.Api.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserService _userService;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, IUserService userService, ICurrentUser currentUser, IMapper mapper)
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
            if (!await _userService.CanViewOrEdit(_currentUser.User.Id))
            {
                return Forbid();
            }
            var user = new ApplicationUser()
            {
                Email = registerModel.Email,
                UserName = registerModel.Email,
                PasswordHash = registerModel.Password,
                Status = 1
            };
            await CreateNewUser(user);
            return Ok();
        }
        [HttpGet]
        [Route("GetUsers")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return User data", typeof(List<UserViewModel>))]

        public async Task<IActionResult> GetUsers()
        {
            if (!await _userService.CanViewOrEdit(_currentUser.User.Id))
            {
                return Forbid();
            }
            var users = await _userManager.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Select(user => new UserViewModel {
                    Id = user.Id,
                    FirstName = user.UserProfile != null ? user.UserProfile.FirstName : "",
                    LastName = user.UserProfile != null ? user.UserProfile.LastName : "",
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UserRoles = user.UserRoles.Select(y => y.Role.Name).ToList()
                })
                .ToListAsync();
            return Ok(users);
        }
        
        [HttpGet]
        [Route("GetUserById")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return User data", typeof(UserViewModel))]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (!await _userService.CanViewOrEdit(id))
            {
                return Forbid();
            }
            var user = await _userService.GetUserById(id);
            if (user == null) return BadRequest();

            return Ok(user);
        }
        [HttpPatch]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserModel user)
        {
            if (!await _userService.CanViewOrEdit(user.Id))
            {
                return Forbid();
            }
            await _userService.UpdateUser(user);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _userService.CanViewOrEdit(id))
            {
                return Forbid();
            }
            await _userService.Delete(id);
            return Ok();
        }
        [HttpPatch]
        [Route("ChangePassword")]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (!await _userService.CanViewOrEdit(_currentUser.User.Id))
            {
                return Forbid();
            }
            var user = await _userManager.FindByIdAsync(_currentUser.User.Id.ToString());
            var result = await _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
            if(result.Succeeded) return Ok();

            return BadRequest(result.Errors.FirstOrDefault());

        }
        [HttpPatch]
        [Route("ResetPassword")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!await _userService.CanViewOrEdit(_currentUser.User.Id))
            {
                return Forbid();
            }
            var user = await _userManager.FindByIdAsync(_currentUser.User.Id.ToString());
            await _userManager.ChangePasswordAsync(user, resetPasswordModel.CurrentPassword, resetPasswordModel.NewPassword);
            return Ok();
        }

        private async Task<IActionResult> CreateNewUser(ApplicationUser user)
        {
            if (!await _userService.CanViewOrEdit(_currentUser.User.Id))
            {
                return Forbid();
            }
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                throw new Exception(errors.ToString());
            }
            await _userManager.AddToRoleAsync(user, RoleEnum.User.ToString());

            return Ok();
        }
    }
}
