using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shared.Helper;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserService.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private CommonMethods _commonMethods;
        private readonly IUsersService _usersService;

        public HttpClient Client { get; }

        public UserController(IUsersService usersService, HttpClient client, IConfiguration Configuration)
        {
            _usersService = usersService;
            Client = client;
            _configuration = Configuration;
            _commonMethods = new CommonMethods();

        }

        [NonAction]
        public TokenClaimsModal GetUserByClaim()
        {
            HttpContext httpContext = HttpContext.Request.HttpContext;
            var claims = _commonMethods.GetUserClaimsFromToken(httpContext);
            return claims;
        }

        [Authorize]
        [HttpGet]
        [Route("GetPatientByMob")]
        public async Task<IActionResult> GetPatientByMob()
        {
            string phone = "12316556";
            ResponseModel result = await _usersService.GetPatientByMob(phone);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            string name = "nitesh";
            return name;
        }
    }
}
