using Backlog.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{
    [Route("api/agileteams")]
    public class AgileTeamController: ControllerBase
    {
        private readonly IAgileTeamService _service;
        public AgileTeamController(IAgileTeamService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
    }
}
