using Backlog.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Backlog.Api.Controllers;

[Route("api/users")]
public class UserController
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("token")]
    public async Task<IActionResult> Token(string username, string password)
    {
        (Guid userId, string accessToken) = await _service.Authenticate(username, password);

        return new OkObjectResult(new { userId, accessToken });
    }
}
