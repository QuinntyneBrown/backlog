using Backlog.Domain.Dtos;
using Backlog.Domain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Backlog.Domain.Extensions;

namespace Backlog.Api.Controllers
{
    [Route("api/agileteams")]
    public class AgileTeamController: ControllerBase
    {
        private readonly IAgileTeamService _service;
        private readonly IValidator<AgileTeamDto> _validator;

        public AgileTeamController(
            IAgileTeamService service,
            IValidator<AgileTeamDto> validator
            )
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return new OkObjectResult(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save()
        {
            var body = await Request.GetBodyAsync(_validator);

            if (!body.IsValid) throw new Exception();

            var agileTeam = _service.InsertAsync(body.Value);

            return new OkObjectResult(agileTeam);

        }
    }
}
