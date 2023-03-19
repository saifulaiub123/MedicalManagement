using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MH.Application.IService;
using MH.Domain.IEntity;
using MH.Domain.Model;

namespace MH.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserProfileImageController : BaseController
    {
        private readonly IUserProfileImageService _userProfileImageService;
        private readonly ICurrentUser _currentUser;

        public UserProfileImageController(IUserProfileImageService userProfileImageService, ICurrentUser currentUser)
        {
            _userProfileImageService = userProfileImageService;
            _currentUser = currentUser;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromForm] UserProfileImageModel model)
        {
            if (model.File.Length > 0)
            {
                await _userProfileImageService.Add(model);
            }
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _userProfileImageService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var result = await _userProfileImageService.GetById(id);
            return Ok(result);
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<ActionResult> Update([FromForm] UserProfileImageModel userProfileImage)
        {
            userProfileImage.UserId = _currentUser.User.Id;
            await _userProfileImageService.Update(userProfileImage);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await _userProfileImageService.Delete(id);
            return Ok();
        }
    }
}
