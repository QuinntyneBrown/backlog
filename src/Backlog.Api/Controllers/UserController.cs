using Backlog.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{
    public class UserController
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        public Task<IActionResult> Token()
        {

        }
    }
}
