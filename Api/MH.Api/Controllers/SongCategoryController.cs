using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MH.Application.IService;
using MH.Domain.IEntity;
using MH.Domain.Model;

namespace MH.Api.Controllers
{
    [Authorize]
    public class SongCategoryController : BaseController
    {
        private readonly ISongCategoryService _songCategoryService;
        private readonly ICurrentUser _currentUser;

        public SongCategoryController(ISongCategoryService songCategoryService, ICurrentUser currentUser)
        {
            _songCategoryService = songCategoryService;
            _currentUser = currentUser;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] SongCategoryModel model)
        {
            await _songCategoryService.Add(model);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _songCategoryService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var result = await _songCategoryService.GetById(id);
            return Ok(result);
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] SongCategoryModel songCategory)
        {
            await _songCategoryService.Update(songCategory);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await _songCategoryService.Delete(id);
            return Ok();
        }
    }
}
