using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using MH.Application.IService;
using MH.Domain.IEntity;
using MH.Domain.Model;

namespace MH.Api.Controllers
{
    [Authorize]
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;
        private readonly ICurrentUser _currentUser;

        public CountryController(ICountryService countryService, ICurrentUser currentUser)
        {
            _countryService = countryService;
            _currentUser = currentUser;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromBody] CountryModel model)
        {
            await _countryService.Add(model);
            return Ok();
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _countryService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var result = await _countryService.GetById(id);
            return Ok(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPatch]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] CountryModel country)
        {
            await _countryService.Update(country);
            return Ok();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await _countryService.Delete(id);
            return Ok();
        }
    }
}
