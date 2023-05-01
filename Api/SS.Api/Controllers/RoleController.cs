using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SS.Application.Enum;
using SS.Application.Response;
using SS.Domain.DBModel;
using SS.Domain.Model;
using SS.Domain.ViewModel;
using SS.Application.IService;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using SS.Domain.IEntity;

namespace SS.Api.Controllers
{
    [Authorize]
    public class RoleController : BaseController
    {
        private readonly RoleManager<Domain.DBModel.Role> _roleManager;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly ICurrentUser _currentUser;
        public RoleController(RoleManager<Domain.DBModel.Role> roleManager, IRoleService roleService, IUserService userService, ICurrentUser currentUser)
        {
            _roleManager = roleManager;
            _roleService = roleService;
            _userService = userService;
            _currentUser = currentUser;
        }

        [HttpGet]
        [Route("GetRoles")]
        [SwaggerResponse(StatusCodes.Status200OK, "Return Role data", typeof(List<RoleViewModel>))]
        public async Task<IActionResult> GetRoles()
        {
            var roles = (await _roleManager.Roles.ToListAsync())
                .Select(x=> new RoleViewModel 
                { 
                    Id = x.Id,
                    Name = x.Name
                });
            return Ok(roles);
        }
        
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] RoleModel roleModel)
        {
            if(!await _userService.CanViewOrEdit(_currentUser.User.Id))
            {
                return Forbid();
            }
            var role = new Role()
            {
                Name = roleModel.Name,
                NormalizedName = roleModel.Name.ToUpper(),
                ConcurrencyStamp = DateTime.Now.ToString()
            };
            await _roleManager.CreateAsync(role);
            return Ok();
        }
        
        [HttpPatch]
        [Route("Update")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Update([FromBody] RoleModel roleModel)
        {
            var existingRole = await _roleService.GetById(roleModel.Id);
            if(existingRole != null)
            {
                var role = new Role()
                {
                    Id = existingRole.Id,
                    Name = roleModel.Name,
                    NormalizedName = roleModel.Name.ToUpper(),
                    ConcurrencyStamp = existingRole.ConcurrencyStamp
                };
                await _roleManager.UpdateAsync(role);
                return Ok();
            }
            
            return BadRequest();
        }
    }
}
