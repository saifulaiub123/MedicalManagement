using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MH.Application.IService;
using MH.Domain.IEntity;
using MH.Domain.Model;

namespace MH.Api.Controllers
{
    [Authorize]
    public class LyricsController : BaseController
    {
        private readonly ILyricsService _lyricsService;
        private readonly ICurrentUser _currentUser;

        public LyricsController(ILyricsService lyricsService, ICurrentUser currentUser)
        {
            _lyricsService = lyricsService;
            _currentUser = currentUser;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] LyricsModel model)
        {
            await _lyricsService.Add(model);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _lyricsService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var result = await _lyricsService.GetById(id);
            return Ok(result);
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] LyricsModel lyrics)
        {
            await _lyricsService.Update(lyrics);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await _lyricsService.Delete(id);
            return Ok();
        }
    }
}
