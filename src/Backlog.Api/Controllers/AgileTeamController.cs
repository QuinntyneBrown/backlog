using Backlog.Domain.Dtos;
using Backlog.Domain.Extensions;
using Backlog.Domain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{
    [Route("api/agileteams")]
    public class AgileTeamController: ControllerBase
    {
        private readonly IAgileTeamService _service;

        public AgileTeamController(
            IAgileTeamService service
            )
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return new OkObjectResult(await _service.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Save()
        {
            var body = await Request.GetBodyAsync<AgileTeamDto>();

            if (!body.IsValid) throw new Exception();

            var agileTeam = _service.InsertAsync(body.Value);

            return new OkObjectResult(agileTeam);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove()
        {            
            var agileTeam = _service.InsertAsync((await GetBody()).Value);

            return new OkObjectResult(agileTeam);
        }

        public async Task<HttpResponseBody<AgileTeamDto>> GetBody()
        {
            var body = await Request.GetBodyAsync<AgileTeamDto>();

            if (!body.IsValid) throw new Exception();

            return body;
        }
    }
}
