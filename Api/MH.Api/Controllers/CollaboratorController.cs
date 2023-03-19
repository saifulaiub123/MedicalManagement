using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MH.Application.IService;
using MH.Domain.IEntity;
using MH.Domain.Model;

namespace MH.Api.Controllers
{
    [Authorize]
    public class CollaboratorController : BaseController
    {
        private readonly ICollaboratorService _collaboratorService;
        private readonly ICurrentUser _currentUser;

        public CollaboratorController(ICollaboratorService collaboratorService, ICurrentUser currentUser)
        {
            _collaboratorService = collaboratorService;
            _currentUser = currentUser;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] CollaboratorModel model)
        {
            await _collaboratorService.Add(model);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _collaboratorService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var result = await _collaboratorService.GetById(id);
            return Ok(result);
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] CollaboratorModel collaborator)
        {
            await _collaboratorService.Update(collaborator);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await _collaboratorService.Delete(id);
            return Ok();
        }
    }
}
