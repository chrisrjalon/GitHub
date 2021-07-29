using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHub.Domain.Interfaces;
using GitHub.Services.Interfaces;

namespace GitHub.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IServiceFactory _serviceFactory;

        public UserController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [Route("RetrieveUsers")]
        [HttpGet]
        public async Task<IActionResult> RetrieveUsers([FromBody] string[] usernames)
        {
            var users = await _serviceFactory.UserService.GetUsersByUsernames(usernames);
            return Ok(users);
        }
    }
}
