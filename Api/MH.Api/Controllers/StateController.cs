using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MH.Application.IService;
using MH.Domain.IEntity;
using MH.Domain.Model;

namespace MH.Api.Controllers
{
    [Authorize]
    public class StateController : BaseController
    {
        private readonly IStateService _stateService;
        private readonly ICurrentUser _currentUser;

        public StateController(IStateService stateService, ICurrentUser currentUser)
        {
            _stateService = stateService;
            _currentUser = currentUser;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] StateModel model)
        {
            await _stateService.Add(model);
            return Ok();
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _stateService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var result = await _stateService.GetById(id);
            return Ok(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPatch]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] StateModel state)
        {
            await _stateService.Update(state);
            return Ok();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await _stateService.Delete(id);
            return Ok();
        }
    }
}
