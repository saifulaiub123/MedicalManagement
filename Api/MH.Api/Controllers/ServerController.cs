using MH.Application.IService;
using MH.Application.Service;
using MH.Domain.Constant;
using MH.Domain.IEntity;
using MH.Domain.Model;
using MH.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MH.Api.Controllers
{
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ServerController : BaseController
    {
        private readonly IServerService _serverService;
        private readonly IUserService _userService;
        private readonly ICurrentUser _currentUser;

        public ServerController(IServerService serverService, IUserService userService, ICurrentUser currentUser)
        {
            _serverService = serverService;
            _userService = userService;
            _currentUser = currentUser;
        }

        [HttpGet]
        [Route("GetAllServer")]
        public async Task<IActionResult> GetAllServer()
        {
           var data = await _serverService.GetAllServer();
           return Ok(data);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] ServerModel model)
        {
            await _serverService.Add(model);
            return Ok();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var hasPermission = await _userService.IsAdmin(_currentUser.User.Id);
            if (!hasPermission) return Forbid();

            var result = await _serverService.GetById(id);
            return Ok(result);
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] ServerModel server)
        {
            var hasPermission = await _userService.IsAdmin(_currentUser.User.Id);
            if (!hasPermission) return Forbid();

            await _serverService.Update(server);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            var hasPermission = await _userService.IsAdmin(_currentUser.User.Id);
            if (!hasPermission) return Forbid();

            await _serverService.Delete(id);
            return Ok();
        }
    }
}
