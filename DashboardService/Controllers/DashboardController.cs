using DashboardService.Common.ResponseVM;
using DashboardService.Common.StaticConstants;
using DashboardService.Model;
using DashboardService.Services.Interfaces;
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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DashboardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly CommonMethods _commonMethods;

        private readonly IDashboardService _dashboardService;

        private readonly IConfiguration _configuration;

        public HttpClient Client { get; }

        public DashboardController(IDashboardService adminDashboardService, HttpClient client, IConfiguration Configuration)
        {
            _dashboardService = adminDashboardService;
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

        [HttpPost]
        [Route("GetAdminDashboardDetails")]
        public IActionResult GetAdminDashboardDetails([FromBody] FilterParameters filterModel)
        {
            var response = _dashboardService.GetAdminDashboardDetails(filterModel, GetUserByClaim());
            return Ok(new AdminResponseVM()
            {
                Data = response.DashboardList,
                ReturnCode = response.DashboardList.FirstOrDefault().ReturnCode,
                Message = IEHMessages.Success,
                StatusCode = IEHMessages.Ok
            });
        }
    }
}
